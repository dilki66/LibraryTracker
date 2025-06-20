public abstract class User: IUser
{
    public string Name {get; set;}
    public User(string name)
    {
        Name = name;
    }
     public  abstract void ViewBooks(Library library);
}