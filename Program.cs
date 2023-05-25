using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using StreamAtLesson_8May.Models;


namespace StreamAtLesson_8May
{
   

    public class Program
    {
        static void Main()
        {
            int say = 0;
            while (true)
            {
                Console.WriteLine("Screen etmek , yoxsa GetPictures sechmek isteyirsiniz ? ( A  ve ya  B daxil edin) :  ");
                dynamic choose = Console.ReadKey();
                if (choose.Key! == ConsoleKey.A)
                {
                    while (true)
                    {
                        Console.WriteLine("Ekran Resmi almaq uchun Enter , cixmaq uchun istenilen diger symbol daxil edin ");

                        if (Console.ReadKey().Key == ConsoleKey.Enter)
                        {
                            if (say == 0) Directory.CreateDirectory($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/ScreensByCs");

                            FileStream stream = new($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/ScreensByCs/screenshot_.{DateTime.Now:yyyyMMddHHmmss}.png", FileMode.OpenOrCreate, FileAccess.Write);


                            

                            Bitmap screenshot = ClassCapture.CaptureScreen();
                            screenshot.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                            // screenshot.Save (,)
                            Console.WriteLine("Ekran görüntüsü saxlanildi: " + stream);
                        }
                        else break;
                    }
                }
                else if (choose.Key == ConsoleKey.B)
                {
                    string folderPath = $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/ScreensByCs";
                    string[] photoFiles = Directory.GetFiles(folderPath, "*.png"); 

                    foreach (string photoFile in photoFiles)
                    {
                        using (FileStream fs = File.OpenRead(photoFile))
                        {
                           
                            Console.WriteLine(Path.GetFileName(photoFile));
                        }
                    }
                    Console.ReadKey(true );
                }
                else continue;
                break;
            }
        }
        
    }

}



/*
 Her defe Enter duymesine click edende ekranin ScreenShot-nu ceksin
ve hemin ScreenShot-lari Desktop-da Images Folder-inde save etsin.
Eger Images folder-i yoxdusa yaransin, varsa yaranmasin.

Her defe shekil save edende, kohne shekiller silinmesin.
Yazdiginiz kod menim komputerim de de ishlemelidir.

Elave:

Hemin folder-in icherisindeki shekillerin adlarini chap etmek funskiyanalligi da olsun.
GetFiles()....

Eger alindira bilsez, hansisa shekili sechende onu Default Program-i ile achsin. (Photos)
 */