Feature: DeleteLanguage4
	
@mytag
Scenario: check if user is able to delete the language
	Given I click on the Language tab under Profile page
	When I click on Delete option in language list 
	Then I check if language is deleted or not
	
	