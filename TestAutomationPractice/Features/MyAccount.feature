Feature: MyAccount
	In order to find products 
	As a user
	I want to be able to login 

@mytag
Scenario: User can login
	Given User open login page
	And  enter correct credentials
	When user submits the form
	Then user will be logged in