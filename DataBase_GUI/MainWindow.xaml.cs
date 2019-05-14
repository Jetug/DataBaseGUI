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
using BaseOutPut;

namespace DataBase_GUI
{
 
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();

        }

        

        private void InputBase_Button_Click(object sender, RoutedEventArgs e)
        {
            DataView tableButtons = new DataView();
            Main_Presenter.Content = tableButtons;
        }


        private void OutBase_Button_Click(object sender, RoutedEventArgs e)
        {
            DataTabs tabs = new DataTabs();
            DataView dataView = new DataView();
            Main_Presenter.Content = tabs;
        }

        private void FileSelection_Button_Click(object sender, RoutedEventArgs e)
        {
            Tables table = new Tables();
            Output output = new Output();
            DataTabs tabs = new DataTabs();


            ListView listView = new ListView();
            Main_Presenter.Content = tabs;

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
