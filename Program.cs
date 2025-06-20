using System.Transactions;

class program
{
static async Task Main(string[] args)
{
     Library library = new Library();
     library.LoadBooksFromFile();// // Load books at the start of the program
     await library.LoadBooksFromFileAsync(); // await the async file loading

     Console.WriteLine("Login As :");
     Console.WriteLine("1.Admin");
     Console.WriteLine("2.Guest");
     int LoginType = int.Parse(Console.ReadLine());

     Console.WriteLine("Enter Your Name :");
     string UserName = Console.ReadLine();

     User currentuser;

      if(LoginType == 1)
     {
          currentuser = new AdminUser(UserName);
     }

     else 
     {
          currentuser = new GuestUser(UserName);
     }

     while(true)
     {
         Console.WriteLine($"--Welcome To Library {currentuser.Name}--");

          if(currentuser is AdminUser)
         {
          Console.WriteLine("1. Add Book");
         }   
         Console.WriteLine("2. View All Books");
         Console.WriteLine("3. Search Book By Title");
         Console.WriteLine("4. Search Book By Title using  LINQ");
         Console.WriteLine("5. Filter Book By Category using  LINQ");
         Console.WriteLine("6. Sort Books");
         Console.WriteLine("7. Save books to file Async");
         Console.WriteLine("8. Exit");
         Console.WriteLine("Choose Option : ");
     
         int option = int.Parse(Console.ReadLine());
          try
           {
           switch(option)
           {
               case 1:

               if(currentuser is AdminUser admin)
               {
               admin.AddBook(library);
               }
               else
               {
               Console.WriteLine("Access Deinied");
               }
               break; 

               case 2:
               currentuser.ViewBooks(library);
               break;

               case 3:
               library.SearchByTitle();
               break;

               case 4 :
               library.SearchByTitleLINQ();
               break;

               case 5 :
               library.FilterByCategory();
               break;

               case 6 :
               library.SortBooks();
               break;

               case 7:
               await library.SaveBookToFileAsync();
               break;

               case 8:
               Console.WriteLine("Exiting!!!");
               return;

               default:
               Console.WriteLine("Invalid ...!!!");
               break;
           }
           }
          catch( Exception ex)
          {
               Console.WriteLine(ex.Message);
          }
     }     
}
}