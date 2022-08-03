namespace Client
{
    partial class RestoreGames
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
            this.closeBtn = new System.Windows.Forms.Button();
            this.restoreDataGrid = new System.Windows.Forms.DataGridView();
            this.restoreGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.restoreDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // closeBtn
            // 
            this.closeBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeBtn.FlatAppearance.BorderSize = 0;
            this.closeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.closeBtn.Font = new System.Drawing.Font("Verdana", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeBtn.ForeColor = System.Drawing.Color.Maroon;
            this.closeBtn.Location = new System.Drawing.Point(922, -2);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(40, 40);
            this.closeBtn.TabIndex = 0;
            this.closeBtn.Text = "X";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // restoreDataGrid
            // 
            this.restoreDataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.restoreDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.restoreDataGrid.GridColor = System.Drawing.SystemColors.Control;
            this.restoreDataGrid.Location = new System.Drawing.Point(184, 38);
            this.restoreDataGrid.Name = "restoreDataGrid";
            this.restoreDataGrid.ReadOnly = true;
            this.restoreDataGrid.RowHeadersWidth = 51;
            this.restoreDataGrid.RowTemplate.Height = 24;
            this.restoreDataGrid.Size = new System.Drawing.Size(602, 359);
            this.restoreDataGrid.TabIndex = 1;
            // 
            // restoreGame
            // 
            this.restoreGame.FlatAppearance.BorderColor = System.Drawing.Color.Maroon;
            this.restoreGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.restoreGame.Font = new System.Drawing.Font("Verdana", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.restoreGame.Location = new System.Drawing.Point(375, 463);
            this.restoreGame.Name = "restoreGame";
            this.restoreGame.Size = new System.Drawing.Size(225, 72);
            this.restoreGame.TabIndex = 2;
            this.restoreGame.Text = "restore Game";
            this.restoreGame.UseVisualStyleBackColor = true;
            this.restoreGame.Click += new System.EventHandler(this.restoreGame_Click);
            // 
            // RestoreGames
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(961, 582);
            this.Controls.Add(this.restoreGame);
            this.Controls.Add(this.restoreDataGrid);
            this.Controls.Add(this.closeBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RestoreGames";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RestoreGames";
            ((System.ComponentModel.ISupportInitialize)(this.restoreDataGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.DataGridView restoreDataGrid;
        private System.Windows.Forms.Button restoreGame;
    }
}