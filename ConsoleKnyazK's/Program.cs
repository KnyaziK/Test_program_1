using System;

namespace ConsoleKnyaziK
{
    class program
    {
        static void Main()
        {
            Action_List list = new Action_List();
            while (true)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1 - Создать новую запись.");
                Console.WriteLine("2 - Показать все записи.");
                Console.WriteLine("3 - Удалить запись.");
                Console.WriteLine("4 - Изменить запись.");
                Console.WriteLine("5 - Exit.");
                Console.WriteLine("Команда =>");
                var i = Console.ReadLine();
                Console.Clear();
                switch (i)
                {
                    case "1":
                        list.New();
                        break;
                    case "2":
                        list.Show();
                        break;
                    case "3":
                        list.Remove();
                        break;
                    case "4":
                        list.Remake();
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Введеная команда не опознана, введите команду из списка.");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }

        }
    }
}
