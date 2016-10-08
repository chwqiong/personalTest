namespace Bluetooth {
	enum BleModelType
	{
		BLE_MOVE,
		BLE_VOICE
	};

	enum MotionRejectoryType
	{
		Rejectory1 = 0,
		Rejectory2,
		Rejectory3,
		Rejectory4
	};

	struct Instruction {
		byte speed;
		short time;
		short lightIdx;
		short soundIdx;
		byte skillIdx;
	};

	class BLE {
		public static string KEY_MOVE_SPEED_L = "speed_l";
		public static string KEY_MOVE_SPEED_R = "speed_r";
		public static string KEY_MOVE_TIME = "time";
		public static string KEY_LIGHT = "light";
		public static string KEY_VOICE = "voice";

		public static int[,] MOTION_REJECTORY1_TABLE = new int[,] {
			{90, 80, 2000}, {80, 90, 2000},
			{90, 80, 2000}, {80, 90, 2000}
		};
		public static int[,] MOTION_REJECTORY2_TABLE = new int[,] {
			{70, 70, 2000},{70, -70, 200},{70, 70, 2000},{-70, 70, 200},
			{70, 70, 2000},{70, -70, 200},{70, 70, 2000},{-70, 70, 200},
			{70, 70, 2000},{70, -70, 200},{70, 70, 2000},{-70, 70, 200},
			{70, 70, 2000},{70, -70, 200},{70, 70, 2000},{-70, 70, 200}
		};
		public static int[,] MOTION_REJECTORY3_TABLE = new int[,] {
			{ 70, 70, 2000 }, { 70, -70, 200 }, { 70, 70, 2000 }, { 70, -70, 400 },
			{ 70, 70, 2000 }, { 70, -70, 200 }, { 70, 70, 2000 }, { 70, -70, 400 },
			{ 70, 70, 2000 }, { 70, -70, 200 }, { 70, 70, 2000 }, { 70, -70, 400 },
			{ 70, 70, 2000 }, { 70, -70, 200 }, { 70, 70, 2000 }, { 70, -70, 400 }
		};
		public static int[,] MOTION_REJECTORY4_TABLE = new int[,] {
			{ 90, 80, 2000 }, { 90, 70, 2000 }, { 90, 80, 2000 }, { 90, 70, 2000 }
		};
	}
}
