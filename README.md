This is a specflow+Nunit framework project to test sample Banking operations.

Major Dependencies used:
1. Nunit - To setup Nunit test framework.
2. Specflow - To use BDD concepts.
3. Restsharp - To validate rest APIs.
4. NewtonsoftJson - To help in Serializing and Deserializing json objects for APIs.
   
Folder structure details:
1. Features - Includes feature files for the test scenarios.
2. Models - Includes classes with getters and setters for API request and response objects.
3. StepDefinitions - Includes step definitions for feature files.
4. Utilities - Includes all utlities and API related action methods.

Below are the scenarios covered here.
1. Create account using Name, Address and Initial balance - Scenario outline used here to create muntiple account with different data.
2. Delete an account using account number.
3. Deposit amount into an account using account number and amoount.
4. Withdraw amount from an account using account number and amoount.
5. Delete an account with invalid account number.
6. Deposit amount into an invalid account.
7. Withdraw amount from an invalid account.

NOTE: For API operations we could have used Authentication, Parameterization but here I have not used them because in given sample endpoints these are not included. Hence its a simple API calls by adding request body in json format.
