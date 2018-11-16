# NetCoreSamples
## Palindrome finder ##

The project is implemented using C# on .NET Core.
It outputs the 3 longest palindromes in the given input string.

## Assumptions ##

1. Input should be a string with no spaces. It doesnt consider space. It trims to remove space.
2. The code by default ignore cases. But can also be tested with case sensitive.
3. Minumum length of input is 3.
4. A palindrome with space is ignored.

## Instructions to build a project ##
### To build the project ###

- For Release build execute - 
  `dotnet build -c Release`

- For Debug build execute -
  `dotnet build -c Debug`

### To run the project ###
1. Build the project.
2. To run the project execute:
   `dotnet run`

### To Create a portable application ###
1. `dotnet publish -o PublishFolder`
2. To run from the publish dolder execute:
   `dotnet Palindrome.dll`
