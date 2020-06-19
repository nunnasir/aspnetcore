using System;
using System.Collections.Generic;
using System.Text;

namespace question5
{
    public class PcBuilder
    {
        Dictionary<string, string> PcConfigure = new Dictionary<string, string>();

        public PcBuilder(string pcType, string processor, string ramSize)
        {
            PcConfigure.Add("Pc Type", pcType);
            PcConfigure.Add("Processor", processor);
            PcConfigure.Add("RAM", ramSize);
        }

        public PcBuilder SetMonitor(string monitor)
        {
            PcConfigure.Add("Monitor", monitor);
            return this;
        }

        public PcBuilder SetOs(string os)
        {
            PcConfigure.Add("Operating System", os);
            return this;
        }

        public PcBuilder SetHardDisk(string hardDisk)
        {
            PcConfigure.Add("Hard Disk", hardDisk);
            return this;
        }

        public PcBuilder SetGraphics(string graphics)
        {
            PcConfigure.Add("Graphics", graphics);
            return this;
        }

        public void GetPc()
        {
            foreach (var item in PcConfigure)
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }
        }
    }

}
