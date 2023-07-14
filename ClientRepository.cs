using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Documents;
using System.Windows.Input;

namespace Practic_10
{
    public static class ClientRepository
    {
        private static ObservableCollection<Client> clients;

        internal static ObservableCollection<Client> Clients { get => clients; set => clients = value; }

        private static string @path = "data.xml";

        static ClientRepository()
        {
            clients =  XmlFile.ReadFromFile(path);
        }

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
            if(index!=-1)
                clients.RemoveAt(index);
        }

        /// <summary>
        /// Метод сортировки массива клиентов
        /// </summary>
        public static void SortList()
        {
            List<Client> ls = clients.OrderBy(p=>p).Select(p => p).ToList();

            clients.Clear();

            foreach (Client client in ls)
            {
                clients.Add(client);
            }
        }
    }
}
