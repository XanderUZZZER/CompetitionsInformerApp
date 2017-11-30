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
            this.btRefresh = new System.Windows.Forms.Button();
            this.btAddParticipant = new System.Windows.Forms.Button();
            this.NameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SubjectCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlaceCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionLevelCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.participantsCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.holdCol = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.CompetitionsDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // CompetitionsDGV
            // 
            this.CompetitionsDGV.AllowUserToAddRows = false;
            this.CompetitionsDGV.AllowUserToDeleteRows = false;
            this.CompetitionsDGV.AllowUserToResizeRows = false;
            this.CompetitionsDGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CompetitionsDGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.CompetitionsDGV.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.CompetitionsDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CompetitionsDGV.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.NameCol,
            this.SubjectCol,
            this.PlaceCol,
            this.DateCol,
            this.RegionLevelCol,
            this.participantsCol,
            this.holdCol});
            this.CompetitionsDGV.Location = new System.Drawing.Point(12, 12);
            this.CompetitionsDGV.MultiSelect = false;
            this.CompetitionsDGV.Name = "CompetitionsDGV";
            this.CompetitionsDGV.ReadOnly = true;
            this.CompetitionsDGV.RowHeadersVisible = false;
            this.CompetitionsDGV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CompetitionsDGV.ShowEditingIcon = false;
            this.CompetitionsDGV.Size = new System.Drawing.Size(660, 198);
            this.CompetitionsDGV.TabIndex = 0;
            // 
            // AddCompetitionBtn
            // 
            this.AddCompetitionBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.AddCompetitionBtn.Location = new System.Drawing.Point(12, 229);
            this.AddCompetitionBtn.Name = "AddCompetitionBtn";
            this.AddCompetitionBtn.Size = new System.Drawing.Size(132, 23);
            this.AddCompetitionBtn.TabIndex = 1;
            this.AddCompetitionBtn.Text = "Add competition";
            this.AddCompetitionBtn.UseVisualStyleBackColor = true;
            this.AddCompetitionBtn.Click += new System.EventHandler(this.AddCompetitionBtn_Click);
            // 
            // btRefresh
            // 
            this.btRefresh.Location = new System.Drawing.Point(383, 229);
            this.btRefresh.Name = "btRefresh";
            this.btRefresh.Size = new System.Drawing.Size(75, 23);
            this.btRefresh.TabIndex = 2;
            this.btRefresh.Text = "Refresh";
            this.btRefresh.UseVisualStyleBackColor = true;
            this.btRefresh.Click += new System.EventHandler(this.btRefresh_Click);
            // 
            // btAddParticipant
            // 
            this.btAddParticipant.Location = new System.Drawing.Point(505, 229);
            this.btAddParticipant.Name = "btAddParticipant";
            this.btAddParticipant.Size = new System.Drawing.Size(105, 23);
            this.btAddParticipant.TabIndex = 3;
            this.btAddParticipant.Text = "Add participant";
            this.btAddParticipant.UseVisualStyleBackColor = true;
            this.btAddParticipant.Click += new System.EventHandler(this.btAddParticipant_Click);
            // 
            // NameCol
            // 
            this.NameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.NameCol.HeaderText = "Name";
            this.NameCol.Name = "NameCol";
            this.NameCol.ReadOnly = true;
            // 
            // SubjectCol
            // 
            this.SubjectCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.SubjectCol.HeaderText = "Subject";
            this.SubjectCol.Name = "SubjectCol";
            this.SubjectCol.ReadOnly = true;
            this.SubjectCol.Width = 68;
            // 
            // PlaceCol
            // 
            this.PlaceCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.PlaceCol.HeaderText = "Place";
            this.PlaceCol.Name = "PlaceCol";
            this.PlaceCol.ReadOnly = true;
            this.PlaceCol.Width = 59;
            // 
            // DateCol
            // 
            this.DateCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.DateCol.FillWeight = 50F;
            this.DateCol.HeaderText = "Date";
            this.DateCol.Name = "DateCol";
            this.DateCol.ReadOnly = true;
            this.DateCol.Width = 55;
            // 
            // RegionLevelCol
            // 
            this.RegionLevelCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.RegionLevelCol.HeaderText = "RegionLevel";
            this.RegionLevelCol.Name = "RegionLevelCol";
            this.RegionLevelCol.ReadOnly = true;
            this.RegionLevelCol.Width = 92;
            // 
            // participantsCol
            // 
            this.participantsCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.participantsCol.HeaderText = "Participants";
            this.participantsCol.Name = "participantsCol";
            this.participantsCol.ReadOnly = true;
            this.participantsCol.Width = 87;
            // 
            // holdCol
            // 
            this.holdCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.holdCol.HeaderText = "Hold";
            this.holdCol.Name = "holdCol";
            this.holdCol.ReadOnly = true;
            this.holdCol.Width = 35;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 265);
            this.Controls.Add(this.btAddParticipant);
            this.Controls.Add(this.btRefresh);
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
        private System.Windows.Forms.Button btRefresh;
        private System.Windows.Forms.Button btAddParticipant;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn SubjectCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlaceCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn RegionLevelCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn participantsCol;
        private System.Windows.Forms.DataGridViewCheckBoxColumn holdCol;
    }
}

