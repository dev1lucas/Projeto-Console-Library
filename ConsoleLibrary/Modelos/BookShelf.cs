namespace ConsoleLibrary.Modelos;
class BookShelf
{
    private List<Book> booksList = new List<Book>();
    public Menu Menu { get; }

    public BookShelf(Menu menu)
    {
        this.Menu = menu;
    }
    public void AddBook()
    {
        Console.Clear();
        Console.WriteLine("Digite o Nome do Livro que deseja adicionar a biblioteca:");
        string bookName = Console.ReadLine()!;
        if (booksList.Any(b => b.Name.Equals(bookName)))
        {
            Console.WriteLine($"O livro {bookName} já esta registardo");
            Thread.Sleep(3000);
            
        }
        else
        {
            Console.WriteLine($"\nDigite o nome do autor do livro {bookName}");
            string authorName = Console.ReadLine()!;
            booksList.Add(new Book(bookName, authorName));
            Console.WriteLine($"O livro {bookName} foi adicionado a biblioteca"); //Adicionando a lista
            Thread.Sleep(3000);
            
        }
    }
    public void SeeBooks()
    {
        Console.Clear();
        if (!booksList.Any())
        {
            Console.WriteLine("Nenhum livro registrado.");
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();

        }
        else
        {
            foreach (var book in booksList)
            {
                string notaTexto = book.Rating.HasValue ? book.Rating.ToString() : "Ainda não avaliado";
                Console.WriteLine($"Livro: {book.Name}, Autor: {book.Author}, Nota: {notaTexto}");
            }
        }
        Console.WriteLine("\nPressione qualquer tecla para voltar...");
        Console.ReadKey();
    }
    public void RatingBook()
    {
        Console.Clear();
        Console.WriteLine("Digite o Nome do livro que deseja avaliar");
        string bookName = Console.ReadLine()!;
        var book = booksList.FirstOrDefault(b => b.Name.Equals(bookName, StringComparison.OrdinalIgnoreCase));
        if (book != null)
        {
            Console.WriteLine($"Digite a nota para o livro {bookName}");
            int rating = int.Parse(Console.ReadLine()!);
            book.Rating = rating;
            Console.WriteLine($"A nota {rating} foi registrada para o livro {bookName}");
            Thread.Sleep(3000);
        }
        else
        {
            Console.WriteLine("Livro não encontrado.");
            Console.WriteLine("\nPressione qualquer tecla para voltar...");
            Console.ReadKey();
        }
    }
}