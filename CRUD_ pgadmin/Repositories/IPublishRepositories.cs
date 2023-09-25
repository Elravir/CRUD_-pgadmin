using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUD__pgadmin.Models;

namespace CRUD__pgadmin.Repositories
{
    internal interface IPublishRepositories
    {
        IList<Publish> GetAll();
        void DeletePublish(int value);
        void InsertPublish(Publish new_book);
        void UpdatePublish(Publish book);


    }
}