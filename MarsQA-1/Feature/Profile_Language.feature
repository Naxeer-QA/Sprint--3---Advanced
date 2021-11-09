Feature: Profile_Language
	As a skill trader
	I want to be able to add, update, and delete languages

@AddLanguage
Scenario Outline: Add New Language
	Given the user clicks on profile tab
	And enters new '<Language>' and '<LanguageLevel>'
	Then the added language '<Language>' is shown 
	And the toast message '<SuccessMessage>' is shown
	Examples: 
	| Language | LanguageLevel | SuccessMessage                           |
	| English  | Native        | English has been added to your languages |
	| Arabic   | Fluent        | Arabic has been added to your languages  |
	| Chinese  | Basic         | Chinese has been added to your languages |

Scenario: Add duplicate language
	Given the user clicks on profile tab
	And attempts to add an existing '<Language>' and '<LanguageLevel>'
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
	| Language | LanguageLevel |ErrorMessage										 |
	| English  | Native        |This language is already exist in your language list.| 

Scenario: Validate error message for changing level of existing language
	Given the user clicks on profile tab
	And attempts to add an existing '<Language>' with different '<LanguageLevel>' level
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
	| Language | LanguageLevel | ErrorMessage    |
	| English  | Fluent        | Duplicated data |

Scenario: Add duplicate language with different proficiency level
	Given the user clicks on profile tab
	And attempts to add an existing '<Language>' and '<LanguageLevel>'
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
	| Language | LanguageLevel |ErrorMessage      |
	| English  | Basic      |Duplicated data   |

Scenario: Add new language without level
	Given the user clicks on profile tab
	And attempts to add new language '<Language>' without selecting a level '<LanguageLevel>'
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
	| Language | LanguageLevel			|ErrorMessage					   |
	| Persian  | Choose Language Level  |Please enter language and level   |

@EditLanguage
Scenario: Edit existing Language
	Given the user clicks on profile tab
	And replace the '<ExistingLanguage>' with new '<Language>' language and '<LanguageLevel>' level
	Then the replaced '<Language>' language is shown
	Then the toast message '<SuccessMessage>' is shown
	Examples: 
	| ExistingLanguage | Language | LanguageLevel | SuccessMessage							 |
	| Arabic		   | Persian  | Basic         |Persian has been updated to your languages|

Scenario: Edit existing language without level
	Given the user clicks on profile tab
	And attempts to edit '<ExistingLanguage>' language without selecting a '<LanguageLevel>' level
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
	| ExistingLanguage | LanguageLevel  | ErrorMessage					  |
	| Chinese          | Language Level |Please enter language and level  |

@DeleteLanguage
	Scenario: User deletes language
	Given the user clicks on profile tab
	And attempts to delete an existing '<ExistingLanguage>' language
	Then the deleted '<DeletedLangage>' language is not shown 
	Then the toast message '<SuccessMessage>' is shown
	Examples: 
	| ExistingLanguage | DeletedLangage  | SuccessMessage								|
	| Chinese          | Chinese		 |Chinese has been deleted from your languages  |