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
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPalcoNet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.controllerError)).BeginInit();
            this.SuspendLayout();
            // 
            // logoPalcoNet
            // 
            this.logoPalcoNet.Location = new System.Drawing.Point(82, 12);
            // 
            // userTextbox
            // 
            this.userTextbox.Location = new System.Drawing.Point(92, 171);
            this.userTextbox.Name = "userTextbox";
            this.userTextbox.Size = new System.Drawing.Size(150, 20);
            this.userTextbox.TabIndex = 1;
            this.userTextbox.TextChanged += new System.EventHandler(this.userTextbox_TextChanged);
            // 
            // pwTextbox
            // 
            this.pwTextbox.Location = new System.Drawing.Point(92, 210);
            this.pwTextbox.Name = "pwTextbox";
            this.pwTextbox.Size = new System.Drawing.Size(150, 20);
            this.pwTextbox.TabIndex = 2;
            this.pwTextbox.UseSystemPasswordChar = true;
            this.pwTextbox.TextChanged += new System.EventHandler(this.pwTextbox_TextChanged);
            // 
            // pwLabel
            // 
            this.pwLabel.AutoSize = true;
            this.pwLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pwLabel.Location = new System.Drawing.Point(15, 210);
            this.pwLabel.Name = "pwLabel";
            this.pwLabel.Size = new System.Drawing.Size(71, 16);
            this.pwLabel.TabIndex = 3;
            this.pwLabel.Text = "Password:";
            // 
            // userLabel
            // 
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLabel.Location = new System.Drawing.Point(28, 171);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(58, 16);
            this.userLabel.TabIndex = 4;
            this.userLabel.Text = "Usuario:";
            // 
            // byeBtn
            // 
            this.byeBtn.BackColor = System.Drawing.Color.Crimson;
            this.byeBtn.Font = new System.Drawing.Font("Arial", 10F);
            this.byeBtn.Location = new System.Drawing.Point(57, 243);
            this.byeBtn.Name = "byeBtn";
            this.byeBtn.Size = new System.Drawing.Size(75, 34);
            this.byeBtn.TabIndex = 5;
            this.byeBtn.Text = "Salir";
            this.byeBtn.UseVisualStyleBackColor = false;
            this.byeBtn.Click += new System.EventHandler(this.byeBtn_Click);
            // 
            // loginBtn
            // 
            this.loginBtn.BackColor = System.Drawing.Color.LimeGreen;
            this.loginBtn.Font = new System.Drawing.Font("Arial", 10F);
            this.loginBtn.Location = new System.Drawing.Point(167, 243);
            this.loginBtn.Name = "loginBtn";
            this.loginBtn.Size = new System.Drawing.Size(75, 34);
            this.loginBtn.TabIndex = 6;
            this.loginBtn.Text = "Ingresar";
            this.loginBtn.UseVisualStyleBackColor = false;
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
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(51, 291);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(191, 13);
            this.linkLabel1.TabIndex = 9;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "¿Aún no tiene una cuenta? Regístrese";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(2, 315);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(295, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Si es la primera vez que ingresa y fue dado de alta";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel2.Location = new System.Drawing.Point(245, 328);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(37, 13);
            this.linkLabel2.TabIndex = 11;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = " aquí";
            this.linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel2_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(2, 328);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "por un administrador, por favor, haga click";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 359);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.linkLabel2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.failureMsgLabel);
            this.Controls.Add(this.loginBtn);
            this.Controls.Add(this.byeBtn);
            this.Controls.Add(this.userLabel);
            this.Controls.Add(this.pwLabel);
            this.Controls.Add(this.pwTextbox);
            this.Controls.Add(this.userTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Login";
            this.Text = "Login - PalcoNet";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Login_FormClosed);
            this.Load += new System.EventHandler(this.Login_Load);
            this.Controls.SetChildIndex(this.logoPalcoNet, 0);
            this.Controls.SetChildIndex(this.userTextbox, 0);
            this.Controls.SetChildIndex(this.pwTextbox, 0);
            this.Controls.SetChildIndex(this.pwLabel, 0);
            this.Controls.SetChildIndex(this.userLabel, 0);
            this.Controls.SetChildIndex(this.byeBtn, 0);
            this.Controls.SetChildIndex(this.loginBtn, 0);
            this.Controls.SetChildIndex(this.failureMsgLabel, 0);
            this.Controls.SetChildIndex(this.linkLabel1, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.linkLabel2, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.logoPalcoNet)).EndInit();
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
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.LinkLabel linkLabel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}