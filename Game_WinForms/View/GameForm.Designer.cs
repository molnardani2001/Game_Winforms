
namespace Game_WinForms.View
{
    partial class GameForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this._toolStrip = new System.Windows.Forms.ToolStrip();
            this._toolStripLabelTime = new System.Windows.Forms.ToolStripLabel();
            this._toolStripLabelStepCount = new System.Windows.Forms.ToolStripLabel();
            this._menuStrip = new System.Windows.Forms.MenuStrip();
            this._saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._difficultyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._easyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._mediumToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._hardToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._continueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this._openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this._saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this._toolStrip.SuspendLayout();
            this._menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // _tableLayoutPanel
            // 
            this._tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 732F));
            this._tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this._tableLayoutPanel.Location = new System.Drawing.Point(0, 28);
            this._tableLayoutPanel.Name = "_tableLayoutPanel";
            this._tableLayoutPanel.Size = new System.Drawing.Size(702, 720);
            this._tableLayoutPanel.TabIndex = 0;
            // 
            // _toolStrip
            // 
            this._toolStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            this._toolStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._toolStripLabelTime,
            this._toolStripLabelStepCount});
            this._toolStrip.Location = new System.Drawing.Point(0, 648);
            this._toolStrip.Name = "_toolStrip";
            this._toolStrip.Size = new System.Drawing.Size(702, 25);
            this._toolStrip.TabIndex = 1;
            this._toolStrip.Text = "_toolStrip";
            // 
            // _toolStripLabelTime
            // 
            this._toolStripLabelTime.Name = "_toolStripLabelTime";
            this._toolStripLabelTime.Size = new System.Drawing.Size(34, 22);
            this._toolStripLabelTime.Text = "Idő:";
            // 
            // _toolStripLabelStepCount
            // 
            this._toolStripLabelStepCount.Name = "_toolStripLabelStepCount";
            this._toolStripLabelStepCount.Size = new System.Drawing.Size(122, 22);
            this._toolStripLabelStepCount.Text = "Kosarak száma: 0";
            // 
            // _menuStrip
            // 
            this._menuStrip.AutoSize = false;
            this._menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this._menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._saveToolStripMenuItem,
            this._openToolStripMenuItem,
            this._difficultyToolStripMenuItem,
            this._continueToolStripMenuItem});
            this._menuStrip.Location = new System.Drawing.Point(0, 0);
            this._menuStrip.Name = "_menuStrip";
            this._menuStrip.Size = new System.Drawing.Size(702, 28);
            this._menuStrip.TabIndex = 2;
            this._menuStrip.Text = "_menuStrip";
            // 
            // _saveToolStripMenuItem
            // 
            this._saveToolStripMenuItem.Name = "_saveToolStripMenuItem";
            this._saveToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this._saveToolStripMenuItem.Text = "Mentés";
            this._saveToolStripMenuItem.Click += new System.EventHandler(this._saveToolStripMenuItem_Click);
            // 
            // _openToolStripMenuItem
            // 
            this._openToolStripMenuItem.Name = "_openToolStripMenuItem";
            this._openToolStripMenuItem.Size = new System.Drawing.Size(91, 24);
            this._openToolStripMenuItem.Text = "Megnyitás";
            this._openToolStripMenuItem.Click += new System.EventHandler(this._openToolStripMenuItem_Click);
            // 
            // _difficultyToolStripMenuItem
            // 
            this._difficultyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this._easyToolStripMenuItem,
            this._mediumToolStripMenuItem,
            this._hardToolStripMenuItem});
            this._difficultyToolStripMenuItem.Name = "_difficultyToolStripMenuItem";
            this._difficultyToolStripMenuItem.Size = new System.Drawing.Size(87, 24);
            this._difficultyToolStripMenuItem.Text = "Játékmód";
            // 
            // _easyToolStripMenuItem
            // 
            this._easyToolStripMenuItem.Name = "_easyToolStripMenuItem";
            this._easyToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this._easyToolStripMenuItem.Text = "Könnyű";
            this._easyToolStripMenuItem.Click += new System.EventHandler(this.EasyToolStripMenuItem_Click);
            // 
            // _mediumToolStripMenuItem
            // 
            this._mediumToolStripMenuItem.Name = "_mediumToolStripMenuItem";
            this._mediumToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this._mediumToolStripMenuItem.Text = "Közepes";
            this._mediumToolStripMenuItem.Click += new System.EventHandler(this.MediumToolStripMenuItem_Click);
            // 
            // _hardToolStripMenuItem
            // 
            this._hardToolStripMenuItem.Name = "_hardToolStripMenuItem";
            this._hardToolStripMenuItem.Size = new System.Drawing.Size(148, 26);
            this._hardToolStripMenuItem.Text = "Nehéz";
            this._hardToolStripMenuItem.Click += new System.EventHandler(this.HardToolStripMenuItem_Click);
            // 
            // _continueToolStripMenuItem
            // 
            this._continueToolStripMenuItem.Name = "_continueToolStripMenuItem";
            this._continueToolStripMenuItem.Size = new System.Drawing.Size(82, 24);
            this._continueToolStripMenuItem.Text = "Folytatás";
            this._continueToolStripMenuItem.Click += new System.EventHandler(this._continueToolStripMenuItem_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 773);
            this.Controls.Add(this._tableLayoutPanel);
            this.Controls.Add(this._menuStrip);
            this.Controls.Add(this._toolStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this._menuStrip;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Maci Laci";
            this.Load += new System.EventHandler(this.GameForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GameForm_KeyDown);
            this._toolStrip.ResumeLayout(false);
            this._toolStrip.PerformLayout();
            this._menuStrip.ResumeLayout(false);
            this._menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel _tableLayoutPanel;
        private System.Windows.Forms.ToolStrip _toolStrip;
        private System.Windows.Forms.ToolStripLabel _toolStripLabelTime;
        private System.Windows.Forms.MenuStrip _menuStrip;
        private System.Windows.Forms.ToolStripMenuItem _saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _difficultyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _easyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _mediumToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem _hardToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel _toolStripLabelStepCount;
        private System.Windows.Forms.ToolStripMenuItem _continueToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog _openFileDialog;
        private System.Windows.Forms.ToolStripMenuItem _openToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog _saveFileDialog;
    }
}

