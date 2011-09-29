using System;
using System.Linq;
using System.Reflection;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using MEFArchitecture.App_Interfaces;

namespace MEFArchitecture
{
    public class Program
    {
        [Import]
        public IDiagnostic Diagnostic { get; set; }

        public Program()
        {
        }

        public void Run()
        {
            Compose();
            for (int i = 0; i < 10; i++)
                Diagnostic.OutputMessage("Mensagem de teste!!!!");
        }

        private void Compose()
        {
            var container = new CompositionContainer();
            container.ComposeParts(this, new App_Exports.Diagnostics.OutputMonitor());
            
        }
    }
}
