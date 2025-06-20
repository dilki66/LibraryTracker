public class AdminUser : User
{
public AdminUser(string name) : base(name){}
    public override void ViewBooks(Library library)
    {
        library.DisplayBooks();
    }

    public void AddBook(Library library)
    {
        library.AddBook();
    }
}
