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
        static void Main(string[] args)
        {
            Print("Добро пожаловать" + Environment.NewLine + "Список команд (вводите команду цифрой):");
            Print("1 - Узнать список аниме");
            Print("2 - Узнать список манги");
            Print("3 - Просмотреть свои тайтлы");
            Print("4 - Вернуться на главную");
            Print(Environment.NewLine);

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
                    break;
                default:
                    Print("Неизвестная команда");
                    break;
            }
        }
        private static void AnimeShow()
        {
            Print(TitleListToString(AnimeList, 2));
        }
        private static void MangaShow()
        {
            Print(TitleListToString(AnimeList, 1));
        }

        private static void MyList()
        {

        }

        private static string TitleListToString(List<Title> list, int titleType)
        {
            var resultStr = "";

            foreach (var i in list)
            {
                if (i.titleType == titleType)
                    resultStr += i.name + Environment.NewLine;
            }

            return resultStr;
        }
    }
}
