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

    public void AddLogItem(string habitName, DateOnly logDate, int qty)
    {
        if (habitName == null) throw new ArgumentNullException(nameof(habitName));
        var cmd = $"""
                    INSERT INTO {habitName}(date, quantity) VALUES('{logDate}',{qty})
                    """;
        SendCmd(cmd);
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
                results.Add(reader.GetString(0));
            }

        }
        conn.Close();
        return results;
    }
}