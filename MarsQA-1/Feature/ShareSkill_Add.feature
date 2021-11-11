Feature: ShareSkill_Add
	As a skill trader
	I want to be able to offer my services 
	So that the customers can view my services I am offering
	And can trade with me

@AddSkill
Scenario: Add Skills
	Given the user is on a shareskill page
	When the user adds skill along with all the mandatory relevant details
	Then the added service/skill shown on the Listings page