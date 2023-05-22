﻿using HabitTrackerFuriax.Models;
using Microsoft.Data.Sqlite;
using System.Globalization;

string connectionString = @"Data Source=habitTracker.db";

//create db if it doesnt exist yet
using (var connection = new SqliteConnection(connectionString))
{
	connection.Open();
	var command = connection.CreateCommand();

	command.CommandText = 
		@"CREATE TABLE IF NOT EXISTS drinking(
		Id INTEGER PRIMARY KEY AUTOINCREMENT,
		Date TEXT,
		Quantity INTEGER)";
	command.ExecuteNonQuery();
	connection.Close();
}
GetInput();



void GetInput()
{
	Console.Clear();
	bool closeApp = false;
	while (closeApp == false)
	{
		
		Console.WriteLine("Welcome to this habit tracker");
		Console.WriteLine("---------------------------------");
		Console.WriteLine("Please make a selection:");
		Console.WriteLine("Type 1 to View All Records");
		Console.WriteLine("Type 2 to Insert a Record");
        Console.WriteLine("Type 3 to Delete a Record");
        Console.WriteLine("Type 4 to Update a Record");
        Console.WriteLine("Type 0 to Close this Application");
        Console.WriteLine("---------------------------------");
		string input = Console.ReadLine();

		switch (input)
		{
			case "0": Environment.Exit(0);
				break;
			case "1": ViewRecords();
				break;
			case "2": InsertRecord();
				break;
			case "3": DeleteRecord();
				break;
			case "4": UpdateRecord();
				break;
			default:
                Console.WriteLine("Invalid input, please enter a correct number");
                break;
		}
	}
}

void ViewRecords()
{
	
	using (var connection = new SqliteConnection(connectionString))
	{
		connection.Open();
		var command = connection.CreateCommand();
		command.CommandText = "SELECT * FROM drinking";
		List<DrinkWater> records = new();
		SqliteDataReader reader = command.ExecuteReader();
		if (reader.HasRows)
		{
			while(reader.Read())
			{
				records.Add(new DrinkWater
				{
					Id = reader.GetInt32(0),
					Date = DateTime.ParseExact(reader.GetString(1), "dd/MM/yy", new CultureInfo("nl-BE")),
					Quantity = reader.GetInt32(2)
				}); ;
			}
		}
        else
            Console.WriteLine("No data found");

        connection.Close();

		Console.Clear();
		foreach (var record in records)
		{
            Console.WriteLine($"{record.Id} - {record.Date.ToString("dd/MM/yyyy")} - {record.Quantity}");
        }
		Console.ReadLine();
		Console.Clear();
	}
}
void UpdateRecord()
{
	throw new NotImplementedException();
}

void DeleteRecord()
{
	throw new NotImplementedException();
}

void InsertRecord()
{
	string date = GetDate();
	int quantity = GetNumber("How many water did you drink (in centiliters)");

	using (var connection = new SqliteConnection(connectionString))
	{
		connection.Open();
		var command = connection.CreateCommand();
		command.CommandText = $"INSERT INTO drinking(date, quantity) VALUES ('{date}','{quantity}')";
		command.ExecuteNonQuery();
		connection.Close();
	}
	Console.Clear();
}

int GetNumber(string question)
{
    Console.WriteLine(question);
	int input = Convert.ToInt32(Console.ReadLine());
	if (input == 0)
		GetInput();
	return input;
}

string GetDate()
{
    Console.WriteLine("Enter the date (dd/mm/yy), type 0 to return to main menu");
	string input = Console.ReadLine();
	if (input == "0")
		GetInput();
	return input;
}

