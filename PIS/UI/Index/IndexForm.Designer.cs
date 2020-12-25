namespace PIS.UI.Index
{
    partial class IndexForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.ButtonShowLoginForm = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonAdminPanel = new System.Windows.Forms.Button();
            this.labelUsername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(338, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "тут таблица с исходными данными доступными без авторизации";
            // 
            // ButtonShowLoginForm
            // 
            this.ButtonShowLoginForm.Location = new System.Drawing.Point(503, 7);
            this.ButtonShowLoginForm.Name = "ButtonShowLoginForm";
            this.ButtonShowLoginForm.Size = new System.Drawing.Size(134, 23);
            this.ButtonShowLoginForm.TabIndex = 1;
            this.ButtonShowLoginForm.Text = "Войти";
            this.ButtonShowLoginForm.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            this.dataGridView1.Location = new System.Drawing.Point(14, 110);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(622, 122);
            this.dataGridView1.TabIndex = 2;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Год";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Месяц";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Нас. пункт";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Статус";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Дата установки статуса";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // buttonAdminPanel
            // 
            this.buttonAdminPanel.Location = new System.Drawing.Point(472, 26);
            this.buttonAdminPanel.Name = "buttonAdminPanel";
            this.buttonAdminPanel.Size = new System.Drawing.Size(165, 23);
            this.buttonAdminPanel.TabIndex = 3;
            this.buttonAdminPanel.Text = "Панель администратора";
            this.buttonAdminPanel.UseVisualStyleBackColor = true;
            this.buttonAdminPanel.Visible = false;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(469, 10);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(35, 13);
            this.labelUsername.TabIndex = 4;
            this.labelUsername.Text = "label2";
            this.labelUsername.Visible = false;
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 450);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.buttonAdminPanel);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.ButtonShowLoginForm);
            this.Controls.Add(this.label1);
            this.Name = "IndexForm";
            this.Text = "Garbage";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ButtonShowLoginForm;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Button buttonAdminPanel;
        private System.Windows.Forms.Label labelUsername;
    }
}

