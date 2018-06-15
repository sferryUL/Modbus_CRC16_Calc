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
            int i, j;
            int CRCResult = 0xFFFF, CRC16Upper = 0, CRC16Lower = 0, XOR = 0;
            int[] buffer = new int[] { 0x01, 0x08, 0x00, 0x00, 0xA5, 0x37 };
            int XORVal = 0xA001;

            for (i = 0; i < buffer.Length; i++)
            {
                CRCResult ^= buffer[i];
                for (j = 0; j < 8; j++)
                {
                    XOR = CRCResult & 0x01;
                    CRCResult >>= 1;

                    if (XOR > 0)
                        CRCResult ^= XORVal;

                }
            }

            CRC16Upper = CRCResult & 0x00FF;
            CRC16Lower = (CRCResult & 0xFF00) >> 8;
            txtModCRC16Result.Text = "0x" + CRCResult.ToString("X");
            txtModCRC16Upper.Text = CRC16Upper.ToString("X");
            txtModCRC16Lower.Text = CRC16Lower.ToString("X");
        }
    }
}
