using Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnimePicker
{
    class Program
    {
        private static List<Title> AnimeList = DataManager.GetTitles();

        private static List<Title> miniList = new List<Title>();
        static void Main(string[] args)
        {

            Print("Добро пожаловать" + Environment.NewLine + "Список команд (вводите команду цифрой):");
            StartProgramm();

            for (int i = 0; true; i++)
            {
                string readNum = Console.ReadLine();
                if (IsNumber(readNum))
                {
                    Input(int.Parse(readNum));
                }
            }
        }

        private static void Print(string str)
        {
            Console.WriteLine(str);
        }
        private static bool IsNumber(string str)
        {
            var isNum = int.TryParse(str, out int n);
            if (isNum)
            {
                return isNum;
            }
            else
            {
                Print("Неизвестная команда");
                return isNum;
            } 

        }
        
        private static void Input(int command)
        {
            switch (command){
                case 1:
                    AnimeShow();
                    break;
                case 2:
                    MangaShow();
                    break;
                case 3:
                    MyList();
                    break;
                case 4:
                    StartProgramm();
                    break;
                default:
                    Print("Неизвестная команда");
                    break;
            }
        }
        private static void AnimeShow()
        {
            miniList = new List<Title>();
            foreach (var i in AnimeList)
            {
                if (i.titleType == 1)
                    miniList.Add(i);
            }
            Print(TitleListToString(miniList));

            PickAndShow();
        }
        private static void MangaShow()
        {
            miniList = new List<Title>();
            foreach (var i in AnimeList)
            {
                if (i.titleType == 1)
                    miniList.Add(i);
            }
            Print(TitleListToString(miniList));

            PickAndShow();
        }

        private static void MyList()
        {
            Print(UserListsToString());

            StartProgramm();
        }

        private static string TitleListToString(List<Title> list)
        {
            var resultStr = "";

            for (int i = 1; i<=list.Count; i++)
            {
                resultStr += $"{i} - " + list[i-1].name + Environment.NewLine;
            }

            return resultStr;
        }

        private static void StartProgramm()
        {
            Print("1 - Узнать список аниме");
            Print("2 - Узнать список манги");
            Print("3 - Просмотреть свои тайтлы");
            Print("4 - Вернуться на главную");
            Print(Environment.NewLine);
        }
        private static void PickAndShow()
        {
            var key = Console.ReadLine();

            if (IsNumber(key) && miniList.Count > (int.Parse(key)-1))
            {
                Print(TitleToString(miniList[int.Parse(key)-1]));
                Print(Environment.NewLine);
                Print("1 - Добавить в \"Завершённые\"");
                Print("2 - Добавить в \"В процессе\"");
                Print("3 - Добавить в \"Запланированные\"");
                Print("4 - Добавить в \"Брошено\"");
                Print("5 - Удалить из текущей коллекции");
                Print("6 - На главную");
                Print(Environment.NewLine);

                string readNum = Console.ReadLine();
                if (IsNumber(readNum))
                {
                    ActionOnTitle(miniList[int.Parse(key) - 1], int.Parse(readNum));
                }
                else Print("Неизвестная команда");
            }
            else Print("Неизвестная команда");
        }

        private static string TitleToString(Title title)
        {

            string type = (title.titleType == 1) ? "Манга" : "Аниме";
            string listType = "";
            int idListType = DataManager.GetTitleWithList(title.id);

            foreach (ListType i in DataManager.GetListTypes())
            {
                if (idListType == i.id)
                {
                    listType = i.name;
                    break;
                }
            }

            return $"{title.name} Тип: {type}" + Environment.NewLine +
                title.description + Environment.NewLine + 
                Environment.NewLine + listType;
        }
        private static string TitleUlToString(Title title)
        {
            return $"{title.name}, эпизоды: {title.episodes}";
        }

        private static void ActionOnTitle(Title title, int command)
        {
            switch (command)
            {
                case 1:
                    Print("Успешно");
                    DataManager.AddTitleToList(title, 1);
                    break;
                case 2:
                    Print("Успешно");
                    DataManager.AddTitleToList(title, 2);
                    break;
                case 3:
                    Print("Успешно");
                    DataManager.AddTitleToList(title, 3);
                    break;
                case 4:
                    Print("Успешно");
                    DataManager.AddTitleToList(title, 4);
                    break;
                case 5:
                    Print("Успешно");
                    DataManager.DeleteTitleFromList(title);
                    break;
                case 6:
                    break;
                default:
                    Print("Неизвестная команда");
                    break;
            }
            StartProgramm();
        }
        private static string UserListsToString()
        {
           var stringToReturn = "";
           var doneList = new List<string>();
           var processList = new List<string>();
           var planeList = new List<string>();
           var leaveList = new List<string>();

            foreach (var i in DataManager.GetTitlesWithList())
            {
                switch (i.listType)
                {
                    case 1:
                        doneList.Add(TitleUlToString(DataManager.TitleById(i.idTitle)));
                        break;
                    case 2:
                        processList.Add(TitleUlToString(DataManager.TitleById(i.idTitle)));
                        break;
                    case 3:
                        planeList.Add(TitleUlToString(DataManager.TitleById(i.idTitle)));
                        break;
                    case 4:
                        leaveList.Add(TitleUlToString(DataManager.TitleById(i.idTitle)));
                        break;
                    default:
                        break;
                }
            }
            stringToReturn += "Завершённые:" + Environment.NewLine + ListToString(doneList)
                + "В процессе:" + Environment.NewLine + ListToString(processList) + "Запланировано:"
                 + Environment.NewLine + ListToString(planeList) + "Брошено:" +
                 Environment.NewLine + ListToString(leaveList);
            return stringToReturn;
        }

        private static string ListToString(List<string> list)
        {
            var result = "";

            foreach (var i in list)
            {
                result += i + Environment.NewLine;
            }
            result += Environment.NewLine;
            return result;
        }
    }
}
