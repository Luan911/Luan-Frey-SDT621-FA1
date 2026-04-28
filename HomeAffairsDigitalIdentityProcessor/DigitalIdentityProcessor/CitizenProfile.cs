using System.Globalization;

namespace DigitalIdentityProcessor
{
    public class CitizenProfile
    {
        public string FullName { get; }
        public string IDNumber { get; }
        public int Age { get; private set; }
        public string CitizenshipStatus { get; }

        public CitizenProfile(string fullName, string idNumber, string citizenshipStatus)
        {
            FullName = fullName;
            IDNumber = idNumber;
            CitizenshipStatus = citizenshipStatus;
            Age = CalculateAge();
        }

        private int CalculateAge()
        {
            if (IDNumber.Length < 6 || !IDNumber.Take(6).All(char.IsDigit))
            {
                return -1;
            }

            string birthPart = IDNumber[..6];
            if (!DateTime.TryParseExact(
                    birthPart,
                    "yyMMdd",
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out DateTime parsedDate))
            {
                return -1;
            }

            int yy = int.Parse(birthPart[..2], CultureInfo.InvariantCulture);
            int currentYY = DateTime.Today.Year % 100;
            int fullYear = yy <= currentYY ? 2000 + yy : 1900 + yy;

            DateTime birthDate;
            try
            {
                birthDate = new DateTime(fullYear, parsedDate.Month, parsedDate.Day);
            }
            catch
            {
                return -1;
            }

            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate.Date > DateTime.Today.AddYears(-age))
            {
                age--;
            }

            return age;
        }

        public string ValidateID()
        {
            if (IDNumber.Length != 13)
            {
                return "Invalid ID. ID number must contain exactly 13 digits.";
            }

            if (!IDNumber.All(char.IsDigit))
            {
                return "Invalid ID. ID number must be numeric only.";
            }

            if (Age < 0)
            {
                return "Invalid ID. Birth date in ID number is not valid.";
            }

            if (Age > 120)
            {
                return "Invalid ID. Calculated age is out of range.";
            }

            return $"Valid ID. Citizen is {Age} years old.";
        }
    }
}
