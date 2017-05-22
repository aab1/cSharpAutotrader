Feature: SearchAndViewACar
	In order to view a car
	As a customer
	I want to be able to search for and view a car

@mytag1
Scenario: Customer can search for  and view a car
	Given I navigate to Autotrader 
	When search for a car
	Then the result is displayed
	And I can view a selected car
