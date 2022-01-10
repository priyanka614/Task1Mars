 Feature: SpecFlowFeature2

@mytag
Scenario Outline: Check if user could able to add a language for different iterarions
	Given I click on the Language tab in profile
	When I addded a new language <Languages> and <Level>
	Then that language should be displayed on my listing
	Examples: 
	| Languages | Level          |
	| Hindi     | Conversational |
	| Telugu    | Fluent         |
	| English   |Native/Bilingual|
	| Spanish   | Basic          |