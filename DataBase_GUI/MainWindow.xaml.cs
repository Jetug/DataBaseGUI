﻿using System;
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
using DataBaseLogic;
using System.IO;
using System.Media;

namespace DataBase_GUI
{
    class EmptyException : ArgumentException
    {
        public new string Message = "Была введена пустая строка";
    }

    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainPage_Button_Click(object sender, RoutedEventArgs e)
        {
            TextBlock infoBlock = new TextBlock();
            infoBlock.Text = "Test";
            Main_Presenter.Content = infoBlock;
        }

        public void PlaySound(string soundName)
        {
            try
            {
                SoundPlayer player = new SoundPlayer($"C:/Windows/Media/{soundName}");
                player.Play();
            }
            catch (Exception)
            {

            }
        }

        private void OutBase_Button_Click(object sender, RoutedEventArgs e)
        {
            if (File.Exists($"C:/C#/RunDll/XMLfiles/{FileXML.fileName}.xml"))//( (FileXML.villages == null) || (FileXML.houses == null) || (FileXML.developers == null))
            {
                DataTabs tabs = new DataTabs();
                Main_Presenter.Content = tabs;
            }
            else
            {
                PlaySound("Windows Ding.wav");
                MessageBox.Show("Файл не найден, возможно он был удалён", "Ошибка!");
                HomePage home = new HomePage();
            }

        }

        private void FileSelection_Button_Click(object sender, RoutedEventArgs e)
        {
            FileSettings fileSet = new FileSettings();
            Main_Presenter.Content = fileSet;

            //data.dataGrid.ColumnWidth = 100;
            //foreach ( Village sm in table.villages)
            //{
            //    DataGridTextColumn column = new DataGridTextColumn();
            //    column.Header = sm.Name;
            //    column.Width = DataGridLength.Auto;
            //    column.Binding = new Binding("Lay" + i + "Vol");
            //    data.dataGrid.Columns.Add(column); i++;
            //}

        }
    }
}
