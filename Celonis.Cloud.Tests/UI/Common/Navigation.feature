@UI
Feature: Navigation

@Demo
@Smoke
Scenario: List of applications is displayed in navigation bar
	When a user is logged in
	Then applications are displayed in navigation bar
		| Application        |
		| Business Views     |
		| Studio             |
		| Process Analytics  |
		| Event Collection   |
		| Celonis Gallery    |
		| Machine Learning   |
		| Process Repository |
		| Task Mining        |

@Demo
@Smoke
Scenario Outline: User is able to navigate to application
	Given a user is logged in
	When a user select '<Application>' in navigation bar
	Then '<Application>' application page is opened

	Examples:
		| Application        |
		| Business Views     |
		| Studio             |
		| Process Analytics  |
		| Event Collection   |
		| Celonis Gallery    |
		| Machine Learning   |
		| Process Repository |
		| Task Mining        |