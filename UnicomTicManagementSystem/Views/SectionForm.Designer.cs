namespace UnicomTicManagementSystem.Views
{
    partial class SectionForm
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
            this.delete = new System.Windows.Forms.Button();
            this.update = new System.Windows.Forms.Button();
            this.add = new System.Windows.Forms.Button();
            this.secName = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.dgvSections = new System.Windows.Forms.DataGridView();
            this.secSearch = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).BeginInit();
            this.SuspendLayout();
            // 
            // delete
            // 
            this.delete.Location = new System.Drawing.Point(109, 135);
            this.delete.Name = "delete";
            this.delete.Size = new System.Drawing.Size(85, 32);
            this.delete.TabIndex = 1;
            this.delete.Text = "DELETE";
            this.delete.UseVisualStyleBackColor = true;
            this.delete.Click += new System.EventHandler(this.delete_Click);
            // 
            // update
            // 
            this.update.Location = new System.Drawing.Point(270, 135);
            this.update.Name = "update";
            this.update.Size = new System.Drawing.Size(82, 32);
            this.update.TabIndex = 2;
            this.update.Text = "UPDATE";
            this.update.UseVisualStyleBackColor = true;
            this.update.Click += new System.EventHandler(this.update_Click);
            // 
            // add
            // 
            this.add.Location = new System.Drawing.Point(427, 135);
            this.add.Name = "add";
            this.add.Size = new System.Drawing.Size(86, 33);
            this.add.TabIndex = 3;
            this.add.Text = "ADD";
            this.add.UseVisualStyleBackColor = true;
            this.add.Click += new System.EventHandler(this.button3_Click);
            // 
            // secName
            // 
            this.secName.Location = new System.Drawing.Point(258, 79);
            this.secName.Name = "secName";
            this.secName.Size = new System.Drawing.Size(255, 22);
            this.secName.TabIndex = 4;
            this.secName.TextChanged += new System.EventHandler(this.secName_TextChanged);
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(109, 189);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(84, 32);
            this.search.TabIndex = 5;
            this.search.Text = "SEARCH";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // dgvSections
            // 
            this.dgvSections.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSections.Location = new System.Drawing.Point(109, 251);
            this.dgvSections.Name = "dgvSections";
            this.dgvSections.RowHeadersWidth = 51;
            this.dgvSections.RowTemplate.Height = 24;
            this.dgvSections.Size = new System.Drawing.Size(404, 187);
            this.dgvSections.TabIndex = 6;
            this.dgvSections.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSections_CellContentClick);
            // 
            // secSearch
            // 
            this.secSearch.Location = new System.Drawing.Point(258, 198);
            this.secSearch.Name = "secSearch";
            this.secSearch.Size = new System.Drawing.Size(255, 22);
            this.secSearch.TabIndex = 7;
            this.secSearch.TextChanged += new System.EventHandler(this.secSearch_TextChanged);
            // 
            // txtName
            // 
            this.txtName.AutoSize = true;
            this.txtName.Location = new System.Drawing.Point(106, 85);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(114, 16);
            this.txtName.TabIndex = 8;
            this.txtName.Text = "SECTION NAME :";
            this.txtName.Click += new System.EventHandler(this.txtName_Click);
            // 
            // SectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 520);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.secSearch);
            this.Controls.Add(this.dgvSections);
            this.Controls.Add(this.search);
            this.Controls.Add(this.secName);
            this.Controls.Add(this.add);
            this.Controls.Add(this.update);
            this.Controls.Add(this.delete);
            this.Name = "SectionForm";
            this.Text = "SectionForm";
            this.Load += new System.EventHandler(this.SectionForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSections)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button delete;
        private System.Windows.Forms.Button update;
        private System.Windows.Forms.Button add;
        private System.Windows.Forms.TextBox secName;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.DataGridView dgvSections;
        private System.Windows.Forms.TextBox secSearch;
        private System.Windows.Forms.Label txtName;
    }
}