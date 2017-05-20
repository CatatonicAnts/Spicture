using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;

namespace Spicture {
	class Program {
		static NotificationIcon TrayIcon;
		static bool Running;

		[STAThread]
		static void Main(string[] args) {
			/*
#if DEBUG
			if (!Debugger.IsAttached)
				Debugger.Launch();
#endif*/

			Running = true;
			TrayIcon = new NotificationIcon("Spicture", "silkicons/camera.png");
			
			TrayIcon.AddItem(TrayIcon.CreateMenuItem("silkicons/tick.png", "Test", () => {
				API.UsingScreenGraphics((Gfx) => {
					Gfx.Clear(Color.Black);
					Thread.Sleep(2000);
					Gfx.Clear(Color.Red);
				});
			}));

			TrayIcon.AddItem(TrayIcon.CreateSeparator());
			TrayIcon.AddItem(TrayIcon.CreateMenuItem("silkicons/cancel.png", "Exit", () => Running = false));

			while (Running) {
				Application.DoEvents();
				Thread.Sleep(50);
			}

			TrayIcon.Dispose();
			Environment.Exit(0);
		}
	}
}
