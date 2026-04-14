Hi Team, 

Next Friday's activity will be code challenge. Giving the following problem you are asked to propose a code solution using best practices. 
Please make sure to send to my email your approach by Thursday, We'll pick 3 or 4 solutions to discuss during the call. Nevertheless, all solutions will be reviewed and I'll provide feedback next Monday.

Felipe

 

Valencia

,

Gilberto

 

Carranza

,

Ulises

 

Meixueiro

, Julio Villa,

Miguel

 

Pulgaron

,

Bernardo

 

Mayol

,

Rosario

 

Silva

,

Emmanuel

 

Contreras

,

Wences

 

Cervantes

,

Javier

 

Cazares

,

Rafael

 

Trujillo

,

Juan

 

De

 

Leon

,

Christopher

 

Bluethman

,

Gerardo

 

Herrera

,

Maria

 

Alvarado

,

Daniel

 

Chacon

,

Christopher

 

Prado

,

Francisco

 

Gonzalez

,

Axel

 

Carretero

,

Steven

 

Zenert

,

Jesus

 

Navarro

,

Alan

 

Cortez

,

Harsh

 

Patel

,

Stuart

 

Rodney

 

Simpson

,

Julio

 

Beltran

,

Alejandro

 

Ibarra

,

Saul

 

Iribe

,

Marco

 

Saglietto

,

Pedro

 

Muñoz

,

Gabriel

 

Burrola

,

Sergio

 

Triana

,

Areli

 

Murillo

,

Ricardo

 

Morales

Reflection-Based Object Mapper
Problem
You are often mapping Data Transfer Objects (DTOs) to domain models. Writing this manually is tedious.
Your task is to create a generic utility method Map<TSource, TTarget>(TSource source) that uses reflection to copy property values from a source object to a new TTarget object. The copy should only happen if the property name and type match.
Starter Code:

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
