using System.Linq.Expressions;
using System.Net;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;

public class Library
{
    private List<Book> books = new List<Book>();
    private readonly string filepath = "books.json";
    private const string Filepath = "books.json";

    public void AddBook()
    {
        Console.WriteLine("Enter Title :");
        string title = Console.ReadLine();

        Console.WriteLine("Enter Author :");
        string author = Console.ReadLine();

        Console.WriteLine("Choose category:");
        foreach (var cat in Enum.GetValues(typeof(BookCategory)))
        {
            Console.WriteLine($"{(int)cat} - {cat}"); // show BookCategory with names and numbers
        }

        int categorychoice = int.Parse(Console.ReadLine());
        BookCategory category = (BookCategory)categorychoice;
        Book book = new Book(title, author, category); //as parameterized constructor
        books.Add(book);
        Console.WriteLine("Book Added Successfully");

        //SaveBookToFile(); // every time a book is added, it’s saved permanently.
        //SaveBookToFileAsync();
    }

    public void DisplayBooks()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No Book Available");
            return;
        }
        foreach (var book in books)
        {
            Console.WriteLine($"BookId :{book.BookId},Title :{book.Title}, Author:{book.Author},Category :{book.Category}");
        }
    }
    public void SearchByTitle()
    {
        Console.WriteLine("Enter the Title");
        string searchTitle = Console.ReadLine();

        Book foundBook = books.Find(book => book.Title.Equals(searchTitle, StringComparison.OrdinalIgnoreCase));
        if (foundBook != null)
        {
            Console.WriteLine($"Found :{foundBook.Title} by {foundBook.Author}, Category is {foundBook.Category}");
        }
        else
        {
            Console.WriteLine("Book not found");
        }

    }

    public void SaveBookToFile()
    {
        try
        {
            string json = JsonSerializer.Serialize(books); // book list convert to json
            File.WriteAllText(filepath, json); // save json to file
            Console.WriteLine("Book saved to file..!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error :{ex.Message}");
        }
    }

    public void LoadBooksFromFile()
    {
        try
        {
            if (File.Exists(filepath))
            {
                string json = File.ReadAllText(filepath);
                books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                Console.WriteLine("Book loaded from file");
            }
            else
            {
                Console.WriteLine("No file found..!!");
                books = new List<Book>();
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error loading..!!{ex.Message}");
        }
    }

    public void SearchByTitleLINQ()
    {
        Console.WriteLine("Enter Title");
        string searchTitle = Console.ReadLine();
        var foundBooks = books.Where(b => b.Title.Contains(searchTitle, StringComparison.OrdinalIgnoreCase)).ToList();

        if (foundBooks.Count > 0)
        {
            Console.WriteLine("Book Found");

            foreach (var book in foundBooks)
            {
                Console.WriteLine($"ID :{book.BookId} , Title: {book.Title} , Author: {book.Author}, Category: {book.Category}");
            }
        }
        else
        {
            Console.WriteLine("No Book Found With that title");
        }
    }

    public void FilterByCategory()
    {
        Console.WriteLine("Choose category to filter :");
        foreach (var cat in Enum.GetValues(typeof(BookCategory)))
        {
            Console.WriteLine($"{(int)cat}-{cat}");
        }
        int choice = int.Parse(Console.ReadLine());
        BookCategory category = (BookCategory)choice;

        var FilterBooks = books.Where(b => b.Category == category).ToList();

        if (FilterBooks.Count == 0)
        {
            Console.WriteLine("No Book Found With that category");
        }

        else
        {
            Console.WriteLine($"Books in {category} category :");
            foreach (var book in FilterBooks)
            {
                Console.WriteLine($"ID ={book.BookId}, Title :{book.Title}, Author :{book.Author}");
            }
        }
    }

    public void SortBooks()
    {
        Console.WriteLine("Sort By 1-Title or 2-Author");
        int choice = int.Parse(Console.ReadLine());

        IEnumerable<Book> SortedBooks;

        if (choice == 1)
        {
            SortedBooks = books.OrderBy(book => book.Title);
        }

        else if (choice == 2)
        {
            SortedBooks = books.OrderBy(book => book.Author);
        }
        else
        {
            Console.WriteLine("Invalid Input");
            return;
        }

        Console.WriteLine("Sorted Books :");
        foreach (var book in SortedBooks)// book mean one object
        {
            Console.WriteLine($"ID:{book.BookId} ,Title:{book.Title},Author:{book.Author},Category:{book.Category}");

        }

    }

    public async Task LoadBooksFromFileAsync()
    {
        try
        {
            if (File.Exists(Filepath))
            {
                string json = await File.ReadAllTextAsync(Filepath);
                books = JsonSerializer.Deserialize<List<Book>>(json) ?? new List<Book>();
                Console.WriteLine("Book loaded from file");
            }
            else
            {
                Console.WriteLine("No file found..!!");
                books = new List<Book>();
            }
        }

        catch (Exception ex)
        {
            Console.WriteLine($"Error loading..!!{ex.Message}");
        }
    }
    public async Task SaveBookToFileAsync()
    {
        try
        {
            await Task.Delay(1); // simulate slow operation
            string json = JsonSerializer.Serialize(books); // book list convert to json
            await File.WriteAllTextAsync(Filepath, json); // save json to file
            Console.WriteLine("Book saved to file..!!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error :{ex.Message}");
        }
        
    }



}

