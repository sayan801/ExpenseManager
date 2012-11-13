namespace ExpenseManager
{
    partial class ExpnsMngr
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.mainMenuItem = new System.Windows.Forms.MenuItem();
            this.googleDocMenuItem = new System.Windows.Forms.MenuItem();
            this.saveMonthlyReportMenuItem = new System.Windows.Forms.MenuItem();
            this.changeNameMenuItem = new System.Windows.Forms.MenuItem();
            this.changeSalDateMenuItem = new System.Windows.Forms.MenuItem();
            this.changeUnitMenuItem = new System.Windows.Forms.MenuItem();
            this.aboutenuItem = new System.Windows.Forms.MenuItem();
            this.helpMenuItem = new System.Windows.Forms.MenuItem();
            this.QuitMenuItem = new System.Windows.Forms.MenuItem();
            this.addExpenseBtn = new System.Windows.Forms.Button();
            this.addCreditBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.availBalLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.totExpLabel = new System.Windows.Forms.Label();
            this.expenseDetailsLabel = new System.Windows.Forms.Label();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.Add(this.mainMenuItem);
            this.mainMenu1.MenuItems.Add(this.QuitMenuItem);
            // 
            // mainMenuItem
            // 
            this.mainMenuItem.MenuItems.Add(this.googleDocMenuItem);
            this.mainMenuItem.MenuItems.Add(this.saveMonthlyReportMenuItem);
            this.mainMenuItem.MenuItems.Add(this.changeNameMenuItem);
            this.mainMenuItem.MenuItems.Add(this.changeSalDateMenuItem);
            this.mainMenuItem.MenuItems.Add(this.changeUnitMenuItem);
            this.mainMenuItem.MenuItems.Add(this.aboutenuItem);
            this.mainMenuItem.MenuItems.Add(this.helpMenuItem);
            this.mainMenuItem.Text = "Menu";
            // 
            // googleDocMenuItem
            // 
            this.googleDocMenuItem.Text = "Upload to Google Docs";
            this.googleDocMenuItem.Click += new System.EventHandler(this.googleDocMenuItem_Click);
            // 
            // saveMonthlyReportMenuItem
            // 
            this.saveMonthlyReportMenuItem.Text = "Save Monthly Report";
            this.saveMonthlyReportMenuItem.Click += new System.EventHandler(this.saveMonthlyReportMenuItem_Click);
            // 
            // changeNameMenuItem
            // 
            this.changeNameMenuItem.Text = "Change Name";
            this.changeNameMenuItem.Click += new System.EventHandler(this.changeNameMenuItem_Click);
            // 
            // changeSalDateMenuItem
            // 
            this.changeSalDateMenuItem.Text = "Change Salary Date";
            this.changeSalDateMenuItem.Click += new System.EventHandler(this.changeSalDateMenuItem_Click);
            // 
            // changeUnitMenuItem
            // 
            this.changeUnitMenuItem.Text = "Change Unit";
            this.changeUnitMenuItem.Click += new System.EventHandler(this.changeUnitMenuItem_Click);
            // 
            // aboutenuItem
            // 
            this.aboutenuItem.Text = "About";
            this.aboutenuItem.Click += new System.EventHandler(this.aboutenuItem_Click);
            // 
            // helpMenuItem
            // 
            this.helpMenuItem.Text = "Help";
            this.helpMenuItem.Click += new System.EventHandler(this.helpMenuItem_Click);
            // 
            // QuitMenuItem
            // 
            this.QuitMenuItem.Text = "Quit";
            this.QuitMenuItem.Click += new System.EventHandler(this.QuitMenuItem_Click);
            // 
            // addExpenseBtn
            // 
            this.addExpenseBtn.Location = new System.Drawing.Point(3, 245);
            this.addExpenseBtn.Name = "addExpenseBtn";
            this.addExpenseBtn.Size = new System.Drawing.Size(111, 20);
            this.addExpenseBtn.TabIndex = 0;
            this.addExpenseBtn.Text = "Add Expense";
            this.addExpenseBtn.Click += new System.EventHandler(this.addExpenseBtn_Click);
            // 
            // addCreditBtn
            // 
            this.addCreditBtn.Location = new System.Drawing.Point(130, 245);
            this.addCreditBtn.Name = "addCreditBtn";
            this.addCreditBtn.Size = new System.Drawing.Size(107, 20);
            this.addCreditBtn.TabIndex = 1;
            this.addCreditBtn.Text = "Add Credit";
            this.addCreditBtn.Click += new System.EventHandler(this.addCreditBtn_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(3, 217);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 19);
            this.label1.Text = "Available Balance:   INR";
            // 
            // availBalLabel
            // 
            this.availBalLabel.Location = new System.Drawing.Point(169, 217);
            this.availBalLabel.Name = "availBalLabel";
            this.availBalLabel.Size = new System.Drawing.Size(66, 18);
            this.availBalLabel.Text = "0.00";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(163, 18);
            this.label2.Text = "Total Expenses:     INR";
            // 
            // totExpLabel
            // 
            this.totExpLabel.Location = new System.Drawing.Point(169, 188);
            this.totExpLabel.Name = "totExpLabel";
            this.totExpLabel.Size = new System.Drawing.Size(66, 18);
            this.totExpLabel.Text = "0.00";
            // 
            // expenseDetailsLabel
            // 
            this.expenseDetailsLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.expenseDetailsLabel.Location = new System.Drawing.Point(169, 0);
            this.expenseDetailsLabel.Name = "expenseDetailsLabel";
            this.expenseDetailsLabel.Size = new System.Drawing.Size(66, 149);
            this.expenseDetailsLabel.Text = "No Expenses     :-)";
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(0, 0);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.Size = new System.Drawing.Size(163, 149);
            this.monthCalendar1.TabIndex = 7;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // infoLabel
            // 
            this.infoLabel.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Italic);
            this.infoLabel.Location = new System.Drawing.Point(6, 156);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(228, 32);
            this.infoLabel.Text = "Welcome to Expense Manger";
            // 
            // ExpnsMngr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(240, 268);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.expenseDetailsLabel);
            this.Controls.Add(this.totExpLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.availBalLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addCreditBtn);
            this.Controls.Add(this.addExpenseBtn);
            this.ForeColor = System.Drawing.SystemColors.ControlDark;
            this.Menu = this.mainMenu1;
            this.Name = "ExpnsMngr";
            this.Text = "Expense Manger";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem mainMenuItem;
        private System.Windows.Forms.MenuItem changeNameMenuItem;
        private System.Windows.Forms.MenuItem changeSalDateMenuItem;
        private System.Windows.Forms.MenuItem QuitMenuItem;
        private System.Windows.Forms.Button addExpenseBtn;
        private System.Windows.Forms.Button addCreditBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label availBalLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label totExpLabel;
        private System.Windows.Forms.Label expenseDetailsLabel;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.MenuItem changeUnitMenuItem;
        private System.Windows.Forms.MenuItem aboutenuItem;
        private System.Windows.Forms.MenuItem helpMenuItem;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.MenuItem googleDocMenuItem;
        private System.Windows.Forms.MenuItem saveMonthlyReportMenuItem;
    }
}

