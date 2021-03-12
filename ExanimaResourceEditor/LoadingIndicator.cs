using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExanimaResourceEditor {
    public partial class LoadingIndicator : Form {
        public LoadingIndicator(string message, Task runningTask) {
            InitializeComponent();

            messageLabel.Text = message;
            runningTask.ContinueWith((task) =>
            Invoke((MethodInvoker)delegate () {
                Close();
            }));
        }
    }
}
