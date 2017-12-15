Feature: US05_PPCRentalPosting
	In order to post a new property
	As a agency
	I want to post a new Property on website

Background: 
	Given User have an exist account following information below
	| Email           | Password | RePassword | Fullname | Phone       | Address | Role |
	| admin@gmail.com | camatngu | camatngu   | Nguyên   | 01228080287 | HCM     | 1    |
	And User have been logged on website with 'Session ID'
	| SessionID |
	| 3         |

@web
Scenario: Post property successful
	Given User click on "Post project" button in sidebar
	And User input information of property
	| PropertyName    | PropertyType_ID | Content            | Street_ID | Ward_ ID | District_ID | Price  | UnitPrice | Area  | BedRoom | BathRoom | PackingPlace | UserID | Status_ID |
	| VinHome Central | 1               | Khu căn hộ cao cấp | 1         | 1        | 1           | 200000 | USD       | 120m2 | 3       | 3        | 5            | 3      | 1         |
	When I press Save button
	Then User should see view Ìndex of Agency
