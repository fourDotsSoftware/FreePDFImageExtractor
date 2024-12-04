using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.IO;
using System.Collections;

namespace PdfImageExtractor
{
    public class UniqueImageSaver
    {
        public Dictionary<string, Dictionary<long,List<string>>> dict = new Dictionary<string, Dictionary<long, List<string>>>();

        public List<string> tempImageFiles = new List<string>();
        
        public bool ImageIsUnique(Image imgfile,string filepath)
        {
            if (!Properties.Settings.Default.SaveOnlyUniqueImages) return true;

            Dictionary<long, List<string>> d;

            bool suc = false;

            suc = dict.TryGetValue(ImagesExtractorHelper.CurrentInputFilepath,out d);

            FileInfo fi = new FileInfo(filepath);

            if (!suc)
            {
                d = new Dictionary<long, List<string>>();

                List<string> lst = new List<string>();

                lst.Add(filepath);

                d.Add(fi.Length, lst);

                dict.Add(ImagesExtractorHelper.CurrentInputFilepath, d);

                return true;
            }
            else
            {
                foreach (KeyValuePair<long,List<string>> dd in d)
                {
                    if (dd.Key==fi.Length)
                    {
                        if (dd.Key==100)
                        {
                            int a = 1;

                            Console.Write(100);
                        }

                        for (int m = 0; m < dd.Value.Count; m++)
                        {
                            FileInfo fi2 = new FileInfo(dd.Value[m]);

                            if (FilesAreEqual_OneByte(fi, fi2))
                            {
                                fi.Attributes = FileAttributes.Normal;
                                fi.Delete();

                                return false;
                            }
                        }
                    }
                }

                List<string> dd3;

                bool suc2 = d.TryGetValue(fi.Length, out dd3);

                if (suc2)
                {
                    d[fi.Length].Add(filepath);
                }
                else
                {
                    List<string> lst2 = new List<string>();
                    lst2.Add(filepath);

                    d.Add(fi.Length, lst2);
                }
                
                return true;
            }
        }

        public void ClearAfterUse()
        {
            for(int m=0;m<tempImageFiles.Count;m++)
            {
                if (System.IO.File.Exists(tempImageFiles[m]))
                {
                    FileInfo fi = new FileInfo(tempImageFiles[m]);
                    fi.Attributes = System.IO.FileAttributes.Normal;
                    fi.Delete();
                }
            }

            dict = new Dictionary<string, Dictionary<long, List<string>>>();
        }
        private static bool FilesAreEqual_OneByte(FileInfo first, FileInfo second)
        {
            if (first.Length != second.Length)
                return false;

            if (string.Equals(first.FullName, second.FullName, StringComparison.OrdinalIgnoreCase))
                return true;

            using (FileStream fs1 = first.OpenRead())
            using (FileStream fs2 = second.OpenRead())
            {
                for (int i = 0; i < first.Length; i++)
                {
                    if (fs1.ReadByte() != fs2.ReadByte())
                        return false;
                }
            }

            return true;
        }
    }
}
