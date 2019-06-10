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
using DataBaseLogic;

namespace DataBase_GUI
{
    /// <summary>
    /// Логика взаимодействия для HouseTable.xaml
    /// </summary>
    public partial class HouseTable : UserControl
    {
        public HouseTable()
        {
            InitializeComponent();
            dataGrid.ItemsSource = FileXML.houses;
        }

        private FileXML file = new FileXML();

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            House house = new House();
            try
            {
                if ((nameTextBox.Text == "") || (typeTextBox.Text == ""))
                {
                    throw new EmptyException();
                }
                house.name = nameTextBox.Text;
                house.num = ushort.Parse(numTextBox.Text);
                house.area = float.Parse(areaTextBox.Text);
                house.floor = byte.Parse(floorTextBox.Text);
                house.type = typeTextBox.Text;

                nameTextBox.Clear();
                numTextBox.Clear();
                areaTextBox.Clear();
                floorTextBox.Clear();
                typeTextBox.Clear();

                FileXML.houses.Add(house);
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = FileXML.houses;
            }
            catch (OverflowException)
            {
                MessageBox.Show("Было введено слишком малое или слишком большое значение", "Ошибка!");
            }
            catch (FormatException exc)
            {
                MessageBox.Show(exc.Message, "Ошибка!");
            }
            catch (EmptyException exc)
            {
                MessageBox.Show(exc.Message, "Ошибка!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Непредвидимая ошибка!");
            }
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            file.SaveAll();
            this.Cursor = Cursors.Arrow;
        }
    }
}
