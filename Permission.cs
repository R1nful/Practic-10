namespace Practic_10
{
    static internal class Permission
    {
        private const short rightChange = 0;
        private const short errorAccess = 1;
        private const short errorInput = 2;
        private const short newError = 3;

        private static string noAccess = new string('*', 10);

        private static short accessAnswer;

        private static string path = "Change.xml";

        /// <summary>
        /// Список перечеслений полей
        /// </summary>
        public enum Active
        {
            LastName,
            FirstName,
            Patronymic,
            Phone,
            Passport
        }

        /// <summary>
        /// Изменение поля клиента
        /// </summary>
        /// <param name="bankWorker"></param>
        /// <param name="client"></param>
        /// <param name="active"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        static public short ChangeClientField(BankWorker bankWorker, ref Client client, Active active, string newValue)
        {
            string oldValue = "";

            switch (active)
            {
                case Active.LastName:
                    accessAnswer = CheckAccess(bankWorker.CanWriteLastName, newValue);
                    if (accessAnswer == rightChange)
                    {
                        oldValue = client.LastName;
                        client.LastName = newValue;
                    }
                    break;

                case Active.FirstName:
                    accessAnswer = CheckAccess(bankWorker.CanWriteFirstName, newValue);
                    if (accessAnswer == rightChange)
                    {
                        oldValue = client.FirstName;
                        client.FirstName = newValue;
                    }
                    break;

                case Active.Patronymic:
                    accessAnswer = CheckAccess(bankWorker.CanWritePatronymic, newValue);
                    if (accessAnswer == rightChange)
                    {
                        oldValue = client.Patronymic;
                        client.Patronymic = newValue;
                    }
                    break;

                case Active.Phone:
                    accessAnswer = CheckAccess(bankWorker.CanWritePhone, newValue);
                    if (accessAnswer == rightChange)
                    {
                        oldValue = client.Phone;
                        client.Phone = newValue;
                    }
                    break;

                case Active.Passport:
                    accessAnswer = CheckAccess(bankWorker.CanWritePassport, newValue);
                    if (accessAnswer == rightChange)
                    {
                        oldValue = client.Passport;
                        client.Passport = newValue;
                    }
                    break;

                default:
                    accessAnswer = newError;
                    break;
            }

            if (accessAnswer == rightChange)
                XmlFile.SaveDataChange(bankWorker, client, oldValue, newValue, active, path);

            return accessAnswer;
        }

        /// <summary>
        /// Получение поля клиента
        /// </summary>
        /// <param name="bankWorker"></param>
        /// <param name="client"></param>
        /// <param name="active"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static public string ReadClientField(BankWorker bankWorker, Client client, Active active)
        {
            string value = noAccess;

            switch (active)
            {
                case Active.LastName:
                    accessAnswer = CheckAccess(bankWorker.CanReadLastName, client.LastName);
                    if (accessAnswer == rightChange)
                        value = client.LastName;
                    break;

                case Active.FirstName:
                    accessAnswer = CheckAccess(bankWorker.CanReadFirstName, client.FirstName);
                    if (accessAnswer == rightChange)
                        value = client.FirstName;
                    break;

                case Active.Patronymic:
                    accessAnswer = CheckAccess(bankWorker.CanReadPatronymic, client.Patronymic);
                    if (accessAnswer == rightChange)
                        value = client.Patronymic;
                    break;

                case Active.Phone:
                    accessAnswer = CheckAccess(bankWorker.CanReadPhone, client.Phone);
                    if (accessAnswer == rightChange)
                        value = client.Phone;
                    break;

                case Active.Passport:
                    accessAnswer = CheckAccess(bankWorker.CanReadPassport, client.Passport);
                    if (accessAnswer == rightChange)
                        value = client.Passport;
                    break;

                default:
                    accessAnswer = newError;
                    break;
            }

            if (accessAnswer == errorInput)
                value = "";

            return value;
        }

        /// <summary>
        /// Проверка уровня доступа, возвращяет код ответа
        /// </summary>
        /// <param name="access"></param>
        /// <param name="newValue"></param>
        /// <returns></returns>
        static private short CheckAccess(bool access, string? newValue)
        {
            if (newValue?.Trim() == "")
                return errorInput;


            if (access)
            {
                return rightChange;
            }
            else
                return errorAccess;
        }


    }
}
