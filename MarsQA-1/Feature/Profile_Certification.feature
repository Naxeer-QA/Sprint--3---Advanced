Feature: Profile_Certification
	As a skill trader
	I want to be able to add, update, and delete Certification

@AddCertification
Scenario: Add New Certification
	Given the user clicks on Certification tab under profile tab
	And enters new Certification '<CertificationName>', '<CertificationFrom>', '<CertificationYear>' details
	#Then the added '<CertificationName>' Certification is shown (WILL IMPLEMENT LATER)
	Then the toast message '<SuccessMessage>' is shown
	Examples:
    | CertificationName | CertificationFrom | CertificationYear | SuccessMessage                                |
    | ISTQB             | MindQ             | 2015              | ISTQB has been added to your certification    |
    | Selenium          | MindQ             | 2015              | Selenium has been added to your certification |
    | Java              | Naresh I Tech     | 2014              | Java has been added to your certification     |
    | C                 | Somewhere         | 2007              | C has been added to your certification        |

Scenario: Add duplicate Certification
	Given the user clicks on Certification tab under profile tab
	And attempts to add an existing '<CertificationName>', '<CertificationFrom>', '<CertificationYear>' Certification
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples:
    | CertificationName | CertificationFrom | CertificationYear | ErrorMessage							 | 
    | ISTQB             | MindQ             | 2015              | This information is already exist.     | 

Scenario: Validate error message when any field is left empty
	Given the user clicks on Certification tab under profile tab
	And attempts to add a new Certification '<CertificationName>', '<CertificationFrom>' with any mandatory field '<CertificationYear>' left empty
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
    | CertificationName | CertificationFrom |CertificationYear  | ErrorMessage																| 
    | ISTQB             | MindQ             | Year  			| Please enter Certification Name, Certification From and Certification Year| 

@EditCertification
Scenario: Edit existing Certification
	Given the user clicks on Certification tab under profile tab
	And replace the existing '<ExistingAward>' certification with new '<CertificationName>', '<CertificationFrom>', '<CertificationYear>' details
	#Then the edited Certification is shown (WILL IMPLEMENT LATER)
	Then the toast message '<SuccessMessage>' is shown
	Examples: 
    | ExistingAward | CertificationName | CertificationFrom | CertificationYear | SuccessMessage |
    | Selenium      | Cypress           | IndustryConnect   | 2019              | Cypress has been updated to your certification | 

Scenario: Validate error message for updating Certification with empty fields
	Given the user clicks on Certification tab under profile tab
	And attempts to replace existing '<ExistingAward>' Certification with new '<CertificationName>', '<CertificationFrom>' award with any mandatory field  '<CertificationYear>' left empty
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
    | ExistingAward | CertificationName | CertificationFrom | CertificationYear | ErrorMessage |
    | Cypress		| NEAT              | MindQ             | Year  		    |Please enter Certification Name, Certification From and Certification Year| 

@DeleteCertification
	Scenario: User deletes Certification
	Given the user clicks on Certification tab under profile tab
	And attempts to delete an existing '<ExistingAward>' Certification
	#Then the deleted Certification '<ExistingAward>' is not shown in my listings (WILL IMPLEMENT LATER)
	Then the toast message '<SuccessMessage>' is shown
	Examples: 
    | ExistingAward | SuccessMessage                                   |
    | Cypress       | Cypress has been deleted from your certification |