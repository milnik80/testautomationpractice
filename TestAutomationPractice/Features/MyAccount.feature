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

Scenario: User can create an account
	Given User open login page
	And initiates a flow for creating account
	And user enters all required personal details
	When user submits the sign up form
	Then user will be logged in
	And users full name is displayed
