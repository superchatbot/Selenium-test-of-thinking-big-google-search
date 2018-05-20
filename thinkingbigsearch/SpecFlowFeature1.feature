Feature: Searchingoogle

@mytag
Scenario: Search Google for "thinking big" and find how many results there are.
	Given I navigate to google search page
	When I entered key words as "thinking big"
	And I pressed Enter
	Then I should see the number of searching results
