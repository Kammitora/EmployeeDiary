
namespace EmployeeDiary
{
    partial class MainWindow
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
            this.dgvEmployeeData = new System.Windows.Forms.DataGridView();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnFire = new System.Windows.Forms.Button();
            this.cmbAllEmployedUnemployed = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeData)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvEmployeeData
            // 
            this.dgvEmployeeData.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvEmployeeData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmployeeData.Location = new System.Drawing.Point(34, 41);
            this.dgvEmployeeData.Name = "dgvEmployeeData";
            this.dgvEmployeeData.Size = new System.Drawing.Size(730, 354);
            this.dgvEmployeeData.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(34, 412);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Dodaj";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(115, 412);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "Edytuj";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnFire
            // 
            this.btnFire.Location = new System.Drawing.Point(689, 412);
            this.btnFire.Name = "btnFire";
            this.btnFire.Size = new System.Drawing.Size(75, 23);
            this.btnFire.TabIndex = 3;
            this.btnFire.Text = "Zwolnij";
            this.btnFire.UseVisualStyleBackColor = true;
            this.btnFire.Click += new System.EventHandler(this.btnFire_Click);
            // 
            // cmbAllEmployedUnemployed
            // 
            this.cmbAllEmployedUnemployed.FormattingEnabled = true;
            this.cmbAllEmployedUnemployed.Items.AddRange(new object[] {
            "Wszyscy",
            "Zatrudnieni",
            "Zwolnieni"});
            this.cmbAllEmployedUnemployed.Location = new System.Drawing.Point(368, 414);
            this.cmbAllEmployedUnemployed.MaxDropDownItems = 3;
            this.cmbAllEmployedUnemployed.Name = "cmbAllEmployedUnemployed";
            this.cmbAllEmployedUnemployed.Size = new System.Drawing.Size(265, 21);
            this.cmbAllEmployedUnemployed.TabIndex = 4;
            this.cmbAllEmployedUnemployed.Text = "Wszyscy";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 417);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Wyświetl pracowników:";
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbAllEmployedUnemployed);
            this.Controls.Add(this.btnFire);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.dgvEmployeeData);
            this.Name = "MainWindow";
            this.Text = "HRHelper";
            this.Activated += new System.EventHandler(this.MainWindow_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmployeeData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmployeeData;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnFire;
        private System.Windows.Forms.ComboBox cmbAllEmployedUnemployed;
        private System.Windows.Forms.Label label1;
    }
}

