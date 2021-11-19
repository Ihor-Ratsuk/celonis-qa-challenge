@UI
Feature: Workspaces

Background:
	Given a user is logged in

@Demo
@Smoke
Scenario: User is able to access to list of workspaces
	When a user navigates to 'Process Analytics'
	Then list of workspaces is displayed, including:
		| Workspace                     |
		| --> Pizza Demo                |
		| --> SAP ECC - Order to Cash   |
		| --> SAP ECC - Purchase to Pay |
		| --> ServiceNow Ticketing      |

@Demo
@Smoke
Scenario: User is able to access to list of analysis
	When a user navigates to 'Process Analytics'
	Then link to process analytics is displayed for each workspace