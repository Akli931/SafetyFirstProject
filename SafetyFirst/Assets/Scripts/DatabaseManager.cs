using System.Data;
using Mono.Data.Sqlite;
using System.IO;
using UnityEngine;

public class DatabaseManager : MonoBehaviour
{
    public static DatabaseManager Instance;
    private string dbPath;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            dbPath = "URI=file:" + Application.persistentDataPath + "/users.db";
            CreateDatabase();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void CreateDatabase()
    {
        if (!File.Exists(Application.persistentDataPath + "/users.db"))
        {
            using (var conn = new SqliteConnection(dbPath))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = "CREATE TABLE IF NOT EXISTS users (id INTEGER PRIMARY KEY AUTOINCREMENT, username TEXT UNIQUE, password TEXT);";
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }

    public bool Register(string username, string password)
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "INSERT INTO users (username, password) VALUES (@username, @password);";
                cmd.Parameters.Add(new SqliteParameter("@username", username));
                cmd.Parameters.Add(new SqliteParameter("@password", password));

                try
                {
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch
                {
                    return false; 
                }
            }
        }
    }

    public bool Login(string username, string password)
    {
        using (var conn = new SqliteConnection(dbPath))
        {
            conn.Open();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "SELECT COUNT(*) FROM users WHERE username = @username AND password = @password;";
                cmd.Parameters.Add(new SqliteParameter("@username", username));
                cmd.Parameters.Add(new SqliteParameter("@password", password));

                int count = System.Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
    }
}
