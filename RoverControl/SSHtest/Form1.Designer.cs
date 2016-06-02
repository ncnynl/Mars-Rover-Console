namespace RoverControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_send = new System.Windows.Forms.Button();
            this.lbx_Commands = new System.Windows.Forms.ListBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_Reverse = new System.Windows.Forms.PictureBox();
            this.btn_SlideLeft = new System.Windows.Forms.PictureBox();
            this.btn_TurnLeft = new System.Windows.Forms.PictureBox();
            this.btn_Forward = new System.Windows.Forms.PictureBox();
            this.btn_TurnRight = new System.Windows.Forms.PictureBox();
            this.btn_SlideRight = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_Abort = new System.Windows.Forms.Button();
            this.SndRcv_Wrkr = new System.ComponentModel.BackgroundWorker();
            this.lbl_Conn = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Reverse)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_SlideLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TurnLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Forward)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TurnRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_SlideRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Conn)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_send
            // 
            this.btn_send.BackColor = System.Drawing.Color.Transparent;
            this.btn_send.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_send.BackgroundImage")));
            this.btn_send.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_send.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_send.Location = new System.Drawing.Point(12, 488);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(550, 100);
            this.btn_send.TabIndex = 5;
            this.btn_send.UseVisualStyleBackColor = false;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // lbx_Commands
            // 
            this.lbx_Commands.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.lbx_Commands.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbx_Commands.Enabled = false;
            this.lbx_Commands.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbx_Commands.ForeColor = System.Drawing.Color.Transparent;
            this.lbx_Commands.FormattingEnabled = true;
            this.lbx_Commands.ItemHeight = 25;
            this.lbx_Commands.Location = new System.Drawing.Point(6, 33);
            this.lbx_Commands.Name = "lbx_Commands";
            this.lbx_Commands.Size = new System.Drawing.Size(200, 425);
            this.lbx_Commands.TabIndex = 13;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Transparent;
            this.groupBox1.Controls.Add(this.lbl_Conn);
            this.groupBox1.Controls.Add(this.btn_Reverse);
            this.groupBox1.Controls.Add(this.btn_SlideLeft);
            this.groupBox1.Controls.Add(this.btn_TurnLeft);
            this.groupBox1.Controls.Add(this.btn_Forward);
            this.groupBox1.Controls.Add(this.btn_TurnRight);
            this.groupBox1.Controls.Add(this.btn_SlideRight);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(550, 470);
            this.groupBox1.TabIndex = 17;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Command Buttons";
            // 
            // btn_Reverse
            // 
            this.btn_Reverse.Image = ((System.Drawing.Image)(resources.GetObject("btn_Reverse.Image")));
            this.btn_Reverse.Location = new System.Drawing.Point(203, 324);
            this.btn_Reverse.Name = "btn_Reverse";
            this.btn_Reverse.Size = new System.Drawing.Size(140, 140);
            this.btn_Reverse.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Reverse.TabIndex = 14;
            this.btn_Reverse.TabStop = false;
            this.btn_Reverse.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_SlideLeft
            // 
            this.btn_SlideLeft.Image = ((System.Drawing.Image)(resources.GetObject("btn_SlideLeft.Image")));
            this.btn_SlideLeft.Location = new System.Drawing.Point(57, 178);
            this.btn_SlideLeft.Name = "btn_SlideLeft";
            this.btn_SlideLeft.Size = new System.Drawing.Size(140, 140);
            this.btn_SlideLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_SlideLeft.TabIndex = 14;
            this.btn_SlideLeft.TabStop = false;
            this.btn_SlideLeft.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_TurnLeft
            // 
            this.btn_TurnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btn_TurnLeft.Image")));
            this.btn_TurnLeft.Location = new System.Drawing.Point(57, 32);
            this.btn_TurnLeft.Name = "btn_TurnLeft";
            this.btn_TurnLeft.Size = new System.Drawing.Size(140, 140);
            this.btn_TurnLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_TurnLeft.TabIndex = 14;
            this.btn_TurnLeft.TabStop = false;
            this.btn_TurnLeft.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_Forward
            // 
            this.btn_Forward.Image = ((System.Drawing.Image)(resources.GetObject("btn_Forward.Image")));
            this.btn_Forward.Location = new System.Drawing.Point(203, 32);
            this.btn_Forward.Name = "btn_Forward";
            this.btn_Forward.Size = new System.Drawing.Size(140, 140);
            this.btn_Forward.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_Forward.TabIndex = 14;
            this.btn_Forward.TabStop = false;
            this.btn_Forward.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_TurnRight
            // 
            this.btn_TurnRight.Image = ((System.Drawing.Image)(resources.GetObject("btn_TurnRight.Image")));
            this.btn_TurnRight.Location = new System.Drawing.Point(349, 32);
            this.btn_TurnRight.Name = "btn_TurnRight";
            this.btn_TurnRight.Size = new System.Drawing.Size(140, 140);
            this.btn_TurnRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_TurnRight.TabIndex = 14;
            this.btn_TurnRight.TabStop = false;
            this.btn_TurnRight.Click += new System.EventHandler(this.btn_Click);
            // 
            // btn_SlideRight
            // 
            this.btn_SlideRight.Image = ((System.Drawing.Image)(resources.GetObject("btn_SlideRight.Image")));
            this.btn_SlideRight.Location = new System.Drawing.Point(349, 178);
            this.btn_SlideRight.Name = "btn_SlideRight";
            this.btn_SlideRight.Size = new System.Drawing.Size(140, 140);
            this.btn_SlideRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btn_SlideRight.TabIndex = 14;
            this.btn_SlideRight.TabStop = false;
            this.btn_SlideRight.Click += new System.EventHandler(this.btn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(203, 178);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(140, 140);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Transparent;
            this.groupBox2.Controls.Add(this.lbx_Commands);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(125)))), ((int)(((byte)(50)))));
            this.groupBox2.Location = new System.Drawing.Point(568, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(220, 470);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Program List";
            // 
            // btn_Abort
            // 
            this.btn_Abort.BackColor = System.Drawing.Color.Transparent;
            this.btn_Abort.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_Abort.BackgroundImage")));
            this.btn_Abort.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Abort.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Abort.Location = new System.Drawing.Point(568, 488);
            this.btn_Abort.Name = "btn_Abort";
            this.btn_Abort.Size = new System.Drawing.Size(220, 100);
            this.btn_Abort.TabIndex = 19;
            this.btn_Abort.UseVisualStyleBackColor = false;
            this.btn_Abort.Click += new System.EventHandler(this.Abort_Click);
            // 
            // SndRcv_Wrkr
            // 
            this.SndRcv_Wrkr.WorkerReportsProgress = true;
            this.SndRcv_Wrkr.WorkerSupportsCancellation = true;
            this.SndRcv_Wrkr.DoWork += new System.ComponentModel.DoWorkEventHandler(this.SndRcv_Wrkr_DoWork);
            this.SndRcv_Wrkr.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.SndRcv_Wrkr_ProgressChanged);
            this.SndRcv_Wrkr.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.SndRcv_Wrkr_RunWorkerCompleted);
            // 
            // lbl_Conn
            // 
            this.lbl_Conn.Image = ((System.Drawing.Image)(resources.GetObject("lbl_Conn.Image")));
            this.lbl_Conn.Location = new System.Drawing.Point(436, 369);
            this.lbl_Conn.Name = "lbl_Conn";
            this.lbl_Conn.Size = new System.Drawing.Size(108, 95);
            this.lbl_Conn.TabIndex = 16;
            this.lbl_Conn.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(33)))), ((int)(((byte)(61)))));
            this.ClientSize = new System.Drawing.Size(800, 600);
            this.ControlBox = false;
            this.Controls.Add(this.btn_Abort);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btn_send);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RoverConrol";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btn_Reverse)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_SlideLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TurnLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_Forward)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_TurnRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_SlideRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lbl_Conn)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.ListBox lbx_Commands;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_Abort;
        private System.ComponentModel.BackgroundWorker SndRcv_Wrkr;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox btn_Reverse;
        private System.Windows.Forms.PictureBox btn_SlideLeft;
        private System.Windows.Forms.PictureBox btn_TurnLeft;
        private System.Windows.Forms.PictureBox btn_Forward;
        private System.Windows.Forms.PictureBox btn_TurnRight;
        private System.Windows.Forms.PictureBox btn_SlideRight;
        private System.Windows.Forms.PictureBox lbl_Conn;
    }
}

