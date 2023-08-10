using System;
using System.Windows.Forms;

namespace UI
{
    partial class FormGameSettings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameSettings));
            this.playersLabel = new System.Windows.Forms.Label();
            this.player2CheckBox = new System.Windows.Forms.CheckBox();
            this.player1Label = new System.Windows.Forms.Label();
            this.player2TextBox = new System.Windows.Forms.TextBox();
            this.player1TextBox = new System.Windows.Forms.TextBox();
            this.boardSizeLabel = new System.Windows.Forms.Label();
            this.numOfRows = new System.Windows.Forms.NumericUpDown();
            this.numOfColumns = new System.Windows.Forms.NumericUpDown();
            this.rowLabel = new System.Windows.Forms.Label();
            this.columnLabel = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numOfRows)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfColumns)).BeginInit();
            this.SuspendLayout();
            // 
            // playersLabel
            // 
            this.playersLabel.AutoSize = true;
            this.playersLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.playersLabel.Location = new System.Drawing.Point(24, 34);
            this.playersLabel.Name = "playersLabel";
            this.playersLabel.Size = new System.Drawing.Size(64, 20);
            this.playersLabel.TabIndex = 4;
            this.playersLabel.Text = "Players:";
            // 
            // player2CheckBox
            // 
            this.player2CheckBox.AutoSize = true;
            this.player2CheckBox.Location = new System.Drawing.Point(44, 114);
            this.player2CheckBox.Name = "player2CheckBox";
            this.player2CheckBox.Size = new System.Drawing.Size(95, 24);
            this.player2CheckBox.TabIndex = 5;
            this.player2CheckBox.Text = "Player 2:";
            this.player2CheckBox.UseVisualStyleBackColor = true;
            this.player2CheckBox.CheckedChanged += new System.EventHandler(this.player2CheckBox_CheckedChanged);
            // 
            // player1Label
            // 
            this.player1Label.AutoSize = true;
            this.player1Label.Location = new System.Drawing.Point(40, 74);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(69, 20);
            this.player1Label.TabIndex = 6;
            this.player1Label.Text = "Player 1:";
            // 
            // player2TextBox
            // 
            this.player2TextBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.player2TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player2TextBox.Enabled = false;
            this.player2TextBox.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.player2TextBox.Location = new System.Drawing.Point(145, 112);
            this.player2TextBox.MaxLength = 10;
            this.player2TextBox.Name = "player2TextBox";
            this.player2TextBox.Size = new System.Drawing.Size(163, 26);
            this.player2TextBox.TabIndex = 7;
            this.player2TextBox.Text = "[Computer]";
            // 
            // player1TextBox
            // 
            this.player1TextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.player1TextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.player1TextBox.ForeColor = System.Drawing.SystemColors.MenuText;
            this.player1TextBox.Location = new System.Drawing.Point(145, 68);
            this.player1TextBox.MaxLength = 10;
            this.player1TextBox.Name = "player1TextBox";
            this.player1TextBox.Size = new System.Drawing.Size(163, 26);
            this.player1TextBox.TabIndex = 9;
            // 
            // boardSizeLabel
            // 
            this.boardSizeLabel.AutoSize = true;
            this.boardSizeLabel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.boardSizeLabel.Location = new System.Drawing.Point(24, 192);
            this.boardSizeLabel.Name = "boardSizeLabel";
            this.boardSizeLabel.Size = new System.Drawing.Size(91, 20);
            this.boardSizeLabel.TabIndex = 10;
            this.boardSizeLabel.Text = "Board Size:";
            this.boardSizeLabel.Click += new System.EventHandler(this.boardSizeLabel_Click);
            // 
            // numOfRows
            // 
            this.numOfRows.Location = new System.Drawing.Point(108, 240);
            this.numOfRows.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numOfRows.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numOfRows.Name = "numOfRows";
            this.numOfRows.Size = new System.Drawing.Size(59, 26);
            this.numOfRows.TabIndex = 11;
            this.numOfRows.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numOfRows.ValueChanged += new System.EventHandler(this.numOfRows_ValueChanged);
            // 
            // numOfColumns
            // 
            this.numOfColumns.Location = new System.Drawing.Point(273, 240);
            this.numOfColumns.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numOfColumns.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numOfColumns.Name = "numOfColumns";
            this.numOfColumns.Size = new System.Drawing.Size(59, 26);
            this.numOfColumns.TabIndex = 12;
            this.numOfColumns.Value = this.numOfRows.Value;
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Location = new System.Drawing.Point(51, 242);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(53, 20);
            this.rowLabel.TabIndex = 13;
            this.rowLabel.Text = "Rows:";
            // 
            // columnLabel
            // 
            this.columnLabel.AutoSize = true;
            this.columnLabel.Location = new System.Drawing.Point(192, 242);
            this.columnLabel.Name = "columnLabel";
            this.columnLabel.Size = new System.Drawing.Size(75, 20);
            this.columnLabel.TabIndex = 14;
            this.columnLabel.Text = "Columns:";
            // 
            // buttonStart
            // 
            this.buttonStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonStart.Location = new System.Drawing.Point(44, 305);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(327, 42);
            this.buttonStart.TabIndex = 15;
            this.buttonStart.Text = "Start!";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // FormGameSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(412, 400);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.columnLabel);
            this.Controls.Add(this.rowLabel);
            this.Controls.Add(this.numOfColumns);
            this.Controls.Add(this.numOfRows);
            this.Controls.Add(this.boardSizeLabel);
            this.Controls.Add(this.player1TextBox);
            this.Controls.Add(this.player2TextBox);
            this.Controls.Add(this.player1Label);
            this.Controls.Add(this.player2CheckBox);
            this.Controls.Add(this.playersLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormGameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.FormGameSettings_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.numOfRows)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numOfColumns)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label playersLabel;
        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.CheckBox player2CheckBox;
        private System.Windows.Forms.TextBox player2TextBox;
        private System.Windows.Forms.TextBox player1TextBox;
        private System.Windows.Forms.Label boardSizeLabel;
        private System.Windows.Forms.NumericUpDown numOfRows;
        private System.Windows.Forms.NumericUpDown numOfColumns;
        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.Label columnLabel;
        private System.Windows.Forms.Button buttonStart;
    }
}