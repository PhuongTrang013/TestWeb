#add @web tag to run the search tests with Selenium automation

#@web
@automated
Feature: US03_PPCRentalFilter
	In order to filter
	As a User
	I want to filter project

Background: 
	Given the following property
		| Property_Name          | Property_Type | Ward_ID     | Price | Bedroom | District_ID | Bathroom |
		| PIS Top Apartment      | Apartment     | TT Tây Đằng | 10000 | 3       | Ba Vì       | 3        |
		| Modern Style Apartment | Villa         | Ba Trại     | 30000 | 2       | Ba Vì       | 4        |
		| PIS Serviced Apartment | Villa         | Ba Vì       | 70000 | 3       | Ba Vì       | 2        |

Scenario: Property Name should be matched
	Given User at the Home page
	When I search for property by the pharse 'Property name'
	Then User should see the list name of project
		| Property_Name          |
		| PIS Top Apartment      | 
		| Modern Style Apartment | 
		| PIS Serviced Apartment | 