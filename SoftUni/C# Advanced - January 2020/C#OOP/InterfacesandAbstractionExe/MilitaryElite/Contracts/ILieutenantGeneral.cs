namespace MilitaryElite.Contracts
{
    using System.Collections.Generic;

    interface ILieutenantGeneral : IPrivate
    {
        IReadOnlyCollection<IPrivate> Privates { get; }
    }
}
