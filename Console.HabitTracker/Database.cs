namespace Console.HabitTracker;
using Microsoft.Data.Sqlite;

public class Database(string connString = @"Data Source=HabitTracker.db")
{
    public void CreateLogCategory(string habitName)
    {
        var cmd = $"""
                       CREATE TABLE IF NOT EXISTS '{habitName}'
                       (Id INTEGER PRIMARY KEY AUTOINCREMENT, Date TEXT,
                       Quantity INTEGER)
                       """;
        SendCmd(cmd);
    }

    public List<object> GetLogCategories()
    {
        const string cmd = """
                           SELECT name FROM sqlite_master
                           WHERE type='table';
                           """;
        return SendCmdRead(cmd);
    }

    public void AddLogItem(string category, DateOnly logDate, int qty)
    {
        ArgumentNullException.ThrowIfNull(category);
        var cmd = $"""
                    INSERT INTO {category}(date, quantity) VALUES('{logDate}',{qty})
                    """;
        SendCmd(cmd);
    }

    public List<object> GetLogItems(string category)
    {
        ArgumentNullException.ThrowIfNull(category);
        var cmd = $"""
                    SELECT * FROM {category};
                    """;
        return SendCmdRead(cmd);
    }

    public void DeleteLogItem(string habitName, int logId)
    {
        ArgumentNullException.ThrowIfNull(habitName);
        var cmd = $"""
                    DELETE FROM '{habitName}' WHERE id = '{logId}'
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

    private List<object> SendCmdRead(string command)
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
                if (reader.FieldCount == 1)
                {
                    results.Add(reader.GetString(0));
                }

                if (reader.FieldCount != 3) continue;
                HabitLogLine habit = new()
                {
                    Id = reader.GetString(0),
                    Date = reader.GetString(1),
                    Quantity = reader.GetString(2)
                };
                results.Add(habit);

            }

        }
        conn.Close();
        return results;
    }
}