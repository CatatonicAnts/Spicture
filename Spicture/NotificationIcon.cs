using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace Spicture {
	class NotificationIcon : IDisposable {
		bool Disposed = false;

		NotifyIcon NotifyIcon;
		ContextMenuStrip ContextMenu;

		public NotificationIcon(string Text, string IconFile) {
			NotifyIcon = new NotifyIcon();
			NotifyIcon.Icon = API.OpenIcon(IconFile);
			NotifyIcon.Text = Text;
			NotifyIcon.Visible = true;

			ContextMenu = new ContextMenuStrip();
			NotifyIcon.ContextMenuStrip = ContextMenu;
		}

		public void AddItem(object Item) {
			ContextMenu.Items.Add(Item as ToolStripItem);
		}

		public void AddItem(object Item, object SubItem) {
			if (Item is ToolStripMenuItem)
				((ToolStripMenuItem)Item).DropDownItems.Add((ToolStripItem)SubItem);
			else
				throw new Exception("Unknown item type " + Item.GetType());
		}

		public object CreateMenuItem(string IconFile, string Text, Action OnClick = null) {
			ToolStripMenuItem Itm = new ToolStripMenuItem();
			Itm.Text = Text;
			Itm.Image = API.OpenImage(IconFile);

			if (OnClick != null)
				Itm.Click += (S, E) => OnClick();

			return Itm;
		}

		public object CreateSeparator() {
			return new ToolStripSeparator();
		}

		public void Dispose() {
			if (Disposed)
				return;
			Disposed = true;

			NotifyIcon.Visible = false;
		}
	}

	public static partial class API {
		public static Image OpenImage(string ImageFile) {
			return Image.FromFile(ImageFile);
		}

		public static Icon OpenIcon(string IconFile) {
			using (Bitmap Bmp = new Bitmap(OpenImage(IconFile))) {
				return Icon.FromHandle(Bmp.GetHicon());
			}
		}
	}
}
