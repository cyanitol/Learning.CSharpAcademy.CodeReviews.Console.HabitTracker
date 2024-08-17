namespace Console.HabitTracker;
using Microsoft.Data.Sqlite;

public class Database(string connString = @"Data Source=HabitTracker.db")
{
    public void CreateLogCategory(string habitName)
    {
        if (habitName == null) throw new ArgumentNullException(nameof(habitName));
        var cmd = $"""
                    CREATE TABLE IF NOT EXISTS {habitName}
                    (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT,
                    Quantity INTEGER)
                    """;
        SendCmd(cmd);
    }

    public List<object> GetLogCategories()
    {
        var cmd = $"""
                    SELECT name FROM sqlite_master
                    WHERE type='table';
                    """;
        return SendCmdRead(cmd);
    }

    public void AddLogItem(string category, DateOnly logDate, int qty)
    {
        if (category == null) throw new ArgumentNullException(nameof(category));
        var cmd = $"""
                    INSERT INTO {category}(date, quantity) VALUES('{logDate}',{qty})
                    """;
        SendCmd(cmd);
    }

    public List<object> GetLogItems(string category){
        if (category == null) throw new ArgumentNullException(nameof(category));
        var cmd = $"""
                    SELECT * FROM {category};
                    """;
        return SendCmdRead(cmd);
    }

    public void DeleteLogItem(string habitName, int logId)
    {
        if (habitName == null) throw new ArgumentNullException(nameof(habitName));
        var cmd = $"""
                    DELETE FROM {habitName} WHERE id = '{logId}'
                    """;
        SendCmd(cmd);
    }

    private void SendCmd(string command)
    {
        using var conn = new SqliteConnection(connString);
        conn.Open();
        var cmd = conn.CreateCommand();
        cmd.CommandText = $"{command}";
        cmd.ExecuteNonQuery();
        conn.Close();
    }

    internal List<object> SendCmdRead(string command)
    {
        using var conn = new SqliteConnection(connString);
        var cmd = conn.CreateCommand();
        var results = new List<object>();
        cmd.CommandText = $"{command}";
        conn.Open();

        using (var reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                if (reader.FieldCount == 1){
                results.Add(reader.GetString(0));
                }
                if (reader.FieldCount == 3){
                HabitLogLine habit = new();
                habit.id = reader.GetString(0);
                habit.date = reader.GetString(1);
                habit.quantity = reader.GetString(2);
                results.Add(habit);
                }

            }

        }
        conn.Close();
        return results;
    }
}