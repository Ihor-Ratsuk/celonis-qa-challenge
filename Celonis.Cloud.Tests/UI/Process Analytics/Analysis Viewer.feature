@UI
Feature: Analysis

@Ignore
@NotAutomated
Scenario: User is able to access Analysis Options in Analysis Viewer
	Given a user on '--> Pizza Demo' process explorer page
	When a user open analysis options menu
	Then analysys options menu includes
		| Option                |
		| Analysis settings     |
		| Saved formulas        |
		| Load script           |
		| Process explorer KPIs |
		| Variables             |
		| Manual (EN)           |
		| Keyboard shortcuts    |
		| Activate LiveReload   |
