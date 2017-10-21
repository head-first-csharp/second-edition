namespace Baseball
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.trajectory = new System.Windows.Forms.NumericUpDown();
            this.distance = new System.Windows.Forms.NumericUpDown();
            this.playBallButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Trajectory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Distance";
            // 
            // trajectory
            // 
            this.trajectory.Location = new System.Drawing.Point(72, 12);
            this.trajectory.Name = "trajectory";
            this.trajectory.Size = new System.Drawing.Size(94, 20);
            this.trajectory.TabIndex = 2;
            this.trajectory.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // distance
            // 
            this.distance.Location = new System.Drawing.Point(72, 38);
            this.distance.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.distance.Name = "distance";
            this.distance.Size = new System.Drawing.Size(94, 20);
            this.distance.TabIndex = 3;
            this.distance.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // playBallButton
            // 
            this.playBallButton.Location = new System.Drawing.Point(72, 64);
            this.playBallButton.Name = "playBallButton";
            this.playBallButton.Size = new System.Drawing.Size(75, 23);
            this.playBallButton.TabIndex = 4;
            this.playBallButton.Text = "Play ball!";
            this.playBallButton.UseVisualStyleBackColor = true;
            this.playBallButton.Click += new System.EventHandler(this.playBallButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 94);
            this.Controls.Add(this.playBallButton);
            this.Controls.Add(this.distance);
            this.Controls.Add(this.trajectory);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Baseball";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown trajectory;
        private System.Windows.Forms.NumericUpDown distance;
        private System.Windows.Forms.Button playBallButton;
    }
}

