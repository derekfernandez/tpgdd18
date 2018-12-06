namespace PalcoNet.Login
{
    partial class Login
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.userTextbox = new System.Windows.Forms.TextBox();
            this.pwTextbox = new System.Windows.Forms.TextBox();
            this.pwLabel = new System.Windows.Forms.Label();
            this.userLabel = new System.Windows.Forms.Label();
            this.byeBtn = new System.Windows.Forms.Button();
            this.loginBtn = new System.Windows.Forms.Button();
            this.failureMsgLabel = new System.Windows.Forms.Label();
            this.controllerError = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.controllerError)).BeginInit();
            this.SuspendLayout();
            // 
            // userTextbox
            // 
            this.userTextbox.Location = new System.Drawing.Point(76, 189);
            this.userTextbox.Name = "userTextbox";
            this.userTextbox.Size = new System.Drawing.Size(150, 20);
            this.userTextbox.TabIndex = 1;
            this.userTextbox.TextChanged += new System.EventHandler(this.userTextbox_TextChanged);
            // 
            // pwTextbox
            // 
            this.pwTextbox.Location = new System.Drawing.Point(76, 224);
            this.pwTextbox.Name = "pwTextbox";
            this.pwTextbox.Size = new System.Drawing.Size(150, 20);
            this.pwTextbox.TabIndex = 2;
            this.pwTextbox.TextChanged += new System.EventHandler(this.pwTextbox_TextChanged);
            // 
            // pwLabel
            // 
            this.pwLabel.AutoSize = true;
            this.pwLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwLabel.Location = new System.Drawing.Point(2, 224);
            this.pwLabel.Name = "pwLabel";
            this.pwLabel.Size = new System.Drawing.Size(71, 16);
            this.pwLabel.TabIndex = 3;
            this.pwLabel.Text = "Password:";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.Location = new System.Drawing.Point(12, 189);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(58, 16);
            this.userLabel.TabIndex = 4;
            this.userLabel.Text = "Usuario:";
            // 
            // byeBtn
            // 
            this.byeBtn.Location = new System.Drawing.Point(103, 254);
            this.byeBtn.Name = "byeBtn";
            this.byeBtn.Size = new System.Drawing.Size(75, 23);
            this.byeBtn.TabIndex = 5;
            this.byeBtn.Text = "Salir";
            this.byeBtn.UseVisualStyleBackColor = true;
            this.byeBtn.Click += new System.EventHandler(this.byeBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.Location = new System.Drawing.Point(185, 254);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 23);
            this.loginBtn.TabIndex = 6;
            this.loginBtn.Text = "Ingresar";
            this.loginBtn.UseVisualStyleBackColor = true;
            this.loginBtn.Click += new System.EventHandler(this.loginBtn_Click);
            // 
            // failureMsgLabel
            // 
            this.failureMsgLabel.AutoSize = true;
            this.failureMsgLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.failureMsgLabel.ForeColor = System.Drawing.Color.Red;
            this.failureMsgLabel.Location = new System.Drawing.Point(66, 153);
            this.failureMsgLabel.Name = "failureMsgLabel";
            this.failureMsgLabel.Size = new System.Drawing.Size(0, 17);
            this.failureMsgLabel.TabIndex = 8;
            // 
            // controllerError
            // 
            this.controllerError.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.controllerError.ContainerControl = this;
            // 
            // LoginUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 289);
            this.Controls.Add(this.failureMsgLabel);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.byeBtn);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.pwLabel);
            this.Controls.Add(this.pwTextbox);
            this.Controls.Add(this.userTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "LoginUsuario";
            this.Text = "Login - PalcoNet";
            this.Load += new System.EventHandler(this.Login_Load);
            this.Controls.SetChildIndex(this.userTextbox, 0);
            this.Controls.SetChildIndex(this.pwTextbox, 0);
            this.Controls.SetChildIndex(this.pwLabel, 0);
            this.Controls.SetChildIndex(this.userLabel, 0);
            this.Controls.SetChildIndex(this.byeBtn, 0);
            this.Controls.SetChildIndex(this.loginBtn, 0);
            this.Controls.SetChildIndex(this.failureMsgLabel, 0);
            ((System.ComponentModel.ISupportInitialize)(this.controllerError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox userTextbox;
        private System.Windows.Forms.TextBox pwTextbox;
        private System.Windows.Forms.Label pwLabel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button byeBtn;
        private System.Windows.Forms.Button loginBtn;
        private System.Windows.Forms.Label failureMsgLabel;
        private System.Windows.Forms.ErrorProvider controllerError;
    }
}