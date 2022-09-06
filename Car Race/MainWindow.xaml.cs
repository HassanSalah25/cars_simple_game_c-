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
using System.Windows.Threading;


namespace Car_Race
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int carspeed = 3;
        public int collectionCoins = 9;
        DispatcherTimer dispatcherTimer = new DispatcherTimer();
        public MainWindow()
        {
            timer1_Tick();
            InitializeComponent();
            //l1.Content = Key.M.GetTypeCode().ToString();
        }
        private void timer1_Tick()
        {
            
            dispatcherTimer.Tick += new EventHandler(timer);
            dispatcherTimer.Interval = new TimeSpan(0,0,0,0,30);
            dispatcherTimer.Start();
        }
        private void timer(object sender, EventArgs e)
        {
            moveLine(carspeed);
            enemies(carspeed);
            GameOver();
            coins(carspeed);
            collection();
            Intersectionwall();
        }
        public void moveLine(int speed)
        {
            int st = (int)Canvas.GetTop(Label1);
            int nd = (int)Canvas.GetTop(Label2);
            int rd = (int)Canvas.GetTop(Label3);
            l1.Content = DateTime.Now.ToString("ss");

            if(st >= 535) 
                {Canvas.SetTop(Label1,0);}
            else
                {Canvas.SetTop(Label1, st += speed);}
                
            if (nd >= 535) 
                {Canvas.SetTop(Label2, 0);}
            else
                {Canvas.SetTop(Label2, nd += speed);}

            if (rd >= 535) 
                {Canvas.SetTop(Label3, 0);}
            else
                {Canvas.SetTop(Label3, rd += speed);}
        }

        private void Car1_KeyDown(object sender,KeyEventArgs e)
        {
            int c1 = (int)Canvas.GetLeft(car1);
            if (e.Key == Key.Left)
                {
                
                    Canvas.SetLeft(car1, c1 -= 8);
            }
            if (e.Key == Key.Right)
            {
                
                    Canvas.SetLeft(car1, c1 += 8);
            }
            if (e.Key == Key.Up)
                {
                if(carspeed >= 20);
                else
                     carspeed++;
            }
            if (e.Key == Key.Down)
                {
                if (carspeed <= 3);
                else
                    carspeed--;
            }
        }
        void enemies(int speed)
        {
            int st = (int)Canvas.GetTop(ecar1);
            int nd = (int)Canvas.GetTop(ecar2);
            int rd = (int)Canvas.GetTop(ecar3);
            int x, y;
            Random r = new Random();

            if (st >= 535)
            {
                x = r.Next(7, 330);
                Canvas.SetLeft(ecar1,x);
                Canvas.SetTop(ecar1, -90);
            }
            else
            { Canvas.SetTop(ecar1, st += speed); }
            if (nd >= 535)
            {
                x = r.Next(7, 330);
                Canvas.SetLeft(ecar2, x);
                Canvas.SetTop(ecar2, -90);
            }
            else
            { Canvas.SetTop(ecar2, nd += speed); }
            if (rd >= 535)
            {
                x = r.Next(7, 330);
                Canvas.SetLeft(ecar3, x);
                Canvas.SetTop(ecar3, -90);
            }
            else
            { Canvas.SetTop(ecar3, rd += speed); }

        }
        void GameOver()
        {
            double x = Canvas.GetTop(ecar3);
            double y = Canvas.GetTop(car1);
            double a = Canvas.GetTop(ecar2);
            double b = Canvas.GetTop(ecar1);
            double w = Canvas.GetLeft(ecar3);
            double z = Canvas.GetLeft(car1);
            double c = Canvas.GetLeft(ecar2);
            double d = Canvas.GetLeft(ecar1);
            Rect r1 = new Rect(x+5, w+15, ecar3.Height -30, ecar3.Width -15);
            Rect r2 = new Rect(a+5, c+15, ecar2.Height -30, ecar2.Width -15);
            Rect r3 = new Rect(b+5, d+15, ecar1.Height -30, ecar1.Width -15);
            Rect r4 = new Rect(y+5, z+15, car1.Height -30, car1.Width -15);
            bool v1 = r4.IntersectsWith(r1);
            bool v2 = r4.IntersectsWith(r2);
            bool v3 = r4.IntersectsWith(r3);
            if (v1 == true || v2 == true || v3 == true)
            {
                GO1.Visibility = Visibility.Visible;
                dispatcherTimer.Stop();
            }
        }
        void coins(int speed)
        {
            int st = (int)Canvas.GetTop(coin1);
            int nd = (int)Canvas.GetTop(coin2);
            int rd = (int)Canvas.GetTop(coin3);
            int x, y;
            Random r = new Random();

            if (st >= 535)
            {
                x = r.Next(7, 330);
                Canvas.SetLeft(coin1, x);
                Canvas.SetTop(coin1, -90);
            }
            else { Canvas.SetTop(coin1, st += speed); }
            if (nd >= 535)
            {
                x = r.Next(7, 330);
                Canvas.SetLeft(coin2, x);
                Canvas.SetTop(coin2, -90);
            }
            else { Canvas.SetTop(coin2, nd += speed); }
            if (rd >= 535)
            {
                x = r.Next(7, 330);
                Canvas.SetLeft(coin3, x);
                Canvas.SetTop(coin3, -90);
            }
            else { Canvas.SetTop(coin3, rd += speed); }
        }
       void collection()
        {
            double x = Canvas.GetTop(coin3);
            double y = Canvas.GetTop(car1);
            double a = Canvas.GetTop(coin2);
            double b = Canvas.GetTop(coin1);
            double w = Canvas.GetLeft(coin3);
            double z = Canvas.GetLeft(car1);
            double c = Canvas.GetLeft(coin2);
            double d = Canvas.GetLeft(coin1);
            Rect r1 = new Rect(x , w + 10, coin3.Height - 10, coin3.Width - 5);
            Rect r2 = new Rect(a , c + 10, coin2.Height - 10, coin2.Width - 5);
            Rect r3 = new Rect(b , d + 10, coin1.Height - 10, coin1.Width - 5);
            Rect r4 = new Rect(y + 5, z + 15, car1.Height - 15, car1.Width - 25);
            bool v1 = r4.IntersectsWith(r1);
            bool v2 = r4.IntersectsWith(r2);
            bool v3 = r4.IntersectsWith(r3);
            Random r = new Random();
            if (v1)
            {
                collectionCoins++;
                l3.Content = "Coins = " + collectionCoins.ToString();
                x = r.Next(7, 330);
                Canvas.SetLeft(coin3, x);
                Canvas.SetTop(coin3, -90);

            }
            if (v2)
            {
                collectionCoins++;
                l3.Content = "Coins = " + collectionCoins.ToString();
                x = r.Next(7, 330);
                Canvas.SetLeft(coin2, x);
                Canvas.SetTop(coin2, -90);

            }
            if (v3)
            {
                collectionCoins++;
                l3.Content = "Coins = " + collectionCoins.ToString();
                x = r.Next(7, 330);
                Canvas.SetLeft(coin1, x);
                Canvas.SetTop(coin1, -90);

            }
        }
        void Intersectionwall()
        {
            double a2 = Canvas.GetTop(car1);
            double a4 = Canvas.GetLeft(wall1);
            double a5 = Canvas.GetLeft(car1);
            double a6 = Canvas.GetLeft(wall2);
            Rect r5 = new Rect(0, 395, 519, 7);
            Rect r6 = new Rect(0, -10,   519, 7);
            Rect r7 = new Rect(a2, a5, car1.Height, car1.Width);
            bool v3 = r7.IntersectsWith(r5);
            bool v4 = r7.IntersectsWith(r6);
            if (v3 == true || v4 == true)
            {
                GO1.Visibility = Visibility.Visible;
                dispatcherTimer.Stop();
                
            }
        }
    }
}
