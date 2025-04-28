using ConsoleLibrary.Modelos;

var book = new Book("","");
var bookShelf = new BookShelf(null); 
var menu = new Menu(bookShelf);

bookShelf = new BookShelf(menu);

menu.SetupMenu();
