using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Spicture.Native;

namespace Spicture {
	public static partial class API {
		public static OperatingSystem GetOSVersion() {
			return Environment.OSVersion;
		}

		public static void UsingScreenGraphics(Action<Graphics> Action) {
			IntPtr Desktop = user32.GetDC(IntPtr.Zero);
			using (Graphics G = Graphics.FromHdc(Desktop)) {
				Action(G);
			}
			user32.ReleaseDC(Desktop, IntPtr.Zero);
		}
	}
}