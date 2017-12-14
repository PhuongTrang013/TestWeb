#add @web tag to run the search tests with Selenium automation

#@web
@automated
Feature: US01_PPCRentalDetails
    In order to details
    As a Agency
    I want to details project

Background:
	Given the following project
		| PropertyName            | PropertyType | Content																																																																																	  | Street         | Ward        | District | Price |
		| PIS Top Apartment       | Apartment    | The surrounding neighborhood is very much localized with a great number of local shops, cafes and restaurants all within minutes walk of the apartment. There is also a large daily market close by where you can buy groceries, home appliances and clothing.																			  | Điền Viên Thôn | TT Tây Đằng | Ba Vì    | 10000 |
		| Saigon Pearl Ruby Block | Apartment    |– Located on Nguyen Huu Canh Street, this nice apartment has all amenities like swimming pool, sauna, jacuzzi, gym and pet allowed… – It has fully furnished with everything you need like TV, fridge, washing machine, wardrobe, sofa, dining table, kitchenette, … – With $1600/month for 3 bedroom apartment. Inclusive of management fee| Thôn Chúc Đồng | Đại Yên     |Chương Mỹ | 30000 |


Scenario: The author, the PropertyName,the Address and the price of a project can be seen
    When I open the details of 'PIS Top Apartment'
	Then the project details should show
		| PropertyName            | PropertyType | Content																																																																																	  | Street         | Ward        | District | Price |
		| PIS Top Apartment       | Apartment    | The surrounding neighborhood is very much localized with a great number of local shops, cafes and restaurants all within minutes walk of the apartment. There is also a large daily market close by where you can buy groceries, home appliances and clothing.																			  | Điền Viên Thôn | TT Tây Đằng | Ba Vì    | 10000 |
