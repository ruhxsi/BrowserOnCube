using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;

namespace BrowserOnCube
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// Install-Package HelixToolkit.Wpf 
    /// </summary>
    public partial class MainWindow : Window
    {
        Random r = new Random();

        public MainWindow()
        {
            InitializeComponent();
            viewRight.ZoomExtentsWhenLoaded = true;
            viewLeft.ZoomExtentsWhenLoaded = true;
            viewLeft.Title = "viewLeft";

            viewRight.Title = viewRight.TriangleCountInfo;
            viewRight.TitleBackground = Brushes.Yellow;
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as Button).Content.ToString());

            cubeRightModel3D.Transform = new RotateTransform3D();
        }

        private void cubeRight_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            cubeRightModel3D.Material = new DiffuseMaterial(Brushes.Red);
        }

        private void cubeRight_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            ImageBrush ib = new ImageBrush();
            // physikalische Ressource
            ib.ImageSource = new BitmapImage(new Uri("../../Jibe.png", UriKind.Relative));

            // oder zufälliges Bild mit 400x400 px
            //ib.ImageSource = new BitmapImage(new Uri(
            //    "http://lorempixel.com/400/400/", UriKind.Absolute));

            cubeRightModel3D.Material = new DiffuseMaterial(ib);
        }

        private void inkCanvas_MouseLeftButtonUp(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            inkCanvas.DefaultDrawingAttributes.Color = Color.FromRgb(
                                                            (byte)r.Next(256), 
                                                            (byte)r.Next(256), 
                                                            (byte)r.Next(256));
        }


        private void sliderRotate_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            RotateTransform3D rottrans = new RotateTransform3D();
            AxisAngleRotation3D axisRot = new AxisAngleRotation3D(new Vector3D(1, 1, 1), sliderRotate.Value);
            rottrans.Rotation = axisRot;

            cubeRightModel3D.Transform = rottrans;
        }
    }
}
