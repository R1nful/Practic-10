namespace Practic_10
{
    internal abstract class BankWorker
    {
        public abstract string Name { get; }

        public virtual bool CanWriteLastName { get; } = false;
        public virtual bool CanReadLastName { get; } = true;

        public virtual bool CanWriteFirstName { get; } = false;
        public virtual bool CanReadFirstName { get; } = true;

        public virtual bool CanWritePatronymic { get; } = false;
        public virtual bool CanReadPatronymic { get; } = true;

        public virtual bool CanWritePhone { get; } = false;
        public virtual bool CanReadPhone { get; } = true;

        public virtual bool CanWritePassport { get; } = false;
        public virtual bool CanReadPassport { get; } = false;

        public virtual bool canAddNewClient { get; } = false;
        public virtual bool canRemoveClient { get; } = false;
    }
}
