
namespace Library
{
    internal class Library
    {
       
        public static List<Books> books = new List<Books>();

        public static void AddBook(Books book)
        {
            books.Add(book);

        }

        public static void RemoveBook(string title)
        {
            Books book = books.Find(l => l.Title == title);

            if(book != null) 
            {
                books.Remove(book);
                Console.WriteLine("Book removed successfully");
            }
            else
            {
                Console.WriteLine("Book not found.");
            }

           
        }

        public static void RemoveAllBooks()
        {
            books.Clear();
        }


        public  static void FindBook(string title)
        {
            if(books.Exists(l => l.Title == title))
            {
                Books book = books.Find(l => l.Title == title);
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Year of publication {book.PublicationYear}, Number of page: {book.NumPages}");
            }
            else
            {
                Console.WriteLine("Book not find");
            }         

        }

        public  static void GetAllBooks()
        {
            if(books.Count < 0) 
            {
                Console.WriteLine("Your bookshelf is empty");
            }else
            {
                foreach (var book in books)
                {
                    Console.WriteLine($"Title: {book.Title}," +
                        $" Author: " +
                        $"{book.Author}, " +
                        $"Year of publication: {book.PublicationYear}," +
                        $" Number of page: {book.NumPages}");
                }
            }

           
        }
    }
}
