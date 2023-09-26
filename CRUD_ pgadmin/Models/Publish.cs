using System;
using System.Collections.Generic;

namespace CRUD__pgadmin.Models;

public partial class Publish
{
    public int IdPublish { get; set; }

    public string? NamePublish { get; set; }

    public string? Adress { get; set; }

    public int? Phone { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
