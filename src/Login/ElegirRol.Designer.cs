namespace PalcoNet.Login
{
    partial class ElegirRol
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
            this.roleSelect = new System.Windows.Forms.ComboBox();
            this.roleLabel = new System.Windows.Forms.Label();
            this.gobtn = new System.Windows.Forms.Button();
            this.backbtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // roleSelect
            // 
            this.roleSelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.roleSelect.FormattingEnabled = true;
            this.roleSelect.Location = new System.Drawing.Point(137, 180);
            this.roleSelect.Name = "roleSelect";
            this.roleSelect.Size = new System.Drawing.Size(153, 21);
            this.roleSelect.TabIndex = 1;
            // 
            // roleLabel
            // 
            this.roleLabel.AutoSize = true;
            this.roleLabel.Font = new System.Drawing.Font("Arial", 10F);
            this.roleLabel.Location = new System.Drawing.Point(10, 181);
            this.roleLabel.Name = "roleLabel";
            this.roleLabel.Size = new System.Drawing.Size(121, 16);
            this.roleLabel.TabIndex = 2;
            this.roleLabel.Text = "Seleccione un rol:";
            // 
            // gobtn
            // 
            this.gobtn.BackColor = System.Drawing.Color.LimeGreen;
            this.gobtn.Font = new System.Drawing.Font("Arial", 10F);
            this.gobtn.Location = new System.Drawing.Point(183, 221);
            this.gobtn.Name = "gobtn";
            this.gobtn.Size = new System.Drawing.Size(75, 28);
            this.gobtn.TabIndex = 3;
            this.gobtn.Text = "Ingresar";
            this.gobtn.UseVisualStyleBackColor = false;
            this.gobtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // backbtn
            // 
            this.backbtn.BackColor = System.Drawing.Color.Crimson;
            this.backbtn.Font = new System.Drawing.Font("Arial", 10F);
            this.backbtn.Location = new System.Drawing.Point(82, 221);
            this.backbtn.Name = "backbtn";
            this.backbtn.Size = new System.Drawing.Size(75, 28);
            this.backbtn.TabIndex = 4;
            this.backbtn.Text = "Volver";
            this.backbtn.UseVisualStyleBackColor = false;
            this.backbtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // ElegirRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(302, 257);
            this.Controls.Add(this.backbtn);
            this.Controls.Add(this.gobtn);
            this.Controls.Add(this.roleLabel);
            this.Controls.Add(this.roleSelect);
            this.Name = "ElegirRol";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.ElegirRol_Load);
            this.Controls.SetChildIndex(this.roleSelect, 0);
            this.Controls.SetChildIndex(this.roleLabel, 0);
            this.Controls.SetChildIndex(this.gobtn, 0);
            this.Controls.SetChildIndex(this.backbtn, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox roleSelect;
        private System.Windows.Forms.Label roleLabel;
        private System.Windows.Forms.Button gobtn;
        private System.Windows.Forms.Button backbtn;
    }
}