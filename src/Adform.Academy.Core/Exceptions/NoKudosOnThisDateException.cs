namespace Adform.Academy.Core.Exceptions
{
    public class NoKudosOnThisDateException : Exception
    {
        public NoKudosOnThisDateException() { }

        public NoKudosOnThisDateException(DateTime date)
            : base(String.Format($"No kudos found sent on selected month: {date.Date}")) { }
    }
}
