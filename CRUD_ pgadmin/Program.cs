using CRUD__pgadmin.Repositories;
using Npgsql;
using System.Runtime.InteropServices;
using CRUD__pgadmin.Models;

namespace PostgresSqlClient;

internal class Program {

    const string ConnString = "Host=ep-winter-frog-92114323.us-east-2.aws.neon.tech;Username=kek.20;Password=QRIiynfvcx23;Database=neondb";

    //static private NpgsqlConnection connection;
    static void Main(string[] args) {

        var BookRepo = new BookRepositories(ConnString);
        var PublishRepo = new PublishRepositories(ConnString);

        while (true){
            
            Console.WriteLine("Выберите действие:\n1. Показать список всех книг\n2. Удалить книгу\n3. Добавить книгу\n4. Изменить данные книги");
            Console.WriteLine("5. Показать список всех издательств\n6. Удалить издательство\n7. Добавить издательство\n8. Изменить данные издательства");
            string action = Console.ReadLine();

                switch (action) {
                    case "1":
                        foreach(var item in BookRepo.GetAll()) {
                        Console.WriteLine($"{item.Id_book} {item.Name_book} {item.Id_publish} {item.Price}");
                        } 
                        continue;
                    case "2":
                        Console.WriteLine("Введите id книги для удаления");
                        int value = Convert.ToInt32(Console.ReadLine());
                        BookRepo.DeleteBook(value);
                        continue;
                    case "3":
                        Console.WriteLine("введите параметры новой книги");

                        Book boo = new Book();
                        boo.Id_book = Convert.ToInt32(Console.ReadLine());
                        boo.Name_book = Console.ReadLine();
                        boo.Id_publish = Convert.ToInt32(Console.ReadLine());
                        boo.Price = Convert.ToInt32(Console.ReadLine());

                        BookRepo.InsertBook(boo);
                        continue;
                    case "4":
                        Console.WriteLine("введите id для изменения");
                        Book book= new Book();
                        book.Id_book = Convert.ToInt32(Console.ReadLine());
                        book.Name_book = Console.ReadLine();
                        book.Id_publish = Convert.ToInt32(Console.ReadLine());
                        book.Price = Convert.ToInt32(Console.ReadLine());
                        BookRepo.UpdateBook(book);
                        continue;
                    case "5":
                        foreach (var item in PublishRepo.GetAll()) {
                            Console.WriteLine($"{item.Id_publish} {item.Name_publish} {item.Adress} {item.Phone}");
                        }
                        continue;
                    case "6":
                        Console.WriteLine("Введите id издательства для удаления");
                        value = Convert.ToInt32(Console.ReadLine());
                        PublishRepo.DeletePublish(value);
                        continue;
                    case "7":
                        Console.WriteLine("введите параметры нового издательства");

                        Publish publ = new Publish();
                        publ.Id_publish = Convert.ToInt32(Console.ReadLine());
                        publ.Name_publish = Console.ReadLine();
                        publ.Adress = Console.ReadLine();
                        publ.Phone = Convert.ToInt32(Console.ReadLine());

                        PublishRepo.InsertPublish(publ);
                        continue;
                    case "8":
                        Console.WriteLine("введите id для изменения");
                        Publish publish = new Publish();
                        publish.Id_publish = Convert.ToInt32(Console.ReadLine());
                        publish.Name_publish = Console.ReadLine();
                        publish.Adress = Console.ReadLine();
                        publish.Phone = Convert.ToInt32(Console.ReadLine());
                        PublishRepo.UpdatePublish(publish);
                        continue;
            }
         
        }


    }


}
