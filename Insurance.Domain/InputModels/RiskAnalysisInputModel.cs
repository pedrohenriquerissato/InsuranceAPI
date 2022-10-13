namespace Insurance.Domain.InputModels
{
    public class RiskAnalysisInputModel
    {
        public int? Age { get; set; }
        public int? Dependents { get; set; }
        public House? House { get; set; }
        public int? Income { get; set; }
        public string? MaritalStatus { get; set; }
        public int[]? RiskQuestions { get; set; }
        public Entities.Vehicle? Vehicle { get; set; }
    }

    public class House
    {
        public string? OwnershipStatus { get; set; }
    }
}
