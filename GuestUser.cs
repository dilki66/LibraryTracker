public class GuestUser : User
{
public GuestUser(string name) : base(name){}

    public override void ViewBooks(Library library)
    {
        library.DisplayBooks();
    }
}