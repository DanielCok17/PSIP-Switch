
namespace psip_zadanie
{
    partial class mainWindow
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statistics1 = new System.Windows.Forms.TextBox();
            this.statistics2 = new System.Windows.Forms.TextBox();
            this.clearStatistics = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(158, 29);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 47);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(158, 29);
            this.button2.TabIndex = 2;
            this.button2.Text = "Stop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // statistics1
            // 
            this.statistics1.Location = new System.Drawing.Point(176, 12);
            this.statistics1.Multiline = true;
            this.statistics1.Name = "statistics1";
            this.statistics1.Size = new System.Drawing.Size(362, 231);
            this.statistics1.TabIndex = 3;
            // 
            // statistics2
            // 
            this.statistics2.Location = new System.Drawing.Point(176, 249);
            this.statistics2.Multiline = true;
            this.statistics2.Name = "statistics2";
            this.statistics2.Size = new System.Drawing.Size(362, 231);
            this.statistics2.TabIndex = 4;
            // 
            // button3
            // 
            /*this.button3.Location = new System.Drawing.Point(12, 230);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(144, 56);
            this.button3.TabIndex = 5;
            this.button3.Text = "Clear Statistics";
            this.button3.UseVisualStyleBackColor = true;
            */

            // clearStatistics
            // 
            this.clearStatistics.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.clearStatistics.Location = new System.Drawing.Point(12, 230);
            this.clearStatistics.Name = "clearStatistics";
            this.clearStatistics.Size = new System.Drawing.Size(144, 56);
            this.clearStatistics.TabIndex = 16;
            this.clearStatistics.Text = "Clear Statistics";
            this.clearStatistics.UseVisualStyleBackColor = true;
            this.clearStatistics.Click += new System.EventHandler(this.clearStatistics_Click);
            // 
            // mainWindow
            // 
            this.ClientSize = new System.Drawing.Size(741, 618);
            this.Controls.Add(this.clearStatistics);
            this.Controls.Add(this.statistics2);
            this.Controls.Add(this.statistics1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "mainWindow";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainWindow_FormClosing);
            this.Load += new System.EventHandler(this.mainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox statistics1;
        private System.Windows.Forms.TextBox statistics2;
        private System.Windows.Forms.Button clearStatistics;

        

        }
}

