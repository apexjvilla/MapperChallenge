# Code challenge: Reflection-Based Object Mapper

---

## Problem

You are often mapping Data Transfer Objects (DTOs) to domain models. Writing this manually is tedious.
Your task is to create a generic utility method Map<TSource, TTarget>(TSource source) that uses reflection to copy property values from a source object to a new TTarget object. The copy should only happen if the property name and type match.

## Starter Code

```C#
public class UserDto
{
public string Name { get; set; }
public int Age { get; set; }
public string ExtraField { get; set; } // This should be ignored
}

public class User
{
public string Name { get; set; }
public int Age { get; set; }
public string Location { get; set; } // This should remain null/default
}

public class MapperUtility
{
public TTarget Map<TSource, TTarget>(TSource source) where TTarget : new()
{
// TODO: Implement this using Reflection
// 1. Create a new TTarget
// 2. Get properties for TSource and TTarget
// 3. Loop and copy matching properties
// 4. Return the new TTarget
}
}
```
