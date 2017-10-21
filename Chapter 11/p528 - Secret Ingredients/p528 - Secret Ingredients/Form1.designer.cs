namespace p528___Secret_Ingredients
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
            this.useIngredient = new System.Windows.Forms.Button();
            this.amount = new System.Windows.Forms.NumericUpDown();
            this.getSuzanne = new System.Windows.Forms.Button();
            this.getAmy = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // useIngredient
            // 
            this.useIngredient.Location = new System.Drawing.Point(12, 12);
            this.useIngredient.Name = "useIngredient";
            this.useIngredient.Size = new System.Drawing.Size(131, 23);
            this.useIngredient.TabIndex = 0;
            this.useIngredient.Text = "Get the ingredient";
            this.useIngredient.UseVisualStyleBackColor = true;
            this.useIngredient.Click += new System.EventHandler(this.useIngredient_Click);
            // 
            // amount
            // 
            this.amount.Location = new System.Drawing.Point(149, 15);
            this.amount.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.amount.Name = "amount";
            this.amount.Size = new System.Drawing.Size(38, 20);
            this.amount.TabIndex = 1;
            this.amount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // getSuzanne
            // 
            this.getSuzanne.Location = new System.Drawing.Point(12, 41);
            this.getSuzanne.Name = "getSuzanne";
            this.getSuzanne.Size = new System.Drawing.Size(175, 23);
            this.getSuzanne.TabIndex = 2;
            this.getSuzanne.Text = "Get Suzanne\'s delegate";
            this.getSuzanne.UseVisualStyleBackColor = true;
            this.getSuzanne.Click += new System.EventHandler(this.getSuzanne_Click);
            // 
            // getAmy
            // 
            this.getAmy.Location = new System.Drawing.Point(12, 70);
            this.getAmy.Name = "getAmy";
            this.getAmy.Size = new System.Drawing.Size(175, 23);
            this.getAmy.TabIndex = 3;
            this.getAmy.Text = "Get Amy\'s delegate";
            this.getAmy.UseVisualStyleBackColor = true;
            this.getAmy.Click += new System.EventHandler(this.getAmy_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(199, 106);
            this.Controls.Add(this.getAmy);
            this.Controls.Add(this.getSuzanne);
            this.Controls.Add(this.amount);
            this.Controls.Add(this.useIngredient);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "Secret Ingredients";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button useIngredient;
        private System.Windows.Forms.NumericUpDown amount;
        private System.Windows.Forms.Button getSuzanne;
        private System.Windows.Forms.Button getAmy;
    }
}

