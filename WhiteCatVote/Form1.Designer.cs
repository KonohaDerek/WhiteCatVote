﻿namespace WhiteCatVote
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.nbVote = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nbdely = new System.Windows.Forms.NumericUpDown();
            this.tbResult = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbFbId = new System.Windows.Forms.TextBox();
            this.bgVote = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.nbVote)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbdely)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(381, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "投票";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // nbVote
            // 
            this.nbVote.Location = new System.Drawing.Point(58, 12);
            this.nbVote.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.nbVote.Name = "nbVote";
            this.nbVote.Size = new System.Drawing.Size(120, 22);
            this.nbVote.TabIndex = 1;
            this.nbVote.Value = new decimal(new int[] {
            200,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "票數";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(190, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "延遲(秒)";
            // 
            // nbdely
            // 
            this.nbdely.Location = new System.Drawing.Point(245, 12);
            this.nbdely.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.nbdely.Name = "nbdely";
            this.nbdely.Size = new System.Drawing.Size(120, 22);
            this.nbdely.TabIndex = 3;
            this.nbdely.Value = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            // 
            // tbResult
            // 
            this.tbResult.Location = new System.Drawing.Point(13, 69);
            this.tbResult.Multiline = true;
            this.tbResult.Name = "tbResult";
            this.tbResult.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbResult.Size = new System.Drawing.Size(599, 399);
            this.tbResult.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "FB 文章ID : ";
            // 
            // tbFbId
            // 
            this.tbFbId.Location = new System.Drawing.Point(97, 41);
            this.tbFbId.Name = "tbFbId";
            this.tbFbId.Size = new System.Drawing.Size(268, 22);
            this.tbFbId.TabIndex = 7;
            this.tbFbId.Text = resources.GetString("tbFbId.Text");
            // 
            // bgVote
            // 
            this.bgVote.WorkerReportsProgress = true;
            this.bgVote.WorkerSupportsCancellation = true;
            this.bgVote.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgVote_DoWork);
            this.bgVote.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgVote_ProgressChanged);
            this.bgVote.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgVote_RunWorkerCompleted);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 480);
            this.Controls.Add(this.tbFbId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tbResult);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nbdely);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nbVote);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.nbVote)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nbdely)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.NumericUpDown nbVote;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown nbdely;
        private System.Windows.Forms.TextBox tbResult;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbFbId;
        private System.ComponentModel.BackgroundWorker bgVote;
    }
}

