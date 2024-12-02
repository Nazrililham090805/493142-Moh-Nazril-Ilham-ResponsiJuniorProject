namespace ResponsiJunpro
{
    partial class Form1
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
            tbNama = new TextBox();
            btnInsert = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            dgvDataGrid = new DataGridView();
            lblNamakaryawan = new Label();
            lblDepKaryawan = new Label();
            cbDepartemen = new ComboBox();
            dgvKaryawan = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvDataGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvKaryawan).BeginInit();
            SuspendLayout();
            // 
            // tbNama
            // 
            tbNama.Location = new Point(288, 134);
            tbNama.Name = "tbNama";
            tbNama.Size = new Size(100, 23);
            tbNama.TabIndex = 0;
            // 
            // btnInsert
            // 
            btnInsert.Location = new Point(288, 229);
            btnInsert.Name = "btnInsert";
            btnInsert.Size = new Size(75, 23);
            btnInsert.TabIndex = 2;
            btnInsert.Text = "Insert";
            btnInsert.UseVisualStyleBackColor = true;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(380, 229);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(75, 23);
            btnEdit.TabIndex = 3;
            btnEdit.Text = "Edit";
            btnEdit.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(466, 229);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 4;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // dgvDataGrid
            // 
            dgvDataGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDataGrid.Location = new Point(288, 271);
            dgvDataGrid.Name = "dgvDataGrid";
            dgvDataGrid.Size = new Size(320, 150);
            dgvDataGrid.TabIndex = 5;
            // 
            // lblNamakaryawan
            // 
            lblNamakaryawan.AutoSize = true;
            lblNamakaryawan.Location = new Point(160, 142);
            lblNamakaryawan.Name = "lblNamakaryawan";
            lblNamakaryawan.Size = new Size(93, 15);
            lblNamakaryawan.TabIndex = 6;
            lblNamakaryawan.Text = "Nama Karyawan";
            lblNamakaryawan.Click += label1_Click;
            // 
            // lblDepKaryawan
            // 
            lblDepKaryawan.AutoSize = true;
            lblDepKaryawan.Location = new Point(160, 186);
            lblDepKaryawan.Name = "lblDepKaryawan";
            lblDepKaryawan.Size = new Size(84, 15);
            lblDepKaryawan.TabIndex = 7;
            lblDepKaryawan.Text = "Dep. karyawan";
            // 
            // cbDepartemen
            // 
            cbDepartemen.FormattingEnabled = true;
            cbDepartemen.Location = new Point(288, 183);
            cbDepartemen.Name = "cbDepartemen";
            cbDepartemen.Size = new Size(121, 23);
            cbDepartemen.TabIndex = 8;
            // 
            // dgvKaryawan
            // 
            dgvKaryawan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKaryawan.Location = new Point(449, 103);
            dgvKaryawan.Name = "dgvKaryawan";
            dgvKaryawan.Size = new Size(173, 120);
            dgvKaryawan.TabIndex = 9;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvKaryawan);
            Controls.Add(cbDepartemen);
            Controls.Add(lblDepKaryawan);
            Controls.Add(lblNamakaryawan);
            Controls.Add(dgvDataGrid);
            Controls.Add(btnDelete);
            Controls.Add(btnEdit);
            Controls.Add(btnInsert);
            Controls.Add(tbNama);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dgvDataGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvKaryawan).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbNama;
        private Button btnInsert;
        private Button btnEdit;
        private Button btnDelete;
        private DataGridView dgvDataGrid;
        private Label lblNamakaryawan;
        private Label lblDepKaryawan;
        private ComboBox cbDepartemen;
        private DataGridView dgvKaryawan;
    }
}
