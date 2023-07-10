namespace Practic_10
{
    internal class Manager : BankWorker
    {
        public override string Name => "Manager";

        public override bool CanWriteLastName => true;

        public override bool CanWriteFirstName => true;

        public override bool CanWritePatronymic => true;

        public override bool CanWritePhone => true;

        public override bool CanWritePassport => true;
        public override bool CanReadPassport => true;

        public override bool canAddNewClient => true;
        public override bool canRemoveClient => true;

    }
}
