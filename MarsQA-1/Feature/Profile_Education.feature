Feature: Profile_Education
	As a skill trader
	I want to be able to add, update, and delete Education

@AddEducation
Scenario Outline: Add New Education
	Given the user clicks on Education tab under profile tab
	And enters '<CollegeName>', '<CollegeCountry>', '<EducationTitle>', '<DegreeName>', '<GraduationYear>' Education details
	Then the added '<CollegeName>' Education is shown 
	And the toast message '<SuccessMessage>' is shown
	Examples: 
	 | CollegeName                   | CollegeCountry | EducationTitle | DegreeName | GraduationYear | SuccessMessage           |
	 | Auckland Institute Of Studies | New Zealand    | Associate      | GDIT       | 2018           | Education has been added |
	 | EFLU                          | India          | PHD            | Ph.D       | 2016           | Education has been added |
	 | Nadwa                         | India          | B.A            | Graduation | 2006           | Education has been added |

Scenario: Add duplicate Education
	Given the user clicks on Education tab under profile tab
	And enters an existing '<CollegeName>', '<CollegeCountry>', '<EducationTitle>', '<DegreeName>', '<GraduationYear>' Education details
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
	| CollegeName                   | CollegeCountry | EducationTitle | DegreeName | GraduationYear | ErrorMessage						 |
	| Auckland Institute Of Studies | New Zealand    | Associate      | GDIT       | 2018           |This information is already exist.  |

Scenario: Validate error message when any field is left empty
	Given the user clicks on Education tab under profile tab
	And attempts to add a new Education '<CollegeName>', '<CollegeCountry>' with any mandatory field left empty
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
    | CollegeName   | CollegeCountry| ErrorMessage               | 
    | AUT           | New Zealand   | Please enter all the fields| 

@EditEducation
Scenario: Edit existing Education
	Given the user clicks on Education tab under profile tab
	And replace the existing '<ExistingDegree>' details with new '<CollegeName>', '<CollegeCountry>', '<EducationTitle>', '<DegreeName>', '<GraduationYear>' Education details
	Then the edited Education '<CollegeName>' is shown
	And the toast message '<SuccessMessage>' is shown
	Examples: 
    | ExistingDegree | CollegeName | CollegeCountry | EducationTitle | DegreeName | GraduationYear | SuccessMessage            |
    | Ph.D           | AUT         | New Zealand    | M.Tech         | M.Tech     |2020			   | Education as been updated | 

Scenario: Validate error message for updating education with mandatory fields left empty 
	Given the user clicks on Education tab under profile tab
	And attempts to edit an existing '<ExistingDegree>' Education '<CollegeName>' with any mandatory field '<GraduationYear>'left empty
	Then the user should see the'<ErrorMessage>' message displayed on my listings
	Examples: 
    | ExistingDegree | CollegeName | GraduationYear		| ErrorMessage				|
    | Graduation     | MIT         | Year of graduation |Please enter all the fields|  

@DeleteEducation
	Scenario: User deletes Education
	Given the user clicks on Education tab under profile tab
	And attempts to delete an existing '<CollegeName>' Education
	#Then the deleted Education '<CollegeName>' is not shown in my listings
	Then the toast message '<SuccessMessage>' is shown
	Examples: 
    | SuccessMessage					  |	CollegeName	 |
	| Education entry successfully removed| Nadwa		 |
    