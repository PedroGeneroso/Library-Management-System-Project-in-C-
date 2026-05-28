using System;
using System.Linq;

class LibraryManagementSystem
{
    // Variables to store up to 5 book titles
    static string book1 = "";
    static string book2 = "";
    static string book3 = "";
    static string book4 = "";
    static string book5 = "";
    
    // Track the number of books currently in the library
    static int bookCount = 0;

    static void Main()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("  LIBRARY MANAGEMENT SYSTEM");
        Console.WriteLine("========================================\n");

        bool running = true;

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddBook();
                    break;
                case "2":
                    RemoveBook();
                    break;
                case "3":
                    DisplayBooks();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("\nThank you for using the Library Management System. Goodbye!");
                    break;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.\n");
                    break;
            }
        }
    }

    static void DisplayMenu()
    {
        Console.WriteLine("\n--- Main Menu ---");
        Console.WriteLine("1. Add a Book");
        Console.WriteLine("2. Remove a Book");
        Console.WriteLine("3. Display All Books");
        Console.WriteLine("4. Exit");
        Console.Write("\nEnter your choice (1-4): ");
    }

    static void AddBook()
    {
        if (bookCount >= 5)
        {
            Console.WriteLine("\n[ERROR] Library is full! You can only store up to 5 books.\n");
            return;
        }

        Console.Write("\nEnter book title: ");
        string title = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("[ERROR] Book title cannot be empty.\n");
            return;
        }

        // Add book to the next available slot
        switch (bookCount)
        {
            case 0:
                book1 = title;
                break;
            case 1:
                book2 = title;
                break;
            case 2:
                book3 = title;
                break;
            case 3:
                book4 = title;
                break;
            case 4:
                book5 = title;
                break;
        }

        bookCount++;
        Console.WriteLine($"[SUCCESS] Book '{title}' added to the library.\n");
    }

    static void RemoveBook()
    {
        if (bookCount == 0)
        {
            Console.WriteLine("\n[ERROR] No books in the library to remove.\n");
            return;
        }

        Console.Write("\nEnter the title of the book to remove: ");
        string title = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("[ERROR] Title cannot be empty.\n");
            return;
        }

        // Search for the book and remove it
        if (book1 == title)
        {
            RemoveBookAtPosition(1);
        }
        else if (book2 == title)
        {
            RemoveBookAtPosition(2);
        }
        else if (book3 == title)
        {
            RemoveBookAtPosition(3);
        }
        else if (book4 == title)
        {
            RemoveBookAtPosition(4);
        }
        else if (book5 == title)
        {
            RemoveBookAtPosition(5);
        }
        else
        {
            Console.WriteLine($"\n[ERROR] Book '{title}' not found in the library.\n");
        }
    }

    static void RemoveBookAtPosition(int position)
    {
        string removedBook = "";

        // Remove the book at the specified position and shift remaining books
        if (position == 1)
        {
            removedBook = book1;
            book1 = book2;
            book2 = book3;
            book3 = book4;
            book4 = book5;
            book5 = "";
        }
        else if (position == 2)
        {
            removedBook = book2;
            book2 = book3;
            book3 = book4;
            book4 = book5;
            book5 = "";
        }
        else if (position == 3)
        {
            removedBook = book3;
            book3 = book4;
            book4 = book5;
            book5 = "";
        }
        else if (position == 4)
        {
            removedBook = book4;
            book4 = book5;
            book5 = "";
        }
        else if (position == 5)
        {
            removedBook = book5;
            book5 = "";
        }

        bookCount--;
        Console.WriteLine($"[SUCCESS] Book '{removedBook}' removed from the library.\n");
    }

    static void DisplayBooks()
    {
        Console.WriteLine("\n========================================");
        Console.WriteLine("  LIBRARY COLLECTION");
        Console.WriteLine("========================================");

        if (bookCount == 0)
        {
            Console.WriteLine("No books in the library.\n");
            return;
        }

        Console.WriteLine($"Total Books: {bookCount}\n");

        int displayCount = 1;
        if (!string.IsNullOrEmpty(book1)) Console.WriteLine($"{displayCount++}. {book1}");
        if (!string.IsNullOrEmpty(book2)) Console.WriteLine($"{displayCount++}. {book2}");
        if (!string.IsNullOrEmpty(book3)) Console.WriteLine($"{displayCount++}. {book3}");
        if (!string.IsNullOrEmpty(book4)) Console.WriteLine($"{displayCount++}. {book4}");
        if (!string.IsNullOrEmpty(book5)) Console.WriteLine($"{displayCount++}. {book5}");

        Console.WriteLine("========================================\n");
    }
}
