namespace ConsoleApp;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Code challenge: Reflection-Based Object Mapper");

        UserDto userDto = new()
        {
            Name = "Julio",
            Age = 39,
            ExtraField = "This should be ignored"
        };

        Console.WriteLine("UserDto: " + userDto.ToJson());

        User user = MapperUtility.Map<UserDto, User>(userDto);

        Console.WriteLine("Mapped object: " + user.ToJson());

        Console.ReadKey();
    }
}