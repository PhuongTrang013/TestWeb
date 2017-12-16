#add @web tag to run the search tests with Selenium automation

#@web
@automated
Feature: US01_PPCRentalDetails
    In order to details
    As a Agency
    I want to details project

Background: 
Given the following projects 
| PropertyName      | PropertyType | Content                                                                                                                                                                                                                                                        | Street         | Ward        | District | Price |
| PIS Top Apartment | Apartment    | The surrounding neighborhood is very much localized with a great number of local shops, cafes and restaurants all within minutes walk of the apartment. There is also a large daily market close by where you can buy groceries, home appliances and clothing. | Điền Viên Thôn | TT Tây Đằng | Ba Vì    | 10000 |


@automated
Scenario: The author the PropertyName of a project can be seen 
When I open the details of 'PIS Top Apartment' 
Then the project details should show 
| PropertyName      |
| PIS Top Apartment |