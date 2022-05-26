﻿using AnimePickerWPF.pages;
using Core;
using System;
using System.Collections.Generic;
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

namespace AnimePickerWPF
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            userNameTxt.Text = DataManager.GetUsers()[0].name;
            frame_choose.NavigationService.Navigate(new ChoosePage());
        }

      

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            frame_choose.NavigationService.Navigate(new ChoosePage());
        }

        private void userSP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            frame_choose.NavigationService.Navigate(new MyListPage());
        }
    }
}
