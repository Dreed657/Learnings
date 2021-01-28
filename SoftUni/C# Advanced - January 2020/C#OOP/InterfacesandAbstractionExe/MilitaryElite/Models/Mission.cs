namespace MilitaryElite.Models
{
    using System;

    using MilitaryElite.Contracts;
    using MilitaryElite.Enums;

    public class Mission : IMission
    {
        public Mission(string codename, string state)
        {
            this.CodeName = codename;
            this.State = state switch
            {
                "inProgress" => MissionState.inProgress,
                "finished" => MissionState.finished,
                _ => throw new Exception("Invalid Mission State")
            };
        }

        public string CodeName { get; }

        public MissionState State { get; private set; }

        public void CompleteMission()
        {
            if (this.State == MissionState.inProgress)
            {
                this.State = MissionState.finished;
            }
        }

        public override string ToString()
        {
            return $"  Code Name: {this.CodeName} State: {this.State}";
        }
    }
}
