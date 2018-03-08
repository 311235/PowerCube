///Kyler Campbell
///March 6, 2018
///Find the yellow cube when selecting a photo
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace canvasImage
{
    /// </summary>
    public partial class MainWindow : Window
    {
        
        /// Set variables
        
        private readonly object filter;
        Point p1 = new Point();
        Point p2 = new Point();
        private UIElement r;
        private double l;
        private double t;
        private object red;
        private object green;
        private object blue;


        /*double t = 20;
        double l = 20;
        */

        public MainWindow()
        {
            InitializeComponent();
        }
        
        
        
        /// Gets file when clicked, opens the file
        private void btnGetFile_Click(object sender, RoutedEventArgs e)
        {
            if (canvas.Children.Count > 0)
            {
                canvas.Children.RemoveAt(0);
            }
            Microsoft.Win32.OpenFileDialog openFileD = new Microsoft.Win32.OpenFileDialog();
            openFileD.ShowDialog();

            BitmapImage bi = new BitmapImage(new Uri(openFileD.FileName));
            System.Windows.Media.ImageBrush ib = new ImageBrush(bi);
            canvas.Background = ib;




            ///Creating new rectangle and its properties
            Rectangle r = new Rectangle();
            r.Stroke = System.Windows.Media.Brushes.GreenYellow;
            r.Width = 100;
            r.Height = 100;
            r.StrokeThickness = 2;


            /// Setting the top left and top
            canvas.Children.Add(r);
            Canvas.SetLeft(r, l);
            Canvas.SetTop(r, t);
            l += 20;
            t += 20;


            ///Get pixel
            int stride = bi.PixelWidth * 4;
            int size = bi.PixelHeight * stride;
            byte[] pixels = new byte[size];
            bi.CopyPixels(pixels, stride, 0);






            ///picks random number
            Random rand = new Random();
            
            /// Make sure its an integer
            int q = rand.Next(1, 2);


            for (int i = q; i < q + 5000; i++)


            {

            }

          
            ///Set interger
            int x = 799;
            int y = 0;
            int index = y * stride + 4 * x;

            /// Use colours as varibles to find cordinates of yellow box
            byte blue = pixels[index];
            byte green = pixels[index + 1];
            byte red = pixels[index + 2];
            byte alpha = pixels[index + 3];



            /// Message box shows corordinates of where the box is ;)
            MessageBox.Show(red.ToString() + ", " + green.ToString() + ", " + blue.ToString());
        }



        
        /// Draws a box around where clicked, cannot draw backwords 
        
        private void canvas_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            Window.Title = e.GetPosition(canvas).ToString();
            p1 = e.GetPosition(canvas);
        }

        private void canvas_PreviewMouseUp(object sender, MouseButtonEventArgs e)



        {
            ///Properties for rectangle box being drawn
            p2 = e.GetPosition(canvas);
            if (canvas.Children.Count > 0)
            {
                canvas.Children.RemoveAt(0);
            }
            Rectangle r = new Rectangle();
            r.Stroke = System.Windows.Media.Brushes.GreenYellow;
            r.Width = p2.X - p1.X;
            r.Height = p2.Y - p1.Y;
            r.StrokeThickness = 2;

            canvas.Children.Add(r);
            Canvas.SetLeft(r, p1.X);
            Canvas.SetTop(r, p1.Y);

            {


            }



            /*MessageBox.Show(red.ToString() + ", " + green.ToString() + ", " + blue.ToString());
        
            */   
        }


             internal class dbSet
        {



                internal static void Count(object filter)
            {
                throw new NotImplementedException();
            }
        }
    }
}
