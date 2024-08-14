using System;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using SolidWorks.Interop.swcommands;
using System.IO;
using System.Text;

namespace SLD_getSketchPoints
{
    class Program
    {
        static void Main(string[] args)
        {
            SldWorks swApp = new();
            ModelDoc2 myModel = default(ModelDoc2);
            SelectionMgr SelMgr = default(SelectionMgr);
            Feature myFeature = default(Feature);
            Sketch mySketch = default(Sketch);
            PartDoc myPart = default(PartDoc);
            SketchPoint swSketchPoint;
            object[] sketchPointArray;
            Double x;
            Double y;
            string s;

            myModel = (ModelDoc2)swApp.ActiveDoc;
            SelMgr = (SelectionMgr)myModel.SelectionManager;
            myPart = (PartDoc)myModel;
            myFeature = (Feature)myPart.FeatureByName("Points");
            mySketch = (Sketch)myFeature.GetSpecificFeature2();

            sketchPointArray = (object[])mySketch.GetSketchPoints2();
            StreamWriter sl = new StreamWriter("F:\\Points.csv");

            for(int i = 0; i < sketchPointArray.Length; i++)
            {
                s = "";
                swSketchPoint = (SketchPoint)sketchPointArray[i];
                swSketchPoint.GetCoords();
                swSketchPoint.GetCoords();
                x = swSketchPoint.X*1000;
                y = swSketchPoint.Y*1000;
                s = string.Concat(x.ToString(), ", ", y.ToString());
                sl.WriteLine(s);
            }

            sl.Close();
        }
    }
}
