using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fortigate_Gui.Script
{
    public class ReadFilter
    {
        private List<string> _lines;
        
        public ReadFilter()
        {
            _lines = new List<string>();
        }
        public List<string> ReadLines()
        {
            using (StreamReader reader = new StreamReader("wwwroot/files/FortiGate_Security_Profiles.txt") )
            {
                while (!reader.EndOfStream)
                {
                    string Line = reader.ReadLine();
                    
                    _lines.Add(Line);
                }
                return _lines;
            }
        }

 
    }
}
