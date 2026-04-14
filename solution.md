# Reflection-Based Object Mapper - Solution

---

## Overview

To solve the challenge, I implmented a generic reflection-based mapper that copies values from a source object to a new target object only when both property name and type are compatible.

The core implementation is in `src/ConsoleApp/ConsoleApp/MapperUtility.cs`.

An example usage could be found in `src/ConsoleApp/ConsoleApp/Program.cs`.

## Implemented approach

1. Added a generic mapper method.

2. Added an overload that accepts mapping configuratoin.

3. Implemented null validation for the source object (`ArgumentNullException`).

4. Created the target instance using `new TTarget()`.

5. Used reflection to read public instance properties from source and target.

6. Matched source and target properties by name (optionally case-insensitive).

7. Copied values only when:

   a. The source property exists.
   b. The target property is writable.
   c. The source and target property types are exactly the same.

8. Ignored properties that do not match (or enforced strict behavior when enabled).

9. Added error handling options for mapping failures:

   a. Throw an exception.
   b. Or call a custom callback (`OnMappingError`).

10. Added a reflection performance optimization by caching property metadata in.

## Configuration class

The mapper uses `MapperConfiguration` to control behavior:

- `IgnorePropertyNameCase`: Enables case-insensitive property name matching.
- `StrictMode`: Fails when a required source property is missing.
- `ThrowOnMappingError`: Throws when assignment/conversion fails.
- `OnMappingError`: Callback for non-throwing error handling.

This makes the solution more flexible than a single hardcoded mapping strategy.

## Example

With `UserDto` -> `User`:

- `Name` maps successfully.
- `Age` maps succesfully.
- `email` maps to `Email` when case-insensitive matching is enabled.
- `ExtraField` is ignored (no corresponding target property).
- `Location` remains default on target (no corresponding source property).
- `LoyaltyPoints` is not copied because source is `string` and target is `int`.

## Output example

```console
Code challenge: Reflection-Based Object Mapper
UserDto: {
  "Name": "Julio",
  "Age": 39,
  "email": "julio@example.com",
  "LoyaltyPoints": "120",
  "ExtraField": "This should be ignored"
}
Mapped object with relaxed config: {
  "Name": "Julio",
  "Age": 39,
  "Email": "julio@example.com",
  "LoyaltyPoints": 0,
  "Location": ""
}
Strict mode enabled: property 'LoyaltyPoints' has incompatible types. Source: String, Target: Int32.
Strict mapping failed as expected: Strict mode enabled: source property 'Location' was not found.

```
