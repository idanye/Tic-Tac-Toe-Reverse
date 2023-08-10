using System;
using System.Collections.Generic;

namespace Logic
{
    public class GameManager
    {
        private Board m_Board;
        private eGameMode m_GameMode;

        public eTeam CurrentTurnTeam { get; private set; }

        public Player XPlayer { get; private set; }

        public Player OPlayer { get; private set; }

        public Player GameWinner { get; private set; }

        public int BoardSize { get => m_Board.Size; }

        public CellData[][] BoardSnapshot { get => m_Board.Snapshot; }

        public bool IsCurrentTurnHuman { get { return CurrentTurnTeam == XPlayer.Team || m_GameMode == eGameMode.TwoPlayers; } }

        public GameManager(string i_Player1Name, string i_Player2Name, eGameMode i_GameMode, int i_BoardSize)
        {
            m_GameMode = i_GameMode;
            initializePlayers(i_Player1Name, i_Player2Name, i_GameMode);
            m_Board = new Board(i_BoardSize);
            CurrentTurnTeam = XPlayer.Team;
        }

        public void RestartRound()
        {
            m_Board = new Board(BoardSize);
            CurrentTurnTeam = XPlayer.Team;
            XPlayer.RoundScore = 0;
            OPlayer.RoundScore = 0;
        }

        public void PerformTurn(Turn i_Turn)
        {
            if (IsValidTurn(i_Turn))
            {
                m_Board.PerformTurn(i_Turn, CurrentTurnTeam);
                SwitchTurns();

                if (IsRoundOver())
                {
                    if (!m_Board.IsTie())
                    {
                        if (XPlayer.Team == CurrentTurnTeam)
                        {
                            XPlayer.RoundScore++;
                        }
                        else
                        {
                            OPlayer.RoundScore++;
                        }
                    }
                    else
                    {
                        XPlayer.RoundScore++;
                        OPlayer.RoundScore++;
                    }
                }
            }
            else
            {
                throw new InvalidOperationException("Invalid input move!\nPlease re-enter a move in the format rowcolumn(together):");
            }
        }

        public bool IsValidTurn(Turn i_Turn)
        {
            List<Turn> possibleTurns = m_Board.GetPossibleTurns();

            return possibleTurns.Contains(i_Turn);
        }

        public bool IsRoundOver()
        {
            return m_Board.IsGameOver();
        }

        public Player GetWinningPlayer()
        {
            Player winningPlayer = null;

            if (IsRoundOver())
            {
                if (OPlayer.RoundScore > XPlayer.RoundScore)
                {
                    winningPlayer = OPlayer;
                    winningPlayer.GameScore++;
                }

                if (OPlayer.RoundScore < XPlayer.RoundScore)
                {
                    winningPlayer = XPlayer;
                    winningPlayer.GameScore++;
                }

                if (OPlayer.RoundScore == XPlayer.RoundScore)
                {
                    XPlayer.GameScore++;
                    OPlayer.GameScore++;
                }

                SetGameWinner();
            }

            return winningPlayer;
        }

        public void SetGameWinner()
        {

            if (OPlayer.GameScore > XPlayer.GameScore)
            {
                GameWinner = OPlayer;
            }

            if (OPlayer.GameScore < XPlayer.GameScore)
            {
                GameWinner = OPlayer;
            }

            if (OPlayer.GameScore == XPlayer.GameScore)
            {
                GameWinner = null;
            }
        }

        public void PerformComputerMove()
        {
            List<Turn> possibleTurns = m_Board.GetPossibleTurns();
            Random randomGenerator = new Random();
            int randomIndex = randomGenerator.Next(0, possibleTurns.Count);
            Turn randomTurn = possibleTurns[randomIndex];

            m_Board.PerformTurn(randomTurn, eTeam.O);
            SwitchTurns();

            if (IsRoundOver())
            {
                if (!m_Board.IsTie())
                {
                    if (XPlayer.Team == CurrentTurnTeam)
                    {
                        XPlayer.RoundScore++;
                    }
                    else
                    {
                        OPlayer.RoundScore++;
                    }
                }
                else
                {
                    XPlayer.RoundScore++;
                    OPlayer.RoundScore++;
                }
            }
        }

        private void initializePlayers(string i_Player1Name, string i_Player2Name, eGameMode i_GameMode)
        {
            bool isHuman = true;

            XPlayer = new Player(i_Player1Name, isHuman, eTeam.X);

            if (i_GameMode == eGameMode.TwoPlayers)
            {
                OPlayer = new Player(i_Player2Name, isHuman, eTeam.O);
            }
            else
            {
                isHuman = false;
                OPlayer = new Player("Computer", isHuman, eTeam.O);
            }
        }

        public void SwitchTurns()
        {
            if (CurrentTurnTeam == XPlayer.Team)
            {
                CurrentTurnTeam = OPlayer.Team;
            }
            else
            {
                CurrentTurnTeam = XPlayer.Team;
            }
        }
    }
}
