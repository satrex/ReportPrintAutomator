using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;

namespace Automation
{
    public class FileTraceListener: TraceListener
    {
        private string outputPath;
        public string OutputPath {
            get
            {
                if (outputPath == null)
                    outputPath = @"C:automation.log";

                return this.outputPath;
            }
            set
            {
                this.outputPath = value;
            }
        }
        public override void Write(string message)
        {
            using (var writer = File.AppendText(this.OutputPath))
            {
                writer.Write(message);
            }
        }

        public override void WriteLine(string message)
        {
            using (var writer = File.AppendText(this.OutputPath))
            {
                writer.WriteLine(message);
            }
        }
    }
}
