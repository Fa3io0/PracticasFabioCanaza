using System.Data.SQLite;


namespace SQLite
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool control = true;


            string connectionString = "Data Source=games.db";
            SQLiteConnection connection = new SQLiteConnection(connectionString);

            connection.Open();

            //Per crear la taula

            string createTableQuery = "CREATE TABLE IF NOT EXISTS Games (Year INTEGER PRIMARY KEY, Name TEXT, Studio TEXT)";
            SQLiteCommand createTableCommand = new SQLiteCommand(createTableQuery, connection);
            createTableCommand.ExecuteNonQuery();


            while (control)
            {
                Console.WriteLine("1 - Create game");
                Console.WriteLine("2 - List games");
                Console.WriteLine("3 - Delete games");
                Console.WriteLine("4 - Search game by name");
                Console.WriteLine("5 - Update any game");
                Console.WriteLine("6 - Exit");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        CrearPersona(connection);
                        break;
                    case "2":
                        MostrarPersonas(connection);
                        break;
                    case "3":
                        EliminarPersona(connection);
                        break;
                    case "4":
                        SearchByName(connection);
                        break;
                    case "5":
                        UpdateGame(connection);
                        break;
                    case "6":
                        control = false;
                        break;
                    default:
                        Console.WriteLine("No existe esa opción");
                        break;
                }
            }

            connection.Close();
        }

        static void CrearPersona(SQLiteConnection connection)
        {

            Console.WriteLine("Name of the game?");
            string name = Console.ReadLine();

            Console.WriteLine("Name of the studio?");
            string studio = Console.ReadLine();

            string insertQuery = "INSERT INTO games (Name, Studio) VALUES (@name, @studio)";
            SQLiteCommand insertCommand = new SQLiteCommand(insertQuery, connection);
            insertCommand.Parameters.AddWithValue("@name", name);
            insertCommand.Parameters.AddWithValue("@studio", studio);
            insertCommand.ExecuteNonQuery();

            Console.WriteLine("Se ha añadido un game a la BBDD");
        }

        static void MostrarPersonas(SQLiteConnection connection)
        {
            string selectQuery = "SELECT * FROM Games";
            SQLiteCommand selectCommand = new SQLiteCommand(selectQuery, connection);
            SQLiteDataReader result = selectCommand.ExecuteReader();

            Console.WriteLine("Games in the BBDD");

            while (result.Read())
            {
                Console.WriteLine("Id: {0}, Name: {1}, Studio: {2}", result["Year"], result["Name"], result["Studio"]);
            }
        }

        static void EliminarPersona(SQLiteConnection connection)
        {
            MostrarPersonas(connection);

            Console.WriteLine("Write the ID of the game that u wanna delete:");
            int year = Convert.ToInt32(Console.ReadLine());

            string deleteQuery = "DELETE FROM Games WHERE Year = @year";
            SQLiteCommand deleteCommand = new SQLiteCommand(deleteQuery, connection);
            deleteCommand.Parameters.AddWithValue("@year", year);

            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Delete successfully :>");

            MostrarPersonas(connection);
        }

        static void SearchByName(SQLiteConnection connection)
        {
            Console.Write("Write the name that you are looking for: ");
            string name = Console.ReadLine();

            string selectQuery = "SELECT * FROM Games WHERE Name = @name";
            SQLiteCommand searchCommand = new SQLiteCommand(selectQuery, connection);
            searchCommand.Parameters.AddWithValue("@name", name);
            SQLiteDataReader result = searchCommand.ExecuteReader();

            while (result.Read())
            {
                Console.WriteLine("Id: {0}, Name: {1}, Studio: {2}", result["Year"], result["Name"], result["Studio"]);
            }
        }

        static void UpdateGame(SQLiteConnection connection)
        {
            Console.Write("Write the Id of the game that u wanna update: ");
            int year = Convert.ToInt32(Console.ReadLine());

            Console.Write("New name: ");
            string newName = Console.ReadLine();

            Console.Write("New name of the studio: ");
            string newStudio = Console.ReadLine();

            string updateQuery = "UPDATE Games SET Name = @name, Studio = @studio WHERE Year = @year";
            SQLiteCommand updateCommand = new SQLiteCommand(updateQuery, connection);

            updateCommand.Parameters.AddWithValue("@name", newName);
            updateCommand.Parameters.AddWithValue("@studio", newStudio);
            updateCommand.Parameters.AddWithValue("@year", year);
            
            updateCommand.ExecuteNonQuery();
            Console.WriteLine("Update successfully");
            
        }
    }
}