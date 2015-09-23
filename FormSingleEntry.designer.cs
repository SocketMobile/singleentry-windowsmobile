// Copyright 2015 Socket Mobile, Inc.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//
namespace SingleEntryWM
{
    partial class SingleEntryWM
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
            this.textScannedData = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.timerScanners = new System.Windows.Forms.Timer();
            this.btnScan = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textScannedData
            // 
            this.textScannedData.Location = new System.Drawing.Point(1, 79);
            this.textScannedData.Name = "textScannedData";
            this.textScannedData.Size = new System.Drawing.Size(282, 21);
            this.textScannedData.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(1, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.Text = "Scanned Data";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(1, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.Text = "Status:";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(291, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.Text = "label3";
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(1, 26);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(282, 16);
            this.lblStatus.Text = "status";
            // 
            // timerScanners
            // 
            this.timerScanners.Tick += new System.EventHandler(this.timerScanners_Tick_1);
            // 
            // btnScan
            // 
            this.btnScan.Location = new System.Drawing.Point(4, 130);
            this.btnScan.Name = "btnScan";
            this.btnScan.Size = new System.Drawing.Size(75, 23);
            this.btnScan.TabIndex = 6;
            this.btnScan.Text = "&Scan";
            this.btnScan.Click += new System.EventHandler(this.button1_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(110, 234);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(72, 20);
            this.button1.TabIndex = 11;
            this.button1.Text = "Exit";
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // SingleEntryWM
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(240, 274);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnScan);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textScannedData);
            this.Name = "SingleEntryWM";
            this.Text = "Socket SingleEntry";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox textScannedData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Timer timerScanners;
        private System.Windows.Forms.Button btnScan;
        private System.Windows.Forms.Button button1;
    }
}

