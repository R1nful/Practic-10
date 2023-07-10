namespace Practic_10
{
    internal class Consultant : BankWorker
    {
        public override string Name => "Consultant";

        public override bool CanWritePhone => true;
    }
}
