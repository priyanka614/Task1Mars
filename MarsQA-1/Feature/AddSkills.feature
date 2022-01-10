Feature:  SpecFlowFeature6
	In order to update my profile 
	As a skill trader
	I want to add the skills

@mytag
Scenario:  Check if user could able to add a Skills 
	Given I clicked on the Skills tab under Profile page
	When  I add a new Skills < Skill> and <Level>
	Then that Skills should be displayed on my listings
	Examples:
	| Skill               | Level        |
	| Manual Testing      | Expert       |
	| Api Testing         | Intermediate |
	| performance Testing | Beginner     |
	| Automation Testing  | Intermediate |