namespace cucmDashboard
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnListPhones = new Button();
            dataGridView1 = new DataGridView();
            lblPhoneList = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            lblFilter = new Label();
            txtFilter = new TextBox();
            btnGroupByModel = new Button();
            lblDeviceCount = new Label();
            lblCount = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnListPhones
            // 
            btnListPhones.Location = new Point(12, 12);
            btnListPhones.Name = "btnListPhones";
            btnListPhones.Size = new Size(75, 37);
            btnListPhones.TabIndex = 0;
            btnListPhones.Text = "List Phones";
            btnListPhones.UseVisualStyleBackColor = true;
            btnListPhones.Click += btnListPhones_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 83);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(776, 355);
            dataGridView1.TabIndex = 1;
            // 
            // lblPhoneList
            // 
            lblPhoneList.AutoSize = true;
            lblPhoneList.Location = new Point(12, 65);
            lblPhoneList.Name = "lblPhoneList";
            lblPhoneList.Size = new Size(65, 15);
            lblPhoneList.TabIndex = 2;
            lblPhoneList.Text = "Phone List:";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(566, 61);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(71, 15);
            lblFilter.TabIndex = 3;
            lblFilter.Text = "Name Filter:";
            lblFilter.Visible = false;
            // 
            // txtFilter
            // 
            txtFilter.Location = new Point(643, 57);
            txtFilter.Name = "txtFilter";
            txtFilter.Size = new Size(145, 23);
            txtFilter.TabIndex = 4;
            txtFilter.Visible = false;
            txtFilter.TextChanged += txtFilter_TextChanged;
            // 
            // btnGroupByModel
            // 
            btnGroupByModel.Location = new Point(713, 6);
            btnGroupByModel.Name = "btnGroupByModel";
            btnGroupByModel.Size = new Size(75, 48);
            btnGroupByModel.TabIndex = 5;
            btnGroupByModel.Text = "Group by Model";
            btnGroupByModel.UseVisualStyleBackColor = true;
            btnGroupByModel.Visible = false;
            btnGroupByModel.Click += btnGroupByModel_Click;
            // 
            // lblDeviceCount
            // 
            lblDeviceCount.AutoSize = true;
            lblDeviceCount.Location = new Point(12, 450);
            lblDeviceCount.Name = "lblDeviceCount";
            lblDeviceCount.Size = new Size(42, 15);
            lblDeviceCount.TabIndex = 6;
            lblDeviceCount.Text = "Result:";
            // 
            // lblCount
            // 
            lblCount.AutoSize = true;
            lblCount.Location = new Point(54, 450);
            lblCount.Name = "lblCount";
            lblCount.Size = new Size(0, 15);
            lblCount.TabIndex = 7;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 474);
            Controls.Add(lblCount);
            Controls.Add(lblDeviceCount);
            Controls.Add(btnGroupByModel);
            Controls.Add(txtFilter);
            Controls.Add(lblFilter);
            Controls.Add(lblPhoneList);
            Controls.Add(dataGridView1);
            Controls.Add(btnListPhones);
            Name = "Form1";
            Text = "cucmDashboard";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnListPhones;
        private DataGridView dataGridView1;
        private Label lblPhoneList;
        private System.Windows.Forms.Timer timer1;
        private Label lblFilter;
        private TextBox txtFilter;
        private Button btnGroupByModel;
        private Label lblDeviceCount;
        private Label lblCount;
    }
}
