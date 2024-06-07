using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfControlLibrary1
{
    public partial class UserControl1 : UserControl
    {
        public Viewport3D myViewport3D = new Viewport3D();
        public PerspectiveCamera myPCamera = new PerspectiveCamera();
        public int index = 0;
        public Point point = new Point();
        public Point point2 = new Point();

        public UserControl1()
        {
            functions.Add(new Fun1());
            functions.Add(new Fun2());
            functions.Add(new Fun3());
            functions.Add(new Fun4());
            functions.Add(new Fun5());
            myPCamera.Position = new Point3D(9, 9, 9);
            myPCamera.LookDirection = new Vector3D(-9, -9, -9);
            myPCamera.UpDirection = new Vector3D(0, 1, 0);
            myPCamera.FieldOfView = 80;
            myViewport3D.Camera = myPCamera;
            myViewport3D.Children.Add(CreateModel(-5, 5, -5, 5, 0.1, 0.1));
            this.Content = myViewport3D;

        }
        List<IFunction> functions = new List<IFunction>();
        
        public MeshGeometry3D CreateMesh(double xMin, double xMax, double zMin, double zMax, double deltaX, double deltaZ)
        {
            int xSteps = (int)((xMax - xMin) / deltaX) + 1;
            int zSteps = (int)((zMax - zMin) / deltaZ) + 1;
            MeshGeometry3D mesh = new MeshGeometry3D();
            for (int z = 0; z < zSteps; z++)
            {
                double zPos = zMin + z * deltaZ;
                for (int x = 0; x < xSteps; x++)
                {
                    double xPos = xMin + x * deltaX;
                    double u = (double)x / (xSteps - 1);
                    double v = (double)z / (zSteps - 1);
                    mesh.Positions.Add(new Point3D(xPos, functions[index].calc(xPos, zPos), zPos));
                    mesh.TextureCoordinates.Add(new Point(u, 1 - v));

                    if (x > 0 && z > 0)
                    {
                        int p1 = (xSteps * z) + x;
                        int p2 = (xSteps * z) + x - 1;
                        int p3 = (xSteps * (z - 1)) + x - 1;
                        int p4 = (xSteps * (z - 1)) + x;
                        mesh.TriangleIndices.Add(p1);
                        mesh.TriangleIndices.Add(p2);
                        mesh.TriangleIndices.Add(p3);
                        mesh.TriangleIndices.Add(p1);
                        mesh.TriangleIndices.Add(p3);
                        mesh.TriangleIndices.Add(p4);
                    }
                }
            }
            return mesh;
        }
        public GeometryModel3D AxisZ()
        {
            MeshGeometry3D mesh2 = new MeshGeometry3D();
            mesh2.Positions.Add(new Point3D(-0.05, -100, 0));
            mesh2.Positions.Add(new Point3D(0.05, -100, 0));
            mesh2.Positions.Add(new Point3D(-0.05, 100, 0));
            mesh2.Positions.Add(new Point3D(0.05, 100, 0));
            mesh2.TriangleIndices.Add(1);
            mesh2.TriangleIndices.Add(0);
            mesh2.TriangleIndices.Add(2);
            mesh2.TriangleIndices.Add(1);
            mesh2.TriangleIndices.Add(2);
            mesh2.TriangleIndices.Add(3);
            DiffuseMaterial myMaterial3 = new DiffuseMaterial(new SolidColorBrush(Colors.Blue));
            GeometryModel3D model2 = new GeometryModel3D(mesh2, myMaterial3);
            model2.BackMaterial = myMaterial3;
            return model2;
        }
        public GeometryModel3D AxisZ2()
        {
            MeshGeometry3D mesh2 = new MeshGeometry3D();
            mesh2.Positions.Add(new Point3D(0, -100, 0.05));
            mesh2.Positions.Add(new Point3D(0, -100, -0.05));
            mesh2.Positions.Add(new Point3D(0, 100, 0.05));
            mesh2.Positions.Add(new Point3D(0, 100, -0.05));
            mesh2.TriangleIndices.Add(1);
            mesh2.TriangleIndices.Add(0);
            mesh2.TriangleIndices.Add(2);
            mesh2.TriangleIndices.Add(1);
            mesh2.TriangleIndices.Add(2);
            mesh2.TriangleIndices.Add(3);
            DiffuseMaterial myMaterial3 = new DiffuseMaterial(new SolidColorBrush(Colors.Blue));
            GeometryModel3D model2 = new GeometryModel3D(mesh2, myMaterial3);
            model2.BackMaterial = myMaterial3;
            return model2;
        }
        public GeometryModel3D AxisX()
        {
            MeshGeometry3D mesh5 = new MeshGeometry3D();
            mesh5.Positions.Add(new Point3D(-100, 0, -0.05));
            mesh5.Positions.Add(new Point3D(-100, 0, 0.05));
            mesh5.Positions.Add(new Point3D(100, 0, -0.05));
            mesh5.Positions.Add(new Point3D(100, 0, 0.05));
            mesh5.TriangleIndices.Add(1);
            mesh5.TriangleIndices.Add(0);
            mesh5.TriangleIndices.Add(2);
            mesh5.TriangleIndices.Add(1);
            mesh5.TriangleIndices.Add(2);
            mesh5.TriangleIndices.Add(3);
            DiffuseMaterial myMaterial3 = new DiffuseMaterial(new SolidColorBrush(Colors.Red));
            GeometryModel3D model5 = new GeometryModel3D(mesh5, myMaterial3);
            model5.BackMaterial = myMaterial3;
            return model5;
        }
        public GeometryModel3D AxisX2()
        {
            MeshGeometry3D mesh5 = new MeshGeometry3D();
            mesh5.Positions.Add(new Point3D(-100, -0.05, 0));
            mesh5.Positions.Add(new Point3D(-100,0.05, 0));
            mesh5.Positions.Add(new Point3D(100, -0.05, 0));
            mesh5.Positions.Add(new Point3D(100, 0.05, 0));
            mesh5.TriangleIndices.Add(1);
            mesh5.TriangleIndices.Add(0);
            mesh5.TriangleIndices.Add(2);
            mesh5.TriangleIndices.Add(1);
            mesh5.TriangleIndices.Add(2);
            mesh5.TriangleIndices.Add(3);
            DiffuseMaterial myMaterial3 = new DiffuseMaterial(new SolidColorBrush(Colors.Red));
            GeometryModel3D model5 = new GeometryModel3D(mesh5, myMaterial3);
            model5.BackMaterial = myMaterial3;
            return model5;
        }
        public GeometryModel3D AxisY()
        {
            MeshGeometry3D mesh4 = new MeshGeometry3D();
            mesh4.Positions.Add(new Point3D(-0.05, 0, -100));
            mesh4.Positions.Add(new Point3D(0.05, 0, -100));
            mesh4.Positions.Add(new Point3D(-0.05, 0, 100));
            mesh4.Positions.Add(new Point3D(0.05, 0, 100));
            mesh4.TriangleIndices.Add(1);
            mesh4.TriangleIndices.Add(0);
            mesh4.TriangleIndices.Add(2);
            mesh4.TriangleIndices.Add(1);
            mesh4.TriangleIndices.Add(2);
            mesh4.TriangleIndices.Add(3);
            DiffuseMaterial myMaterial3 = new DiffuseMaterial(new SolidColorBrush(Colors.LimeGreen));
            GeometryModel3D model4 = new GeometryModel3D(mesh4, myMaterial3);
            model4.BackMaterial = myMaterial3;
            return model4;
        }
        public GeometryModel3D AxisY2()
        {
            MeshGeometry3D mesh4 = new MeshGeometry3D();
            mesh4.Positions.Add(new Point3D(0, 0.05, -100));
            mesh4.Positions.Add(new Point3D(0, -0.05, -100));
            mesh4.Positions.Add(new Point3D(0, 0.05, 100));
            mesh4.Positions.Add(new Point3D(0, -0.05, 100));
            mesh4.TriangleIndices.Add(1);
            mesh4.TriangleIndices.Add(0);
            mesh4.TriangleIndices.Add(2);
            mesh4.TriangleIndices.Add(1);
            mesh4.TriangleIndices.Add(2);
            mesh4.TriangleIndices.Add(3);
            DiffuseMaterial myMaterial3 = new DiffuseMaterial(new SolidColorBrush(Colors.LimeGreen));
            GeometryModel3D model4 = new GeometryModel3D(mesh4, myMaterial3);
            model4.BackMaterial = myMaterial3;
            return model4;
        }
        public GeometryModel3D Transparentcube()
        {
            MeshGeometry3D mesh7 = new MeshGeometry3D();
            mesh7.Positions.Add(new Point3D(-50, -50, -50));
            mesh7.Positions.Add(new Point3D(-50, 50, -50));
            mesh7.Positions.Add(new Point3D(-50, 50, 50));
            mesh7.Positions.Add(new Point3D(-50, -50, 50));
            mesh7.Positions.Add(new Point3D(50, -50, -50));
            mesh7.Positions.Add(new Point3D(50, 50, -50));
            mesh7.Positions.Add(new Point3D(50, 50, 50));
            mesh7.Positions.Add(new Point3D(50, -50, 50));
            mesh7.TriangleIndices.Add(0);
            mesh7.TriangleIndices.Add(1);
            mesh7.TriangleIndices.Add(2);
            mesh7.TriangleIndices.Add(0);
            mesh7.TriangleIndices.Add(2);
            mesh7.TriangleIndices.Add(3);
            mesh7.TriangleIndices.Add(0);
            mesh7.TriangleIndices.Add(4);
            mesh7.TriangleIndices.Add(5);
            mesh7.TriangleIndices.Add(0);
            mesh7.TriangleIndices.Add(5);
            mesh7.TriangleIndices.Add(1);
            mesh7.TriangleIndices.Add(4);
            mesh7.TriangleIndices.Add(5);
            mesh7.TriangleIndices.Add(7);
            mesh7.TriangleIndices.Add(7);
            mesh7.TriangleIndices.Add(5);
            mesh7.TriangleIndices.Add(6);
            mesh7.TriangleIndices.Add(3);
            mesh7.TriangleIndices.Add(7);
            mesh7.TriangleIndices.Add(6);
            mesh7.TriangleIndices.Add(3);
            mesh7.TriangleIndices.Add(6);
            mesh7.TriangleIndices.Add(2);
            mesh7.TriangleIndices.Add(5);
            mesh7.TriangleIndices.Add(1);
            mesh7.TriangleIndices.Add(2);
            mesh7.TriangleIndices.Add(5);
            mesh7.TriangleIndices.Add(2);
            mesh7.TriangleIndices.Add(6);
            mesh7.TriangleIndices.Add(7);
            mesh7.TriangleIndices.Add(4);
            mesh7.TriangleIndices.Add(3);
            mesh7.TriangleIndices.Add(3);
            mesh7.TriangleIndices.Add(4);
            mesh7.TriangleIndices.Add(0);
            DiffuseMaterial myMaterial7 = new DiffuseMaterial(new SolidColorBrush(Colors.Transparent));
            GeometryModel3D model7 = new GeometryModel3D(mesh7, myMaterial7);
            model7.BackMaterial = myMaterial7;
            return model7;
        }
        public GeometryModel3D Setka()
        {
            MeshGeometry3D mesh3 = new MeshGeometry3D();
            for (int i = -100; i <= 100; i++)
            {
                mesh3.Positions.Add(new Point3D(i + 0.02, 0, -100));
                mesh3.Positions.Add(new Point3D(i - 0.02, 0, -100));
                mesh3.Positions.Add(new Point3D(i - 0.02, 0, 100));
                mesh3.Positions.Add(new Point3D(i + 0.02, 0, -100));
                mesh3.Positions.Add(new Point3D(i - 0.02, 0, 100));
                mesh3.Positions.Add(new Point3D(i + 0.02, 0, 100));
            }
            for (int i = -100; i <= 100; i++)
            {
                mesh3.Positions.Add(new Point3D(-100, 0, i + 0.02));
                mesh3.Positions.Add(new Point3D(-100, 0, i - 0.02));
                mesh3.Positions.Add(new Point3D(100, 0, i - 0.02));
                mesh3.Positions.Add(new Point3D(-100, 0, i + 0.02));
                mesh3.Positions.Add(new Point3D(100, 0, i - 0.02));
                mesh3.Positions.Add(new Point3D(100, 0, i + 0.02));
            }
            DiffuseMaterial myMaterial3 = new DiffuseMaterial(new SolidColorBrush(Colors.Gray));
            GeometryModel3D model3 = new GeometryModel3D(mesh3, myMaterial3);
            model3.BackMaterial = myMaterial3;
            return model3;
        }       
        public ModelVisual3D CreateModel(double xMin, double xMax, double zMin, double zMax, double deltaX, double deltaZ)
        {
            MeshGeometry3D mesh = CreateMesh(xMin, xMax, zMin, zMax, deltaX, deltaZ);
            LinearGradientBrush myHorizontalGradient = new LinearGradientBrush();
            myHorizontalGradient.StartPoint = new Point(0, 0);
            myHorizontalGradient.EndPoint = new Point(1, 1);
            myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Yellow, 0.0));
            myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Red, 0.35));
            myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.Blue, 0.65));
            myHorizontalGradient.GradientStops.Add(new GradientStop(Colors.LimeGreen, 1.00));
            DiffuseMaterial myMaterial = new DiffuseMaterial(myHorizontalGradient);
            GeometryModel3D model = new GeometryModel3D(mesh, myMaterial);
            model.BackMaterial = myMaterial;
            Model3DGroup myModel3DGroup = new Model3DGroup();
            AmbientLight ambient = new AmbientLight(Colors.White);
            myModel3DGroup.Children.Add(ambient);
            myModel3DGroup.Children.Add(model);
            myModel3DGroup.Children.Add(Setka());
            myModel3DGroup.Children.Add(AxisY());
            myModel3DGroup.Children.Add(AxisY2());
            myModel3DGroup.Children.Add(AxisX());
            myModel3DGroup.Children.Add(AxisX2());
            myModel3DGroup.Children.Add(AxisZ());
            myModel3DGroup.Children.Add(AxisZ2());
            myModel3DGroup.Children.Add(Transparentcube());
            ModelVisual3D visual = new ModelVisual3D();
            visual.Content = myModel3DGroup;
            return visual;
        }
        public void update()
        {
            myViewport3D.Children.RemoveAt(0);
            myViewport3D.Children.Add(CreateModel(-5, 5, -5, 5, 0.1, 0.1));
            myPCamera.Position = new Point3D(9, 9, 9);
            myPCamera.LookDirection = new Vector3D(-9, -9, -9);
            myPCamera.UpDirection = new Vector3D(0, 1, 0);
            myPCamera.FieldOfView = 80;
            myViewport3D.Camera = myPCamera;
        }
    }
}

   
