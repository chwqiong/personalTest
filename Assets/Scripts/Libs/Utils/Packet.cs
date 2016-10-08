using System;
using System.Text;

namespace Utils
{
    class Packet
    {
        private const int MAX_DATA_LEN = 13;
        public static string StrPacket(byte cmd, byte[] data)
        {
            byte[] packet = encryptPacket(cmd, data);
            return UTF8Encoding.UTF8.GetString(packet);
        }
        public static byte[] encryptPacket(byte cmd, byte[] data)
        {
            byte[] raw = BlePackage(cmd, data);
			// DEBUG: disable encrypt
            // return AES.Encrypt(raw);
			return raw;
        }

        private static byte[] BlePackage(byte cmd, byte[] data)
        {
            byte[] packet = new byte[16];
            packet[0] = 0x55;
            packet[1] = cmd;
            byte len = (byte)Math.Min(data.Length, MAX_DATA_LEN);
            packet[2] = len;
            Buffer.BlockCopy(data, 0, packet, 3, len);
            return packet;
        }
    }
}
