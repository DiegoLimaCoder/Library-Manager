
using Library;
using Spectre.Console;
using System.ComponentModel;

namespace Main
{
    class Program
    {
        static void Main(string[] args)
        {
        starting:
            var menu = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .AddChoices(new[] {
            "Add a book", "Remove a book", "Remove all books","Search for a book",
            "List all books","Exit the program"
        }));

            Books books = new Books();
           switch (menu)
            {
                case "Add a book":
                    
                    Console.Write("Enter the title of the book: ");
                    books.Title = Console.ReadLine();

                    Console.Write("What is the name of the author? ");
                    books.Author = Console.ReadLine();

                    Console.Write("In which year was the book published? ");
                    books.PublicationYear = int.Parse(Console.ReadLine());

                    Console.Write("How many pages does the book have? ");
                    books.NumPages = int.Parse(Console.ReadLine());
                    Library.Library.AddBook(books);

                    Console.WriteLine("\n");
                    goto starting;
                   
                case "Remove a book":

                    Console.Write("Enter the title of the book to be removed: ");
                    books.Title = Console.ReadLine();

                    Library.Library.RemoveBook(books.Title);
                    Console.WriteLine("\n");
                    goto starting;

                case "Remove all books":
                    Library.Library.RemoveAllBooks();
                    goto starting;

                case "Search for a book":
                    Console.Write("Search by book title: ");
                    books.Title = Console.ReadLine();
                    Library.Library.FindBook(books.Title);
                    Console.WriteLine("\n");
                    goto starting;

                case "List all books" :
                    Library.Library.GetAllBooks();
                    goto starting;

                case "Exit the program":

                    Console.WriteLine("see you later");
                    break;
            }

          





        }
    }
}

