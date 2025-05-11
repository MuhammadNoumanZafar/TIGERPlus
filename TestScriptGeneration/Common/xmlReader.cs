using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace TestScriptGeneration
{
    class xmlReader
    {
        public xmlReader()
        {
            Signal = new List<Signal>();
        }
        private List<Signal> Signal { get; set; }
        public string Path { get; set; }

        public List<Signal> ReadFile(string path)
        {
            Signal = new List<Signal>();
            //  Console.WriteLine("Getting Signals Information");
            //  Console.WriteLine("================================");
            Path = path;
            if (File.Exists(Path) == false)
            {
                FileStream Fs = File.Create(Path);
                Fs.Dispose();
            }
            try
            {
                XDocument XDOC = XDocument.Load(Path);

                Signal = (from x in XDOC.Root.Descendants("Signal")
                         select
                         new Signal
                         {
                             Stype = (string)x.Element("Type").Value ?? string.Empty,
                             dataType = (string)x.Element("DataType").Value ?? string.Empty,
                             LogicalName = (string)x.Element("LogicalName").Value ?? string.Empty,
                             PrimarySignalName = (string)x.Element("PrimaryTechnicalName").Value ?? string.Empty,
                             SecondarySignalName = (string)x.Element("SecondaryTechnicalName").Value ?? string.Empty,
                             Primary2SignalName = (string)x.Element("Primary2TechnicalName").Value ?? string.Empty,
                             Secondary2SignalName = (string)x.Element("Secondary2TechnicalName").Value ?? string.Empty,
                         }).ToList();

            }
            catch (XmlException e)
            {
                string ex = e.ToString();
            }
            return Signal;

        }
    }
}
