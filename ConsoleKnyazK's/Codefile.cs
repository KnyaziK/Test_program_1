using System;
using System.Collections.Generic;

namespace ConsoleKnyaziK
{
    public interface Action_Info
    {
        string Head { get; set; }
        string Note { get; set; }
        DateTime Date { get; set; }
        void ShowAction();
    }
    
    [Serializable]
    abstract class CompleteAction
    {
        public bool Complete { get; protected set; }
        protected virtual bool CheckTimeToEnd() { return false; }
    }

    [Serializable]
    class Action : CompleteAction, Action_Info
    {
        public string Head { get; set; }
        public string Note { get; set; }
        public DateTime Date { get; set; }

        public Action()
        {
            Console.WriteLine("Название заголовка.");
            Head = Console.ReadLine();
            SetDate();
            SetNote();
        }

        public void ShowAction()
        {
            Console.WriteLine("Заголовок: " + Head);
            Console.WriteLine("Дата: " + Date);
            Console.WriteLine("Пометка к записи: " + Note);
            Complete = CheckTimeToEnd();
            Console.WriteLine("Статус дела: {0} ", Complete ? "Непросроченно." : "Просроченно.");
        }
        
        protected override bool CheckTimeToEnd()
        {
            if (DateTime.Now <= Date)
                return true;

            return false;
        }

        public void SetDate()
        {
            Console.WriteLine("Введите дату и время окончания заявки (дд.мм.гггг чч:мм:сс).");
            Console.WriteLine("Пример:  01.01.2001 10:10:25.");
            bool result = false;
            while (!result)
            {
                try
                {
                    Date = DateTime.Parse(Console.ReadLine());
                    result = true;
                }
                catch
                {
                    Console.WriteLine("Ошибка даты введите заново.");
                }
            }
        }

        public void SetNote()
        {
            Note = "";
            Console.WriteLine("Введите описание к заметки. Для выхода из меню введите 'Exit'.");
            while (true)
            {
                string str = Console.ReadLine();
                if (str.ToLower() == "exit")
                {
                    if (Note == "")
                    {
                        Note = "Пусто.";
                    }
                    break;
                }
                Note += str + "\n";
            }
            Note = Note.TrimEnd('\n');
        }
    }

    [Serializable]
    class Action_List
    {
        List<Action> ListAction = new List<Action>();

        public void New()
        {
            ListAction.Add(new Action());
            Console.WriteLine("Запись добавлена.");
        }

        public void Show()
        {
            if (ListAction.Count == 0)
            {
                Console.WriteLine("Записей нет.");
                return;
            }
            for (int i = 0; i < ListAction.Count; i++)
            {
                Console.WriteLine("{" + $"{i + 1}" + "}");
                ListAction[i].ShowAction();
                Console.WriteLine();
            }
        }

        public void Remove()
        {
            Console.WriteLine("введите номер записи которую хотите удалить иначе введите 0.");
            Console.WriteLine();
            Show();
            int num = Int32.Parse(Console.ReadLine());
            Console.WriteLine();

            if (num > 0)
            {
                ListAction.RemoveAt(num - 1);
                Console.WriteLine("Запись удалена!");
            }
        }

        public void Remake()
        {
            Show();
            Console.WriteLine();
            Console.WriteLine("введите номер записи которую хотите изменить иначе введите 0.");
            int num = Int32.Parse(Console.ReadLine());
            Console.WriteLine();
            if (num > 0)
            {
                Console.WriteLine("Введите пункты по порядку без пробелов котрые хотите изменить котрые хотите изменить \n" + "1 - Изменить заголовок \n" + "2 - изменить дату и время\n" + "3 - изменить информацию\n.");
                string point = Console.ReadLine();
                var arr = point.ToCharArray();
                for (int i = 0; i < arr.Length - 1; i++)
                    for (int j = i + 1; j < arr.Length; j++)
                    {
                        if (arr[i] > arr[j])
                        {
                            var ch = arr[i];
                            arr[i] = arr[j];
                            arr[j] = ch;
                        }
                    }
                point = new string(arr);
                switch (point)
                {
                    case "1":
                        Console.WriteLine("Введите заголовок.");
                        ListAction[num - 1].Head = Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Введите новую дату и время.");
                        ListAction[num - 1].SetDate();
                        break;
                    case "3":
                        Console.WriteLine("Введите новое описание задачи.");
                        ListAction[num - 1].SetNote();
                        break;
                    case "12":
                        Console.WriteLine("Введите новый заголовок, поменяйте дату и время.");
                        ListAction[num - 1].Head = Console.ReadLine();
                        ListAction[num - 1].SetDate();
                        break;
                    case "13":
                        Console.WriteLine("Введите новый заголовок и описание задачи.");
                        ListAction[num - 1].Head = Console.ReadLine();
                        ListAction[num - 1].SetNote();
                        break;
                    case "23":
                        Console.WriteLine("Введите новое описание задачи, дата и время.");
                        ListAction[num - 1].SetDate();
                        ListAction[num - 1].SetNote();
                        break;
                    case "123":
                        Console.WriteLine("Введите новый заголовок, дату и время, новое описание задачи.");
                        ListAction[num - 1].Head = Console.ReadLine();
                        ListAction[num - 1].SetDate();
                        ListAction[num - 1].SetNote();
                        break;
                }
            }
        }
    }
}