using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD__pgadmin.Models;
using System.Windows.Markup;
using Dapper;

namespace CRUD__pgadmin.Repositories
{
    internal class BookRepositories: IBookRepositories
    {
        private NpgsqlConnection connection;
        string connString = null;
        public BookRepositories(string connectionString) {
            connString= connectionString;
            //connection = new NpgsqlConnection(connectionString);
            //connection.Open();
        }

        public IList<Book> GetAll() {

            using (NpgsqlConnection con = new NpgsqlConnection(connString)) {
                string sql = "select id_book, name_book, id_publish, price from book";
                return con.Query<Book>(sql).ToList();
            }

        }

        public void DeleteBook(int id_book) {

            using (NpgsqlConnection con = new NpgsqlConnection(connString)) {
                
                string sql = "delete from book where id_book = @id_book";
                con.Execute(sql, new { id_book });

            }

        }

        public void InsertBook(Book new_book) {

            using (NpgsqlConnection con = new NpgsqlConnection(connString)) {

                string sql = "insert into book (id_book, name_book, id_publish, price) values (@id_book, @name_book, @id_publish, @price)";
                con.Execute(sql, new_book);

            }

            //using (var command = connection.CreateCommand()) {

            //    command.Parameters.AddWithValue("@id_book", new_book.Id_book);
            //    command.Parameters.AddWithValue("@name_book", new_book.Name_book);
            //    command.Parameters.AddWithValue("@id_publish", new_book.Id_publish);
            //    command.Parameters.AddWithValue("@price", new_book.Price);
            //    command.ExecuteNonQuery();
            //}
        }

        public void UpdateBook(Book new_book) {

            using (NpgsqlConnection con = new NpgsqlConnection(connString)) {

                string sql = "update book set name_book = @name_book, id_publish = @id_publish, price = @price where id_book = @id_book";
                con.Execute(sql, new_book);

            }

            //using (var command = connection.CreateCommand()) {

            //    command.Parameters.AddWithValue("@id_book", new_book.Id_book);
            //    command.Parameters.AddWithValue("@name_book", new_book.Name_book);
            //    command.Parameters.AddWithValue("@id_publish", new_book.Id_publish);
            //    command.Parameters.AddWithValue("@price", new_book.Price);

            //    command.ExecuteNonQuery();
            //}

        }
    }
}
