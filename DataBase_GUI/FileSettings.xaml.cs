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
using System.IO;

namespace DataBase_GUI
{
    class FileAlreadyExistsExeption: Exception
    {
        public new string Message = "Файл уже существует";
    }

    /// <summary>
    /// Логика взаимодействия для FileSettings.xaml
    /// </summary>
    public partial class FileSettings : UserControl
    {
        public FileSettings()
        {
            InitializeComponent();
            FileXML tables = new FileXML();
            fileView.ItemsSource = tables.Load_FileList();
           
            CurrentName.Content = FileXML.fileName;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            FileXML file = new FileXML();
            try
            {
               
                if (fileNameBox.Text == "")
                    throw new EmptyException();
                if (File.Exists(FileXML.path + fileNameBox.Text + ".xml"))
                {
                    throw new FileAlreadyExistsExeption();
                }
                file.Create_XmlFile(fileNameBox.Text);
                fileView.ItemsSource = file.Load_FileList();
                FileXML.fileName = fileNameBox.Text;
                CurrentName.Content = FileXML.fileName;

                fileNameBox.Clear();
            }
            catch (FileAlreadyExistsExeption exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            catch (EmptyException exc)
            {
                MessageBox.Show(exc.Message, "Ошибка");
            }
            catch (ArgumentException)
            {
                MessageBox.Show("Имя файла содержит недопустимые знаки", "Ошибка");
            }
            //catch(Exception exc)
            //{
            //    MessageBox.Show(exc.Message, "Ошибка");
            //}
            
        }

        private void SelectButton_Click(object sender, RoutedEventArgs e)
        {
            FileXML.fileName = (string)fileView.SelectedItem;
            CurrentName.Content = FileXML.fileName;
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            FileXML file = new FileXML();
            string fileName = (string)fileView.SelectedItem;
            File.Delete($"C:/C#/RunDll/XMLfiles/{fileName}.xml");
            CurrentName.Content = "<не выбран>";
            fileView.ItemsSource = file.Load_FileList();
        }
    }
}
