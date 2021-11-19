@UI
Feature: Process Explorer

Background:
	Given a user is logged in

@Demo
@Smoke
Scenario Outline: User is able to access Process Explorer
	Given a user is on the 'Process Analytics'
	When a user opens analysis in '<Workspace>' workspace
	And navigates to process explorer
	Then process graph is displayed

	Examples:
		| Workspace                     |
		| --> Pizza Demo                |
		| --> SAP ECC - Order to Cash   |
		| --> SAP ECC - Purchase to Pay |
		| --> ServiceNow Ticketing      |

@Ignore
@NotAutomated
Scenario: User is able to view details about selected activity
	Given a user is on the process explorer page
	When a user selects activity in process graph
	Then selected activity details are displayed

@Ignore
@NotAutomated
Scenario: User is able to view details about selected connection
	Given a user is on the process explorer page
	When a user selects connection in process graph
	Then selected connection details are displayed

@Ignore
@NotAutomated
Scenario: User is able to add activities
	Given a user is on the process explorer page
	When a user pulls the activities slider up
	Then new activities are added to process graph

@Ignore
@NotAutomated
Scenario: User is able to add connections
	Given a user is on the process explorer page
	When a user pulls the connections slider up
	Then new connections are added to process graph

@Ignore
@NotAutomated
Scenario Outline: User is able to switch KPIs in process graph
	Given a user is on the process explorer page
	When a user switch to <KPI> KPI in process graph
	Then <KPI> KPI values are displayed for graph connections

	Examples:
		| KPI                            |
		| Case Frequency                 |
		| Activity Frequency             |
		| Throughput Time (Median)       |
		| Throughput Time (AVG)          |
		| Throughput Time (Trimmed mean) |