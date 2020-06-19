using System;

namespace question5
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new PcBuilder("Laptop", "Intel Corei3", "8 GB");

            builder.SetGraphics("2GB Nvidia")
                .SetHardDisk("250GB SSD")
                .SetMonitor("Del 21inc HD Monitor")
                .SetOs("Windows 10 Pro");

            builder.GetPc();

        }
    }
}
