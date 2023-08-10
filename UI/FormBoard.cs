using System;
using System.Drawing;
using System.Windows.Forms;
using Logic;
using UI.Enums;

namespace UI
{
    internal partial class FormBoard : Form
    {
        private readonly ButtonBoard[][] r_ButtonBoard;
        private readonly GameManager r_GameManager;
        private ButtonBoard m_HighlightedButton;

        public FormBoard(FormGameSettings.InitPackage i_InitPackage)
        {
            InitializeComponent();
            r_GameManager = new GameManager(i_InitPackage.Player1Name, i_InitPackage.Player2Name, i_InitPackage.GameMode, i_InitPackage.BoardSize);
            r_ButtonBoard = new ButtonBoard[i_InitPackage.BoardSize][];
            prepareBoard(i_InitPackage);
        }

        private ButtonBoard HighlightedButton
        {
            get
            {
                return m_HighlightedButton;
            }

            set
            {
                if (value != null)
                {
                    value.Highlight();
                }

                if (value == null && m_HighlightedButton != null)
                {
                    value.UnHighlight();
                }

                m_HighlightedButton = value;
            }
        }

        private void prepareBoard(FormGameSettings.InitPackage i_InitPackage)
        {
            int sizeMultiplier = 65;

            ClientSize = new Size(i_InitPackage.BoardSize * sizeMultiplier, i_InitPackage.BoardSize * sizeMultiplier);
            setPlayerLabels();
            initButtonBoard(i_InitPackage.BoardSize);
        }

        private void FormBoard_Load(object sender, EventArgs e)
        {
        }

        private void setPlayerLabels()
        {
            float player1NameXMult = 0.3f;
            float player2NameXMult = 0.6f;
            float playerNamesYMult = 0.08f;
            Label[] playersLabels = new Label[] { player1Label, player2Label, turnLabel };

            updateScore(r_GameManager.XPlayer);
            updateScore(r_GameManager.OPlayer);

            player1Label.Location = new Point((int)(ClientSize.Width * player1NameXMult), (int)(ClientSize.Height * playerNamesYMult));
            player2Label.Location = new Point((int)(ClientSize.Width * player2NameXMult), (int)(ClientSize.Height * playerNamesYMult));

            setLabelSizes(playersLabels);
            updateTurnLabel();
        }

        private void updateScore(Player i_Player)
        {
            if (i_Player.Team == eTeam.X)
            {
                player1Label.Text = string.Format("{0}: {1}", i_Player.Name, i_Player.GameScore);
            }

            if (i_Player.Team == eTeam.O)
            {
                player2Label.Text = string.Format("{0}: {1}", i_Player.Name, i_Player.GameScore);
            }
        }

        private void setLabelSizes(Label[] i_PlayersLabels)
        {
            float labelSizeMult = 0.15f;

            foreach (Label label in i_PlayersLabels)
            {
                label.Font = new Font(label.Font.FontFamily, label.Font.Size * r_GameManager.BoardSize * labelSizeMult);
            }
        }

        private void updateTurnLabel()
        {
            if (r_GameManager.CurrentTurnTeam == eTeam.X)
            {
                turnLabel.Text = string.Format("{0}'s turn!", r_GameManager.XPlayer.Name);
            }
            else
            {
                turnLabel.Text = string.Format("{0}'s turn!", r_GameManager.OPlayer.Name);
            }
        }

        private void initButtonBoard(int i_BoardSize)
        {
            CellData[][] boardSnapshot = r_GameManager.BoardSnapshot;
            int buttonSize = ClientSize.Width / (i_BoardSize + 2);
            float boardYMult = 0.15f;

            for (int i = 0; i < i_BoardSize; i++)
            {
                r_ButtonBoard[i] = new ButtonBoard[i_BoardSize];

                for (int j = 0; j < i_BoardSize; j++)
                {
                    ButtonBoard currentButton = new ButtonBoard(eButtonBoardType.Empty, i, j);

                    currentButton.Size = new Size(buttonSize, buttonSize);
                    currentButton.Location = new Point((j + 1) * buttonSize, (int)(ClientSize.Height * boardYMult) + (i * buttonSize));
                    currentButton.Enabled = true;
                    currentButton.Click += buttonBoard_Click;
                    r_ButtonBoard[i][j] = currentButton;
                    Controls.Add(currentButton);
                }
            }

            updateForm();
        }

