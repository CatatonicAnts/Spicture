using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Spicture.Native {
	public static class user32 {
		[DllImport(nameof(user32))]
		public static extern IntPtr GetDC(IntPtr HWnd);

		[DllImport(nameof(user32))]
		public static extern IntPtr ReleaseDC(IntPtr HWnd, IntPtr DC);
	}
}
