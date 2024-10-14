using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Project_01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hangi programı çalıştırmak istersiniz ? \r\n 1-Rastgele Sayı Bulma Oyunu\r\n 2-Hesap Makinesi\r\n 3-Ortalama Hesaplama");
            Console.WriteLine("Çalıştırmak istediğiniz Programı Rakam Olarak Giriniz");
            int Program = Convert.ToInt32(Console.ReadLine()); //  Çalıştırmak istediğimiz programı seçmek için bir sayı aldık.
            if (Program == 1) // girilen sayı 1 ise Rastgele Sayı Bulma Oyunu Başlar
            {
                RastgeleSayıBulma();
            }
            else if (Program == 2) // girilen sayı 2 ise Hesap Makinesi oyunu Başlar
            {
                HesapMakinesi();
            }
            else if (Program == 3) // girilen sayı 3 ise OrtalamaBulma oyunu Başlar
            {
                OrtalamaHesaplama();
            }
            Console.ReadKey();
        }
        static void RastgeleSayıBulma()
        {
            Random rnd = new Random();    // Rastgele bir sayı ürettik
            int RastgeleSayı = rnd.Next(0, 100);  // Rastgele sayının 0-99 arasında olmasını sağladık
            Console.WriteLine("RASTGELESAYI: " + RastgeleSayı); //Ekrana Rastgele Sayıyı Yazdırdık
            int Haksayısı = 5; // Kullanıcının Hak Sayısını Belirledik
            for (int i = 0; i < 5; i++) //For Döngüsünde Şartların Sağlanıp Sağlanmadığını 5 kere kontrol ettik
            {
                Console.WriteLine("Hakınız: " + Haksayısı); //Hak Sayısını Ekrana Yazdırdık
                Console.Write("Tahmin:"); // Tahmini Ekrana Yazdırdık
                int Tahmin = Convert.ToInt32(Console.ReadLine()); // Tahmin EttiğimizSayıyı Ekrana Yazdırdık
                if (Tahmin > RastgeleSayı && Haksayısı > 0) // Tahmin Rastgele sayıdan büyük olursa daha küçük bir sayı girilmesi icin uyarıda bulunduk
                {
                    Console.WriteLine("DAHA KÜÇÜK SAYI GİRİN.");
                    Haksayısı--; // Hak Sayısını 1 azalttık
                }
                else if (Tahmin < RastgeleSayı && Haksayısı > 0)    // Tahmin Rastgele sayıdan küçük  olursa daha büyük bir sayı girilmesi icin uyarıda bulunduk
                {
                    Console.WriteLine("DAHA BÜYÜK SAYI GİRİN");
                    Haksayısı--; // Hak Sayısını 1 azalttık
                }
                else if (Tahmin == RastgeleSayı && Haksayısı > 0) // Tahmin rastgele sayıya eşitse Girilen sayının Doğru olduğunu bildirdik ve break komutuyla oyunu bitirdik
                {
                    Console.WriteLine("TEBRİKLER DOĞRU TAHMİN...."); // Tahmin Edilen Sayının Doğru olduğunu Ekrana yazdırdık
                    break; // Oyunu Bitirdik.
                }
            }
            if (Haksayısı == 0) //Hak sayısı 0 a eşit olursa Doğru sayıyı ve oyunun bittiğini bildirdik.
            {
                Console.WriteLine("Oyun Bitti Doğru Cevap...: " + RastgeleSayı);
            }
        }
        static void HesapMakinesi()
        {
            double Sonuç; // Yapılacak olan işlemler için bir sonuç değeri belirledik
            Console.Write("İlk Sayıyı Girin: ");
            double Sayı1 = Convert.ToDouble(Console.ReadLine());  // ilk sayıyı yazdırdık
            Console.Write("İkinci Sayıyı Girin: ");
            double Sayı2 = Convert.ToDouble(Console.ReadLine());//ikinci sayıyı yazdırdık
            Console.WriteLine("Yapmak istediğinz İşlemi Girin: \r\nToplama için + Çıkartma için - Çarpma için * Bölme için / Tuşuna basın"); // işlemi seçtik
            string Seçim = Console.ReadLine();
            if (Seçim == "+") // işlemin toplama olacağı şartı belirledik
            {
                Sonuç = Sayı1 + Sayı2; // toplama işlemi için matematiksel işlemi yazdık
                Console.WriteLine("Sonuç: " + Sonuç); // cevabı ekrana yazdırdık
            }
            else if (Seçim == "-")// işlemin çıkartma olacağı şartı belirledik
            {
                Sonuç = Sayı1 - Sayı2; // Çıakrtma işlemi için matematiksel işlemi yazdık
                Console.WriteLine("Sonuç: " + Sonuç); // cevabı ekrana yazdırdık
            }
            else if (Seçim == "*") // işlemin çarpma olacağı şartı belirledik
            {
                Sonuç = Sayı1 * Sayı2; // Çarpma işlemi için matematiksel işlemi yazdık
                Console.WriteLine("Sonuç: " + Sonuç);  // cevabı ekrana yazdırdık
            }
            else if (Seçim == "/") // Bölme işlemi için matematiksel işlemi yazdık
            {
                if (Sayı1 == 0 || Sayı2 == 0) // Sayı1 yada Sayı2 nin 0 0lması durumunda hatalı işlem olduğunu bildirien şart
                {
                    Console.WriteLine("Hatalı İşlem...");
                }
                else // sayı1 yada sayı2 0 a eşit olmama durumu
                {
                    Sonuç = Sayı1 / Sayı2; // Bölme işlemi için matematiksel işlemi yazdık
                    Console.WriteLine("Sonuç: " + Sonuç); // cevabı ekrana yazdırdık
                }
            }

        }
        static void OrtalamaHesaplama()
        {
            while (true)
            {
                Console.Write("Birinci Ders Notunu Gririn: ");
                double FirstMark = Convert.ToDouble(Console.ReadLine()); // ilk Nor girdisini aldık
                if (FirstMark < 0 || FirstMark > 100) // Girilen Not Değerinin 0-100 arasında olmaması durumda Girilen notta hata olduğunu bildiren şartı yazdık
                {
                    Console.WriteLine("Girilen Not Hatalı....");   //Şart sağlanırsa ekrana yazılacak olan yazı
                    break;
                }
                Console.Write("İkinci Ders Notunu Gririn: ");
                double SecondMark = Convert.ToDouble(Console.ReadLine()); // İkinci Nor Girdisini aldık
                if (SecondMark < 0 || SecondMark > 100)  // Girilen Not Değerinin 0-100 arasında olmaması durumda Girilen notta hata olduğunu bildiren şartı yazdık
                {
                    Console.WriteLine("Girilen Not Hatalı....");  //Şart sağlanırsa ekrana yazılacak olan yazı
                    break;
                }
                Console.Write("Üçüncü Ders Notunu Gririn: ");
                double ThirdMark = Convert.ToDouble(Console.ReadLine()); // Üçüncü Not Girdisini aldık
                if (ThirdMark < 0 || ThirdMark > 100)  // Girilen Not Değerinin 0-100 arasında olmaması durumda Girilen notta hata olduğunu bildiren şartı yazdık
                {
                    Console.WriteLine("Girilen Not Hatalı....");  //Şart sağlanırsa ekrana yazılacak olan yazı
                    break;
                }
                double Result = (FirstMark + SecondMark + ThirdMark) / 3; // Girilen notların ortalamasını almak için Gerekli olan matematiksel işlemi tanımladık
                Console.WriteLine("Not Ortalaması: " + Result);
                if (Result > 89 && Result < 101)   //Ortalama notun harf karşılığını göstermek için gerekli şartı yazdık
                {
                    Console.WriteLine("Notunuz: AA"); // Şart sağlandığında ekrana yazılacak yazı
                }
                else if (Result > 84 && Result < 90) //Ortalama notun harf karşılığını göstermek için gerekli şartı yazdık
                {
                    Console.WriteLine("Notunuz: BA"); // Şart sağlandığında ekrana yazılacak yazı
                }
                else if (Result > 79 && Result < 85) //Ortalama notun harf karşılığını göstermek için gerekli şartı yazdık
                {
                    Console.WriteLine("Notunuz: BB"); // Şart sağlandığında ekrana yazılacak yazı
                }
                else if (Result > 74 && Result < 80) //Ortalama notun harf karşılığını göstermek için gerekli şartı yazdık
                {
                    Console.WriteLine("Notunuz: CB"); // Şart sağlandığında ekrana yazılacak yazı
                }
                else if (Result > 69 && Result < 75) //Ortalama notun harf karşılığını göstermek için gerekli şartı yazdık
                {
                    Console.WriteLine("Notunuz: CC"); // Şart sağlandığında ekrana yazılacak yazı
                }
                else if (Result > 64 && Result < 70) //Ortalama notun harf karşılığını göstermek için gerekli şartı yazdık
                {
                    Console.WriteLine("Notunuz: DC"); // Şart sağlandığında ekrana yazılacak yazı
                }
                else if (Result > 59 && Result < 65) //Ortalama notun harf karşılığını göstermek için gerekli şartı yazdık
                {
                    Console.WriteLine("Notunuz: DD");  // Şart sağlandığında ekrana yazılacak yazı
                }
                else if (Result > 54 && Result < 60) //Ortalama notun harf karşılığını göstermek için gerekli şartı yazdık
                {
                    Console.WriteLine("Notunuz: FD"); // Şart sağlandığında ekrana yazılacak yazı
                }
                else if (Result < 55) //Ortalama notun harf karşılığını göstermek için gerekli şartı yazdık
                {
                    Console.WriteLine("Notunuz: FF"); // Şart sağlandığında ekrana yazılacak yazı
                }
                break; // Programı sonlandır.
            }
        }
    }
}

