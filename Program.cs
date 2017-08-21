using System;
using System.IO;

namespace Challange1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter FileName with Path...");
            string FileName = Console.ReadLine();

            int Count = 1;
            string NewFileName, FinalFileName = "";

            int startIndex = FileName.LastIndexOf('\\');
            string Path = FileName.Substring(0, startIndex + 1);
            string TempFileName = FileName.Substring(startIndex + 1, (FileName.LastIndexOf('.') - startIndex) - 1);
            string FileExtension = FileName.Substring(FileName.LastIndexOf('.'));

            NewFileName = TempFileName + " - Copy";

            string[] FileList = Directory.GetFiles(Path);

            //string ExistFileName;
            foreach (string Fname in FileList)
            {
                if (Fname.Contains(NewFileName) && !Fname.Contains(NewFileName + " -"))
                {
                    //ExistFileName = Fname;
                    Count++;
                }
            }

            if (Count == 1)
                FinalFileName = Path + TempFileName + " - Copy" + FileExtension;
            else
                FinalFileName = Path + TempFileName + " - Copy (" + Count.ToString() + ")" + FileExtension;

            try
            {
                File.Copy(FileName, FinalFileName, false);
            }
            catch (Exception e)
            {
                if (e.Message.Contains("already exists"))
                {

                }
            }
            //}
        }
    }
}
