Feature: Profile_Avail_Hours_Target
	To be viewed my availability informattion by the buyers
	As a skill trader
	I want to be able to successfully update my availability information

@profileUpdate
Scenario: Update Title
	Given the trader updates '<FirstName>' first name and '<LastName>' last name
	Then the changes are shown in the '<Title>'
	Examples: 
	|FirstName	  | LastName	 | Title			 |
	|Naxeer       | Khan         | Naxeer Khan       |

Scenario: Update availability
	Given the trader selects desired option for availability
	Then the toast message '<SuccessMessage>' is shown
	Examples: 
	| SuccessMessage       |
	| Availability updated |

Scenario: Update Hours
	Given the trader selects desired option for Hours
	Then the toast message '<SuccessMessage>' is shown
	Examples: 
	| SuccessMessage       |
	| Availability updated |

Scenario: Update EarnTarget
	Given the trader selects desired option for EarnTarget
	Then the toast message '<SuccessMessage>' is shown
	Examples: 
	| SuccessMessage       |
	| Availability updated |