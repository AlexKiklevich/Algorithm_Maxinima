using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means
{
    class ClassesData
    {
        public PointData center { get; set; }
        public List<PointData> ObjectClass { get; set; }
        public ClassesData(int X, int Y, Color color)
        {
            Random r = new Random();
            center = new PointData(X,Y, color);
            ObjectClass = new List<PointData> {  };
        }
    }
}
