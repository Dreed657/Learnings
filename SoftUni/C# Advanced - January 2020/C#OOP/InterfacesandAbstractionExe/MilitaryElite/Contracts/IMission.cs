namespace MilitaryElite.Contracts
{
    using MilitaryElite.Enums;

    public interface IMission
    {
        string CodeName { get; }

        MissionState State { get; }

        void CompleteMission();
    }
}
