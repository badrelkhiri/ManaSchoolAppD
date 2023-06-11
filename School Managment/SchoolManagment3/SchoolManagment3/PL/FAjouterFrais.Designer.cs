namespace SchoolManagment3.PL
{
    partial class FAjouterFrais
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnNouveau = new SchoolManagment3.NouveauButtons.NButton();
            this.nButton4 = new SchoolManagment3.NouveauButtons.NButton();
            this.nButton5 = new SchoolManagment3.NouveauButtons.NButton();
            this.nButton1 = new SchoolManagment3.NouveauButtons.NButton();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdView);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(114, 214);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(414, 194);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Détaille";
            // 
            // grdView
            // 
            this.grdView.AllowUserToAddRows = false;
            this.grdView.AllowUserToDeleteRows = false;
            this.grdView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.grdView.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.grdView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grdView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdView.ColumnHeadersHeight = 30;
            this.grdView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.grdView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdView.EnableHeadersVisualStyles = false;
            this.grdView.Location = new System.Drawing.Point(3, 23);
            this.grdView.MultiSelect = false;
            this.grdView.Name = "grdView";
            this.grdView.ReadOnly = true;
            this.grdView.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.grdView.RowHeadersVisible = false;
            this.grdView.RowTemplate.Height = 30;
            this.grdView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdView.Size = new System.Drawing.Size(408, 168);
            this.grdView.TabIndex = 1;
            this.grdView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdView_CellDoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtID);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txtPrice);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtName);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI Semilight", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(114, 33);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(414, 164);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "information de frais";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(113, 26);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(279, 27);
            this.txtID.TabIndex = 26;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 19);
            this.label4.TabIndex = 25;
            this.label4.Text = "ID de frais";
            // 
            // txtPrice
            // 
            this.txtPrice.Location = new System.Drawing.Point(113, 108);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(277, 27);
            this.txtPrice.TabIndex = 1;
            this.txtPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrice_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(6, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 19);
            this.label3.TabIndex = 23;
            this.label3.Text = "prix de frais";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(113, 67);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(277, 27);
            this.txtName.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 19);
            this.label2.TabIndex = 21;
            this.label2.Text = "Nom de frais";
            // 
            // btnNouveau
            // 
            this.btnNouveau.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnNouveau.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.btnNouveau.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnNouveau.BorderRadius = 19;
            this.btnNouveau.BorderSize = 0;
            this.btnNouveau.FlatAppearance.BorderSize = 0;
            this.btnNouveau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNouveau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNouveau.ForeColor = System.Drawing.Color.White;
            this.btnNouveau.Location = new System.Drawing.Point(15, 434);
            this.btnNouveau.Name = "btnNouveau";
            this.btnNouveau.Size = new System.Drawing.Size(150, 40);
            this.btnNouveau.TabIndex = 0;
            this.btnNouveau.Text = "Ajouter";
            this.btnNouveau.TextColor = System.Drawing.Color.White;
            this.btnNouveau.UseVisualStyleBackColor = false;
            this.btnNouveau.Click += new System.EventHandler(this.btnNouveau_Click);
            // 
            // nButton4
            // 
            this.nButton4.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.nButton4.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.nButton4.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.nButton4.BorderRadius = 19;
            this.nButton4.BorderSize = 0;
            this.nButton4.FlatAppearance.BorderSize = 0;
            this.nButton4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nButton4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nButton4.ForeColor = System.Drawing.Color.White;
            this.nButton4.Location = new System.Drawing.Point(171, 434);
            this.nButton4.Name = "nButton4";
            this.nButton4.Size = new System.Drawing.Size(150, 40);
            this.nButton4.TabIndex = 1;
            this.nButton4.Text = "Modifier";
            this.nButton4.TextColor = System.Drawing.Color.White;
            this.nButton4.UseVisualStyleBackColor = false;
            this.nButton4.Click += new System.EventHandler(this.nButton4_Click);
            // 
            // nButton5
            // 
            this.nButton5.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.nButton5.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.nButton5.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.nButton5.BorderRadius = 19;
            this.nButton5.BorderSize = 0;
            this.nButton5.FlatAppearance.BorderSize = 0;
            this.nButton5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nButton5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nButton5.ForeColor = System.Drawing.Color.White;
            this.nButton5.Location = new System.Drawing.Point(327, 434);
            this.nButton5.Name = "nButton5";
            this.nButton5.Size = new System.Drawing.Size(150, 40);
            this.nButton5.TabIndex = 2;
            this.nButton5.Text = "Supprimer";
            this.nButton5.TextColor = System.Drawing.Color.White;
            this.nButton5.UseVisualStyleBackColor = false;
            this.nButton5.Click += new System.EventHandler(this.nButton5_Click);
            // 
            // nButton1
            // 
            this.nButton1.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.nButton1.BackgroundColor = System.Drawing.Color.MediumSlateBlue;
            this.nButton1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.nButton1.BorderRadius = 19;
            this.nButton1.BorderSize = 0;
            this.nButton1.FlatAppearance.BorderSize = 0;
            this.nButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nButton1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nButton1.ForeColor = System.Drawing.Color.White;
            this.nButton1.Location = new System.Drawing.Point(483, 434);
            this.nButton1.Name = "nButton1";
            this.nButton1.Size = new System.Drawing.Size(150, 40);
            this.nButton1.TabIndex = 3;
            this.nButton1.Text = "Annuler";
            this.nButton1.TextColor = System.Drawing.Color.White;
            this.nButton1.UseVisualStyleBackColor = false;
            this.nButton1.Click += new System.EventHandler(this.nButton1_Click_1);
            // 
            // FAjouterFrais
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 526);
            this.Controls.Add(this.nButton1);
            this.Controls.Add(this.nButton5);
            this.Controls.Add(this.nButton4);
            this.Controls.Add(this.btnNouveau);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Name = "FAjouterFrais";
            this.Text = "Ajouter Frais";
            this.Load += new System.EventHandler(this.FAjouterFrais_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label2;
        private NouveauButtons.NButton btnNouveau;
        private NouveauButtons.NButton nButton4;
        private NouveauButtons.NButton nButton5;
        private NouveauButtons.NButton nButton1;
    }
}