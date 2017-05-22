Feature: SearchCarOnAutoTrader
	In order to buy a car
	As a customer
	I want to be able to search for a car

@Scemytag
Scenario Outline: Customer can search for a car
	Given I navigate to Autotrader
	When I search for a car "<Make>" from a "<Postcode>" of range "<Distance>"
	Then the result is displayed contains "<Make>"


Scenarios: 
	| Make   | Postcode | Distance        |
	| Audi   | OL9 8LE  | Within 30 miles |
	| Volvo  | M34 5JE  | Within 70 miles |
	| Ford   | M40 2EW  | Within 60 miles |
	| Honda  | OL9 8LD  | Within 50 miles |
	| Toyota | S8 6TY   | Within 45 miles |
