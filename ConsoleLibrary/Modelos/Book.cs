using System.Xml;

namespace ConsoleLibrary.Modelos;
class Book
{
    public string Name {  get; set; }
    public string Author { get; set; }
    public int? Rating { get; set; }
    public Book(string name, string author)
    {
        Name = name;
        Author = author;
        Rating = null;
    }
}