namespace TicketSupport.Desktop
{
    partial class DashboardForm
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
            dgvTickets = new DataGridView();
            btnCreate = new Button();
            btnAssign = new Button();
            btnStatus = new Button();
            btnComment = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
            SuspendLayout();
            // 
            // dgvTickets
            // 
            dgvTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTickets.Location = new Point(153, 130);
            dgvTickets.Name = "dgvTickets";
            dgvTickets.Size = new Size(549, 198);
            dgvTickets.TabIndex = 0;
            // 
            // btnCreate
            // 
            btnCreate.Location = new Point(164, 101);
            btnCreate.Name = "btnCreate";
            btnCreate.Size = new Size(108, 23);
            btnCreate.TabIndex = 1;
            btnCreate.Text = "Create Ticket";
            btnCreate.UseVisualStyleBackColor = true;
            btnCreate.Click += btnCreate_Click;
            // 
            // btnAssign
            // 
            btnAssign.Location = new Point(300, 101);
            btnAssign.Name = "btnAssign";
            btnAssign.Size = new Size(100, 23);
            btnAssign.TabIndex = 2;
            btnAssign.Text = "Assign Ticket";
            btnAssign.UseVisualStyleBackColor = true;
            btnAssign.Click += btnAssign_Click;
            // 
            // btnStatus
            // 
            btnStatus.Location = new Point(423, 101);
            btnStatus.Name = "btnStatus";
            btnStatus.Size = new Size(90, 23);
            btnStatus.TabIndex = 3;
            btnStatus.Text = "Update Status";
            btnStatus.UseVisualStyleBackColor = true;
            btnStatus.Click += btnStatus_Click;
            // 
            // btnComment
            // 
            btnComment.Location = new Point(536, 101);
            btnComment.Name = "btnComment";
            btnComment.Size = new Size(108, 23);
            btnComment.TabIndex = 4;
            btnComment.Text = "Add Comment";
            btnComment.UseVisualStyleBackColor = true;
            btnComment.Click += btnComment_Click;
            // 
            // DashboardForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnComment);
            Controls.Add(btnStatus);
            Controls.Add(btnAssign);
            Controls.Add(btnCreate);
            Controls.Add(dgvTickets);
            Name = "DashboardForm";
            Text = "DashboardForm";
            ((System.ComponentModel.ISupportInitialize)dgvTickets).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvTickets;
        private Button btnCreate;
        private Button btnAssign;
        private Button btnStatus;
        private Button btnComment;
    }
}