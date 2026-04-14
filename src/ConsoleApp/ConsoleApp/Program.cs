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
            email = "julio@example.com",
            LoyaltyPoints = "120",
            ExtraField = "This should be ignored"
        };

        Console.WriteLine("UserDto: " + userDto.ToJson());

        MapperConfiguration relaxedConfig = new()
        {
            IgnorePropertyNameCase = true,
            StrictMode = false,
            ThrowOnMappingError = false,
            OnMappingError = (property, ex) =>
                Console.WriteLine($"Mapping error on '{property}': {ex.Message}")
        };

        User user = MapperUtility.Map<UserDto, User>(userDto, relaxedConfig);

        Console.WriteLine("Mapped object with relaxed config: " + user.ToJson());

        try
        {
            MapperConfiguration strictConfig = new()
            {
                IgnorePropertyNameCase = true,
                StrictMode = true,
                ThrowOnMappingError = true
            };

            User strictUser = MapperUtility.Map<UserDto, User>(userDto, strictConfig);
            Console.WriteLine("Mapped object with strict config: " + strictUser.ToJson());
        }
        catch (Exception ex)
        {
            Console.WriteLine("Strict mapping failed as expected: " + ex.Message);
        }

        Console.ReadKey();
    }
}