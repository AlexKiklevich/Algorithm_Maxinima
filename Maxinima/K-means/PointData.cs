using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means
{
    class PointData
    {
        public Point point { get; set; }
        public Color color { get; set; }
        public PointData(int X, int Y, Color color)
        {
            point = new Point(X, Y);
            this.color = color;
        }
    }

}
