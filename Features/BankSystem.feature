Feature: BankSystem

Basic Banking system to test Account creation, deletion, deposit and withdrawal scenarios.

Scenario: Create new Account with valid data
	Given Account Initial Balance is $20
	And Account name is "Rajesh Mittal"
	And Address is "Ahmedabad, Gujarat"
	When POST endpoint triggered to create new account with above details
	Then Verify the response code is 201
	And Verify no error is returned
	And Verify the success message "Account X123 created successfully"
	And Verify the account details are correctly returned in the JSON response

Scenario: Delete an Account with valid data
	Given Account number is "ADD4545455"
	When DELETE endpoint triggered to delete the given account
	Then Verify the response code is 200
	And Verify no error is returned
	And Verify the success message "Account 20500 deleted successfully"
	And Verify JSON response for Account deletion

Scenario: Deposit into an Account
	Given Account number is "ADD4545455"
	And Amount to be deposit/withdraw is $30
	When PUT endpoint triggered to deposit an amount into the given account details
	Then Verify the response code is 200
	And Verify no error is returned
	And Verify the success message "1000$ deposited to Account X123 successfully"
	And Verify JSON response for Deposit action

Scenario: Withdraw from an Account
	Given Account number is "ADD4545455"
	And Amount to be deposit/withdraw is $30
	When PUT endpoint triggered to withdraw an amount from the given account details
	Then Verify the response code is 200
	And Verify no error is returned
	And Verify the success message "1000$ withdrawn from Account X123 successfully"
	And Verify JSON response for withdraw action

Scenario: Delete an Account with Invalid data
	Given Account number is "ADD4545455"
	When DELETE endpoint triggered to delete the given account
	Then Verify the response code is 204

Scenario: Deposit into an Invalid Account
	Given Account number is "JUHH3399939"
	And Amount to be deposit/withdraw is $30
	When PUT endpoint triggered to deposit an amount into the given account details
	Then Verify the response code is 204

Scenario: Withdraw from an Invalid Account
	Given Account number is "JUHH3399939"
	And Amount to be deposit/withdraw is $30
	When PUT endpoint triggered to withdraw an amount from the given account details
	Then Verify the response code is 204


