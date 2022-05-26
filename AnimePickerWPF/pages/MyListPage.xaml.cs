using Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnimePickerWPF.pages
{
    /// <summary>
    /// Логика взаимодействия для MyListPage.xaml
    /// </summary>
    public partial class MyListPage : Page
    {
        private static List<UserLists> userList { get; set; }
        private static List<Title> TitleList { get; set; }
        private static List<Title> DoneList  { get; set; }
        private static List<Title> ProcessList { get; set; }
        private static List<Title> PlaneList { get; set; }
        private static List<Title> LeaveList { get; set; }

        public MyListPage()
        {
            InitializeComponent();

            TitleList = DataManager.GetTitles();
            userList = DataManager.GetTitlesWithList();

            DoneList = new List<Title>();
            ProcessList = new List<Title>();
            PlaneList = new List<Title>();
            LeaveList = new List<Title>();

            foreach (var i in userList)
            {
                switch (i.listType)
                {
                    case 1:
                        DataManager.AddTitleById(i.idTitle, DoneList, TitleList);
                        break;
                    case 2:
                        DataManager.AddTitleById(i.idTitle, ProcessList, TitleList);
                        break;
                    case 3:
                        DataManager.AddTitleById(i.idTitle, PlaneList, TitleList);
                        break;
                    case 4:
                        DataManager.AddTitleById(i.idTitle, LeaveList, TitleList);
                        break;
                    default:
                        break;
                }
            }

            nowDG.ItemsSource = ProcessList;
            endedDG.ItemsSource = DoneList;
            leaveDG.ItemsSource = LeaveList;
            planingDG.ItemsSource = PlaneList;
        }

        private void scrollView_PreviewMouseWheel(object sender, MouseWheelEventArgs e)
        {
            ScrollViewer scv = (ScrollViewer)sender;
            scv.ScrollToVerticalOffset(scv.VerticalOffset - e.Delta);
            e.Handled = true;
        }
    }
}
