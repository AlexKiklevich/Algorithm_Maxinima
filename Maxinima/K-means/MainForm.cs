using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace K_means
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Graphics graph;
        private ClassesData[] classes;
        private Color[] colors = new Color[10] {Color.Green, Color.Purple, Color.Salmon, Color.SeaGreen, Color.Silver, Color.Red, Color.Ivory, Color.Khaki, Color.Lavender, Color.LemonChiffon };
        private PointList pointlist;
        private void RandomButton_Click(object sender, EventArgs e)
        {
            PaintPanel.Refresh();
            Random r = new Random();
            graph = PaintPanel.CreateGraphics();
            pointlist = new PointList(Convert.ToInt32(PointsLabel.Text));
            classes = new ClassesData[0];
            for (int i = 0; i < pointlist.pointcollection.Length; i++)
            {
                Point p = new Point(r.Next(1, 200),r.Next(1, 300));
                pointlist.pointcollection[i] = (new PointData(p.X, p.Y, Color.Red));
            }
            foreach (PointData pd in pointlist.pointcollection)
            {
                graph.DrawRectangle(new Pen(pd.color),
                                            pd.point.X, pd.point.Y, 2, 2);
            }

        }

        private void PointsTrackBar_ValueChanged(object sender, EventArgs e)
        {
            PointsLabel.Text = PointsTrackBar.Value.ToString();
        }

        private void ResultButton_Click(object sender, EventArgs e)
        {
            PaintPanel.Refresh();
            classes = new ClassesData[0];
            Random r = new Random();
            Point p = pointlist.pointcollection[r.Next(0, pointlist.pointcollection.Length)].point;
            Array.Resize(ref classes, classes.Length + 1);
            classes[classes.Length - 1] = (new ClassesData(p.X, p.Y, Color.Black));
            p =  pointlist.pointcollection[Calculate(pointlist, classes.First().center.point)].point;
            Array.Resize(ref classes, classes.Length + 1);
            classes[classes.Length - 1] = (new ClassesData(p.X, p.Y, Color.Black));
            for (int i = 0; i < pointlist.pointcollection.Length; i++)
            {
                int numCluster = Calculate(classes, pointlist.pointcollection[i].point);
                pointlist.pointcollection[i].color = colors[numCluster];
                classes[numCluster].ObjectClass.Add(pointlist.pointcollection[i]);
            }

            MaxPoint mp = NewCenter(classes);
            while (IsValidCenter(mp))
            {
                Array.Resize(ref classes, classes.Length + 1);
                classes[classes.Length - 1] = (new ClassesData(mp.point.X, mp.point.Y, Color.Black));
                for (int i = 0; i < pointlist.pointcollection.Length; i++)
                {
                    int numCluster = Calculate(classes, pointlist.pointcollection[i].point);
                    pointlist.pointcollection[i].color = colors[numCluster];
                    classes[numCluster].ObjectClass.Add(pointlist.pointcollection[i]);
                }
                mp = NewCenter(classes);
            }
            foreach (PointData pd in pointlist.pointcollection)
            {
                graph.DrawRectangle(new Pen(pd.color),
                                            pd.point.X, pd.point.Y, 1, 1);
            }
            for (int i = 0; i < classes.Length; i++)
            {
                Rectangle rect = new Rectangle(classes[i].center.point.X,
                                classes[i].center.point.Y, 10, 10);

                graph.DrawRectangle(new Pen(classes[i].center.color),
                                                            rect);
                graph.FillRectangle(Brushes.Black, rect);
            }
        }
        private bool IsValidCenter(MaxPoint NewPoint)
        {
            double l = 0;
            double[] ll = new double[classes.Length];
            for (int i = 0; i < classes.Length; i++)
            {
               for (int j = 0; j < classes.Length - 1; j++)
                {
                    ll[i] += Math.Sqrt(Math.Pow(classes[j].center.point.X - classes[j + 1].center.point.X, 2) +
                    Math.Pow(classes[j].center.point.Y - classes[j + 1].center.point.Y, 2));
                }
                l += ll[i];
            }
            if (NewPoint.length > l/(classes.Length * 2))
            {
                return true;
            }
            return false;
        }
        private MaxPoint NewCenter (ClassesData[] classes)
        {
            MaxPoint[] points = new MaxPoint[classes.Length];
            MaxPoint p = new MaxPoint(new Point(0,0),0);
            for (int i = 0; i < classes.Length; i++)
            {
                points[i] = Calculate(classes[i]);
            }
            for (int i = 0; i < points.Length - 1; i++)
            {
                if (points[i].length > points[i].length)
                {
                    p = points[i];
                }
                else
                {
                    p = points[i + 1];
                }
            }
            return p;
        }
        private int Calculate(ClassesData[] classes, Point point )
        {
            double tempVar = 0;
            double minDistance = 0;
            int numCluster = 0;
            for (int j = 0; j < classes.Length; j++)
            {
                if (j == 0)
                {
                    tempVar = Math.Sqrt(Math.Pow(classes[j].center.point.X - point.X, 2) + Math.Pow(classes[j].center.point.Y - point.Y, 2));
                    minDistance = tempVar;
                }
                else
                {
                    tempVar = Math.Sqrt(Math.Pow(classes[j].center.point.X - point.X, 2) + Math.Pow(classes[j].center.point.Y - point.Y, 2));
                    if (minDistance > tempVar)
                    {
                        minDistance = tempVar;
                        numCluster = j;
                    }
                }
            }
            return numCluster;
        }
        private int Calculate(PointList points, Point center)
        {
            double tempVar = 0;
            double maxDistance = 0;
            int numPoint = 0;
            for (int j = 0; j < points.pointcollection.Length; j++)
            {
                if (j == 0)
                {
                    tempVar = Math.Sqrt(Math.Pow(points.pointcollection[j].point.X - center.X, 2) + Math.Pow(points.pointcollection[j].point.Y - center.Y, 2));
                    maxDistance = tempVar;
                }
                else
                {
                    tempVar = Math.Sqrt(Math.Pow(points.pointcollection[j].point.X - center.X, 2) + Math.Pow(points.pointcollection[j].point.Y - center.Y, 2));
                    if (maxDistance < tempVar)
                    {
                        maxDistance = tempVar;
                        numPoint = j;
                    }
                }
            }
            return numPoint;
        }
        private MaxPoint Calculate(ClassesData classes)
        {
            double tempVar = 0;
            double maxDistance = 0;
            Point numPoint = new Point(1,1);
            foreach(PointData pd in classes.ObjectClass)
            {
                if (pd == classes.ObjectClass.First())
                {
                    tempVar = Math.Sqrt(Math.Pow(pd.point.X - classes.center.point.X, 2) + Math.Pow(pd.point.Y - classes.center.point.Y, 2));
                    maxDistance = tempVar;
                }
                else
                {
                    tempVar = Math.Sqrt(Math.Pow(pd.point.X - classes.center.point.X, 2) + Math.Pow(pd.point.Y - classes.center.point.Y, 2));
                    if (maxDistance < tempVar)
                    {
                        maxDistance = tempVar;
                        numPoint = pd.point;
                    }
                }
            }
            MaxPoint mp = new MaxPoint(numPoint, maxDistance);
            return mp;
        }
        
        
    }
}
