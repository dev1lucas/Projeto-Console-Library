using System.Diagnostics;
using System.Linq.Expressions;
//Console Library
/*
 O que precisa?
    1-Criar um menu com opções:
    -Adicionar livro a Biblioteca
    -Ver livros na Biblioteca (se tiver avaliação mostrar)
    -Avaliar Livro da Biblioteca
    -Sair
    2-Onde cada uma das opções terão uma função
 */
string option;
Dictionary<string, int> livrosRegistrados = new Dictionary<string, int>(); // Refatorar Dictionary por um Object gerando uma Public Class Book no codigo 


void MenuOptions()
{
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

    option = Console.ReadLine()!;
    int optionInt = int.Parse(option);

    switch (optionInt)
    {
        case 1:
            RegisterBook();
            break;
        case 2:
            SeeBooks();
            break;
        case 3:
            EvaluateBook();
            break;
        case 0:
            Console.Clear();
            Console.WriteLine("\nMuito obrigado por ter usado meu projeto Console Library :)");
            Console.WriteLine("Prencione qualquer tecla para sair.");
            Console.ReadKey();
            break;
        default:
            Console.WriteLine("Opção Invalida, tente novamente");
            Thread.Sleep(3000);
            MenuOptions();
            break;
    }

}

void RegisterBook() //Registrar livro
{
    Console.Clear();
    TitleDisplay("Registro de Livro");
    Console.Write("Digite o nome do livro que deseja adicionar: ");
    string bookName = Console.ReadLine()!;
    if (livrosRegistrados.ContainsKey(bookName))
    {
        Console.WriteLine($"O livro {bookName} já esta registardo"); //Se já estiver registrado volte ao menu
        Thread.Sleep(2000);
        MenuOptions();
    }
    else {
        
        livrosRegistrados.Add(bookName, new int());
        Console.WriteLine($"O livro {bookName} foi adicionado a biblioteca"); //Adicionando ao dicionario
        Thread.Sleep(3000);
        MenuOptions();
    }
}   

void SeeBooks() //Visualizar livros já adicionados
{
    Console.Clear();
    TitleDisplay("Livros Registrados");
    if (livrosRegistrados.Count == 0) //Se não tiver livros na biblioteca voltar ao menu
    {
        Console.WriteLine("\nNão tem nenhum livro em sua biblioteca :(");
        Console.WriteLine("Precione qualquer tecla para voltar ao Menu...");
        Console.ReadLine();
        MenuOptions();
    }
    else {

        Console.WriteLine("Seus livros registardos na biblioteca são: \n");
        foreach (var book in livrosRegistrados)
        {
            string bookName = book.Key;
            int evalue = book.Value;

            Console.WriteLine($"Livro: {bookName} - Nota: {(evalue == 0 ? "Ainda não avaliado" : evalue.ToString())}"); //Lista os livros e se não tiver nota imprime a mensagem
        }
        Console.WriteLine("\nDigite qualquer tecla para voltar ao menu...");
        Console.ReadKey();
        MenuOptions();

    }
}

void EvaluateBook() //Avaliar algum livro que foi adicionado
{
    Console.Clear();
    TitleDisplay("Avalie o Livro");
    if (livrosRegistrados.Count == 0)
    {
        Console.WriteLine("\nNão tem nenhum livro em sua biblioteca para avaliar :(");
        Console.WriteLine("Precione qualquer tecla para voltar ao menu...");
        Console.ReadLine();
        MenuOptions();
    }
    else
    {
      foreach (string book in livrosRegistrados.Keys)
        {
            Console.WriteLine($"Livro: {book}");
        }
        Console.WriteLine("\nEscolha um dos livros para avaliar");
        string bookName = Console.ReadLine()!;
        if (livrosRegistrados.ContainsKey(bookName))
        {
            Console.WriteLine("Digite a nota desse livro");
            int evaluate = int.Parse(Console.ReadLine()!);
            livrosRegistrados[bookName] = evaluate;
            Console.WriteLine($"\nA nota {evaluate} foi adicionada com sucesso ao livro {bookName}.");
            Thread.Sleep(3000);
            MenuOptions();
        }
        else
        {
            Console.WriteLine($"\nO livro {bookName} não foi encontrado em nosso banco de dados");
            Console.WriteLine("Digite qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            MenuOptions();
        }
    }

}


void TitleDisplay(string title) //Titulo da interface de cada opção
{
    int lengthLetters = title.Length;
    string asterisk = string.Empty.PadLeft(lengthLetters, '*');
    Console.WriteLine(asterisk);
    Console.WriteLine(title);
    Console.WriteLine(asterisk);
}
MenuOptions();