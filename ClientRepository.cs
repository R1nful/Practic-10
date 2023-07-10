using System.Collections.ObjectModel;

namespace Practic_10
{
    public static class ClientRepository
    {
        private static ObservableCollection<Client> clients;

        internal static ObservableCollection<Client> Clients { get => clients; set => clients = value; }

        /// <summary>
        /// Метод длбавления нового клиента в список клиентов
        /// </summary>
        /// <param name="arr"></param>
        public static void AddNewClient(string[] arr)
        {
            clients.Add(new Client(arr));
        }

        /// <summary>
        /// Метод удаления клиента из списка
        /// </summary>
        /// <param name="index"></param>
        public static void RemoveNewClient(int index)
        {
            clients.RemoveAt(index);
        }
    }
}
