﻿namespace Hotel
{
    partial class MainForm
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
            this.apartsTab = new System.Windows.Forms.TabControl();
            this.singleApartsPage = new System.Windows.Forms.TabPage();
            this.singleApartsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.doubleApartsPage = new System.Windows.Forms.TabPage();
            this.doubleApartsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tripleApartsPage = new System.Windows.Forms.TabPage();
            this.tripleApartsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.гостиницаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.finishDayMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reservedApartsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гостиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reserveApartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vipApartsPage = new System.Windows.Forms.TabPage();
            this.vipApartsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.apartsTab.SuspendLayout();
            this.singleApartsPage.SuspendLayout();
            this.doubleApartsPage.SuspendLayout();
            this.tripleApartsPage.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.vipApartsPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // apartsTab
            // 
            this.apartsTab.Controls.Add(this.singleApartsPage);
            this.apartsTab.Controls.Add(this.doubleApartsPage);
            this.apartsTab.Controls.Add(this.tripleApartsPage);
            this.apartsTab.Controls.Add(this.vipApartsPage);
            this.apartsTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.apartsTab.Location = new System.Drawing.Point(0, 24);
            this.apartsTab.Name = "apartsTab";
            this.apartsTab.SelectedIndex = 0;
            this.apartsTab.Size = new System.Drawing.Size(800, 426);
            this.apartsTab.TabIndex = 0;
            // 
            // singleApartsPage
            // 
            this.singleApartsPage.Controls.Add(this.singleApartsPanel);
            this.singleApartsPage.Location = new System.Drawing.Point(4, 22);
            this.singleApartsPage.Name = "singleApartsPage";
            this.singleApartsPage.Padding = new System.Windows.Forms.Padding(3);
            this.singleApartsPage.Size = new System.Drawing.Size(792, 400);
            this.singleApartsPage.TabIndex = 0;
            this.singleApartsPage.Text = "Одноместные";
            this.singleApartsPage.UseVisualStyleBackColor = true;
            // 
            // singleApartsPanel
            // 
            this.singleApartsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.singleApartsPanel.Location = new System.Drawing.Point(3, 3);
            this.singleApartsPanel.Name = "singleApartsPanel";
            this.singleApartsPanel.Size = new System.Drawing.Size(786, 394);
            this.singleApartsPanel.TabIndex = 0;
            // 
            // doubleApartsPage
            // 
            this.doubleApartsPage.Controls.Add(this.doubleApartsPanel);
            this.doubleApartsPage.Location = new System.Drawing.Point(4, 22);
            this.doubleApartsPage.Name = "doubleApartsPage";
            this.doubleApartsPage.Padding = new System.Windows.Forms.Padding(3);
            this.doubleApartsPage.Size = new System.Drawing.Size(792, 400);
            this.doubleApartsPage.TabIndex = 1;
            this.doubleApartsPage.Text = "Двуместные";
            this.doubleApartsPage.UseVisualStyleBackColor = true;
            // 
            // doubleApartsPanel
            // 
            this.doubleApartsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleApartsPanel.Location = new System.Drawing.Point(3, 3);
            this.doubleApartsPanel.Name = "doubleApartsPanel";
            this.doubleApartsPanel.Size = new System.Drawing.Size(786, 394);
            this.doubleApartsPanel.TabIndex = 0;
            // 
            // tripleApartsPage
            // 
            this.tripleApartsPage.Controls.Add(this.tripleApartsPanel);
            this.tripleApartsPage.Location = new System.Drawing.Point(4, 22);
            this.tripleApartsPage.Name = "tripleApartsPage";
            this.tripleApartsPage.Padding = new System.Windows.Forms.Padding(3);
            this.tripleApartsPage.Size = new System.Drawing.Size(792, 400);
            this.tripleApartsPage.TabIndex = 2;
            this.tripleApartsPage.Text = "Трехместные";
            this.tripleApartsPage.UseVisualStyleBackColor = true;
            // 
            // tripleApartsPanel
            // 
            this.tripleApartsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tripleApartsPanel.Location = new System.Drawing.Point(3, 3);
            this.tripleApartsPanel.Name = "tripleApartsPanel";
            this.tripleApartsPanel.Size = new System.Drawing.Size(786, 394);
            this.tripleApartsPanel.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.гостиницаToolStripMenuItem,
            this.гостиToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // гостиницаToolStripMenuItem
            // 
            this.гостиницаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.finishDayMenuItem,
            this.reservedApartsMenuItem});
            this.гостиницаToolStripMenuItem.Name = "гостиницаToolStripMenuItem";
            this.гостиницаToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.гостиницаToolStripMenuItem.Text = "Гостиница";
            // 
            // finishDayMenuItem
            // 
            this.finishDayMenuItem.Name = "finishDayMenuItem";
            this.finishDayMenuItem.Size = new System.Drawing.Size(222, 22);
            this.finishDayMenuItem.Text = "Завершить день досрочно";
            this.finishDayMenuItem.Click += new System.EventHandler(this.finishDayMenuItem_Click);
            // 
            // reservedApartsMenuItem
            // 
            this.reservedApartsMenuItem.Name = "reservedApartsMenuItem";
            this.reservedApartsMenuItem.Size = new System.Drawing.Size(222, 22);
            this.reservedApartsMenuItem.Text = "Забронированные номера";
            this.reservedApartsMenuItem.Click += new System.EventHandler(this.reservedApartsMenuItem_Click);
            // 
            // гостиToolStripMenuItem
            // 
            this.гостиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reserveApartToolStripMenuItem});
            this.гостиToolStripMenuItem.Name = "гостиToolStripMenuItem";
            this.гостиToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.гостиToolStripMenuItem.Text = "Гости";
            // 
            // reserveApartToolStripMenuItem
            // 
            this.reserveApartToolStripMenuItem.Name = "reserveApartToolStripMenuItem";
            this.reserveApartToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.reserveApartToolStripMenuItem.Text = "Создать бронь";
            this.reserveApartToolStripMenuItem.Click += new System.EventHandler(this.reserveApartToolStripMenuItem_Click);
            // 
            // vipApartsPage
            // 
            this.vipApartsPage.Controls.Add(this.vipApartsPanel);
            this.vipApartsPage.Location = new System.Drawing.Point(4, 22);
            this.vipApartsPage.Name = "vipApartsPage";
            this.vipApartsPage.Padding = new System.Windows.Forms.Padding(3);
            this.vipApartsPage.Size = new System.Drawing.Size(792, 400);
            this.vipApartsPage.TabIndex = 3;
            this.vipApartsPage.Text = "VIP";
            this.vipApartsPage.UseVisualStyleBackColor = true;
            // 
            // vipApartsPanel
            // 
            this.vipApartsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vipApartsPanel.Location = new System.Drawing.Point(3, 3);
            this.vipApartsPanel.Name = "vipApartsPanel";
            this.vipApartsPanel.Size = new System.Drawing.Size(786, 394);
            this.vipApartsPanel.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.apartsTab);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Гостиница";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.apartsTab.ResumeLayout(false);
            this.singleApartsPage.ResumeLayout(false);
            this.doubleApartsPage.ResumeLayout(false);
            this.tripleApartsPage.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.vipApartsPage.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl apartsTab;
        private System.Windows.Forms.TabPage singleApartsPage;
        private System.Windows.Forms.TabPage doubleApartsPage;
        private System.Windows.Forms.TabPage tripleApartsPage;
        private System.Windows.Forms.FlowLayoutPanel singleApartsPanel;
        private System.Windows.Forms.FlowLayoutPanel doubleApartsPanel;
        private System.Windows.Forms.FlowLayoutPanel tripleApartsPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem гостиницаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem finishDayMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reservedApartsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem гостиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reserveApartToolStripMenuItem;
        private System.Windows.Forms.TabPage vipApartsPage;
        private System.Windows.Forms.FlowLayoutPanel vipApartsPanel;
    }
}

