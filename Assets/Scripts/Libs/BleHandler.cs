using UnityEngine;

namespace Bluetooth {
	class BleHandler {
		private static BleHandler _instance = null;
		private static readonly object SynObject = new object(); // sync object

		public static BleHandler Instance
		{
			get
			{
				if (null == _instance)
				{
					lock (SynObject)
					{
						if (null == _instance)
						{
							_instance = new BleHandler();
						}
					}
				}
				return _instance;
			}
		}

		private BleHandler(){
		}

		public void BleScan()
		{
			using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
				{
					jo.Call("StartBleScan");
				}
			}
		}

		public void BleSendData(string data)
		{
			using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
				{
					jo.Call("SendBleData", data);
				}
			}
		}

		public void BleSendCommand(string cmd)
		{
			using (AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer"))
			{
				using (AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity"))
				{
					jo.Call("SendBleCommand", cmd);
				}
			}
		}
	}
}
