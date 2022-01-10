Feature:SpecFlowFeature7
	Simple calculator for adding two numbers

@mytag
Scenario: Check if user could able to add a Certification details
	Given I clicked on the Certification tab under Profile page
	When I add a new Certification details <Certificate > and <From> and <Year>
	Then that Certification Details should be displayed on my listings
	Examples: 
	| Certificate            | From              | Year |
	| Cisco                  | Cisco             | 2015 |
	| Agile Technical Tester | ISTQB/ANZTB       | 2018 |
	| ISTQB                  | ISTQB/ANZTB       | 2017 |