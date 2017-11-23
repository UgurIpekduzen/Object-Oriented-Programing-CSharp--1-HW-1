using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;

namespace OperatorOverloading
{
    class Program
    {
        static void Main(string[] args)
        {
           
            ComplexNumber c1 = new ComplexNumber(2, 3);
            ComplexNumber c2 = new ComplexNumber(4, 6);
            ComplexNumber c3 = new ComplexNumber(2, 3);
            ComplexNumber c4 = new ComplexNumber();

            WriteLine("KARMASIK SAYILARDA TOPLAMA CIKARMA ve CARPMA ISLEMLERI\n");
            c4 = c1 + c2;
            WriteLine("Toplam: (" + c1.ComplexNumberString() + ") + (" + c2.ComplexNumberString() + ") = " + c4.ComplexNumberString());

            c4 = c1 - c2;
            WriteLine("Fark: (" + c1.ComplexNumberString() + ") - (" + c2.ComplexNumberString() + ") = " + c4.ComplexNumberString());

            c4 = c1 * c2;
            WriteLine("Çarpım: (" + c1.ComplexNumberString() + ") * (" + c2.ComplexNumberString() + ") = " + c4.ComplexNumberString());

            WriteLine("\nIKI KARMASIK SAYIYI KARSILASTIRMA\n");
            bool isEqual = (c1 == c2);
            WriteLine(c1.ComplexNumberString() + " == " + c2.ComplexNumberString() + " --> " + isEqual);

            isEqual = (c1 == c3);
            WriteLine(c1.ComplexNumberString() + " == " + c3.ComplexNumberString() + " --> " + isEqual);

            bool isNotEqual = (c1 != c2);
            WriteLine(c1.ComplexNumberString() + " != " + c2.ComplexNumberString() + " --> " + isNotEqual);

            isNotEqual = (c1 != c3);
            WriteLine(c1.ComplexNumberString() + " != " + c3.ComplexNumberString() + " --> " + isNotEqual);

            WriteLine("\nKARMASIK SAYILARIN GERCEK KISMINA DOUBLE DEGER EKLEME CIKARMA\n");

            double num1 = 3, num2 = 5.5;

            ComplexNumber c5 = c1 + num1;
            WriteLine(c1.ComplexNumberString() + " + " + num1 + " = " + c5.ComplexNumberString());

            ComplexNumber c6 = c2 - num2;
            WriteLine(c2.ComplexNumberString() + " - " + num2 + " = " + c6.ComplexNumberString());

            WriteLine("\nKARMASIK SAYI DEGERLERINI NEGATIF DEGERLERE CEVIRME\n");

            ComplexNumber c7 = -c4;
            WriteLine(" -(" + c4.ComplexNumberString() + ") = " + c7.ComplexNumberString());
        }
    }

    class ComplexNumber
    {
        int Re, Im;

        public ComplexNumber() { Re = Im = 0; }
        public ComplexNumber(int Re, int Im)
        {
            this.Re = Re;
            this.Im = Im;
        }

        /*KARMAŞIK SAYILARDA TOPLAMA ÇIKARMA ve ÇARPMA İŞLEMLERİ
         * Parametre olarak aldığı iki karmaşık sayının gerçek ve sanal kısımlarını ayrı ayrı toplar, çıkarır ve çarparlar.
         * Buldukları sonuçları yeni bir karmaşık sayı nesnesine parametre olarak gönderirler.
         - Toplama -->(a+bi) + (c+di) = (a + c) + (b + d)i
         - Çıkarma -->(a+bi)*(c+di) = (a - c) + (b - d)i
         - Çarpma --> (a+bi)*(c+di) = (a*c-b*d) + (a*d+b*c)i
         */
        public static ComplexNumber operator +(ComplexNumber c1, ComplexNumber c2) { return new ComplexNumber(c1.Re + c2.Re, c1.Im + c2.Im); }
        public static ComplexNumber operator -(ComplexNumber c1, ComplexNumber c2) { return new ComplexNumber(c1.Re - c2.Re, c1.Im - c2.Im); }
        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2) { return new ComplexNumber((c1.Re * c2.Re) - (c1.Im * c2.Im), (c1.Re * c2.Im) + (c1.Im * c2.Re)); }

        /*KARMASIK SAYILARIN GERCEK KISMINA DOUBLE DEĞER EKLEME ÇIKARMA
         * Gönderilen double değeri integer değere çevirerek yaklaşık değer hesaplar. 
         * Return değer olarak parametreleri gerçek kısmı yaklaşık değer, sanal kısmı aynı olan yeni bir karmaşık sayı nesnesi döndürür.*/
        public static ComplexNumber operator +(ComplexNumber c, double num) { return new ComplexNumber(c.Re + (int)num, c.Im); }
        public static ComplexNumber operator -(ComplexNumber c, double num) { return new ComplexNumber(c.Re - (int)(num), c.Im); }

        /*IKI KARMASIK SAYIYI KARSILASTIRMA
         * Parametre olarak aldığı iki karmaşık sayının gerçek ve sanal kısımlarını ayrı ayrı karşılaştırır.
         * Bu karşılaştırmanın sonucunu bir bool değişkeninin içinde tutar.
         * Bool değer, koşul bloğu içinde yapılan karşılaştırma sonucuna göre koşulu sağlıyorsa true, sağlamıyorsa false değer alır.*/
        public static bool operator ==(ComplexNumber c1, ComplexNumber c2)
        {
            bool isEqual;
            return isEqual = ((c1.Re == c2.Re) && (c1.Im == c2.Im)) ? true : false;
        }
        public static bool operator !=(ComplexNumber c1, ComplexNumber c2)
        {
            bool isNotEqual;
            return isNotEqual = ((c1.Re != c2.Re) || (c1.Im != c2.Im)) ? true : false;
        }

        //ComplexNumberString(): Karmaşık sayı hakkında metinsel bilgi döndürür.
        public string ComplexNumberString() { return "(" + Re.ToString() + ")" + "+" + "(" + Im.ToString() + ")" + "i"; }

        /*KARMASIK SAYI DEGERLERINI NEGATIF DEGERLERE CEVIRME
         * Parametre olarak aldığı karmaşık sayının gerçek ve sanal kısımlarını negatif değere çevirir.
         * return değer olarak, çevrilen değerlerin parametre olarak atandığı yeni bir karmaşık sayı nesnesi döndürür.*/
        public static ComplexNumber operator -(ComplexNumber c) { return new ComplexNumber(-(c.Re), -(c.Im)); }
    }
}