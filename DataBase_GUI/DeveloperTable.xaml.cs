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
    /// Логика взаимодействия для DeveloperTable.xaml
    /// </summary>
    public partial class DeveloperTable : UserControl
    {
        public DeveloperTable()
        {
            InitializeComponent();
            dataGrid.ItemsSource = FileXML.developers;
        }
        private FileXML file = new FileXML();

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Developer dev = new Developer();
            try
            {
                if ((nameTextBox.Text == "") || (addrTextBox.Text == ""))
                {
                    throw new EmptyException();
                }
                dev.name = nameTextBox.Text;
                dev.inc = float.Parse(incTextBox.Text);
                dev.addr = addrTextBox.Text;

                nameTextBox.Clear();
                incTextBox.Clear();
                addrTextBox.Clear();

                FileXML.developers.Add(dev);
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = FileXML.developers;
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
