namespace Hotel
{
    partial class ReservationsForm
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
            this.reservationsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.reservationsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // reservationsGrid
            // 
            this.reservationsGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.reservationsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.reservationsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reservationsGrid.Location = new System.Drawing.Point(0, 0);
            this.reservationsGrid.Name = "reservationsGrid";
            this.reservationsGrid.Size = new System.Drawing.Size(800, 450);
            this.reservationsGrid.TabIndex = 0;
            // 
            // ReservationsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reservationsGrid);
            this.Name = "ReservationsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Заявки на бронь";
            this.Load += new System.EventHandler(this.ReservationsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.reservationsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView reservationsGrid;
    }
}