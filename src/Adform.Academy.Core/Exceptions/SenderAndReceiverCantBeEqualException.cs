namespace Adform.Academy.Core.Exceptions
{
    public class SenderAndReceiverCantBeEqualException : Exception
    {
        public SenderAndReceiverCantBeEqualException() { }

        public SenderAndReceiverCantBeEqualException(int id)
            : base(String.Format($"Sender and receiver id is equal to: {id}.They cannot be the same!")) { }
    }
}
