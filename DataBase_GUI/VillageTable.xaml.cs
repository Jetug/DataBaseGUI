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
    class EmptyException: ArgumentException
    {
        public new string Message = "Была введена пустая строка";
    }

    /// <summary>
    /// Логика взаимодействия для DataTable.xaml
    /// </summary>
    public partial class VillageTable : UserControl
    {
        public VillageTable()
        {
            InitializeComponent();
            //dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = table.villages;
        }

        private Tables table = new Tables();
        private bool needToSave = true;

        //private List<Village> villages = new List<Village>();

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Village vill = new Village("","",0,0);
            try
            {
                if ((nameTextBox.Text == "") || (devTextBox.Text == ""))
                {
                    throw new EmptyException();
                }
                vill.name = nameTextBox.Text;
                vill.dev = devTextBox.Text;
                vill.area = float.Parse(areaTextBox.Text);
                vill.people = uint.Parse(peopleTextBox.Text);
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
            table.villages.Add(vill);
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = table.villages;

            nameTextBox.Clear();
            devTextBox.Clear();
            areaTextBox.Clear();
            peopleTextBox.Clear();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            this.Cursor = Cursors.Wait;
            needToSave = false;
            table.SaveAll();
            this.Cursor = Cursors.Arrow;
        }
    }
}
