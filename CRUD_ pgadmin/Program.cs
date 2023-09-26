using CRUD__pgadmin.Repositories;
using Npgsql;
using System.Runtime.InteropServices;
using CRUD__pgadmin.Models;
using CRUD__pgadmin;
using Microsoft.EntityFrameworkCore;

namespace PostgresSqlClient;

internal class Program {

    const string ConnString = "Host=ep-winter-frog-92114323.us-east-2.aws.neon.tech;Username=kek.20;Password=QRIiynfvcx23;Database=neondb";

    //static private NpgsqlConnection connection;
    static void Main(string[] args) {

        //var BookRepo = new BookRepositories(ConnString);
        //var PublishRepo = new PublishRepositories(ConnString);

        NeondbContext db = new();

        while (true){
            
            Console.WriteLine("Выберите действие:\n1. Показать список всех книг\n2. Удалить книгу\n3. Изменить книгу\n4. Добавить книгу");
            Console.WriteLine("5. Показать список всех издательств\n6. Удалить издательство\n7. Добавить издательство\n8. Изменить данные издательства");
            string action = Console.ReadLine();

                switch (action) {
                    
                case "1":
                        
                    foreach(var item in db.Books) {                
                        Console.WriteLine($"{item.IdBook} {item.NameBook} {item.IdPublish} {item.Price}");  
                    } 
                        
                    continue;
                    
                case "2":
                        
                    Console.WriteLine("Введите id книги для удаления");  
                    int value = Convert.ToInt32(Console.ReadLine());
                        
                    foreach(var item in db.Books.Where( i => i.IdBook == value)) {   
                        db.Books.Remove(item);   
                    }
                      
                    db.SaveChanges();
                    continue; 
                case "3":
                    
                    Console.WriteLine("введите id для изменения");
                    value = Convert.ToInt32(Console.ReadLine());
                         
                    foreach (var item in db.Books.Where(i => i.IdBook == value)) {
                            
                        item.NameBook = Console.ReadLine();
                        item.IdPublish = Convert.ToInt32(Console.ReadLine());
                        item.Price = Convert.ToInt32(Console.ReadLine());                 
                            
                        db.Books.Update(item);  
                    }
                    db.SaveChanges();
                    continue;
                    
                case "4":
  
                    Console.WriteLine("введите данные новой книги");
                    Book book= new Book();
                    book.IdBook = Convert.ToInt32(Console.ReadLine());
                    book.NameBook = Console.ReadLine();
                    book.IdPublish= Convert.ToInt32(Console.ReadLine());
                    book.Price = Convert.ToInt32(Console.ReadLine());

                    db.Books.Add(book);
                    db.SaveChanges();
                        continue;
    
                case "5":
                        foreach (var item in db.Publishes) {
                            Console.WriteLine($"{item.IdPublish} {item.NamePublish} {item.Adress} {item.Phone}");
                        }
                        continue;
                    
                case "6":
                         
                    Console.WriteLine("Введите id издательства для удаления");
                        
                    value = Convert.ToInt32(Console.ReadLine());
                        
                    foreach (var item in db.Publishes.Where(i => i.IdPublish == value)) {
                        db.Publishes.Remove(item);
                    }

                    db.SaveChanges();
                    continue;
                    
                case "7":
                        
                    Console.WriteLine("введите параметры нового издательства");
  
                    Publish publ = new Publish();  
                    publ.IdPublish = Convert.ToInt32(Console.ReadLine());
                    publ.NamePublish = Console.ReadLine();
                    publ.Adress = Console.ReadLine();
                    publ.Phone = Convert.ToInt32(Console.ReadLine());

                    db.Publishes.Add(publ);
                    db.SaveChanges();
  
                    continue;

                case "8":
                        
                    Console.WriteLine("введите id для изменения");
                    value = Convert.ToInt32(Console.ReadLine());

                    foreach (var item in db.Publishes.Where(i => i.IdPublish == value)) {

                        item.NamePublish = Console.ReadLine();
                        item.Adress = Console.ReadLine();
                        item.Phone = Convert.ToInt32(Console.ReadLine());

                        db.Publishes.Update(item);
                        
                    }
                    db.SaveChanges();
       
                    continue;
                }
         
        }


    }


}
