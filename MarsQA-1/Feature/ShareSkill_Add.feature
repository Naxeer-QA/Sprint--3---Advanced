Feature: ShareSkill_Add
	As a skill trader
	I want to be able to offer my services 
	So that the customers can view my services I am offering
	And can trade with me

@AddSkill
Scenario: Add Skill
	Given the user is on a shareskill page
	When the user adds skill along with all the mandatory relevant details
	Then the toast message '<SuccessMessage>' is shown
	And the added service/skill is listed on the Listings page
	Examples: 
	| SuccessMessage                     |
	| Service Listing Added successfully |

@UpdateSkill
Scenario: Update Skill
	Given the user on a listings page
	When the user clicks on edit icon for any existing lisings
	And the user updates skill along with all the mandatory relevant details
	Then the toast message '<SuccessMessage>' is shown
	And the updated service/skill shown on the Listings page
	Examples: 
	| SuccessMessage                       |
	| Service Listing Updated successfully |

#DeleteSkill
Scenario: Delete skill
	Given the user on a listings page
	When the user clicks on remove icon
	And selects 'Yes' to delete the skill
	Then the toast message '<SuccessMessage>' is shown
	Examples: 
	| SuccessMessage                             |
	| Automation using Selenium has been deleted |

