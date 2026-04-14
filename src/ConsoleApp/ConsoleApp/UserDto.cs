namespace ConsoleApp
{
    public class UserDto
    {
        public string Name { get; set; } = String.Empty;
        public int Age { get; set; }
        public string ExtraField { get; set; } = String.Empty; // Should be ignored
    }
}
