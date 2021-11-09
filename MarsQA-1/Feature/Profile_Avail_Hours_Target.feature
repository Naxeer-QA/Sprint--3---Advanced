Feature: Profile_Avail_Hours_Target
	To be viewed my availability informattion by the buyers
	As a skill trader
	I want to be able to successfully update my availability information

@profileUpdate
Scenario: Update First and Last Name
	Given the trader updates first and last name
	Then the changes are shown in the title

Scenario: Update availability
	Given the trader selects desired option for availability
	Then the successful message is shown

Scenario: Update Hours
	Given the trader selects desired option for Hours
	Then the successful message is shown

Scenario: Update EarnTarget
	Given the trader selects desired option for EarnTarget
	Then the successful message is shown