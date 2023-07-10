using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Practic_10
{
    internal class Client : INotifyPropertyChanged
    {
        private string lastName; 
        private string firstName; 
        private string patronymic; 
        private string phone; 
        private string passport; 

        public string LastName 
        {
            get 
            { 
                return lastName;
            }

            set
            {
                lastName = value;
                OnPropertyChanged("LastName");
            }
        }
        public string FirstName 
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
                OnPropertyChanged("FirstName");
            }
        }
        public string Patronymic 
        {
            get
            {
                return patronymic;
            }

            set
            {
                patronymic = value;
                OnPropertyChanged("Patronymic");
            }
        }
        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
                OnPropertyChanged("Phone");
            }
        }
        public string Passport 
        {
            get
            {
                return passport;
            }

            set
            {
                passport = value;
                OnPropertyChanged("Passport");
            }
        }

        public Client(string lastName, string firstName, string patronymic, string phone, string passport)
        {
            this.LastName = lastName;
            this.FirstName = firstName;
            this.Patronymic = patronymic;
            this.Phone = phone;
            this.Passport = passport;
        }

        public Client(string[] arr)
        {
            this.LastName = arr[0];
            this.FirstName = arr[1];
            this.Patronymic = arr[2];
            this.Phone = arr[3];
            this.Passport = arr[4];
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
