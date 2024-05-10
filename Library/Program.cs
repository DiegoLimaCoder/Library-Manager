
using Library;
using Spectre.Console;
using System.ComponentModel;
using static System.Reflection.Metadata.BlobBuilder;

namespace Main
{
    class Program
    {
        // Variável de instância para a classe Books
        private static Books books = new Books();
        static void Main(string[] args)
        {
            
            Menu();
        }

        static void Menu()
        {
            var menu = AnsiConsole.Prompt(
               new SelectionPrompt<string>()
               .AddChoices(new[] {
            "Add a book", "Remove a book",
            "Remove all books","Search for a book",
            "List all books","Exit the program"
             }));

            Option(menu);
        }

        static void Option(string menu)
        {
            switch (menu)
            {
                case "Add a book":
                    AddBook(books);
                    break;

                case "Remove a book":
                    RemoveBook(books);
                    break;

                case "Remove all books":
                    RemoveAllBooks();
                    break;

                case "Search for a book":
                    SearchBook(books);
                    break;

                case "List all books":
                    ListAllBooks();
                    break;

                case "Exit the program":
                    ExitProgram();
                    break;
            }

            // Método para adicionar um livro
            static void AddBook(Books books)
            {
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
                Menu();
            }

            // Método para remover um livro
            static void RemoveBook(Books books)
            {
                Console.Write("Enter the title of the book to be removed: ");
                books.Title = Console.ReadLine();

                Library.Library.RemoveBook(books.Title);
                Console.WriteLine("\n");
                Menu();
            }

            // Método para remover todos os livros
            static void RemoveAllBooks()
            {
                Console.Write("Are you sure you want to delete all books? (Y/N) ");
                char awnser = char.Parse(Console.ReadLine().ToLower());

                if (awnser == 'y')
                {
                    Library.Library.RemoveAllBooks();
                    Console.WriteLine("All books were removed successfully");
                    Menu();
                }
                else if(awnser == 'n')
                {
                    Menu();
                }                     
                
            }

            // Método para procurar um livro
            static void SearchBook(Books books)
            {
                Console.Write("Search by book title: ");
                books.Title = Console.ReadLine();
                Library.Library.FindBook(books.Title);
                Console.WriteLine("\n");
                Menu();
            }

            // Método para listar todos os livros
            static void ListAllBooks()
            {
                Library.Library.GetAllBooks();
                Menu();
            }

            // Método para sair do programa
            static void ExitProgram()
            {
                Console.WriteLine("see you later");
            }
        }
    }
}

