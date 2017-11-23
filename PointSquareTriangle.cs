using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;

namespace PointSquareTriangle
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("NOKTA ve KARE KULLANIMI\n");

            Point p1 = new Point(1, 3);
            Point p2 = new Point(3, 5);

            Square s1 = new Square(p1, p2);
            WriteLine(s1.SquareString());

            s1 = new Square(1, 3, 4, 6);
            WriteLine(s1.SquareString());

            p1.SetX(2); p1.SetY(3);
            p2.SetX(5); p2.SetY(7);

            s1 = new Square(p1, p2);
            WriteLine(s1.SquareString());

            WriteLine("NOKTA ve UCGEN KULLANIMI\n");

            Point p3 = new Point();
            Point p4 = new Point();
            Point p5 = new Point(0, 4);

            Triangle u1 = new Triangle(p3, p4, p5);
            WriteLine(u1.TriangleString());

            p3.SetX(3); p3.SetY(4);
            p4.SetX(3); p4.SetY(0);
            p5.SetX(0); p5.SetY(0);

            u1 = new Triangle(p3, p4, p5);
            WriteLine(u1.TriangleString());

            u1 = new Triangle(0, 0, 2, 3, 4, 0);
            WriteLine(u1.TriangleString());
        }
    }

    class Point
    {
        int x { get; set; }
        int y { get; set; }

        public Point() { x = y = 0; }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        /* İKİ NOKTA ARASINDAKİ UZAKLIK
                      _________________________ 
         * uzaklık = √(x1 - x2)^2 + (y1 - y2)^2 */
        public double Distance(int x, int y) { return Sqrt(Pow(this.x - x, 2) + Pow(this.y - y, 2)); }
        public double Distance(Point n) { return Sqrt(Pow(x - n.x, 2) + Pow(y - n.y, 2)); }

        public string PointString() { return "X: " + x.ToString() + " Y: " + y.ToString(); }
    }

    class Triangle
    {
        Point p1, p2, p3;

        public Triangle(int p1x, int p1y, int p2x, int p2y, int p3x, int p3y)
        {
            Point temp = new Point(); //p1, p2 ve p3 nesnelerine değer ataması yapmadan önce geçici bir nesne üzerinde girilen noktaları test eder.
            // Set metodlarıyla noktaları temp nesnesine aktarır ve Uzaklık metoduyla birbirine uzaklıklarını hesaplar.
            temp = new Point(p1x, p1y);
            double u1 = temp.Distance(p2x, p2y); // Uzaklık 1

            temp = new Point(p2x, p2y);
            double u2 = temp.Distance(p3x, p3y); // Uzaklık 2

            temp = new Point(p3x, p3y);
            double u3 = temp.Distance(p1x, p1y); // Uzaklık 3

            if (TriangleControl  (u1, u2, u3))
            {
                WriteLine("Ucgen Olustu");
                p1 = new Point(p1x, p1y);
                p2 = new Point(p2x, p2y);
                p3 = new Point(p3x, p3y);
            }
            else
            {
                WriteLine("Ucgen Olusmaz");
                p1 = new Point(0, 0);
                p2 = new Point(0, 1);
                p3 = new Point(1, 0);
            }
        }
        /* : this(...) Constructor Kullanımı
         * Sınıf içindeki aynı ismi taşıyan diğer constructoru çağırmamızı sağlar.*/
        public Triangle(Point p1, Point p2, Point p3) : this(p1.x, p1.y, p2.x, p2.y, p3.x, p3.y) { }

        public bool TriangleControl  (double l1, double l2, double l3) { return ((l1 < l2 + l3) && (l2 < l1 + l3) && (l3 < l1 + l2)); }

        //Perimeter(): double değerleri toplar, sonucu type cast yaparak integer döndürür.
        public int Perimeter() { return (int)(p1.Distance(p2) + p2.Distance(p3) + p3.Distance(p1)); }

        public void TriangleType()
        {
            double u1 = p1.Distance(p2);
            double u2 = p2.Distance(p3);
            double u3 = p3.Distance(p1);

            if ((u1 == u2) && (u2 == u3) && (u1 == u3)) WriteLine("UCGEN TIPI: Eskenar Ucgen");
            else if ((u1 == u2) || (u2 == u3) || (u1 == u3)) WriteLine("UCGEN TIPI: Ikizkenar Ucgen");
            else WriteLine("UCGEN TIPI: Cesitkenar Ucgen");
        }

        public string TriangleString()
        {
            TriangleType();
            return "NOKTALAR\n" +
                    "Nokta 1: " + p1.PointString() +
                    "\nNokta 2: " + p2.PointString() +
                    "\nNokta 3: " + p3.PointString() +
                    "\nKENAR UZUNLUKLARI" +
                   "\nUzunluk 1: " + p1.Distance(p2) +
                   "\nUzunluk 2: " + p2.Distance(p3) +
                   "\nUzunluk 3: " + p3.Distance(p1) +
                   "\nCEVRE:" + Perimeter() + "\n";
        }
    }

    class Square
    {
        Point rightBot, leftTop;

        public Square(int p1x, int p1y, int p2x, int p2y)
        {

            int u1 = Abs(p1x - p2x); // x ekseninde uzaklık
            int u2 = Abs(p1y - p2y); // y ekseninde uzaklık

            if (SquareControl  (u1, u2))
            {
                WriteLine("Kare Olustu");
                leftTop = new Point(p1x, p1y);
                rightBot = new Point(p2x, p2y);
            }
            else
            {
                WriteLine("Kare Olusmaz");
                leftTop = new Point(0, 1);
                rightBot = new Point(1, 0);
            }
        }
        /* : this(...) Constructor Kullanımı
         * Sınıf içindeki aynı ismi taşıyan diğer constructoru çağırmamızı sağlar.*/
        public Square(Point p1, Point p2) : this(p1.x, p1.y, p2.x, p2.y) { }

        public bool SquareControl  (double length1, double length2) { return length1 == length2; }

        //Area(): Bir kenarın uzunluğunun karesini al, Pow metodu double değer döndürdüğü için type cast yaparak sonucu integer döndürür.
        public int Area() { return (int)Pow(rightBot.x - leftTop.x, 2); }

        public int SquarePerimeter () { return Abs(rightBot.x - leftTop.x) * 4; }

        public string SquareString()
        {
            return "NOKTALAR\n" +
                    "Point 1: " + leftTop.PointString() +
                   "\nPoint 2: " + rightBot.PointString() +
                   "\nKENAR UZUNLUKLARI" +
                   "\nUzunluk: " + Abs(rightBot.x - leftTop.x) +
                   "\nCEVRE:" + SquarePerimeter () +
                   "\nALAN:" + Area() + "\n";
        }
    }
}
