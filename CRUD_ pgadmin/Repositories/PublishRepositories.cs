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
    internal class PublishRepositories : IPublishRepositories
    {
        string connString = null;
        public PublishRepositories(string connectionString) {
            connString = connectionString;
        }

        public IList<Publish> GetAll() {

            using (NpgsqlConnection con = new NpgsqlConnection(connString)) {
                string sql = "select id_publish, name_publish, adress, phone from publish";
                return con.Query<Publish>(sql).ToList();
            }

        }

        public void DeletePublish(int id_publish) {

            using (NpgsqlConnection con = new NpgsqlConnection(connString)) {

                string sql = "delete from publish where id_publish = @id_publish";
                con.Execute(sql, new { id_publish });

            }

        }

        public void InsertPublish(Publish new_publish) {

            using (NpgsqlConnection con = new NpgsqlConnection(connString)) {

                string sql = "insert into publish (id_publish, name_publish, adress, phone) values (@id_publish, @name_publish, @adress, @phone)";
                con.Execute(sql, new_publish);

            }

        }

        public void UpdatePublish(Publish new_publish) {

            using (NpgsqlConnection con = new NpgsqlConnection(connString)) {

                string sql = "update publish set name_publish = @name_publish, adress = @adress, phone = @phone where id_publish = @id_publish";
                con.Execute(sql, new_publish);

            }

        }
    }
}
