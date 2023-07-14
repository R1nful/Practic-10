using System.Windows;

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

            if (IsComplete(arr))
            {
                ClientRepository.AddNewClient(arr);
                this.Close();
            }
            else
                ErrorLable.Text = "Ошибка. Не все поля заполнены";
        }

        private bool IsComplete(string[] arr)
        {
            foreach (string s in arr)
            {
                if(s.Trim() == "")
                    return false;
            }

            return true;
        }
    }
}
