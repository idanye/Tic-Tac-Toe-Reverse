using System.Collections.Generic;

namespace Logic
{
    public class Board
    {
        private readonly CellData[][] r_Board;

        internal Board(int i_BoardSize)
        {
            Size = i_BoardSize;
            r_Board = createBoardArray(i_BoardSize);
            initializeBoard();
        }

        internal int Size { get; }

        internal CellData[][] Snapshot { get => r_Board; }

        internal Turn LastTurn { get; private set; }

        private CellData[][] createBoardArray(int i_BoardSize)
        {
            CellData[][] stateBoard = new CellData[i_BoardSize][];

            for (int row = 0; row < Size; row++)
            {
                stateBoard[row] = new CellData[i_BoardSize];
            }

            return stateBoard;
        }

        private void initializeBoard()
        {
            for (int row = 0; row < Size; row++)
            {
                for (int column = 0; column < Size; column++)
                {
                    r_Board[row][column] = new CellData(eTeam.Empty);
                }
            }
        }

        internal void PerformTurn(Turn i_Turn, eTeam i_Team)
        {
            r_Board[i_Turn.Coordinates.Row][i_Turn.Coordinates.Column].Team = i_Team;
            LastTurn = i_Turn;
        }

        internal List<Turn> GetPossibleTurns()
        {
            List<Turn> possibleTurns = new List<Turn>();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (r_Board[i][j].Team == eTeam.Empty)
                    {
                        Turn newTurn = new Turn((i, j));
                        possibleTurns.Add(newTurn);
                    }
                }
            }

            return possibleTurns;
        }

        internal bool IsGameOver()
        {
            return (isWinByFirstDiagonal() || isWinBySecondDiagonal() || isWinByRow() || isWinByColumn() || GetPossibleTurns().Count == 0);
        }

        public bool IsTie()
        {
            return (!isWinByFirstDiagonal() && !isWinBySecondDiagonal() && !isWinByRow() && !isWinByColumn() && GetPossibleTurns().Count == 0);
        }

        private bool isWinByFirstDiagonal()
        {
            bool isOver = true;
            eTeam team = r_Board[0][0].Team;

            if (team != eTeam.Empty)
            {
                for (int row = 1; row < Size; row++)
                {
                    if (r_Board[row][row].Team != team)
                    {
                        isOver = false;
                    }
                }
            }
            else
            {
                isOver = false;
            }

            return isOver;
        }

        private bool isWinBySecondDiagonal()
        {
            bool isOver = true;
            eTeam team = r_Board[0][Size - 1].Team;

            if (team != eTeam.Empty)
            {
                for (int row = 1; row < Size; row++)
                {
                    for (int column = Size - 2; column >= 0; column--)
                    {
                        if (((row + column) == Size - 1) && (r_Board[row][column].Team != team))
                        {
                            isOver = false;
                        }
                    }
                }
            }
            else
            {
                isOver = false;
            }

            return isOver;
        }

        private bool isWinByRow()
        {
            bool isOver = false;

            for (int i = 0; i < Size; i++)
            {
                bool isRowFull = true;
                eTeam rowTeam = r_Board[i][0].Team;

                if (rowTeam != eTeam.Empty)
                {
                    for (int j = 1; j < Size; j++)
                    {
                        if (r_Board[i][j].Team != rowTeam)
                        {
                            isRowFull = false;
                        }
                    }

                    if (isRowFull)
                    {
                        isOver = true;
                        break;
                    }
                }
            }

            return isOver;
        }

        private bool isWinByColumn()
        {
            bool isOver = false;

            for (int j = 0; j < Size; j++)
            {
                bool isColumnFull = true;
                eTeam columnTeam = r_Board[0][j].Team;

                if (columnTeam != eTeam.Empty)
                {
                    for (int i = 1; i < Size; i++)
                    {
                        if (r_Board[i][j].Team != columnTeam)
                        {
                            isColumnFull = false;
                        }
                    }

                    if (isColumnFull)
                    {
                        isOver = true;
                        break;
                    }
                }
            }

            return isOver;
        }
    }
}
