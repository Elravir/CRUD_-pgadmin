using CRUD__pgadmin.Repositories;
using Npgsql;
using System.Runtime.InteropServices;

namespace PostgresSqlClient;

internal class Program {

    const string ConnString = "Host=ep-winter-frog-92114323.us-east-2.aws.neon.tech;Username=kek.20;Password=QRIiynfvcx23;Database=neondb";

    private const string TABLE_NAME_1 = "book";
    private const string TABLE_NAME_2 = "publish";
    static private NpgsqlConnection connection;
    static void Main(string[] args) {
        connection = new NpgsqlConnection();
        connection.Open();

        var BookRepo = new BookRepositories(ConnString);

        string s;
        while (true){
            Console.WriteLine("Выберите таблицу: 1.{0}, 2.{1}",TABLE_NAME_1 ,TABLE_NAME_2);
            s = Console.ReadLine();
            
            Console.WriteLine("Выберите действие:\n1. Показать список всех книг\n2. удалить книгу\n3. изменить данные книги");
            string action = Console.ReadLine();

                switch (action) {
                    case "1":
                        foreach(var item in BookRepo.GetAll()) {
                        Console.WriteLine($"{item.Id_book} {item.Name_book} {item.Id_bublish} {item.Price}");
                        } 
                        continue;
                    case "2":
                        Console.WriteLine("Введите id книги для удаления");
                        int value = Convert.ToInt32(Console.ReadLine());
                        BookRepo.DeleteBook(value);
                        continue;
                    case "3":
                        update_data(TABLE_NAME_1);
                        continue;
                }

            
        }


    }

    static List<string> column_n;

    static async void Print(string name_tbl) {
        using var command = connection.CreateCommand();
        command.CommandText = $"SELECT column_name FROM information_schema.columns where table_name = '{name_tbl}'";
        using var reader = command.ExecuteReader();
        column_n = new List<string>();
        string column_name = "";
        while (reader.Read()) {
            Console.Write(reader[0] + " ");
            column_name += reader[0];
            column_n.Add(reader[0].ToString());
        }
        column_name.TrimEnd(',');
        Console.WriteLine();
        reader.Close();

        await using var command1 = new NpgsqlCommand($"SELECT * from {name_tbl}", connection); ;
        //command1.CommandText = $"SELECT * from {name_tbl}";
        await using var reader1 = command1.ExecuteReader();
        while (reader1.Read()) {
            foreach(string i in column_n) {
                Console.Write(reader1[i] + "  ");
            }
            Console.WriteLine();
            
        }
        reader1.Close();

    }

    static async void insert_data(string name_tbl) {
        List<string> values = new List<string>();
        string str = "";
        Console.WriteLine("введите значения для:");
        foreach (string i in column_n) {
            Console.Write(i + "  ");
            string val = Console.ReadLine();
            values.Add(val);
            if (int.TryParse(val, out int numericValue)) {
                str += val + ",";
            }
            else { 
                str += "'" + val+ "'" + ","; 
            }
        }
        str = str[..^1]; 
        Console.WriteLine(str);

        string CommandText = $"INSERT INTO {name_tbl} VALUES ({str})";
        
        await using (var cmd = new NpgsqlCommand(CommandText, connection)) {
            
            await cmd.ExecuteNonQueryAsync();
        }


    }

    static async void delete_data(string name_tbl) {
        Console.WriteLine("введите id для удаления");
        int id =Convert.ToInt32(Console.ReadLine());
        string commandText = $"DELETE FROM {name_tbl} WHERE {column_n[0]}={id}";
        await using (var cmd = new NpgsqlCommand(commandText, connection)) {
            //cmd.Parameters.AddWithValue("p", id);
            await cmd.ExecuteNonQueryAsync();
        }
    }

    static async void update_data(string name_tbl) {
        Console.WriteLine("введите id для изменения");
        int id = Convert.ToInt32(Console.ReadLine());
        List<string> values = new List<string>();
        string str = "";
        Console.WriteLine("введите значения для:");

        foreach (string i in column_n) {

            if (column_n[0] == i) {
                
                continue;
            }

            Console.Write(i + "  ");
            string val = Console.ReadLine();
            values.Add(val);
            if (int.TryParse(val, out int numericValue)) {
                str +=i + "="+ val + ",";
            }
            else {
                str += i +  "= '" + val + "'" + ",";
            }
        }
        str = str[..^1];
        Console.WriteLine(str);
        string commandText = $"UPDATE {name_tbl} SET {str} WHERE {column_n[0]}={id}";
        await using (var cmd = new NpgsqlCommand(commandText, connection)) {
            //cmd.Parameters.AddWithValue("p", id);
            await cmd.ExecuteNonQueryAsync();
        }
    }

}
