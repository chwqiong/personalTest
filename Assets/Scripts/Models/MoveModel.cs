using UnityEngine;
using System;
using System.Collections.Generic;
using Utils;


namespace Bluetooth
{
    namespace Model
    {

        class MoveModel
		{
			public byte[] genPacket(Dictionary<string, int> dict)
			{
				if (!dict.ContainsKey (BLE.KEY_MOVE_SPEED_L) || !dict.ContainsKey (BLE.KEY_MOVE_SPEED_R) || !dict.ContainsKey (BLE.KEY_MOVE_TIME))
					return null;
				byte cmd = 0x02;
				byte[] data = new byte[4];
				data[0] = Helper.Int2Byte(dict [BLE.KEY_MOVE_SPEED_L]);
				data[1] = Helper.Int2Byte(dict [BLE.KEY_MOVE_SPEED_R]);
				int time = dict [BLE.KEY_MOVE_TIME];
				data [2] = (byte)((time >> 8) & 0xff);
				data [3] = (byte)(time & 0xff);

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
