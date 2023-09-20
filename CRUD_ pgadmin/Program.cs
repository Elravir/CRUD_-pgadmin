using CRUD__pgadmin.Repositories;
using Npgsql;
using System.Runtime.InteropServices;
using CRUD__pgadmin.Models;

namespace PostgresSqlClient;

internal class Program {

    const string ConnString = "Host=ep-winter-frog-92114323.us-east-2.aws.neon.tech;Username=kek.20;Password=QRIiynfvcx23;Database=neondb";

    static private NpgsqlConnection connection;
    static void Main(string[] args) {

        var BookRepo = new BookRepositories(ConnString);

        string s;
        while (true){
            
            Console.WriteLine("Выберите действие:\n1. Показать список всех книг\n2. Удалить книгу\n3. Добавить книгу\n4. Изменить данные книги");
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
                }

            
        }


    }


}
