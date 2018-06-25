using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modbus
{
    public class ModbusRTU
    {
        byte slaveaddr;
        byte funccode;
        ushort startreg;
        ushort regcount;
        byte databytes;
        List<byte> payload;
        ushort crc16;

        public List<byte> Msg;

        public ModbusRTU()
        {
            slaveaddr = funccode = databytes;
            startreg = regcount = crc16 = 0;
            payload = new List<byte>();
        }

        public ModbusRTU(byte p_ToAddr, byte p_FuncCode, ushort p_StartReg)
        {
            slaveaddr = p_ToAddr;
            funccode = p_FuncCode;
            startreg = p_StartReg;
        }


        public ModbusRTU(byte p_ToAddr, byte p_FuncCode, ushort p_StartReg, ushort p_RegCount, List<byte> p_Payload)
        {
            slaveaddr = p_ToAddr;
            funccode = p_FuncCode;
            startreg = p_StartReg;
            databytes = GetNumDataBytes(p_Payload);
            payload = p_Payload.ToList();
        }

        public byte SlaveAddr
        {
            get => slaveaddr;
            set => slaveaddr = value;
        }

        public byte FuncCode
        {
            get => funccode;
            set => funccode = value;
        }

        public ushort StartReg
        {
            get => startreg;
            set => startreg = value;
        }

        public ushort RegCount
        {
            get => regcount;
            set => regcount = value;
        }

        public ushort DataBytes => databytes;
        public ushort CRC16 => crc16;
        public ushort MsgSize => (ushort)Msg.Count();
        
        public List<byte> CreateMessage(List<byte> p_Payload)
        {
            Msg = new List<byte>();
            
            Msg.Add(slaveaddr);                       // Add slave address to overall message
            Msg.Add(funccode);                        // Add function code to overall message
            Msg.Add((byte)(startreg >> 8));           // Add starting register upper byte
            Msg.Add((byte)(startreg & 0x00FF));       // Add starting register lower byte
            Msg.Add((byte)(regcount >> 8));           // Add register count upper byte
            Msg.Add((byte)(regcount & 0x00FF));       // Add register count lower byte
            Msg.Add(GetNumDataBytes(p_Payload));      // Add number of data bytes in the data payload

            // Add data payload to overall message
            for (int i = 0; i < p_Payload.Count; i++)
                Msg.Add(p_Payload[i]);

            crc16 = CalcModbusRTUCRC16(Msg);               // Calculate the Modbus RTU CRC-16 value

            // Modbus RTU CRC16 is Big-Endian format So lower byte is added first
            Msg.Add((byte)(crc16 & 0x00FF));
            Msg.Add((byte)(crc16 >> 8));

            return Msg;
        }

        private byte GetNumDataBytes(List<byte> p_Payload)
        {
            return (byte)p_Payload.Count();
        }

        private ushort CalcModbusRTUCRC16(List<byte> p_DataBuffer)
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
