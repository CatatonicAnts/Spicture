using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Spicture {
	class Program {
		static void Main(string[] args) {

#if DEBUG
			if (!Debugger.IsAttached)
				Debugger.Launch();
#endif


		}
	}
}
