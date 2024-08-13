# Console.HabitTracker

## Requirements
* This is an application where you'll register one habit
* This habit can't be tracked by time (ex. hours of sleep), only by quantity (ex. number of water glasses a day)
* The application should store and retrieve data from real a database
* When the application starts, it should create a sqlite database, if one isn't present
* It should also create a table in the database, where the habit will be logged
* The app should show the user a menu of options
* The users should be able to insert, delete, update and view their logged habit
* You should handle all possible errors so that the application never crashes
* The application should only be terminated when the user inserts 0.
* You can only interact with the database using raw SQL. You can't use mappers such as Entity Framework
* Your project needs to contain a README file where you'll explain how your app works

## Challenges
* Let the users create their own habits to track. That will require that you let them choose the unit of measurement of each habit.
* Seed Data into the database automatically when the database gets created for the first time, generating a few habits and inserting a hundred records with randomly generated values. This is specially helpful during development, so you don't have to reinsert data every time you create the database.
* Create a report functionality where the users can view specific information (i.e. how many times the user ran in a year? how many kms?) SQL allows you to ask very interesting things from your database.

## AI Challenge
* This is a slightly more advanced project, but it taps into the future of programming: Artificial intelligence. Can you let the users add records using their voice? For this you'll use Azure's Language Services.