        private void buttonBoard_Click(object sender, EventArgs e)
        {
            ButtonBoard clickedButton = sender as ButtonBoard;
            CellData[][] gameBoard = r_GameManager.BoardSnapshot;
            CellData clickedCell = gameBoard[clickedButton.XCoord][clickedButton.YCoord];

            if (clickedCell.Team == eTeam.Empty)
            {
                Turn inputTurn = new Turn((clickedButton.XCoord, clickedButton.YCoord));

                if (r_GameManager.IsValidTurn(inputTurn))
                {
                    if (r_GameManager.IsCurrentTurnHuman)
                    {
                        makeTurn(inputTurn);
                    }

                    if (!r_GameManager.IsCurrentTurnHuman)
                    {
                        makeComputerTurn();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid turn.\nPlease select a valid cell.", "Invalid turn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Unavailable cell.\nPlease select a valid cell.", "Invalid turn", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void makeTurn(Turn i_Turn)
        {
            r_GameManager.PerformTurn(i_Turn);
            HighlightedButton = null;
            updateForm();

            if (!r_GameManager.IsRoundOver())
            {
                updateTurnLabel();
            }
            else
            {
                announceWinner();
                Close();
            }
        }

        private void updateForm()
        {
            CellData[][] boardSnapshot = r_GameManager.BoardSnapshot;

            for (int i = 0; i < r_GameManager.BoardSize; i++)
            {
                for (int j = 0; j < r_GameManager.BoardSize; j++)
                {
                    CellData currentCellData = boardSnapshot[i][j];
                    ButtonBoard currentButton = r_ButtonBoard[i][j];

                    if (currentCellData.Team != eTeam.Empty)
                    {
                        if (currentCellData.Team == eTeam.X)
                        {
                            currentButton.BackgroundImage = Properties.Resources.XPicture;
                        }
                        else
                        {
                            currentButton.BackgroundImage = Properties.Resources.OPicture;
                        }

                        currentButton.BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    else
                    {
                        currentButton.BackgroundImage = null;
                    }
                }
            }
        }

        private void announceWinner()
        {
            Player winningPlayer = r_GameManager.GetWinningPlayer();
            DialogResult dialogResult;

            if (winningPlayer != null)
            {
                dialogResult = MessageBox.Show(string.Format("{0} Won!\nDo you want another round?", winningPlayer.Name), "TicTacToeReverse", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                dialogResult = MessageBox.Show("Tie!\nDo you want another round?", "TicTacToeReverse", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }

            haveAnotherRound(dialogResult);
        }

        private void makeComputerTurn()
        {
            r_GameManager.PerformComputerMove();
            HighlightedButton = null;
            updateForm();

            if (!r_GameManager.IsRoundOver())
            {
                updateTurnLabel();
            }
            else
            {
                announceWinner();
                Close();
            }
        }

        private void haveAnotherRound(DialogResult i_DialogResult)
        {
            if (i_DialogResult == DialogResult.Yes)
            {
                r_GameManager.RestartRound();
                updateScore(r_GameManager.XPlayer);
                updateScore(r_GameManager.OPlayer);
                updateForm();
                updateTurnLabel();
            }
            else
            {
                updateScore(r_GameManager.XPlayer);
                updateScore(r_GameManager.OPlayer);
                updateForm();

                if (r_GameManager.GameWinner != null)
                {
                    MessageBox.Show($"The Grand winner is {r_GameManager.GameWinner.Name}!", "TicTacToeReverse", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Close();
                }
                else
                {
                    MessageBox.Show($"The Grand winners are {r_GameManager.XPlayer.Name} and {r_GameManager.OPlayer.Name}!", "TicTacToeReverse", MessageBoxButtons.OK, MessageBoxIcon.None);
                    Close();
                }
            }
        }

        private void player2Label_Click(object sender, EventArgs e)
        {
        }

        private void player1Label_Click(object sender, EventArgs e)
        {
        }
    }
}
