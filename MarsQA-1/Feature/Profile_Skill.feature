Feature: Profile_Skill
	As a skill trader
	I want to be able to add, update, and delete Skills

@AddSkills
Scenario Outline: Add New Skill
	Given the user clicks on Skills tab under profile tab
	And enters '<SkillName>' and '<SkillLevel>'
	Then the added '<SkillName>' is shown
	And the toast message '<SuccessMessage>' is shown
	Examples: 
    | SkillName | SkillLevel   | SuccessMessage                        |
    | C#        | Expert       | C# has been added to your skills      |
    | Java      | Beginner     | Java has been added to your skills	   |
    | Cypress   | Intermediate | Cypress has been added to your skills |     
	
Scenario: Add duplicate Skill
	Given the user clicks on Skills tab under profile tab
	And enters an existing '<SkillName>' Skill and '<SkillLevel>' 
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
	| SkillName | SkillLevel	| ErrorMessage                                    |
	| C#        | Expert        | This skill is already exist in your skill list. |

Scenario: Validate error message for changing level of existing skill
	Given the user clicks on Skills tab under profile tab
	And enters an existing '<SkillName>' Skill with different '<SkillLevel>' level
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
	| SkillName | SkillLevel	| ErrorMessage    |
	| C#        | Intermediate  | Duplicated data |
	
Scenario: Add new skill without level
	Given the user clicks on Skills tab under profile tab
	And adds new '<SkillName>' skill without selecting level '<SkillLevel>'
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
    | SkillName | SkillLevel         | ErrorMessage |
    | C#        | Choose Skill Level |Please enter skill and experience level| 

@EditSkills
Scenario: Edit existing Skills
	Given the user clicks on Skills tab under profile tab
	And replace the '<ExistingSkill>' with new '<SkillName>' Skill and '<SkillLevel>' level
	Then the added '<SkillName>' is shown
	Then the toast message '<SuccessMessage>' is shown
	Examples: 
    | ExistingSkill | SkillName | SkillLevel | SuccessMessage						|
    | Java          | Python    | Beginner   |Python has been updated to your skills| 

Scenario: Edit existing skill without level
	Given the user clicks on Skills tab under profile tab
	And replaces '<Existingskill>' with new '<SkillName>' skill without selecting '<SkillLevel>' level
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
    | Existingskill | SkillName | SkillLevel | ErrorMessage							 |
    | Cypress       | Ruby      | Skill Level|Please enter skill and experience level| 

@DeleteSkill
	Scenario: User deletes skill
	Given the user clicks on Skills tab under profile tab
	And attempts to delete '<SkillName>' skill
	Then the toast message '<SuccessMessage>' is shown
	Examples: 
	| SkillName | SuccessMessage           |
    | Cypress   | Cypress has been deleted |