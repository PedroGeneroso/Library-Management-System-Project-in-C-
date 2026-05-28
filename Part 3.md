Problem Statement

The Library Management System works, but it could be optimized. Use Microsoft Copilot to enhance the code's readability, reduce repetition, and make it more efficient. You will:

Remove code duplication

Improve input validation

Address case sensitivity issues for entering and removing books

Starting Code to Input into Copilot
```
class LibraryManager
{
    static void Main()
    {
        string book1 = "";
        string book2 = "";
        string book3 = "";
        string book4 = "";
        string book5 = "";
        while (true)
        {
            Console.WriteLine("Would you like to add or remove a book? (add/remove/exit)");
            string action = Console.ReadLine().ToLower();
            if (action == "add")
            {
                if (!string.IsNullOrEmpty(book1) && !string.IsNullOrEmpty(book2) && !string.IsNullOrEmpty(book3) && !string.IsNullOrEmpty(book4) && !string.IsNullOrEmpty(book5))
                {
                    Console.WriteLine("The library is full. No more books can be added.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to add:");
                    string newBook = Console.ReadLine();
                    if (string.IsNullOrEmpty(book1))
                    {
                        book1 = newBook;
                    }
                    else if (string.IsNullOrEmpty(book2))
                    {
                        book2 = newBook;
                    }
                    else if (string.IsNullOrEmpty(book3))
                    {
                        book3 = newBook;
                    }
                    else if (string.IsNullOrEmpty(book4))
                    {
                        book4 = newBook;
                    }
                    else if (string.IsNullOrEmpty(book5))
                    {
                        book5 = newBook;
                    }
                }
            }
            else if (action == "remove")
            {
                if (string.IsNullOrEmpty(book1) && string.IsNullOrEmpty(book2) && string.IsNullOrEmpty(book3) && string.IsNullOrEmpty(book4) && string.IsNullOrEmpty(book5))
                {
                    Console.WriteLine("The library is empty. No books to remove.");
                }
                else
                {
                    Console.WriteLine("Enter the title of the book to remove:");
                    string removeBook = Console.ReadLine();
                    if (removeBook == book1)
                    {
                        book1 = "";
                    }
                    else if (removeBook == book2)
                    {
                        book2 = "";
                    }
                    else if (removeBook == book3)
                    {
                        book3 = "";
                    }
                    else if (removeBook == book4)
                    {
                        book4 = "";
                    }
                    else if (removeBook == book5)
                    {
                        book5 = "";
                    }
                    else
                    {
                        Console.WriteLine("Book not found.");
                    }
                }
            }
            else if (action == "exit")
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid action. Please type 'add', 'remove', or 'exit'.");
            }
            // Display the list of books
            Console.WriteLine("Available books:");
            if (!string.IsNullOrEmpty(book1)) Console.WriteLine(book1);
            if (!string.IsNullOrEmpty(book2)) Console.WriteLine(book2);
            if (!string.IsNullOrEmpty(book3)) Console.WriteLine(book3);
            if (!string.IsNullOrEmpty(book4)) Console.WriteLine(book4);
            if (!string.IsNullOrEmpty(book5)) Console.WriteLine(book5);
        }
    }
}
```

Steps to Improve Code Quality
Run the Program to Test Functionality

Use the Visual Studio Code console application you created at the start of the course. Remove any existing code in the Program.cs file of your console application and run the code Starting Code to Input into Copilot in that file.

Verify the functionality of the application.

Use Copilot to Suggest Improvements

Use Microsoft Copilot to suggest ways to reduce code repetition and improve readability.

For example, Copilot might suggest using a method to handle repetitive tasks like adding or removing books.

Simplify the Code

Simplify the program using the suggestions provided by Copilot. This could include creating helper methods, improving variable names, and adding comments to clarify the code’s functionality.

Test the Simplified Program

Use the Visual Studio Code console application you created at the start of the course. Remove any existing code in the Program.cs file of your console application and add all the updated code in that file. 

Run the program after refactoring to ensure that it functions the same way, but with cleaner and more efficient code.