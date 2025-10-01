using System;

class LibraryBook
{
    private string title;
    private string author;
    private int year;

    public string Title => title;
    public string Author => author;
    public int Year => year;


    public LibraryBook() : this("Unknown Title", "Unknown Author", 0) { }


    public LibraryBook(string title, string author)  : this(title, author, 0) { }

    public LibraryBook(string title, string author,int year)
    {
        this.title = string.IsNullOrWhiteSpace(title) ? "Sans Famille" : title.Trim();
        this.author = string.IsNullOrWhiteSpace(author) ? "Hector Malot" : author.Trim();
        this.year = year <= 0 ? 1878 : year;
    }
}

class Program
{
    static void Main()
    {
        var book1 = new LibraryBook();
        var book2 = new LibraryBook(" ", " ");
        var book3 = new LibraryBook(" ", " ", -1);

        Console.WriteLine($"{book1.Title}, {book1.Author}, {book1.Year}");
        Console.WriteLine($"{book2.Title}, {book2.Author}, {book2.Year}");
        Console.WriteLine($"{book3.Title}, {book3.Author}, {book3.Year}");

    }
}
