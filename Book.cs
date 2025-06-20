public class Book
{
public static int BookCount = 1;
public int BookId{get;}
public string Title{get; set;}
public string Author{get; set;}
public BookCategory Category{get; set;}

//constructor
public Book(string title,string author, BookCategory category)
{
    BookId = BookCount++; // auto increment BookId
    Title = title;
    Author =author;
    Category = category;
}
}
