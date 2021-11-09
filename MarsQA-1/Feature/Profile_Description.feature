Feature: Profile_Description
	As a skill trader
	I want to be able to add, update, and delete Description

@AddDescription
Scenario: Add New Description
	Given the user clicks on Description tab under profile tab
	And enters new '<Description>' Description
	Then the added '<Description>' description is shown 
	And the toast message '<SuccessMessage>' is shown
	Examples:
    | Description								   | SuccessMessage   						 | 
    | Hello there, I am an automation test analyst.| Description has been saved successfully |

@EditDescription
Scenario: Edit Description
	Given the user clicks on Description tab under profile tab
	And replace the existing details with new '<Description>' Description
	Then the edited description is shown '<Description>'
	And the toast message '<SuccessMessage>' is shown
	Examples:
    | Description																   | SuccessMessage							    | 
    | Hello there, I am a tester with a mediocre experience in Automation using C#.| Description has been saved successfully    |

@DeleteDescription
Scenario: Validate error message when attempt to delete the description
	Given the user clicks on Description tab under profile tab
	And attempts to save the Description field empty
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples:
    | ErrorMessage					        |
    | Please, a description is required     |