using System.Data;
using System.Drawing.Configuration;
using System.Windows.Forms;

namespace UI
{
    partial class FormBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBoard));
            this.player1Label = new System.Windows.Forms.Label();
            this.player2Label = new System.Windows.Forms.Label();
            this.turnLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // player1Label
            // 
            this.player1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player1Label.AutoSize = true;
            this.player1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.player1Label.Location = new System.Drawing.Point(57, 33);
            this.player1Label.Name = "player1Label";
            this.player1Label.Size = new System.Drawing.Size(106, 29);
            this.player1Label.TabIndex = 0;
            this.player1Label.Text = "Player 1:";
            this.player1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.player1Label.Click += new System.EventHandler(this.player1Label_Click);
            // 
            // player2Label
            // 
            this.player2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.player2Label.AutoSize = true;
            this.player2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.player2Label.Location = new System.Drawing.Point(234, 33);
            this.player2Label.Name = "player2Label";
            this.player2Label.Size = new System.Drawing.Size(106, 29);
            this.player2Label.TabIndex = 1;
            this.player2Label.Text = "Player 2:";
            this.player2Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.player2Label.Click += new System.EventHandler(this.player2Label_Click);
            // 
            // turnLabel
            // 
            this.turnLabel.AutoSize = true;
            this.turnLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.turnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(254)));
            this.turnLabel.Location = new System.Drawing.Point(0, 0);
            this.turnLabel.Name = "turnLabel";
            this.turnLabel.Size = new System.Drawing.Size(0, 29);
            this.turnLabel.TabIndex = 2;
            this.turnLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 369);
            this.Controls.Add(this.turnLabel);
            this.Controls.Add(this.player2Label);
            this.Controls.Add(this.player1Label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tic-Tac-Toe-Reversed";
            this.Load += new System.EventHandler(this.FormBoard_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Label player1Label;
        private System.Windows.Forms.Label player2Label;
        private System.Windows.Forms.Label turnLabel;
    }
}