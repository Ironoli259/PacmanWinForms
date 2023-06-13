namespace Pacman_2022
{
    partial class Form_Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Main));
            this.pictureBox_Map = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_Score = new System.Windows.Forms.Label();
            this.timer_Pacman = new System.Windows.Forms.Timer(this.components);
            this.label_Lives = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timer_Ghosts = new System.Windows.Forms.Timer(this.components);
            this.timer_Ghost_Collision = new System.Windows.Forms.Timer(this.components);
            this.HintButton = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Map)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HintButton)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_Map
            // 
            this.pictureBox_Map.Location = new System.Drawing.Point(0, 90);
            this.pictureBox_Map.Name = "pictureBox_Map";
            this.pictureBox_Map.Size = new System.Drawing.Size(198, 138);
            this.pictureBox_Map.TabIndex = 0;
            this.pictureBox_Map.TabStop = false;
            this.pictureBox_Map.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox_Map_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Yellow;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 33);
            this.label1.TabIndex = 1;
            this.label1.Text = "Score";
            // 
            // label_Score
            // 
            this.label_Score.AutoSize = true;
            this.label_Score.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Score.ForeColor = System.Drawing.Color.Yellow;
            this.label_Score.Location = new System.Drawing.Point(120, 20);
            this.label_Score.Name = "label_Score";
            this.label_Score.Size = new System.Drawing.Size(32, 33);
            this.label_Score.TabIndex = 2;
            this.label_Score.Text = "0";
            // 
            // timer_Pacman
            // 
            this.timer_Pacman.Enabled = true;
            this.timer_Pacman.Interval = 200;
            this.timer_Pacman.Tick += new System.EventHandler(this.timer_Pacman_Tick);
            // 
            // label_Lives
            // 
            this.label_Lives.AutoSize = true;
            this.label_Lives.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_Lives.ForeColor = System.Drawing.Color.Red;
            this.label_Lives.Location = new System.Drawing.Point(329, 20);
            this.label_Lives.Name = "label_Lives";
            this.label_Lives.Size = new System.Drawing.Size(32, 33);
            this.label_Lives.TabIndex = 4;
            this.label_Lives.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(221, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 33);
            this.label3.TabIndex = 3;
            this.label3.Text = "Lives";
            // 
            // timer_Ghosts
            // 
            this.timer_Ghosts.Enabled = true;
            this.timer_Ghosts.Interval = 250;
            this.timer_Ghosts.Tick += new System.EventHandler(this.timer_Ghosts_Tick);
            // 
            // timer_Ghost_Collision
            // 
            this.timer_Ghost_Collision.Enabled = true;
            this.timer_Ghost_Collision.Tick += new System.EventHandler(this.timer_Ghost_Collision_Tick);
            // 
            // HintButton
            // 
            this.HintButton.Image = ((System.Drawing.Image)(resources.GetObject("HintButton.Image")));
            this.HintButton.Location = new System.Drawing.Point(433, 12);
            this.HintButton.Name = "HintButton";
            this.HintButton.Size = new System.Drawing.Size(51, 50);
            this.HintButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.HintButton.TabIndex = 5;
            this.HintButton.TabStop = false;
            this.HintButton.Click += new System.EventHandler(this.HintButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Gold;
            this.label2.Location = new System.Drawing.Point(490, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 33);
            this.label2.TabIndex = 6;
            this.label2.Text = "HINT";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.HintButton);
            this.Controls.Add(this.label_Lives);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label_Score);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox_Map);
            this.Name = "Form_Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Map)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HintButton)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_Map;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Score;
        private System.Windows.Forms.Timer timer_Pacman;
        private System.Windows.Forms.Label label_Lives;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer_Ghosts;
        private System.Windows.Forms.Timer timer_Ghost_Collision;
        private System.Windows.Forms.PictureBox HintButton;
        private System.Windows.Forms.Label label2;
    }
}

