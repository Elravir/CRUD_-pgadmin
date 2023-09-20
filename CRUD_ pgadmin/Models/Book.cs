using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD__pgadmin.Models
{
    internal class Book
    {
        public int Id_book { get; set; }
        
        public string Name_book { get; set; }
        
        public int Id_publish { get; set; }
        
        public int Price { get; set; }

    }
}
