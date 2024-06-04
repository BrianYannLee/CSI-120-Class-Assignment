//Programmer: Brian Lee
//Date: 05/30/2024

//Title: CSI 120 Class Assignment
//-------------------------------------------------------------------------------

using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

//----------------------------------------------------------------------------
namespace CSI_120_Class_Assignment
{
    //--------------------Main Program-----------------------
    internal class Program
    {
        static void Main(string[] args)
        {
            const int numOfBooks = 10;
            bool exitProgram = false;
            Book[] bookList = new Book[numOfBooks];
            do
            {
                exitProgram = MenuSelection.MainMenu(bookList);
            } while (!exitProgram);
        }//end of Main
    }//end of Program (class)
     //--------------------Preloads--------------------------
    #region
    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public Book(string title, string author, int year) //Constructor
        {
            Title = title;
            Author = author;
            Year = year;
        }//end of Constructor
        public Book()// Constructor Default
        {
            Title = "No Title";
            Author = "No Author";
            Year = -1;
        }//end of Constructor Defualt
        public string BookDisplayFortmat()
        {
            return $"{Title} - {Author} -{Year}";
        }
    }//end of Book(class)
    #endregion
    //---------------------Menu/Input Class------------------
    #region
    public class InputChecker
    {
        public static int MenuChecker(int firstChoice, int lastChoice)
        {
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput) || userInput < firstChoice || userInput > lastChoice)
            {
                Console.WriteLine("Inalid Input. Try Again.");
            }
            Console.WriteLine();
            return userInput;
        }//end of MenuChecker(method)
        public static int IntChecker()
        {
            int userInput;
            while (!int.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Input. Try Again");
            }
            return userInput;
        }//end of IntChecker(method)
        public static double DoubleChecker()
        {
            double userInput;
            while (!double.TryParse(Console.ReadLine(), out userInput))
            {
                Console.WriteLine("Invalid Input. Try Again");
            }
            return userInput;
        }//end of DoubleChecker(method)
        public static string StringChecker()
        {
            string? userInput;
            string pattern = @"^[a-zA-Z]+$";

            while ((userInput = Console.ReadLine()) != null && !Regex.IsMatch(userInput, pattern))
            {
                Console.WriteLine("Invalid Input. Try Again");
            }
            return userInput ?? string.Empty;
        }//end of StringChecker(method)

    }//end of InputChecker(class)
    public class MenuSelection
    {
        public static bool MainMenu(Book[] bookList)
        {
            const int firstChoice = 1;
            const int lastChoice = 4;
            int userInput;
            bool exitProgram = false;

            Console.WriteLine("Please Select Method");
            Console.WriteLine("1. Add a new book.");
            Console.WriteLine("2. Display all books.");
            Console.WriteLine("3. Update a book's information");
            Console.WriteLine("4. Exit the program");
            Console.WriteLine();
            userInput = InputChecker.MenuChecker(firstChoice, lastChoice);

            switch (userInput)
            {
                case 1:
                    Console.WriteLine("Adding a new book");
                    Console.WriteLine();
                    MethodList.AddBook(bookList);
                    break;
                case 2:
                    Console.WriteLine("Displaying all books");
                    Console.WriteLine();
                    MethodList.DisplayBook(bookList);
                    break;
                case 3:
                    Console.WriteLine("Updating a book's information");
                    Console.WriteLine();
                    MethodList.UpdateBookInfo(bookList);
                    break;
                case 4:
                    Console.WriteLine("Exiting Program");
                    exitProgram = true;
                    break;
                default:
                    Console.WriteLine("An Error has occured in MainMenu");
                    break;
            }
            return exitProgram;
        }//end of MainMenu(method)

    }//end of MenuSelection(class)
    #endregion
    //---------------------Main Methods---------------------
    #region
    public class MethodList
    {
        public static void AddBook(Book[] bookList)
        {
            string userTitle;
            string userAuthor;
            int userYear;

            Console.WriteLine("Add a New Book");
            Console.WriteLine("--------------");
            Console.WriteLine();

            (userTitle, userAuthor, userYear) = AskBookInfo();

            Book newBook = new Book(userTitle, userAuthor, userYear);

            int index = Array.FindIndex(bookList, b => b == null);
            if (index == -1)
            {
                Console.WriteLine("No more space to add books.");
                return;
            }
            bookList[index] = newBook;
            Console.WriteLine("Book added successfully");
            Console.WriteLine();
        }//end of AddBook(Method)
        public static void DisplayBook(Book[] bookList)
        {
            Console.WriteLine("Display All Books");
            Console.WriteLine("--------------");
            Console.WriteLine();
            
            foreach (Book book in bookList)
            {
                if(book != null)
                {
                    Console.WriteLine(book.BookDisplayFortmat());
                }
            }
            Console.WriteLine();
        }//end of DisplayBook
        public static void UpdateBookInfo(Book[] bookList)
        {
            string userTitle;
            string userAuthor;
            int userYear;

            Console.WriteLine("Update the Book");
            Console.WriteLine("--------------");
            Console.WriteLine();
            Console.Write("Enter the Title: ");
            userTitle = InputChecker.StringChecker();

            int index = Array.FindIndex(bookList, book => book != null && book.Title.Equals(userTitle, StringComparison.OrdinalIgnoreCase));
            if (index == -1)
            {
                Console.WriteLine("Book with the provided title does not exist.");
                return;
            }

            Console.WriteLine("Enter new information for the book:");
            (userTitle, userAuthor, userYear) = AskBookInfo();

            Book newBook = new Book(userTitle, userAuthor, userYear);
            bookList[index] = newBook;
            Console.WriteLine("Book updated successfully");
            Console.WriteLine();
        }
        public static (string, string, int) AskBookInfo()
        {
            string userTitle;
            string userAuthor;
            int userYear;

            Console.Write("Enter the Title: ");
            userTitle = InputChecker.StringChecker();
            Console.Write("Enter the Author: ");
            userAuthor = InputChecker.StringChecker();
            Console.Write("Enter the Year: ");
            userYear = InputChecker.IntChecker();
            return (userTitle, userAuthor, userYear);
        }
    }
    #endregion
    //---------------------Sub Methods----------------------
    #region
    #endregion
}