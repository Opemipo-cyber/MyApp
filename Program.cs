using System;
using System.Collections.Generic;
using System.Linq;

// ===== CLASSES =====

public class Book
{
    public string ISBN { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Category { get; set; }
    public bool IsAvailable { get; set; }
}

public class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
}

//  LIBRARY MANAGEMENT SYSTEM 

public class Library
{
    private List<Book> allBooks = new List<Book>();
    private Dictionary<string, Book> isbnLookup = new Dictionary<string, Book>();
    private Queue<Member> borrowRequests = new Queue<Member>();
    private Stack<string> actionHistory = new Stack<string>();
    private HashSet<string> bookCategories = new HashSet<string>();

    // 1. Add a Book
    public void AddBook(Book book)
    {
        allBooks.Add(book);
        isbnLookup[book.ISBN] = book;
        bookCategories.Add(book.Category);
        actionHistory.Push($"Added book: {book.Title}");
        Console.WriteLine($"Book '{book.Title}' added successfully.");
    }

    // 2. Remove a Book
    public void RemoveBook(string isbn)
    {
        if (isbnLookup.ContainsKey(isbn))
        {
            Book book = isbnLookup[isbn];
            allBooks.Remove(book);
            isbnLookup.Remove(isbn);
            actionHistory.Push($"Removed book: {book.Title}");
            Console.WriteLine($"Book '{book.Title}' removed successfully.");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    // 3. Find a Book
    public void FindBook(string isbn)
    {
        if (isbnLookup.ContainsKey(isbn))
        {
            Book b = isbnLookup[isbn];
            Console.WriteLine($"\n--- Book Found ---");
            Console.WriteLine($"ISBN     : {b.ISBN}");
            Console.WriteLine($"Title    : {b.Title}");
            Console.WriteLine($"Author   : {b.Author}");
            Console.WriteLine($"Category : {b.Category}");
            Console.WriteLine($"Status   : {(b.IsAvailable ? "Available" : "Borrowed")}");
        }
        else
        {
            Console.WriteLine("Book not found.");
        }
    }

    // 4. Request to Borrow a Book
    public void RequestBorrow(int memberId, string memberName)
    {
        Member member = new Member { MemberId = memberId, Name = memberName };
        borrowRequests.Enqueue(member);
        Console.WriteLine($"Borrow request added for '{memberName}'.");
    }

    // 5. Process Next Borrow Request
    public void ProcessNextBorrow()
    {
        if (borrowRequests.Count > 0)
        {
            Member member = borrowRequests.Dequeue();
            Console.WriteLine($"Processing borrow request for: {member.Name} (ID: {member.MemberId})");
        }
        else
        {
            Console.WriteLine("No pending borrow requests.");
        }
    }

    // 6. Undo Last Action
    public void UndoLastAction()
    {
        if (actionHistory.Count > 0)
        {
            string lastAction = actionHistory.Pop();
            Console.WriteLine($"Undo: {lastAction}");
        }
        else
        {
            Console.WriteLine("No actions to undo.");
        }
    }

    // 7. Display All Unique Categories
    public void DisplayCategories()
    {
        Console.WriteLine("\n--- Unique Categories ---");
        foreach (string cat in bookCategories)
            Console.WriteLine($"  - {cat}");
    }

    // 8. Display All Books
    public void DisplayAllBooks()
    {
        Console.WriteLine("\n--- All Books ---");
        if (allBooks.Count == 0) { Console.WriteLine("No books in library."); return; }
        foreach (Book b in allBooks)
            Console.WriteLine($"[{b.ISBN}] {b.Title} by {b.Author} | {b.Category} | {(b.IsAvailable ? "Available" : "Borrowed")}");
    }

    // 9. Display Books Sorted by Title
    public void DisplayBooksSortedByTitle()
    {
        Console.WriteLine("\n--- Books Sorted by Title ---");
        var sorted = allBooks.OrderBy(b => b.Title).ToList();
        foreach (Book b in sorted)
            Console.WriteLine($"{b.Title} by {b.Author}");
    }

    // 10. Library Statistics
    public void DisplayStatistics()
    {
        int total = allBooks.Count;
        int available = allBooks.Count(b => b.IsAvailable);
        int borrowed = total - available;
        int uniqueCats = bookCategories.Count;

        Console.WriteLine("\n--- Library Statistics ---");
        Console.WriteLine($"Total Books        : {total}");
        Console.WriteLine($"Available Books    : {available}");
        Console.WriteLine($"Borrowed Books     : {borrowed}");
        Console.WriteLine($"Unique Categories  : {uniqueCats}");
    }
}

