namespace PIS
{
    partial class LoginForm
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
            this.label2 = new System.Windows.Forms.Label();
            this.input__username = new System.Windows.Forms.TextBox();
            this.input__password = new System.Windows.Forms.TextBox();
            this.btn__login = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Имя пользователя";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Пароль";
            // 
            // input__username
            // 
            this.input__username.Location = new System.Drawing.Point(12, 26);
            this.input__username.Name = "input__username";
            this.input__username.Size = new System.Drawing.Size(189, 20);
            this.input__username.TabIndex = 0;
            // 
            // input__password
            // 
            this.input__password.Location = new System.Drawing.Point(12, 69);
            this.input__password.Name = "input__password";
            this.input__password.PasswordChar = '•';
            this.input__password.Size = new System.Drawing.Size(189, 20);
            this.input__password.TabIndex = 1;
            // 
            // btn__login
            // 
            this.btn__login.Location = new System.Drawing.Point(12, 99);
            this.btn__login.Name = "btn__login";
            this.btn__login.Size = new System.Drawing.Size(189, 23);
            this.btn__login.TabIndex = 2;
            this.btn__login.Text = "Войти";
            this.btn__login.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(212, 134);
            this.Controls.Add(this.btn__login);
            this.Controls.Add(this.input__password);
            this.Controls.Add(this.input__username);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Авторизация";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox input__username;
        private System.Windows.Forms.TextBox input__password;
        private System.Windows.Forms.Button btn__login;
    }
}