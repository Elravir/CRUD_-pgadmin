using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD__pgadmin.Models;

namespace CRUD__pgadmin.Repositories
{
    internal interface IBookRepositories
    {
        IList<Book> GetAll();
        void DeleteBook(int value);
        void InsertBook(Book new_book);
        void UpdateBook(Book book);


    }
}
