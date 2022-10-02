Feature: Contactus
In order to contact customer service
As a user
I want to be able to use contact us as form

@mytag
Scenario: User can contact customer service
	Given user open contact us page
	When user fill in all required fields with 'Webmaster' heading and 'Qa Kurs' message
	And User submits the form
	Then message 'Your message has been successfully sent to our team.' is presented to do user