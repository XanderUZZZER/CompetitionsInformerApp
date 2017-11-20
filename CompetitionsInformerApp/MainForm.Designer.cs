namespace CompetitionsInformerApp
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
            this.CompetitionsDGV = new System.Windows.Forms.DataGridView();
            this.AddCompetitionBtn = new System.Windows.Forms.Button();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionLevelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CompetitionsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // CompetitionsDGV
            // 
            this.CompetitionsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompetitionsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCol,
            this.SubjectCol,
            this.PlaceCol,
            this.DateCol,
            this.RegionLevelCol});
            this.CompetitionsDGV.Location = new System.Drawing.Point(12, 12);
            this.CompetitionsDGV.Name = "CompetitionsDGV";
            this.CompetitionsDGV.Size = new System.Drawing.Size(543, 170);
            this.CompetitionsDGV.TabIndex = 0;
            // 
            // AddCompetitionBtn
            // 
            this.AddCompetitionBtn.Location = new System.Drawing.Point(12, 216);
            this.AddCompetitionBtn.Name = "AddCompetitionBtn";
            this.AddCompetitionBtn.Size = new System.Drawing.Size(132, 23);
            this.AddCompetitionBtn.TabIndex = 1;
            this.AddCompetitionBtn.Text = "Add competition";
            this.AddCompetitionBtn.UseVisualStyleBackColor = true;
            this.AddCompetitionBtn.Click += new System.EventHandler(this.AddCompetitionBtn_Click);
            // 
            // NameCol
            // 
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            // 
            // SubjectCol
            // 
            this.SubjectCol.HeaderText = "Subject";
            this.SubjectCol.Name = "SubjectCol";
            // 
            // PlaceCol
            // 
            this.PlaceCol.HeaderText = "Place";
            this.PlaceCol.Name = "PlaceCol";
            // 
            // DateCol
            // 
            this.DateCol.HeaderText = "Date";
            this.DateCol.Name = "DateCol";
            // 
            // RegionLevelCol
            // 
            this.RegionLevelCol.HeaderText = "RegionLevel";
            this.RegionLevelCol.Name = "RegionLevelCol";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(569, 404);
            this.Controls.Add(this.AddCompetitionBtn);
            this.Controls.Add(this.CompetitionsDGV);
            this.Name = "MainForm";
            this.Text = "Competitions Informer";
            ((System.ComponentModel.ISupportInitialize)(this.CompetitionsDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CompetitionsDGV;
        private System.Windows.Forms.Button AddCompetitionBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionLevelCol;
    }
}

