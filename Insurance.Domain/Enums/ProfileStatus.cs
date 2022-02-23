using Ardalis.SmartEnum;

namespace Insurance.Domain.Enums
{
    public class ProfileStatus : SmartEnum<ProfileStatus>
    {
        public static readonly ProfileStatus None = new("none", 0);
        public static readonly ProfileStatus Ineligible = new("ineligible", 1);
        public static readonly ProfileStatus Regular = new("regular", 2);
        public static readonly ProfileStatus Economic = new("economic", 3);
        public static readonly ProfileStatus Responsible = new("responsible", 4);

        public ProfileStatus(string name, int value) : base(name, value)
        {
        }
    }
}
