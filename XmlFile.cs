using System;
using System.Collections.ObjectModel;
using System.Xml.Linq;
using static Practic_10.Permission;

namespace Practic_10
{
    static internal class XmlFile
    {
        /// <summary>
        /// Загрузка данных из файла в List
        /// </summary>
        /// <param name="path"></param>
        /// <param name="clients"></param>
        static public ObservableCollection<Client> ReadFromFile(string path)
        {
            ObservableCollection<Client>  clients = new ObservableCollection<Client> ();

            XDocument xdoc = XDocument.Load(path);

            XElement? people = xdoc.Element("Clients");

            foreach (XElement client in people.Elements("Client"))
            {
                clients.Add(new Client(ReturnXmlValue(client)));
            }

            return clients;
        }

        /// <summary>
        /// Сохраниене данных в XML файл
        /// </summary>
        static public void SaveToXml(ObservableCollection<Client> clients, string path)
        {
            XElement myClients = new XElement("Clients");

            foreach (Client client in clients)
            {
                myClients.Add(RecordClient(client));
            }

            myClients.Save(path);
        }

        /// <summary>
        /// Сохранение метаданных изменения полей
        /// </summary>
        /// <param name="bankWorker"></param>
        /// <param name="client"></param>
        /// <param name="active"></param>
        static public void SaveDataChange(BankWorker bankWorker, Client client, string oldValue, string newValue, Active active, string path)
        {
            XDocument xdoc = XDocument.Load(path);

            if (xdoc.Element("Changes") != null)
            {
                XElement myChanges = new XElement("Changes");
                XElement myChange = new XElement("Change");

                XElement myClient = new XElement("Client", $"{client.LastName} {client.FirstName}");
                XElement myBWorker = new XElement("BankWorker", bankWorker.Name);
                XElement myChangeField = new XElement("ChangeField", active.ToString());
                XElement myOldValue = new XElement("OldValue", oldValue);
                XElement myNewValue = new XElement("NewValue", newValue);
                XElement myDate = new XElement("Date", DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss"));

                myChange.Add(myClient, myBWorker, myChangeField, myOldValue, myNewValue, myDate);
                myChanges.Add(myChange);

                myChanges.Add(xdoc .Element("Changes").Elements("Change"));

                myChanges.Save(path);
            }
        }

        /// <summary>
        /// Возвращение массива значнией одного клиента 
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        static private string[] ReturnXmlValue(XElement element)
        {
            string[] elements = new string[]
            {
                element.Element("LastName").Value,
                element.Element("FirstName").Value,
                element.Element("Patronymic").Value,
                element.Element("Phone").Value,
                element.Element("Passport").Value
            };

            return elements;
        }

        /// <summary>
        /// Сохраняет клиента в элементе XML файла
        /// </summary>
        static private XElement RecordClient(Client client)
        {
            XElement myClient = new XElement("Client");

            XElement myLastName = new XElement("LastName", client.LastName);
            XElement myFirstName = new XElement("FirstName", client.FirstName);
            XElement myPatronymic = new XElement("Patronymic", client.Patronymic);
            XElement myPhone = new XElement("Phone", client.Phone);
            XElement myPassport = new XElement("Passport", client.Passport);



            myClient.Add(myLastName, myFirstName, myPatronymic, myPhone, myPassport);

            return myClient;
        }
    }
}
