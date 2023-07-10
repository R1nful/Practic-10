using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Shapes;

namespace Practic_10
{
    /// <summary>
    /// Логика взаимодействия для AddClientWindow.xaml
    /// </summary>
    public partial class AddClientWindow : Window
    {
        public AddClientWindow()
        {
            InitializeComponent();
        }

        private void SaveNewClient_Click(object sender, RoutedEventArgs e)
        {
            string[] arr = new string[] { 
                LastNameTextBox.Text,
                FirstNameTextBox.Text,
                PatronymicTextBox.Text,
                PhoneTextBox.Text,
                PassportTextBox.Text
            };

            ClientRepository.AddNewClient(arr);

            this.Close();
        }

        
    }
}
