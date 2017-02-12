using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace K_means
{
    class PointList
    {
        public PointData[] pointcollection { get; set; }
        public PointList(int count )
        {
            pointcollection = new PointData[count];
        }
    }
}
