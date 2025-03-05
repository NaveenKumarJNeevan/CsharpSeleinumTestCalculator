Setup VS Code along with .Net and selenium related dependencies

steps to setup and build project 

1. Navigate to the project folder in terminal
2. dotnet clean to clean existing project files if any not mandatory
3. dotnet build to build the project. once build is successful we are good for the project setup

steps to execute the test cases
Run all test cases against stage
1. dotnet test

Run all test cases against desired stage
1. dotnet test -e Stage="Stage"
2. Stage can have either Stage or Prod as values

Run test cases based on filter
1. dotnet test --filter Category=TestCat -e Stage="Stage"
