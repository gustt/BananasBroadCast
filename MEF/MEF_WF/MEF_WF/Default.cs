using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;

namespace MEF_WF
{
    public partial class Default : Form
    {
        MEFArchitecture.Program prog { get; set; }
        public Default()
        {
            InitializeComponent();
        }

        private void Default_Load(object sender, EventArgs e)
        {
            prog = new MEFArchitecture.Program();
            prog.Run();
        }
        private void Compose()
        {
            
        }
    }
}
