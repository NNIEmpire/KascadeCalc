using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace cascade_calculator
{
    class swapper : Button
    {
        public byte number = 0;
        
        public swapper(byte number)
        {
            this.number = number;
            this.Size = new Size(Cascade.boxSize.Width,24);
            this.Text = "swap";
            this.Location = new Point(Cascade.hold + Cascade.boxSize.Width/2+ (number - 1) * (Cascade.boxSize.Width + Cascade.hold),1);
        }
    }
}
