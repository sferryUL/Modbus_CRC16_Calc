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
            ushort ModbusCRC16;
            byte CRC16Upper, CRC16Lower;
            List<byte> buffer = new List<byte>();
            List<byte> BuffModBus = new List<byte>();

            if (txtDataBuffer.Text == "")
                return;

            // Determine the number of bytes that have been entered into the data field.
            BuffSize = GetNumBytes(txtDataBuffer.Text);

            buffer = CreateDataBuffer(txtDataBuffer.Text);
            ModbusCRC16 = CalcModbusCRC16(buffer); // Calculate Modbus CRC-16 based on the data buffer

            // Fill in all the text boxes with the CRC-16 result, both combined and split.
            CRC16Upper = (byte)(ModbusCRC16 & 0x00FF);
            CRC16Lower = (byte)(ModbusCRC16 >> 8);

            buffer = CombineBuffandCRC16(buffer, ModbusCRC16);
            txtDataBuffComplete.Text = CreateDataBufferString(buffer);

            txtBuffSize.Text = BuffSize.ToString();
            txtModCRC16Result.Text = "0x" + ModbusCRC16.ToString("X");
            txtModCRC16Upper.Text = CRC16Upper.ToString("X");
            txtModCRC16Lower.Text = CRC16Lower.ToString("X");
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtDataBuffer.Clear();
            txtBuffSize.Clear();
            txtModCRC16Result.Clear();
            txtModCRC16Upper.Clear();
            txtModCRC16Lower.Clear();
            txtDataBuffComplete.Clear();
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

        private List<byte> CombineBuffandCRC16(List<byte> p_DataBuffer, ushort ModbusCRC16)
        {
            p_DataBuffer.Add((byte)(ModbusCRC16 & 0x00FF));
            p_DataBuffer.Add((byte)(ModbusCRC16 >> 8));

            return p_DataBuffer;
        }

        private string CreateDataBufferString(List<byte> p_DataBuffer)
        {
            string RetVal = "";

            for (ushort i = 0; i < p_DataBuffer.Count; i++)
            {
                RetVal += ("0x" + p_DataBuffer[i].ToString("X2") + " ");
            }

            return RetVal;
        }

    }
}
