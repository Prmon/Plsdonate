namespace DUCk
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.GunaAni = new Guna.UI2.WinForms.Guna2AnimateWindow(this.components);
            this.Thethingthatmakesround = new Guna.UI2.WinForms.Guna2BorderlessForm(this.components);
            this.DisplatN = new System.Windows.Forms.Label();
            this.BtnInject = new Guna.UI2.WinForms.Guna2Button();
            this.guna2HtmlLabel1 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.guna2HtmlLabel2 = new Guna.UI2.WinForms.Guna2HtmlLabel();
            this.Close1 = new Guna.UI2.WinForms.Guna2ImageButton();
            this.SuspendLayout();
            // 
            // GunaAni
            // 
            this.GunaAni.AnimationType = Guna.UI2.WinForms.Guna2AnimateWindow.AnimateWindowType.AW_BLEND;
            this.GunaAni.TargetForm = this;
            // 
            // Thethingthatmakesround
            // 
            this.Thethingthatmakesround.AnimateWindow = true;
            this.Thethingthatmakesround.BorderRadius = 50;
            this.Thethingthatmakesround.ContainerControl = this;
            this.Thethingthatmakesround.DockIndicatorTransparencyValue = 0.6D;
            this.Thethingthatmakesround.ResizeForm = false;
            this.Thethingthatmakesround.TransparentWhileDrag = true;
            // 
            // DisplatN
            // 
            this.DisplatN.AutoSize = true;
            this.DisplatN.Font = new System.Drawing.Font("Minecraft", 15.25F);
            this.DisplatN.ForeColor = System.Drawing.Color.White;
            this.DisplatN.Location = new System.Drawing.Point(12, 9);
            this.DisplatN.Name = "DisplatN";
            this.DisplatN.Size = new System.Drawing.Size(62, 25);
            this.DisplatN.TabIndex = 0;
            this.DisplatN.Text = "DUCk";
            // 
            // BtnInject
            // 
            this.BtnInject.Animated = true;
            this.BtnInject.BorderColor = System.Drawing.Color.White;
            this.BtnInject.BorderRadius = 1;
            this.BtnInject.BorderThickness = 1;
            this.BtnInject.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.BtnInject.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.BtnInject.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.BtnInject.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.BtnInject.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.BtnInject.Font = new System.Drawing.Font("Minecraft", 15.25F);
            this.BtnInject.ForeColor = System.Drawing.Color.White;
            this.BtnInject.Location = new System.Drawing.Point(207, 155);
            this.BtnInject.Name = "BtnInject";
            this.BtnInject.Size = new System.Drawing.Size(180, 45);
            this.BtnInject.TabIndex = 1;
            this.BtnInject.Text = "INJECT";
            this.BtnInject.Click += new System.EventHandler(this.guna2Button1_Click);
            // 
            // guna2HtmlLabel1
            // 
            this.guna2HtmlLabel1.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel1.Font = new System.Drawing.Font("Minecraft", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel1.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel1.Location = new System.Drawing.Point(12, 315);
            this.guna2HtmlLabel1.Name = "guna2HtmlLabel1";
            this.guna2HtmlLabel1.Size = new System.Drawing.Size(77, 15);
            this.guna2HtmlLabel1.TabIndex = 3;
            this.guna2HtmlLabel1.Text = "Owner DANQT";
            this.guna2HtmlLabel1.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // guna2HtmlLabel2
            // 
            this.guna2HtmlLabel2.BackColor = System.Drawing.Color.Transparent;
            this.guna2HtmlLabel2.Font = new System.Drawing.Font("Minecraft", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.guna2HtmlLabel2.ForeColor = System.Drawing.Color.White;
            this.guna2HtmlLabel2.Location = new System.Drawing.Point(12, 303);
            this.guna2HtmlLabel2.Name = "guna2HtmlLabel2";
            this.guna2HtmlLabel2.Size = new System.Drawing.Size(76, 15);
            this.guna2HtmlLabel2.TabIndex = 4;
            this.guna2HtmlLabel2.Text = "Homie Execpt";
            this.guna2HtmlLabel2.TextAlignment = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // Close1
            // 
            this.Close1.CheckedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Close1.HoverState.ImageSize = new System.Drawing.Size(64, 64);
            this.Close1.Image = ((System.Drawing.Image)(resources.GetObject("Close1.Image")));
            this.Close1.ImageOffset = new System.Drawing.Point(0, 0);
            this.Close1.ImageRotate = 0F;
            this.Close1.ImageSize = new System.Drawing.Size(10, 10);
            this.Close1.Location = new System.Drawing.Point(574, 9);
            this.Close1.Name = "Close1";
            this.Close1.PressedState.ImageSize = new System.Drawing.Size(64, 64);
            this.Close1.Size = new System.Drawing.Size(24, 22);
            this.Close1.TabIndex = 5;
            this.Close1.Click += new System.EventHandler(this.Close1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.ClientSize = new System.Drawing.Size(610, 342);
            this.Controls.Add(this.Close1);
            this.Controls.Add(this.guna2HtmlLabel2);
            this.Controls.Add(this.guna2HtmlLabel1);
            this.Controls.Add(this.BtnInject);
            this.Controls.Add(this.DisplatN);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Guna.UI2.WinForms.Guna2AnimateWindow GunaAni;
        private Guna.UI2.WinForms.Guna2BorderlessForm Thethingthatmakesround;
        private System.Windows.Forms.Label DisplatN;
        private Guna.UI2.WinForms.Guna2Button BtnInject;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel1;
        private Guna.UI2.WinForms.Guna2ImageButton Close1;
        private Guna.UI2.WinForms.Guna2HtmlLabel guna2HtmlLabel2;
    }
}

