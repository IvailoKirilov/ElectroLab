namespace ElectroLabModels.SystemModels
{
    public class OperationResult
    {
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
        public int? CreatedId { get; set; }
    }
}
