using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Modbus_CRC16_Calc
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnCalcModCRC16_Click(object sender, EventArgs e)
        {
            string tmpBuffer;
            Char c;
            int BuffSize = 0;
            int CRCResult = 0xFFFF, CRC16Upper = 0, CRC16Lower = 0, XOR = 0;
            int[] buffer = new int[] { 0x01, 0x08, 0x00, 0x00, 0xA5, 0x37 };
            string[] hexbuff;
            List<int> buff2 = new List<int>();
            int temp;
            int XORVal = 0xA001;

            if (txtDataBuffer.Text == "")
                return;
            // Determine the number of bytes that have been entered into the data field.
            tmpBuffer = txtDataBuffer.Text;
            tmpBuffer = tmpBuffer.Trim();
            tmpBuffer = tmpBuffer.PadRight(tmpBuffer.Length + 1);
            for(int ctr = 0; ctr < tmpBuffer.Length; ctr++)
            {
                c = tmpBuffer[ctr];
                if (Char.IsWhiteSpace(tmpBuffer[ctr]))
                    BuffSize++;
            }

            tmpBuffer = tmpBuffer.Trim();
            hexbuff = tmpBuffer.Split(' ');
            foreach(String hex in hexbuff)
            {
                int val = Convert.ToInt32(hex, 16);
                buff2.Add(val);
            }

            // Calculate Modbus CRC-16 based on the data buffer
            
            for(int i = 0; i < buff2.Count; i++)
            {
                CRCResult ^= buff2[i];
                for (int j = 0; j < 8; j++)
                {
                    XOR = CRCResult & 0x01;
                    CRCResult >>= 1;

                    if (XOR > 0)
                        CRCResult ^= XORVal;
                }
            }
            
            /*
            for (int i = 0; i < buffer.Length; i++)
            {
                CRCResult ^= buffer[i];
                for (int j = 0; j < 8; j++)
                {
                    XOR = CRCResult & 0x01;
                    CRCResult >>= 1;

                    if (XOR > 0)
                        CRCResult ^= XORVal;
                }
            }
            */

            // Fill in all the text boxes with the CRC-16 result, both combined and split.
            CRC16Upper = CRCResult & 0x00FF;
            CRC16Lower = (CRCResult & 0xFF00) >> 8;
            txtModCRC16Result.Text = "0x" + CRCResult.ToString("X");
            txtModCRC16Upper.Text = CRC16Upper.ToString("X");
            txtModCRC16Lower.Text = CRC16Lower.ToString("X");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDataBuffer.Clear();
            txtModCRC16Result.Clear();
            txtModCRC16Upper.Clear();
            txtModCRC16Lower.Clear();
            txtDataBuffer.Focus();
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            txtDataBuffer.Focus();
        }
    }
}
