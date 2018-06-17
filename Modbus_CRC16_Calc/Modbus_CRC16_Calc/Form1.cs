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
            ushort BuffSize = 0;
            int ModbusCRC16, CRC16Upper = 0, CRC16Lower = 0;
            List<byte> buffer = new List<byte>();

            if (txtDataBuffer.Text == "")
                return;

            // Determine the number of bytes that have been entered into the data field.
            BuffSize = GetNumBytes(txtDataBuffer.Text);

            buffer = CreateDataBuffer(txtDataBuffer.Text);
            ModbusCRC16 = CalcModbusCRC16(buffer); // Calculate Modbus CRC-16 based on the data buffer

            // Fill in all the text boxes with the CRC-16 result, both combined and split.
            CRC16Upper = ModbusCRC16 & 0x00FF;
            CRC16Lower = (ModbusCRC16 & 0xFF00) >> 8;

            txtBuffSize.Text = BuffSize.ToString();
            txtModCRC16Result.Text = "0x" + ModbusCRC16.ToString("X");
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

        private ushort GetNumBytes(string p_Buffer)
        {
            ushort BuffSize = 0;
            Char c;

            p_Buffer = p_Buffer.Trim();
            p_Buffer = p_Buffer.PadRight(p_Buffer.Length + 1);
            for (int ctr = 0; ctr < p_Buffer.Length; ctr++)
            {
                c = p_Buffer[ctr];
                if (Char.IsWhiteSpace(p_Buffer[ctr]))
                    BuffSize++;
            }

            return BuffSize;
        }

        private List<byte> CreateDataBuffer(string p_Buffer)
        {
            string[] HexBuffer;
            List<byte> RetVal = new List<byte>();

            p_Buffer = p_Buffer.Trim();
            HexBuffer = p_Buffer.Split(' ');
            foreach (String HexStr in HexBuffer)
            {
                byte HexVal = Convert.ToByte(HexStr, 16);
                RetVal.Add(HexVal);
            }

            return RetVal;
        }

        private ushort CalcModbusCRC16(List<byte>p_DataBuffer)
        {
            ushort CRCResult = 0xFFFF, XORVal = 0xA001, XOR = 0x0000;

            for (int i = 0; i < p_DataBuffer.Count; i++)
            {
                CRCResult ^= p_DataBuffer[i];
                for (int j = 0; j < 8; j++)
                {
                    XOR = (ushort)(CRCResult & 0x0001);
                    CRCResult >>= 1;

                    if (XOR > 0)
                        CRCResult ^= XORVal;
                }
            }

            return CRCResult;
        }
    }
}
