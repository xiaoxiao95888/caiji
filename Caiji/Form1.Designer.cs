namespace Caiji
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.btn_start = new System.Windows.Forms.Button();
            this.lbl_depname = new System.Windows.Forms.Label();
            this.lbl_depcount = new System.Windows.Forms.Label();
            this.lbl_insname = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_inscount = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.label5 = new System.Windows.Forms.Label();
            this.lbl_clientcount = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbl_clientcounttotal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser1);
            this.splitContainer1.Size = new System.Drawing.Size(1519, 544);
            this.splitContainer1.SplitterDistance = 351;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.btn_start);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lbl_depname);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_clientcounttotal);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_clientcount);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_depcount);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_insname);
            this.splitContainer2.Panel2.Controls.Add(this.label4);
            this.splitContainer2.Panel2.Controls.Add(this.label6);
            this.splitContainer2.Panel2.Controls.Add(this.label5);
            this.splitContainer2.Panel2.Controls.Add(this.lbl_inscount);
            this.splitContainer2.Panel2.Controls.Add(this.label3);
            this.splitContainer2.Panel2.Controls.Add(this.label2);
            this.splitContainer2.Panel2.Controls.Add(this.label1);
            this.splitContainer2.Size = new System.Drawing.Size(351, 544);
            this.splitContainer2.SplitterDistance = 72;
            this.splitContainer2.TabIndex = 0;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(119, 24);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.TabIndex = 0;
            this.btn_start.Text = "Start";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // lbl_depname
            // 
            this.lbl_depname.AutoSize = true;
            this.lbl_depname.Location = new System.Drawing.Point(130, 90);
            this.lbl_depname.Name = "lbl_depname";
            this.lbl_depname.Size = new System.Drawing.Size(31, 15);
            this.lbl_depname.TabIndex = 1;
            this.lbl_depname.Text = "---";
            // 
            // lbl_depcount
            // 
            this.lbl_depcount.AutoSize = true;
            this.lbl_depcount.Location = new System.Drawing.Point(160, 132);
            this.lbl_depcount.Name = "lbl_depcount";
            this.lbl_depcount.Size = new System.Drawing.Size(31, 15);
            this.lbl_depcount.TabIndex = 1;
            this.lbl_depcount.Text = "---";
            // 
            // lbl_insname
            // 
            this.lbl_insname.AutoSize = true;
            this.lbl_insname.Location = new System.Drawing.Point(101, 51);
            this.lbl_insname.Name = "lbl_insname";
            this.lbl_insname.Size = new System.Drawing.Size(31, 15);
            this.lbl_insname.TabIndex = 1;
            this.lbl_insname.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(112, 15);
            this.label4.TabIndex = 0;
            this.label4.Text = "当前医院部门：";
            // 
            // lbl_inscount
            // 
            this.lbl_inscount.AutoSize = true;
            this.lbl_inscount.Location = new System.Drawing.Point(116, 18);
            this.lbl_inscount.Name = "lbl_inscount";
            this.lbl_inscount.Size = new System.Drawing.Size(31, 15);
            this.lbl_inscount.TabIndex = 1;
            this.lbl_inscount.Text = "---";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(142, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "当前医院部门数量：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 15);
            this.label2.TabIndex = 0;
            this.label2.Text = "当前医院：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "当前医院数：";
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(1164, 544);
            this.webBrowser1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 175);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "当前部门医生数量：";
            // 
            // lbl_clientcount
            // 
            this.lbl_clientcount.AutoSize = true;
            this.lbl_clientcount.Location = new System.Drawing.Point(160, 175);
            this.lbl_clientcount.Name = "lbl_clientcount";
            this.lbl_clientcount.Size = new System.Drawing.Size(31, 15);
            this.lbl_clientcount.TabIndex = 1;
            this.lbl_clientcount.Text = "---";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 0;
            this.label6.Text = "总计医生数量：";
            // 
            // lbl_clientcounttotal
            // 
            this.lbl_clientcounttotal.AutoSize = true;
            this.lbl_clientcounttotal.Location = new System.Drawing.Point(123, 226);
            this.lbl_clientcounttotal.Name = "lbl_clientcounttotal";
            this.lbl_clientcounttotal.Size = new System.Drawing.Size(31, 15);
            this.lbl_clientcounttotal.TabIndex = 1;
            this.lbl_clientcounttotal.Text = "---";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1519, 544);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Label lbl_inscount;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_insname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_depcount;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_depname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_clientcount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbl_clientcounttotal;
        private System.Windows.Forms.Label label6;
    }
}

