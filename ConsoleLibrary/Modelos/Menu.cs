namespace ConsoleLibrary.Modelos;
 class Menu
{
    private BookShelf bookShelf;
    public bool start = true;
    public Menu(BookShelf bookShelf)
    {
        this.bookShelf = bookShelf;
    }
    public void SetupMenu()
    {
        while (start == true) {
            Console.Clear();
            Console.WriteLine(@"
        ░█████╗░░█████╗░███╗░░██╗░██████╗░█████╗░██╗░░░░░███████╗  ██╗░░░░░██╗██████╗░██████╗░░█████╗░██████╗░██╗░░░██╗
        ██╔══██╗██╔══██╗████╗░██║██╔════╝██╔══██╗██║░░░░░██╔════╝  ██║░░░░░██║██╔══██╗██╔══██╗██╔══██╗██╔══██╗╚██╗░██╔╝
        ██║░░╚═╝██║░░██║██╔██╗██║╚█████╗░██║░░██║██║░░░░░█████╗░░  ██║░░░░░██║██████╦╝██████╔╝███████║██████╔╝░╚████╔╝░
        ██║░░██╗██║░░██║██║╚████║░╚═══██╗██║░░██║██║░░░░░██╔══╝░░  ██║░░░░░██║██╔══██╗██╔══██╗██╔══██║██╔══██╗░░╚██╔╝░░
        ╚█████╔╝╚█████╔╝██║░╚███║██████╔╝╚█████╔╝███████╗███████╗  ███████╗██║██████╦╝██║░░██║██║░░██║██║░░██║░░░██║░░░
        ░╚════╝░░╚════╝░╚═╝░░╚══╝╚═════╝░░╚════╝░╚══════╝╚══════╝  ╚══════╝╚═╝╚═════╝░╚═╝░░╚═╝╚═╝░░╚═╝╚═╝░░╚═╝░░░╚═╝░░░");
            Console.WriteLine("\nDigite 1 Para adicionar um Livro a biblioteca");
            Console.WriteLine("Digite 2 para ver os livros em sua biblioteca");
            Console.WriteLine("Digite 3 para avaliar um livro em sua biblioteca");
            Console.WriteLine("Digite 0 para sair");

            string option = Console.ReadLine()!;
            int optionInt = int.Parse(option);

                switch (optionInt)
                {
                    case 1:
                        bookShelf.AddBook();
                        break;
                    case 2:
                        bookShelf.SeeBooks();
                        break;
                    case 3:
                        bookShelf.RatingBook();
                        break;
                 case 0:
                        Console.Clear();
                        Console.WriteLine("Muito obrigado por ter usado meu projeto Console Library :)");
                        Console.WriteLine("\nPressione qualquer tecla para sair.");
                        Console.ReadKey();
                        start = false;
                        break;
                default:
                    Console.WriteLine("Opção Invalida, tente novamente");
                    Thread.Sleep(3000);
                    SetupMenu();
                    break;
            }
        }
       
    }
}