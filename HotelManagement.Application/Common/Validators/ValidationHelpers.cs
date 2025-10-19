namespace HotelManagement.Application.Common.Validators
{
    public static class ValidationHelpers
    {
        public static bool BeAtLeast18YearsOld(DateTime birthDate)
            => CalculateAge(birthDate) >= 18;

        public static bool BeAtLeast18YearsOld(DateTime? birthDate)
            => birthDate.HasValue && CalculateAge(birthDate.Value) >= 18;

        private static int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}