using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Logic;

namespace UI
{
    public partial class FormGameSettings : Form
    {
        public FormGameSettings()
        {
            InitializeComponent();
        }

        internal InitPackage GetInitPackage()
        {
            InitPackage initPackage = null;
            string player1Name;
            string player2Name;
            int boardSize;
            eGameMode gameMode;
            DialogResult dialogResult;

            dialogResult = ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                player1Name = player1TextBox.Text;
                player2Name = player2TextBox.Text;
                boardSize = getBoardSize();
                gameMode = getGameMode();
                initPackage = new InitPackage(player1Name, player2Name, gameMode, boardSize);
            }

            return initPackage;
        }

        private int getBoardSize()
        {
            return (int)numOfRows.Value;
        }

        private eGameMode getGameMode()
        {
            eGameMode gameMode;

            if (player2CheckBox.Checked)
            {
                gameMode = eGameMode.TwoPlayers;
            }
            else
            {
                gameMode = eGameMode.OnePlayer;
            }

            return gameMode;
        }

        internal class InitPackage
        {
            internal string Player1Name { get; }

            internal string Player2Name { get; }

            internal eGameMode GameMode { get; }

            internal int BoardSize { get; }

            internal InitPackage(string i_Player1Name, string i_Player2Name, eGameMode i_GameMode, int boardSize)
            {
                Player1Name = i_Player1Name;
                Player2Name = i_Player2Name;
                GameMode = i_GameMode;
                BoardSize = boardSize;
            }
        }

        private void player2CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (player2CheckBox.Checked)
            {
                player2TextBox.Enabled = true;
                player2TextBox.Text = string.Empty;
            }
            else
            {
                player2TextBox.Enabled = false;
                player2TextBox.Text = "[Computer]";
            }
        }

        private void boardSizeLabel_Click(object sender, EventArgs e)
        {
        }

        private void numOfRows_ValueChanged(object sender, EventArgs e)
        {
            numOfColumns.Value = numOfRows.Value;
        }

        private bool isVaildPlayerNames()
        {
            return (player1TextBox.Text != string.Empty && player2TextBox.Text != string.Empty);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (!isVaildPlayerNames())
            {
                MessageBox.Show("Please provide both player's names.", "Invalid input", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult = DialogResult.OK;
            }
        }

        private void FormGameSettings_Load_1(object sender, EventArgs e)
        {
        }

        private void numOfColumns_ValueChanged(object sender, EventArgs e)
        {
            numOfRows.Value = numOfColumns.Value;
        }
    }
}
