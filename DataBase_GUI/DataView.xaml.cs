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
    /// Логика взаимодействия для TableButtons.xaml
    /// </summary>
    public partial class DataView : UserControl
    {
        public DataView()
        {
            InitializeComponent();
            Tables table = new Tables();
            VillageTable villTable = new VillageTable();
            DataBaseInfo.Content = villTable;
            villTable.dataGrid.ItemsSource = table.villages;
            
        }

        private void VillageButton_Click(object sender, RoutedEventArgs e)
        {
            Tables table = new Tables();
            VillageTable villTable = new VillageTable();
            villTable.dataGrid.ItemsSource = table.villages;
            DataBaseInfo.Content = villTable;
        }

        private void HouseButton_Click(object sender, RoutedEventArgs e)
        {
            Tables table = new Tables();
            HouseTable houseTable = new HouseTable();
            houseTable.dataGrid.ItemsSource = table.houses;
            DataBaseInfo.Content = houseTable;
        }

        private void DevButton_Click(object sender, RoutedEventArgs e)
        {
            Tables table = new Tables();
            DeveloperTable devTable = new DeveloperTable();
            devTable.dataGrid.ItemsSource = table.developers;
            DataBaseInfo.Content = devTable;
        }
    }
}
