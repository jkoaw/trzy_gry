namespace trzy_gry
{
    partial class Form2
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
            label1 = new Label();
            start = new Button();
            playerone = new Label();
            playertwo = new Label();
            winner = new Label();
            endturn = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 20F);
            label1.Location = new Point(377, 85);
            label1.Name = "label1";
            label1.Size = new Size(0, 37);
            label1.TabIndex = 0;
            label1.Click += label1_Click;
            // 
            // start
            // 
            start.Font = new Font("Top Secret", 26.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            start.Location = new Point(309, 173);
            start.Name = "start";
            start.Size = new Size(185, 95);
            start.TabIndex = 1;
            start.Text = "Start";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // playerone
            // 
            playerone.AutoSize = true;
            playerone.Location = new Point(204, 56);
            playerone.Name = "playerone";
            playerone.Size = new Size(0, 15);
            playerone.TabIndex = 2;
            // 
            // playertwo
            // 
            playertwo.AutoSize = true;
            playertwo.Location = new Point(819, 500);
            playertwo.Name = "playertwo";
            playertwo.RightToLeft = RightToLeft.Yes;
            playertwo.Size = new Size(0, 15);
            playertwo.TabIndex = 3;
            // 
            // winner
            // 
            winner.AutoSize = true;
            winner.Font = new Font("Segoe UI", 20F);
            winner.Location = new Point(360, 34);
            winner.Name = "winner";
            winner.Size = new Size(0, 37);
            winner.TabIndex = 4;
            // 
            // endturn
            // 
            endturn.Location = new Point(481, 453);
            endturn.Name = "endturn";
            endturn.Size = new Size(75, 23);
            endturn.TabIndex = 5;
            endturn.Text = "next turn";
            endturn.UseVisualStyleBackColor = true;
            endturn.Click += endturn_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1124, 630);
            Controls.Add(endturn);
            Controls.Add(winner);
            Controls.Add(playertwo);
            Controls.Add(playerone);
            Controls.Add(start);
            Controls.Add(label1);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button start;
        private Label playerone;
        private Label playertwo;
        private Label winner;
        private Button endturn;
    }
}