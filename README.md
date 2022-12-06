# Adform Academy Kudos API

## Requirements to run

To run this program, the following software is needed:

* Visual Studio 2022 with .NET 6 installed
* Docker

Optional: 
* Some tool to view database such as DBeaver, pgAdmin, etc.

## Setup

* Clone repository into your own computer
* Local port 8003 is reserved for postgres database, check if available
* Run ```docker compose up``` from terminal in root folder 
* Run Adform.Academy.Kudos.Api project from Visual Studio or command line

## Functionality

### Employee Endpoint

* Create new employee with inputted name and surname
* View all employees

### Kudos Endpoint

* Create new kudos (has reason, free text, sender and receiver)
* View all kudos
* Mark kudos selected by id as exchanged

### Kudos report Endpoint

* Generate kudos report for given date (year and month relevant). Report shows employee who gave the most kudos, employee who received most kudos and total kudos sent that month.

## Missing functionality

* Did not have time to implement kudos filtering, whole api docker support, complete unit test coverage
