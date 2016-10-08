using System.Collections.Generic;
using System.Threading;
using Utils;
using UnityEngine;

namespace Bluetooth
{
    using Model;
    namespace Controller
    {
        class BleController
        {
            private MoveModel moveModel;
            private VoiceModel voiceModel;

            private static BleController _instance = null;
            private static readonly object SynObject = new object(); // sync object

            public static BleController Instance
            {
                get
                {
                    if (null == _instance)
                    {
                        lock (SynObject)
                        {
                            if (null == _instance)
                            {
                                _instance = new BleController();
                            }
                        }
                    }
                    return _instance;
                }
            }

            private BleController()
            {
                moveModel = new MoveModel();
                voiceModel = new VoiceModel();
            }

			public void Transfer(BleModelType type, Dictionary<string, int> dict)
            {
				byte[] packet = null;
                switch (type)
                {
                    case BleModelType.BLE_MOVE:
						packet = moveModel.genPacket(dict);
                        break;
                    case BleModelType.BLE_VOICE:
						packet = voiceModel.genPacket(dict);
                        break;
                    default:
                        break;
				}
				if (packet != null && packet.Length == 16) {
					string pstr = HexString.Bytes2hex(packet);
					BleHandler.Instance.BleSendCommand(pstr);
				}
            }

            public void Receiver(string msg)
            {
                // TODO
            }

			#region rejectory
			public IEnumerable<Dictionary<string, int>> Trajectory(MotionRejectoryType type) {
				int[,] table = null;
				switch (type) {
				case MotionRejectoryType.Rejectory1:
					table = BLE.MOTION_REJECTORY1_TABLE;
					break;
				case MotionRejectoryType.Rejectory2:
					table = BLE.MOTION_REJECTORY2_TABLE;
					break;
				case MotionRejectoryType.Rejectory3:
					table = BLE.MOTION_REJECTORY3_TABLE;
					break;
				case MotionRejectoryType.Rejectory4:
					table = BLE.MOTION_REJECTORY4_TABLE;
					break;
				default:
					break;
				}
				if (null != table) {
					for (int i = 0; i < table.GetLength (0); i++) {
						Dictionary<string, int> dict = new Dictionary<string, int> ();
						dict [BLE.KEY_MOVE_SPEED_L] = table [i, 0];
						dict [BLE.KEY_MOVE_SPEED_R] = table [i, 1];
						dict [BLE.KEY_MOVE_TIME] = table [i, 2];
						yield return dict;
					}
				}
			}
			#endregion
        }
    }
}
