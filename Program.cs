using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'migratoryBirds' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER_ARRAY arr as parameter.
     */

    public static int migratoryBirds(List<int> arr)
    {
        /*
        Bu algoritma, bir liste içindeki belirli bir tür kuşun kaç kez göründüğünü hesaplayarak 
        en sık görülen kuş türünü bulmayı amaçlamaktadır. 
        Örnek olarak aşağıdaki kuş türleri listesini ele alalım:

        Liste: 1 2 3 4 5 4 3 2 1 3 4

        Her kuş türünün kaç kez görüldüğünü hesaplayalım:
        - Tür 1:  2 kere görülmüş
        - Tür 2:  2 kere görülmüş
        - Tür 3:  3 kere görülmüş
        - Tür 4:  3 kere görülmüş
        - Tür 5:  1 kere görülmüş

        Bu durumda, Tür 3 ve Tür 4 en sık görülen türlerdir ve her biri 3 kez görülmüştür.
        Şimdi algoritmamızın nasıl çalıştığını adım adım inceleyelim:

        1. İlk olarak, kuş türlerinin sayısını saklamak için bir dizi (birdTypeCounts) oluşturuyoruz.
        2. Ardından, bu diziyi doldurmak için listeyi (arr) dolaşıyoruz ve her türün sayısını artırıyoruz.
        3. Daha sonra, bu diziyi kullanarak en sık görülen türü belirliyoruz.
        4. Eğer mevcut türün sayısı, şu ana kadar en sık görülen türün sayısından büyükse, bu tür yeni en sık görülen tür olur.
        5. Eğer mevcut türün sayısı, en sık görülen türün sayısına eşitse ve tür kimliği daha küçükse, yine bu tür yeni en sık görülen tür olur.

        Bu durum, eşit sayıda görülen kuş türleri arasında en düşük tür kimliğine sahip olanı tercih etmemizi sağlar. 
        Yani, Tür 3 ve Tür 4 aynı sayıda (3 kez) görülmüşse, Tür 3 tercih edilir çünkü tür kimliği daha küçüktür.

        Algoritmanın işleyişi sonucunda, bu örnekte en sık görülen kuş türü olarak Tür 3 seçilir.
        */
        var birdTypeCounts = new int[5]; //Kuş türlerinin sayısını tutar. Toplamda 5 adet kuş türü vardır.


        for (int i = 0; i < arr.Count; i++)
        {
            birdTypeCounts[arr[i] - 1]++; //her bir kuş türü sayılır ve ilgili indeksin değeri artırılır. 
        }

        var maxBirdTypeCount = birdTypeCounts[0]; //en çok görülen kuş türünün sayısını tutar.
        var maxBirdType = 1; //Kuş türünün kimliğini tutar.

        //Amaç, aynı sıklıkta görülen kuş türleri arasında en düşük tür kimliğine sahip olanı seçmektir.
        for (int i = 1; i < 5; i++)
        {
            //Eğer mevcut türün sayısı maxBirdTypeCount'tan büyükse, bu tür yeni en sık görülen tür olur (maxBirdTypeCount ve maxBirdType güncellenir).
            if (birdTypeCounts[i] > maxBirdTypeCount)
            {
                maxBirdTypeCount = birdTypeCounts[i];
                maxBirdType = i + 1;
            }

            // Eğer mevcut türün sayısı maxBirdTypeCount'a eşitse ve tür kimliği mevcut maxBirdType'dan küçükse, bu tür yine yeni en sık görülen tür olur.
            if (birdTypeCounts[i] == maxBirdTypeCount && i + 1 < maxBirdType)
            {
                maxBirdType = i + 1;
            }
        }

        return maxBirdType;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int arrCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.migratoryBirds(arr);

        textWriter.WriteLine(result);

        textWriter.Flush();
        textWriter.Close();
    }
}
