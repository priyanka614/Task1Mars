Feature: SpecFlowFeature1
	In order to update my profile 
	As a skill trader
	I want to add the description

@mytag
Scenario: Check if user could able to add description
	 Given user clicked on the description tab under Profile page
	 When user add description and save
	 Then That Description should be displayed in Descrption tab