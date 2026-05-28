using System;

class LibraryManagementSystem
{
    const int MaxBooks = 5;
    const int MaxBorrowedBooks = 3;

    static string[] books = new string[MaxBooks];
    static bool[] isCheckedOut = new bool[MaxBooks];
    static int bookCount = 0;
    static int borrowedCount = 0;

    static void Main()
    {
        Console.WriteLine("========================================");
        Console.WriteLine("  LIBRARY MANAGEMENT SYSTEM");
        Console.WriteLine("========================================\n");

        bool running = true;

        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine() ?? "";

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
                    SearchBook();
                    break;
                case "5":
                    CheckOutBook();
                    break;
                case "6":
                    CheckInBook();
                    break;
                case "7":
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
        Console.WriteLine("4. Search for a Book");
        Console.WriteLine("5. Check Out a Book");
        Console.WriteLine("6. Check In a Book");
        Console.WriteLine("7. Exit");
        Console.Write("\nEnter your choice (1-7): ");
    }

    static void AddBook()
    {
        if (bookCount >= MaxBooks)
        {
            Console.WriteLine("\n[ERROR] Library is full! You can only store up to 5 books.\n");
            return;
        }

        Console.Write("\nEnter book title: ");
        string title = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("[ERROR] Book title cannot be empty.\n");
            return;
        }

        books[bookCount] = title.Trim();
        isCheckedOut[bookCount] = false;
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
        string title = Console.ReadLine() ?? "";

        if (string.IsNullOrWhiteSpace(title))
        {
            Console.WriteLine("[ERROR] Title cannot be empty.\n");
            return;
        }

        int index = FindBookIndex(title);

        if (index < 0)
        {
            Console.WriteLine($"\n[ERROR] Book '{title}' not found in the library.\n");
            return;
        }

        if (isCheckedOut[index])
        {
            borrowedCount = Math.Max(0, borrowedCount - 1);
        }

        RemoveBookAtIndex(index);
    }

    static int FindBookIndex(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return -1;

        title = title.Trim();

        for (int i = 0; i < bookCount; i++)
        {
            if (string.Equals(books[i], title, StringComparison.OrdinalIgnoreCase))
            {
                return i;
            }
        }

        return -1;
    }

    static void RemoveBookAtIndex(int index)
    {
        string removedBook = books[index];

        for (int i = index; i < MaxBooks - 1; i++)
        {
            books[i] = books[i + 1];
            isCheckedOut[i] = isCheckedOut[i + 1];
        }

        books[MaxBooks - 1] = string.Empty;
        isCheckedOut[MaxBooks - 1] = false;
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

        Console.WriteLine($"Total Books: {bookCount}");
        Console.WriteLine($"Borrowed Books: {borrowedCount}/{MaxBorrowedBooks}\n");

        for (int i = 0; i < bookCount; i++)
        {
            string status = isCheckedOut[i] ? "(Checked Out)" : "(Available)";
            Console.WriteLine($"{i + 1}. {books[i]} {status}");
        }

        Console.WriteLine("========================================\n");
    }

    static void SearchBook()
    {
        if (bookCount == 0)
        {
            Console.WriteLine("\n[ERROR] No books in the library to search.\n");
            return;
        }

        Console.Write("\nEnter the title to search for: ");
        string title = Console.ReadLine() ?? "";

        int index = FindBookIndex(title);

        if (index < 0)
        {
            Console.WriteLine($"\n[INFO] '{title}' is not in the collection.\n");
            return;
        }

        if (isCheckedOut[index])
        {
            Console.WriteLine($"\n[INFO] '{books[index]}' is found, but it is currently checked out.\n");
        }
        else
        {
            Console.WriteLine($"\n[INFO] '{books[index]}' is found and available.\n");
        }
    }

    static void CheckOutBook()
    {
        if (bookCount == 0)
        {
            Console.WriteLine("\n[ERROR] No books available to check out.\n");
            return;
        }

        if (borrowedCount >= MaxBorrowedBooks)
        {
            Console.WriteLine($"\n[ERROR] You have reached the limit of {MaxBorrowedBooks} borrowed books. Return a book before checking out another.\n");
            return;
        }

        Console.Write("\nEnter the title of the book to check out: ");
        string title = Console.ReadLine() ?? "";

        int index = FindBookIndex(title);

        if (index < 0)
        {
            Console.WriteLine($"\n[ERROR] Book '{title}' not found in the library.\n");
            return;
        }

        if (isCheckedOut[index])
        {
            Console.WriteLine($"\n[ERROR] '{books[index]}' is already checked out.\n");
            return;
        }

        isCheckedOut[index] = true;
        borrowedCount++;
        Console.WriteLine($"\n[SUCCESS] '{books[index]}' has been checked out. You now have {borrowedCount}/{MaxBorrowedBooks} books borrowed.\n");
    }

    static void CheckInBook()
    {
        if (bookCount == 0)
        {
            Console.WriteLine("\n[ERROR] No books in the library to check in.\n");
            return;
        }

        Console.Write("\nEnter the title of the book to check in: ");
        string title = Console.ReadLine() ?? "";

        int index = FindBookIndex(title);

        if (index < 0)
        {
            Console.WriteLine($"\n[ERROR] Book '{title}' not found in the library.\n");
            return;
        }

        if (!isCheckedOut[index])
        {
            Console.WriteLine($"\n[INFO] '{books[index]}' is not checked out at the moment.\n");
            return;
        }

        isCheckedOut[index] = false;
        borrowedCount = Math.Max(0, borrowedCount - 1);
        Console.WriteLine($"\n[SUCCESS] '{books[index]}' has been checked in.\n");
    }
}
