namespace Console.HabitTracker;
using Microsoft.Data.Sqlite;

public class Database(string connString = @"Data Source=HabitTracker.db")
{
    public void AddHabit(string habitName)
    {
        if (habitName == null) throw new ArgumentNullException(nameof(habitName));
        var cmd  = $"""
                    CREATE TABLE IF NOT EXISTS {habitName}
                    (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT,
                    Quantity INTEGER)
                    """;
        SendCmd(cmd);
        }
    
    public void LogHabit(string habitName, DateOnly logDate, int qty)
    {
        if (habitName == null) throw new ArgumentNullException(nameof(habitName));
        var cmd  = $"""
                    INSERT INTO {habitName}(date, quantity) VALUES('{logDate}',{qty})
                    """;
        SendCmd(cmd);
    }
    
    private void SendCmd(string command)
    {
        if (command == null) throw new ArgumentNullException(nameof(command));
        using (var conn = new SqliteConnection(connString)) {
            conn.Open();
            var cmd = conn.CreateCommand();
            cmd.CommandText = $"{command}";
            cmd.ExecuteNonQuery();
            conn.Close();
        }
    }
}