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
using System.Media;
using System.Threading;
using DataBaseLogic;

namespace DataBase_GUI
{
    

    /// <summary>
    /// Логика взаимодействия для DataTable.xaml
    /// </summary>
    public partial class VillageTable : UserControl
    {
        public VillageTable()
        {
            InitializeComponent();
            dataGrid.ItemsSource = FileXML.villages;
            devComboBox.ItemsSource = file.GetDevNames();
        }

        private FileXML file = new FileXML();
        private bool needToSave = true;

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            Village vill = new Village();
            try
            {
                if ((nameTextBox.Text == "") || (devComboBox.Text == ""))
                {
                    throw new EmptyException();
                }
                vill.name = nameTextBox.Text;
                vill.dev = devComboBox.Text;
                vill.area = float.Parse(areaTextBox.Text);
                vill.people = uint.Parse(peopleTextBox.Text);

                nameTextBox.Clear();
                devComboBox.SelectedIndex = -1;
                areaTextBox.Clear();
                peopleTextBox.Clear();

                FileXML.villages.Add(vill);
                dataGrid.ItemsSource = null;
                dataGrid.ItemsSource = FileXML.villages;
            }
            catch (OverflowException)
            {
                PlaySound("Windows Ding.wav");
                MessageBox.Show("Было введено слишком малое или слишком большое значение", "Ошибка!");
            }
            catch (FormatException exc)
            {
                PlaySound("Windows Ding.wav");
                MessageBox.Show(exc.Message, "Ошибка!");
            }
            catch (EmptyException exc)
            {
                PlaySound("Windows Ding.wav");
                MessageBox.Show(exc.Message, "Ошибка!");
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "Непредвидимая ошибка!");
            }
        }

        //private void SetColumns()
        //{
        //    dataGrid.Columns[0].Header = "Посёлок";
        //    dataGrid.Columns[1].Header = "Девелопер";
        //    dataGrid.Columns[2].Header = "Площадь";
        //    dataGrid.Columns[3].Header = "Население";
        //}

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            Cursor = Cursors.Wait;
            needToSave = false;
            file.SaveAll();
            Cursor = Cursors.Arrow;
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Window searchBox = new Window();
            Search_InVillages search = new Search_InVillages();
            searchBox.Content = search;
            searchBox.Show();
        }

        public void PlaySound(string soundName)
        {
            try
            {
                SoundPlayer player = new SoundPlayer($"C:/Windows/Media/{soundName}");
                player.Play();
            }
            catch
            {

            }
        }
    }
}
