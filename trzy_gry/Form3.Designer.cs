namespace trzy_gry
{
    partial class Form3
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
            start = new Button();
            fold = new Button();
            check = new Button();
            rise = new Button();
            call = new Button();
            player1 = new Label();
            player0 = new Label();
            player2 = new Label();
            player3 = new Label();
            pot = new Label();
            messege = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // start
            // 
            start.Font = new Font("Visitor TT1 BRK", 44.9999962F, FontStyle.Regular, GraphicsUnit.Point, 0);
            start.Location = new Point(502, 233);
            start.Name = "start";
            start.Size = new Size(423, 205);
            start.TabIndex = 0;
            start.Text = "StarT";
            start.UseVisualStyleBackColor = true;
            start.Click += start_Click;
            // 
            // fold
            // 
            fold.Location = new Point(610, 655);
            fold.Name = "fold";
            fold.Size = new Size(75, 23);
            fold.TabIndex = 1;
            fold.Text = "FOLd";
            fold.UseVisualStyleBackColor = true;
            fold.Click += fold_Click;
            // 
            // check
            // 
            check.Location = new Point(963, 655);
            check.Name = "check";
            check.Size = new Size(75, 23);
            check.TabIndex = 2;
            check.Text = "cHeCK";
            check.UseVisualStyleBackColor = true;
            check.Click += check_Click;
            // 
            // rise
            // 
            rise.Location = new Point(850, 655);
            rise.Name = "rise";
            rise.Size = new Size(75, 23);
            rise.TabIndex = 3;
            rise.Text = "RisE";
            rise.UseVisualStyleBackColor = true;
            rise.Click += rise_Click;
            // 
            // call
            // 
            call.Location = new Point(733, 655);
            call.Name = "call";
            call.Size = new Size(75, 23);
            call.TabIndex = 4;
            call.Text = "CaLL";
            call.UseVisualStyleBackColor = true;
            call.Click += call_Click;
            // 
            // player1
            // 
            player1.AutoSize = true;
            player1.Location = new Point(256, 79);
            player1.Name = "player1";
            player1.Size = new Size(38, 15);
            player1.TabIndex = 5;
            player1.Text = "label1";
            // 
            // player0
            // 
            player0.AutoSize = true;
            player0.Location = new Point(43, 410);
            player0.Name = "player0";
            player0.Size = new Size(38, 15);
            player0.TabIndex = 6;
            player0.Text = "label1";
            // 
            // player2
            // 
            player2.AutoSize = true;
            player2.Location = new Point(1303, 140);
            player2.Name = "player2";
            player2.Size = new Size(38, 15);
            player2.TabIndex = 7;
            player2.Text = "label1";
            // 
            // player3
            // 
            player3.AutoSize = true;
            player3.Location = new Point(1061, 606);
            player3.Name = "player3";
            player3.Size = new Size(38, 15);
            player3.TabIndex = 8;
            player3.Text = "label1";
            // 
            // pot
            // 
            pot.AutoSize = true;
            pot.Font = new Font("Segoe UI", 20F);
            pot.Location = new Point(777, 182);
            pot.Name = "pot";
            pot.Size = new Size(90, 37);
            pot.TabIndex = 9;
            pot.Text = "label1";
            // 
            // messege
            // 
            messege.AutoSize = true;
            messege.Location = new Point(643, 591);
            messege.Name = "messege";
            messege.Size = new Size(53, 15);
            messege.TabIndex = 10;
            messege.Text = "messege";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(1148, 9);
            label1.Name = "label1";
            label1.Size = new Size(336, 15);
            label1.TabIndex = 11;
            label1.Text = "to do next action after clicking button click somwere on board";
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1496, 690);
            Controls.Add(label1);
            Controls.Add(messege);
            Controls.Add(pot);
            Controls.Add(player3);
            Controls.Add(player2);
            Controls.Add(player0);
            Controls.Add(player1);
            Controls.Add(call);
            Controls.Add(rise);
            Controls.Add(check);
            Controls.Add(fold);
            Controls.Add(start);
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button start;
        private Button fold;
        private Button check;
        private Button rise;
        private Button call;
        private Label player1;
        private Label player0;
        private Label player2;
        private Label player3;
        private Label pot;
        private Label messege;
        private Label label1;
    }
}