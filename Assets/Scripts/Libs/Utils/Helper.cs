namespace Utils{
	class Helper {
		public static byte Int2Byte(int val) {
			if (val >= 0) {
				return (byte)(val & 0xff);
			} else {
				return (byte)(0xff + val + 1);
			}
		}
	}
}