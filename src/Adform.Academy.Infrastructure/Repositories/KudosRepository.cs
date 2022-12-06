using Adform.Academy.Core.Contracts.Repositories;
using Adform.Academy.Core.Entities;
using Dapper;
using Npgsql;

namespace Adform.Academy.Infrastructure.Repositories
{
    public class KudosRepository : IKudosRepository
    {
        private readonly NpgsqlConnection _connection;
        public KudosRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<int> AddAsync(KudosEntity kudos)
        {
            var query = @"INSERT INTO kudos (sent, reason, ""content"", exchanged, sender_id, receiver_id)
                          VALUES (@sent, @reason, @content, @exchanged, @senderId, @receiverId)
                          RETURNING Id"
            ;

            return await _connection.QuerySingleAsync<int>(query, new
            {
                sent = DateTime.Now,
                reason = kudos.Reason,
                content = kudos.Content,
                exchanged = kudos.Exchanged,
                senderId = kudos.Sender.Id,
                receiverId = kudos.Receiver.Id
            });
        }

        public async Task<List<KudosEntity>> GetAsync()
        {
            var query = @"SELECT * FROM kudos k
                          LEFT JOIN employee s ON k.sender_id=s.id
                          LEFT JOIN employee r ON k.receiver_id=r.id";

            var kudos = await _connection.QueryAsync<KudosEntity, Employee, Employee, KudosEntity>(query, (kudos, sender, receiver) =>
            {
                kudos.Sender = sender;
                kudos.Receiver = receiver;
                return kudos;
            });

            return kudos.ToList();
        }

        public async Task<KudosEntity?> GetByIdAsync(int id)
        {
            var query = @"SELECT * FROM kudos k
                          LEFT JOIN employee s ON k.sender_id=s.id
                          LEFT JOIN employee r ON k.receiver_id=r.id
                          WHERE k.id = @id";

            var kudos = await _connection.QueryAsync<KudosEntity, Employee, Employee, KudosEntity>(query, (kudos, sender, receiver) =>
            {
                kudos.Sender = sender;
                kudos.Receiver = receiver;
                return kudos;
            },
            new { id });

            return kudos.FirstOrDefault();
        }

        public async Task<int> GetKudosCountAsync(DateTime date)
        {
            var query = @"SELECT COUNT(*) FROM kudos
                          WHERE date_part('year', sent) = @year AND date_part('month', sent) = @month";

            return await _connection.QuerySingleAsync<int>(query, new
            {
                year = date.Year,
                month = date.Month
            });
        }

        public async Task<EmployeeKudosCount> GetMostKudosReceivedAsync(DateTime date)
        {
            var query = @"SELECT receiver_id as id, count(*) as count FROM kudos
                          WHERE date_part('year', sent) = @year AND date_part('month', sent) = @month
                          GROUP BY receiver_id 
                          ORDER BY count DESC 
                          LIMIT 1";

            return await _connection.QuerySingleAsync<EmployeeKudosCount>(query, new
            {
                year = date.Year,
                month = date.Month
            });
        }

        public async Task<EmployeeKudosCount> GetMostKudosSentAsync(DateTime date)
        {
            var query = @"SELECT sender_id as id, count(*) as count FROM kudos
                          WHERE date_part('year', sent) = @year AND date_part('month', sent) = @month
                          GROUP BY sender_id 
                          ORDER BY count DESC 
                          LIMIT 1";

            return await _connection.QuerySingleAsync<EmployeeKudosCount>(query, new
            {
                year = date.Year,
                month = date.Month
            });
        }

        public async Task UpdateAsync(KudosEntity kudos)
        {
            string query = @$"UPDATE kudos
                              SET exchanged = @exchanged
                              WHERE id = @id";

            await _connection.ExecuteAsync(query, new
            {
                exchanged = kudos.Exchanged,
                id = kudos.Id
            });
        }
    }
}
