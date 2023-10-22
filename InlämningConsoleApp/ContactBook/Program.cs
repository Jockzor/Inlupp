using ContactBook.Models;
using ContactBook.Services;

namespace ContactBook
{
    internal class Program
    {
        static void Main(string[] args)
        {
           

            MenuService menuService = new MenuService();
            menuService.MainMenu();
        }
    }
}