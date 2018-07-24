namespace XmlCompare
{
    partial class XmCompare
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtzipfilepath = new System.Windows.Forms.TextBox();
            this.btnUnzip = new System.Windows.Forms.Button();
            this.txtextractpath = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtfiletype = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCompare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ZipFile Path";
            // 
            // txtzipfilepath
            // 
            this.txtzipfilepath.Location = new System.Drawing.Point(130, 26);
            this.txtzipfilepath.Name = "txtzipfilepath";
            this.txtzipfilepath.Size = new System.Drawing.Size(271, 20);
            this.txtzipfilepath.TabIndex = 1;
            // 
            // btnUnzip
            // 
            this.btnUnzip.Location = new System.Drawing.Point(90, 142);
            this.btnUnzip.Name = "btnUnzip";
            this.btnUnzip.Size = new System.Drawing.Size(75, 23);
            this.btnUnzip.TabIndex = 2;
            this.btnUnzip.Text = "Unzip";
            this.btnUnzip.UseVisualStyleBackColor = true;
            this.btnUnzip.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtextractpath
            // 
            this.txtextractpath.Location = new System.Drawing.Point(130, 67);
            this.txtextractpath.Name = "txtextractpath";
            this.txtextractpath.Size = new System.Drawing.Size(271, 20);
            this.txtextractpath.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Extract Path";
            // 
            // txtfiletype
            // 
            this.txtfiletype.Location = new System.Drawing.Point(128, 104);
            this.txtfiletype.Name = "txtfiletype";
            this.txtfiletype.Size = new System.Drawing.Size(97, 20);
            this.txtfiletype.TabIndex = 6;
            this.txtfiletype.Text = ".xml";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(98, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "File Type to Extract";
            // 
            // btnCompare
            // 
            this.btnCompare.Location = new System.Drawing.Point(203, 142);
            this.btnCompare.Name = "btnCompare";
            this.btnCompare.Size = new System.Drawing.Size(75, 23);
            this.btnCompare.TabIndex = 7;
            this.btnCompare.Text = "Compare";
            this.btnCompare.UseVisualStyleBackColor = true;
            this.btnCompare.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // XmCompare
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 262);
            this.Controls.Add(this.btnCompare);
            this.Controls.Add(this.txtfiletype);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtextractpath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnUnzip);
            this.Controls.Add(this.txtzipfilepath);
            this.Controls.Add(this.label1);
            this.Name = "XmCompare";
            this.Text = "Xml Compare";
            this.Load += new System.EventHandler(this.XmCompare_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtzipfilepath;
        private System.Windows.Forms.Button btnUnzip;
        private System.Windows.Forms.TextBox txtextractpath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtfiletype;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCompare;
    }
}

