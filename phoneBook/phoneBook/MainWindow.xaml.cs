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

namespace phoneBook
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

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            if (textBox1.Text != "")
            {
                string text = textBox1.Text;
                var peoples = GetPhonebooks();
                foreach (var people in peoples)
                {
                    if(people.Name.IndexOf(text, StringComparison.OrdinalIgnoreCase) != -1)
                    {
                        listBox1.Items.Add(people.Name);
                        Console.WriteLine("ФИО: {0}     Кабинет:{1}     Телефон:{2}", people.Name, people.Cabinet, people.Number);
                    }
                    
                }
            }

            listBox1.SelectionChanged += ListBox1_SelectionChanged;
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selectedName = listBox1.SelectedItem.ToString();
            GetParameters(selectedName);
        }

        private static List<Phonebook> GetPhonebooks()
        {
            var phonebook = new phonebookEntities();
            var peoples = phonebook.Phonebook.ToList();
            return peoples;

        }

        private void GetParameters(string selectedName)
        {
            var peoples = GetPhonebooks();
            foreach(var people in peoples)
            {
                if(selectedName == people.Name)
                {
                    textName.Text = people.Name;
                    textDepartament.Text = people.Departament;
                    textUnit.Text = people.Unit;
                    textPosition.Text = people.Position;
                    textNumber.Text = people.Number;
                    textBuildingCabinet.Text = "Корпус № "+ people.Building + " , кабинет " + people.Cabinet;
                }
            }
        }
    }
}
