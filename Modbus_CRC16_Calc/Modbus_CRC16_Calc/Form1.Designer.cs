namespace Modbus_CRC16_Calc
{
    partial class frmMain
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
            this.lblDataBuffer = new System.Windows.Forms.Label();
            this.txtDataBuffer = new System.Windows.Forms.TextBox();
            this.txtModCRC16Result = new System.Windows.Forms.TextBox();
            this.lblModCRC16Result = new System.Windows.Forms.Label();
            this.txtModCRC16Upper = new System.Windows.Forms.TextBox();
            this.lblModCRC16Upper = new System.Windows.Forms.Label();
            this.txtModCRC16Lower = new System.Windows.Forms.TextBox();
            this.lblModCRC16Lower = new System.Windows.Forms.Label();
            this.btnCalcModCRC16 = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.txtBuffSize = new System.Windows.Forms.TextBox();
            this.lblBuffSize = new System.Windows.Forms.Label();
            this.txtDataBuffComplete = new System.Windows.Forms.TextBox();
            this.lblDataBuffComplete = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblDataBuffer
            // 
            this.lblDataBuffer.AutoSize = true;
            this.lblDataBuffer.Location = new System.Drawing.Point(13, 13);
            this.lblDataBuffer.Name = "lblDataBuffer";
            this.lblDataBuffer.Size = new System.Drawing.Size(90, 13);
            this.lblDataBuffer.TabIndex = 0;
            this.lblDataBuffer.Text = "Data Buffer (hex):";
            this.lblDataBuffer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataBuffer
            // 
            this.txtDataBuffer.Location = new System.Drawing.Point(103, 10);
            this.txtDataBuffer.Name = "txtDataBuffer";
            this.txtDataBuffer.Size = new System.Drawing.Size(233, 20);
            this.txtDataBuffer.TabIndex = 1;
            // 
            // txtModCRC16Result
            // 
            this.txtModCRC16Result.Location = new System.Drawing.Point(194, 47);
            this.txtModCRC16Result.Name = "txtModCRC16Result";
            this.txtModCRC16Result.ReadOnly = true;
            this.txtModCRC16Result.Size = new System.Drawing.Size(142, 20);
            this.txtModCRC16Result.TabIndex = 3;
            // 
            // lblModCRC16Result
            // 
            this.lblModCRC16Result.AutoSize = true;
            this.lblModCRC16Result.Location = new System.Drawing.Point(67, 50);
            this.lblModCRC16Result.Name = "lblModCRC16Result";
            this.lblModCRC16Result.Size = new System.Drawing.Size(121, 13);
            this.lblModCRC16Result.TabIndex = 2;
            this.lblModCRC16Result.Text = "Modbus CRC-16 Result:";
            this.lblModCRC16Result.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtModCRC16Upper
            // 
            this.txtModCRC16Upper.Location = new System.Drawing.Point(194, 73);
            this.txtModCRC16Upper.Name = "txtModCRC16Upper";
            this.txtModCRC16Upper.ReadOnly = true;
            this.txtModCRC16Upper.Size = new System.Drawing.Size(142, 20);
            this.txtModCRC16Upper.TabIndex = 5;
            // 
            // lblModCRC16Upper
            // 
            this.lblModCRC16Upper.AutoSize = true;
            this.lblModCRC16Upper.Location = new System.Drawing.Point(44, 76);
            this.lblModCRC16Upper.Name = "lblModCRC16Upper";
            this.lblModCRC16Upper.Size = new System.Drawing.Size(144, 13);
            this.lblModCRC16Upper.TabIndex = 4;
            this.lblModCRC16Upper.Text = "Modbus CRC-16 Upper Byte:";
            this.lblModCRC16Upper.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtModCRC16Lower
            // 
            this.txtModCRC16Lower.Location = new System.Drawing.Point(194, 99);
            this.txtModCRC16Lower.Name = "txtModCRC16Lower";
            this.txtModCRC16Lower.ReadOnly = true;
            this.txtModCRC16Lower.Size = new System.Drawing.Size(142, 20);
            this.txtModCRC16Lower.TabIndex = 7;
            // 
            // lblModCRC16Lower
            // 
            this.lblModCRC16Lower.AutoSize = true;
            this.lblModCRC16Lower.Location = new System.Drawing.Point(44, 102);
            this.lblModCRC16Lower.Name = "lblModCRC16Lower";
            this.lblModCRC16Lower.Size = new System.Drawing.Size(144, 13);
            this.lblModCRC16Lower.TabIndex = 6;
            this.lblModCRC16Lower.Text = "Modbus CRC-16 Lower Byte:";
            this.lblModCRC16Lower.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCalcModCRC16
            // 
            this.btnCalcModCRC16.Location = new System.Drawing.Point(12, 151);
            this.btnCalcModCRC16.Name = "btnCalcModCRC16";
            this.btnCalcModCRC16.Size = new System.Drawing.Size(144, 23);
            this.btnCalcModCRC16.TabIndex = 8;
            this.btnCalcModCRC16.Text = "Calculate Modbus CRC-16";
            this.btnCalcModCRC16.UseVisualStyleBackColor = true;
            this.btnCalcModCRC16.Click += new System.EventHandler(this.btnCalcModCRC16_Click);
            // 
            // btnClear
            // 
            this.btnClear.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClear.Location = new System.Drawing.Point(474, 151);
            this.btnClear.MaximumSize = new System.Drawing.Size(75, 23);
            this.btnClear.MinimumSize = new System.Drawing.Size(75, 23);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 9;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // txtBuffSize
            // 
            this.txtBuffSize.Location = new System.Drawing.Point(511, 10);
            this.txtBuffSize.Name = "txtBuffSize";
            this.txtBuffSize.ReadOnly = true;
            this.txtBuffSize.Size = new System.Drawing.Size(38, 20);
            this.txtBuffSize.TabIndex = 11;
            // 
            // lblBuffSize
            // 
            this.lblBuffSize.AutoSize = true;
            this.lblBuffSize.Location = new System.Drawing.Point(384, 13);
            this.lblBuffSize.Name = "lblBuffSize";
            this.lblBuffSize.Size = new System.Drawing.Size(121, 13);
            this.lblBuffSize.TabIndex = 10;
            this.lblBuffSize.Text = "Data Buffer Size (bytes):";
            this.lblBuffSize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDataBuffComplete
            // 
            this.txtDataBuffComplete.Location = new System.Drawing.Point(212, 125);
            this.txtDataBuffComplete.Name = "txtDataBuffComplete";
            this.txtDataBuffComplete.ReadOnly = true;
            this.txtDataBuffComplete.Size = new System.Drawing.Size(337, 20);
            this.txtDataBuffComplete.TabIndex = 13;
            // 
            // lblDataBuffComplete
            // 
            this.lblDataBuffComplete.AutoSize = true;
            this.lblDataBuffComplete.Location = new System.Drawing.Point(13, 128);
            this.lblDataBuffComplete.Name = "lblDataBuffComplete";
            this.lblDataBuffComplete.Size = new System.Drawing.Size(193, 13);
            this.lblDataBuffComplete.TabIndex = 12;
            this.lblDataBuffComplete.Text = "Data Buffer with Modbus CRC-16 (hex):";
            this.lblDataBuffComplete.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnCalcModCRC16;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClear;
            this.ClientSize = new System.Drawing.Size(561, 190);
            this.Controls.Add(this.txtDataBuffComplete);
            this.Controls.Add(this.lblDataBuffComplete);
            this.Controls.Add(this.txtBuffSize);
            this.Controls.Add(this.lblBuffSize);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCalcModCRC16);
            this.Controls.Add(this.txtModCRC16Lower);
            this.Controls.Add(this.lblModCRC16Lower);
            this.Controls.Add(this.txtModCRC16Upper);
            this.Controls.Add(this.lblModCRC16Upper);
            this.Controls.Add(this.txtModCRC16Result);
            this.Controls.Add(this.lblModCRC16Result);
            this.Controls.Add(this.txtDataBuffer);
            this.Controls.Add(this.lblDataBuffer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmMain";
            this.Text = "Modbus CRC-16 Calculator";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblDataBuffer;
        private System.Windows.Forms.TextBox txtDataBuffer;
        private System.Windows.Forms.TextBox txtModCRC16Result;
        private System.Windows.Forms.Label lblModCRC16Result;
        private System.Windows.Forms.TextBox txtModCRC16Upper;
        private System.Windows.Forms.Label lblModCRC16Upper;
        private System.Windows.Forms.TextBox txtModCRC16Lower;
        private System.Windows.Forms.Label lblModCRC16Lower;
        private System.Windows.Forms.Button btnCalcModCRC16;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.TextBox txtBuffSize;
        private System.Windows.Forms.Label lblBuffSize;
        private System.Windows.Forms.TextBox txtDataBuffComplete;
        private System.Windows.Forms.Label lblDataBuffComplete;
    }
}

