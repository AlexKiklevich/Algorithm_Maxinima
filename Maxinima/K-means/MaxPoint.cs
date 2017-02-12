using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means
{
    public class MaxPoint
    {
        public Point point { get; set; }
        public double length { get; set; }
        public MaxPoint (Point _point, double _length)
        {
            point = _point;
            length = _length;
        }
    }
}
