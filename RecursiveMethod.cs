using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;
using static System.Math;

namespace RecursiveMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = { 1, 2, 3, 7, 8, 9, 12, 67, 34 };

            bool result = RecMetotX(array, 6);
            WriteLine("{ 1, 2, 3, 7, 8, 9, 12, 67, 34 } dizisinde 6 sayısı bulunma ihtimali: " + result);

            result = RecMetotX(array, 12);
            WriteLine("{ 1, 2, 3, 7, 8, 9, 12, 67, 34 } dizisinde 12 sayısı bulunma ihtimali: " + result);

        }

        //Dizi içinde aramayı özyinelemeli bir döngü şeklinde yapar.
        static bool RecMetotX(int[] arr, int key, int index = 0)
        {
            bool isEqual = false; // isEqual diye değişken oluşturur ve ilk değeri false yapar.
            if (index != arr.Length) // Dizinin indisi dizinin uzunluğuna eşit değilse blok içindeki işlemleri yapar, eşit değilse bloğun içine girmez.
            {
                int arrEl = arr[index];
                if (arrEl == key) isEqual = true; //anahtar değerine eşit bir değer bulunursa isEqual değerini true yapar.
                else
                {
                    index++; //Dizinin sonraki elemanına geçer.
                    isEqual = RecMetotX(arr, key, index); // Metodu kendi içinde tekrar çağırır. Metottan dönen değeri isEqual içinde tutar.
                }
            }
            return isEqual; // En son değeri döndürür.
        }
    }
}
