using Insurance.Domain.Enums;

namespace Insurance.Domain.Entities
{
    public class RiskAnalysis
    {
        public int Age { get; set; }
        public int Dependents { get; set; }
        public House? House { get; set; }
        public int Income { get; set; }
        public MaritalStatus MaritalStatus { get; set; }
        public int[] RiskQuestions { get; set; }
        public Vehicle? Vehicle { get; set; }

        public int AutoScore { get; set; }
        public int HomeScore { get; set; }
        public int DisabilityScore { get; set; }
        public int LifeScore { get; set; }

        public string AutoProfile { get; set; }
        public string LifeProfile { get; set; }
        public string HomeProfile { get; set; }
        public string DisabilityProfile { get; set; }

        public RiskAnalysis(int[] riskQuestions)
        {
            var baseScore = riskQuestions.Sum();

            AutoScore = baseScore;
            HomeScore = baseScore;
            DisabilityScore = baseScore;
            LifeScore = baseScore;
        }

        /// <summary>
        /// Adds an amount of each Score
        /// </summary>
        /// <param name="sum">Amount to sum</param>
        public void AddToScore(int sum)
        {
            var properties = GetAllScores();

            foreach (var property in properties)
            {
                var value = (int)property.GetValue(property);
                property.SetValue(property, value + sum);
            }
        }

        /// <summary>
        /// Substracts an amount of each Score
        /// </summary>
        /// <param name="sum">Amoutn to Subtract</param>
        public void SubtractFromScore(int sum)
        {
            var properties = GetAllScores();

            foreach (var property in properties)
            {
                var value = (int)property.GetValue(property);
                property.SetValue(property, value - sum);
            }
        }

        /// <summary>
        /// Gets all class properties that has Score own its name and it's an integer
        /// </summary>
        /// <returns>A list of <see cref="System.Reflection.PropertyInfo"/></returns>
        private IEnumerable<System.Reflection.PropertyInfo> GetAllScores()
        {
            return GetType().GetProperties().Where(x => x.Name.Contains("Score") && x.PropertyType == typeof(int));
        }
    }
}
