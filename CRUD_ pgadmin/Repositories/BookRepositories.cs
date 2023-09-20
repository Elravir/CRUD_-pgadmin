using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD__pgadmin.Models;
using System.Windows.Markup;

namespace CRUD__pgadmin.Repositories
{
    internal class BookRepositories: IBookRepositories
    {
        private NpgsqlConnection connection;

        public BookRepositories(string connectionString) {
            connection = new NpgsqlConnection(connectionString);
            connection.Open();
        }

        public IList<Book> GetAll() {

            var result = new List<Book>();
            using(var command = connection.CreateCommand()) {
                
                command.CommandText = "select id_book, name_book, id_publish, price from book";
                using var reader = command.ExecuteReader();
                while (reader.Read()) {

                    result.Add(new Book {
                        Id_book = reader.GetInt32(reader.GetOrdinal("id_book")),
                        Name_book = reader.GetString(reader.GetOrdinal("Name_book")),
                        Id_publish = reader.GetInt32(reader.GetOrdinal("id_publish")),
                        Price = reader.GetInt32(reader.GetOrdinal("price"))
                    });
                }

            }
            return result;
        }

        public void DeleteBook(int value) {
            using (var command = connection.CreateCommand()) {

                command.CommandText = "delete from book where id_book = @id_book";
                command.Parameters.AddWithValue("@id_book", value);
                command.ExecuteNonQuery();


            }
        }

        public void InsertBook(Book new_book) {
            using (var command = connection.CreateCommand()) {
                command.CommandText = "insert into book (id_book, name_book, id_publish, price) values (@id_book, @name_book, @id_publish, @price)";

                command.Parameters.AddWithValue("@id_book", new_book.Id_book);
                command.Parameters.AddWithValue("@name_book", new_book.Name_book);
                command.Parameters.AddWithValue("@id_publish", new_book.Id_publish);
                command.Parameters.AddWithValue("@price", new_book.Price);
                command.ExecuteNonQuery();
            }
        }

        public void UpdateBook(Book new_book) {
           
            using (var command = connection.CreateCommand()) {
                command.CommandText = "update book set name_book = @name_book, id_publish = @id_publish, price = @price where id_book = @id_book";

                command.Parameters.AddWithValue("@id_book", new_book.Id_book);
                command.Parameters.AddWithValue("@name_book", new_book.Name_book);
                command.Parameters.AddWithValue("@id_publish", new_book.Id_publish);
                command.Parameters.AddWithValue("@price", new_book.Price);

                command.ExecuteNonQuery();
            }

        }
    }
}
