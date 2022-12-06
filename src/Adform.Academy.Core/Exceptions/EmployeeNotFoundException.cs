namespace Adform.Academy.Core.Exceptions
{
    public class EmployeeNotFoundException : Exception
    {
        public EmployeeNotFoundException() { }

        public EmployeeNotFoundException(int id)
            : base(String.Format($"Employee with id: {id} was not found!")) { }
    }
}
