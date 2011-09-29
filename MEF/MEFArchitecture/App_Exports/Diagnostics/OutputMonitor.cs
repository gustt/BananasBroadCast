using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace MEFArchitecture.App_Exports.Diagnostics
{
    [Export(typeof(App_Interfaces.IDiagnostic))]
    public class OutputMonitor : App_Interfaces.IDiagnostic
    {
        public void OutputMessage(string value)
        {
            Debug.WriteLine(value);
        }
    }
}
