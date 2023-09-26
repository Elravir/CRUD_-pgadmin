using System;
using System.Collections.Generic;

namespace CRUD__pgadmin.Models;

public partial class Book
{
    public int IdBook { get; set; }

    public string? NameBook { get; set; }

    public int? IdPublish { get; set; }

    public int? Price { get; set; }

    public virtual Publish? IdPublishNavigation { get; set; }
}
