namespace Application.Common.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string entityName, object key)
            : base($"'{entityName}' com o id '{key}' não foi encontrado.")
        {
        }
    }
}
