using System;

namespace Logic
{
    public class Player
    {
        public string Name { get; internal set; }

        public bool IsHuman { get; internal set; }

        public int GameScore { get; internal set; }

        public int RoundScore { get; internal set; }

        public eTeam Team { get; internal set; }

        public Player(string i_Name, bool i_IsHuman, eTeam i_Team)
        {
            Name = i_Name;
            IsHuman = i_IsHuman;
            Team = i_Team;
            GameScore = 0;
            RoundScore = 0;
        }
    }
}
