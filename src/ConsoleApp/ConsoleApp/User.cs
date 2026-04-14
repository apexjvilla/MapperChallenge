namespace ConsoleApp
{
    public class User
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Email { get; set; } = string.Empty;
        public int LoyaltyPoints { get; set; }
        public string Location { get; set; } = String.Empty; // Should remain null/default

        public override bool Equals(object? obj)
        {
            return obj is User user &&
                   Name == user.Name;
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
    }
}
