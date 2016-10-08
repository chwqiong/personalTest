using System;
using System.Collections.Generic;
using Utils;

namespace Bluetooth
{
    namespace Model
    {
        class VoiceModel
        {
			public byte[] genPacket(Dictionary<string, int> dict)
			{
				if (!dict.ContainsKey (BLE.KEY_VOICE))
					return null;
				byte cmd = 0x04;
				byte[] data = new byte[2];
				int voice = dict [BLE.KEY_VOICE];
				data [0] = (byte)((voice >> 8) & 0xff);
				data [1] = (byte)(voice & 0xff);

				byte[] packet = Packet.encryptPacket(cmd, data);
				return packet;
            }

			public void Receiver(byte[] packet)
            {
                // TODO
            }
        }
    }
}
