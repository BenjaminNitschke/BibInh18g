namespace Permutations
{
	partial class PermutationsForm
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
			this.WordsTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.PermutationsTextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.GoButton = new System.Windows.Forms.Button();
			this.OutputTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// WordsTextBox
			// 
			this.WordsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.WordsTextBox.Location = new System.Drawing.Point(170, 16);
			this.WordsTextBox.Name = "WordsTextBox";
			this.WordsTextBox.Size = new System.Drawing.Size(296, 20);
			this.WordsTextBox.TabIndex = 0;
			this.WordsTextBox.Text = "apple orange kiwi banana peach citrus pear ";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 19);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(151, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Please enter a bunch of words";
			// 
			// PermutationsTextBox
			// 
			this.PermutationsTextBox.Location = new System.Drawing.Point(170, 43);
			this.PermutationsTextBox.Name = "PermutationsTextBox";
			this.PermutationsTextBox.Size = new System.Drawing.Size(75, 20);
			this.PermutationsTextBox.TabIndex = 2;
			this.PermutationsTextBox.Text = "2";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(13, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(126, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "How many permutations?";
			// 
			// GoButton
			// 
			this.GoButton.Location = new System.Drawing.Point(170, 72);
			this.GoButton.Name = "GoButton";
			this.GoButton.Size = new System.Drawing.Size(75, 23);
			this.GoButton.TabIndex = 4;
			this.GoButton.Text = "Go";
			this.GoButton.UseVisualStyleBackColor = true;
			this.GoButton.Click += new System.EventHandler(this.GoButton_Click);
			// 
			// OutputTextBox
			// 
			this.OutputTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.OutputTextBox.Location = new System.Drawing.Point(13, 106);
			this.OutputTextBox.Multiline = true;
			this.OutputTextBox.Name = "OutputTextBox";
			this.OutputTextBox.Size = new System.Drawing.Size(453, 168);
			this.OutputTextBox.TabIndex = 5;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(478, 286);
			this.Controls.Add(this.OutputTextBox);
			this.Controls.Add(this.GoButton);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.PermutationsTextBox);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.WordsTextBox);
			this.Name = "Form1";
			this.Text = "Permutations";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox WordsTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox PermutationsTextBox;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button GoButton;
		private System.Windows.Forms.TextBox OutputTextBox;
	}
}

