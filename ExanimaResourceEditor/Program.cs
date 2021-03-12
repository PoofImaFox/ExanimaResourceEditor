using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExanimaResourceEditor {
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] launchArguments) {
            var resrouceFile = launchArguments.FirstOrDefault()
                ?? throw new ArgumentNullException(nameof(launchArguments));

            if (!File.Exists(resrouceFile)) {
                throw new FileNotFoundException($"Could not find '{resrouceFile }'");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ResrouceEditorInterface(resrouceFile));
        }
    }
}
