using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modbus
{
    class ModbusCRC16
    {
        struct Message
        {
            byte ToAddr;
            byte FuncCode;
            List<byte> Payload;
            ushort CRC16;
        }

        Message OutMessage, InMessage;

        public void ConstructMessage(byte p_To, byte p_Code, List<byte> p_Payload, uint CRC16)
        {
            CalcCRC16(p_Payload);
        }

        private ushort CalcCRC16(List<byte> p_DataBuffer)
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
