using ConsoleLibrary.Modelos;

var book = new Book("","");
var bookShelf = new BookShelf(null);  // ainda não temos o menu
var menu = new Menu(bookShelf);

// Agora corrigimos:
bookShelf = new BookShelf(menu);

// E chamamos o menu:
menu.SetupMenu();
