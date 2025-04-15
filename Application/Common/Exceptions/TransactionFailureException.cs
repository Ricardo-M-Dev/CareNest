namespace Application.Common.Exceptions
{
    public class TransactionFailureException : Exception
    {
        public string Operation { get; }
        public string ContextInfo { get; }

        public TransactionFailureException(string operation, string contextInfo, Exception innerException)
            : base($"Falha ao executar operação: {operation}. Veja o inner exception para mais detalhes.", innerException)
        {
            Operation = operation;
            ContextInfo = contextInfo;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\nOperation: {Operation}\nContext: {ContextInfo}";
        }
    }
}
