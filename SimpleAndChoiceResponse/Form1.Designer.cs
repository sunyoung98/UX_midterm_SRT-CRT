namespace SimpleAndChoiceResponse
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.SRT_startbtn = new System.Windows.Forms.Button();
            this.CRT2_startbtn = new System.Windows.Forms.Button();
            this.CRT4_startbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SRT_startbtn
            // 
            this.SRT_startbtn.Location = new System.Drawing.Point(66, 220);
            this.SRT_startbtn.Name = "SRT_startbtn";
            this.SRT_startbtn.Size = new System.Drawing.Size(187, 58);
            this.SRT_startbtn.TabIndex = 2;
            this.SRT_startbtn.Text = "SRT";
            this.SRT_startbtn.UseVisualStyleBackColor = true;
            this.SRT_startbtn.Click += new System.EventHandler(this.SRT_startbtn_Click);
            // 
            // CRT2_startbtn
            // 
            this.CRT2_startbtn.Location = new System.Drawing.Point(313, 220);
            this.CRT2_startbtn.Name = "CRT2_startbtn";
            this.CRT2_startbtn.Size = new System.Drawing.Size(187, 58);
            this.CRT2_startbtn.TabIndex = 3;
            this.CRT2_startbtn.Text = "2-2 CRT";
            this.CRT2_startbtn.UseVisualStyleBackColor = true;
            this.CRT2_startbtn.Click += new System.EventHandler(this.CRT2_startbtn_Click);
            // 
            // CRT4_startbtn
            // 
            this.CRT4_startbtn.Location = new System.Drawing.Point(555, 220);
            this.CRT4_startbtn.Name = "CRT4_startbtn";
            this.CRT4_startbtn.Size = new System.Drawing.Size(187, 58);
            this.CRT4_startbtn.TabIndex = 4;
            this.CRT4_startbtn.Text = "4-4 CRT";
            this.CRT4_startbtn.UseVisualStyleBackColor = true;
            this.CRT4_startbtn.Click += new System.EventHandler(this.CRT4_startbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("굴림", 24F);
            this.label1.Location = new System.Drawing.Point(204, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(398, 48);
            this.label1.TabIndex = 5;
            this.label1.Text = "SRT & CRT Prototype";
            this.label1.UseCompatibleTextRendering = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CRT4_startbtn);
            this.Controls.Add(this.CRT2_startbtn);
            this.Controls.Add(this.SRT_startbtn);
            this.Name = "Form1";
            this.Text = "SRT&CRT";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button SRT_startbtn;
        private System.Windows.Forms.Button CRT2_startbtn;
        private System.Windows.Forms.Button CRT4_startbtn;
        private System.Windows.Forms.Label label1;
    }
}

