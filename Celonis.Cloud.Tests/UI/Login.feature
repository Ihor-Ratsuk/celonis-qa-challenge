@UI
Feature: Login

@Demo
@Smoke
Scenario: User is able to login
	Given a user is on the login page
	When valid credentials are provided
	Then user navigated to a main page