Feature: SpecFlowFeature5
	In order to update my profile 
	As a skill trader
	I want to add the education

@mytag
Scenario: Check if user could able to add a Education details
	Given I clicked on the Education tab under Profile page
	When I add a new Education details  <College> and <Degree> and <Country> and <Title> and <Year>
	Then that Education Details should be displayed on my listings
	Examples:
	| College       | Degree         | Country     | Title  | Year |
	| UUNZ          | PostGraduation | New Zealand | M.Tech | 2017 |
	| JNTU          | Graduation     | India       | B.Tech | 2011 |
	| Narayana      | Degree         | India       | B.A    | 2007 |
	| Little Flower | B.Sc           | India       | B.Sc   | 2005 |
	