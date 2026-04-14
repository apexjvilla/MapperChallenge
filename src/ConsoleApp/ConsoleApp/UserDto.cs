namespace ConsoleApp
{
    public class UserDto
    {
        public string Name { get; set; } = String.Empty;
        public int Age { get; set; }
        public string email { get; set; } = String.Empty;
        public string LoyaltyPoints { get; set; } = String.Empty;
        public string ExtraField { get; set; } = String.Empty; // Should be ignored
    }
}
