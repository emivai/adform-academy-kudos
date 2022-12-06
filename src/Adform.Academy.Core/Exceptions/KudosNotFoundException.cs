namespace Adform.Academy.Core.Exceptions
{
    public class KudosNotFoundException : Exception
    {
        public KudosNotFoundException(){}

        public KudosNotFoundException(int id)
            : base(String.Format($"Kudos with id: {id} was not found!")){}
    }
}
