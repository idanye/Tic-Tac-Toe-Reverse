using System;

namespace Logic
{
    public class CellData
    {
        internal CellData(eTeam i_Team)
        {
            Team = i_Team;
        }

        public eTeam Team { get; set; }
    }
}
