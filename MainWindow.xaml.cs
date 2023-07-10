using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Practic_10
{
    public partial class MainWindow : Window
    {
        private BankWorker bankWorker;

        private string path = "data.xml";

        #region константы
        private const string rightAcsses = "Успешно изменено";
        private const string errorAcsses = "Ошибка доступа";
        private const string errorInput = "Ошибка ввода";
        private const string newError = "Неизвестная ошибка";
        private const string SaveData = "Успешно сохранено";
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            XmlFile.ReadFromFile(path, out ObservableCollection<Client> clients);

            ClientRepository.Clients = clients;

            ClientListBox.ItemsSource = ClientRepository.Clients;

            BankWorkerComboBox.ItemsSource = new BankWorker[] {
                new Consultant(),
                new Manager()
            };
        }

        /// <summary>
        /// Выбор из ListBox клиентов
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientListBox_Selected(object sender, SelectionChangedEventArgs e)
        {
            if (ClientListBox.SelectedIndex >= 0)
                RetrieveData(ClientListBox.SelectedItems[0] as Client);
            else
                ClientFieldsListBox.ItemsSource = null;
        }

        /// <summary>
        /// Изменение выбора аккаунта 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BankWorkerComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bankWorker = (BankWorker)BankWorkerComboBox.SelectedItem;
        }

        /// <summary>
        /// Выбор из ListBox полей информации о клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClientFieldsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ChangeTextBox.Text = ClientFieldsListBox.SelectedValue?.ToString();
        }

        /// <summary>
        /// Нажатие на кнопку изменения выбраной информации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            // применение изменений поля
            ChangeValueTextBox();
        }

        /// <summary>
        /// Нажатие на кнопку сохранения информации в файл
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            XmlFile.SaveToXml(ClientRepository.Clients, path);
            AccessLebel.Text = SaveData;
        }

        /// <summary>
        /// Изменение значений TextBox, в зависимочти от уровня доступа
        /// </summary>
        private void ChangeValueTextBox()
        {
            Client choseClient = ClientListBox.SelectedItems[0] as Client;

            string newValue = ChangeTextBox.Text;

            short answerCode;

            int choseIndex = ClientFieldsListBox.SelectedIndex;

            switch (choseIndex)
            {
                case 0:
                    answerCode = Permission.ChangeClientField(bankWorker, ref choseClient, Permission.Active.LastName, newValue);
                    OutputChoseAnswer(answerCode);
                    break;

                case 1:
                    answerCode = Permission.ChangeClientField(bankWorker, ref choseClient, Permission.Active.FirstName, newValue);
                    OutputChoseAnswer(answerCode);
                    break;

                case 2:
                    answerCode = Permission.ChangeClientField(bankWorker, ref choseClient, Permission.Active.Patronymic, newValue);
                    OutputChoseAnswer(answerCode);
                    break;

                case 3:
                    answerCode = Permission.ChangeClientField(bankWorker, ref choseClient, Permission.Active.Phone, newValue);
                    OutputChoseAnswer(answerCode);
                    break;

                case 4:
                    answerCode = Permission.ChangeClientField(bankWorker, ref choseClient, Permission.Active.Passport, newValue);
                    OutputChoseAnswer(answerCode);
                    break;
            }

            RetrieveData(ClientListBox.SelectedItems[0] as Client);
        }

        /// <summary>
        /// Вывод ответа на запрос изменения
        /// </summary>
        /// <param name="code"></param>
        private void OutputChoseAnswer(short code)
        {
            switch (code)
            {
                case 0:
                    AccessLebel.Text = rightAcsses;
                    break;

                case 1:
                    AccessLebel.Text = errorAcsses;
                    break;

                case 2:
                    AccessLebel.Text = errorInput;
                    break;

                default:
                    AccessLebel.Text = newError;
                    break;
            }
        }

        /// <summary>
        /// Зполняет ListBox с данными переданного клиента
        /// </summary>
        private void RetrieveData(Client? client)
        {
            ObservableCollection<string> clientFields = new ObservableCollection<string>() {
                Permission.ReadClientField(bankWorker, client, Permission.Active.LastName),
                Permission.ReadClientField(bankWorker, client, Permission.Active.FirstName),
                Permission.ReadClientField(bankWorker, client, Permission.Active.Patronymic),
                Permission.ReadClientField(bankWorker, client, Permission.Active.Phone),
                Permission.ReadClientField(bankWorker, client, Permission.Active.Passport)
            };

            ClientFieldsListBox.ItemsSource = clientFields;
        }

        /// <summary>
        /// открывает новую форму добавления клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddClientButton_Click(object sender, RoutedEventArgs e)
        {
            if (bankWorker.canAddNewClient)
            {
                Window wd = new AddClientWindow();
                wd.Show();
            }
            else
            {
                AccessLebel.Text = errorAcsses;
            }
        }

        /// <summary>
        /// Удаляет выбранного клиента
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveClientButton_Click(object sender, RoutedEventArgs e)
        {

            if (bankWorker.canRemoveClient)
            {
                int clientIndex = ClientListBox.SelectedIndex;

                if (clientIndex > 0)
                    ClientListBox.SelectedIndex = clientIndex - 1;
                else
                    ClientListBox.SelectedIndex = -1;

                ClientRepository.RemoveNewClient(clientIndex);
            }
            else
            {
                AccessLebel.Text = errorAcsses;
            }
        }
    }
}
