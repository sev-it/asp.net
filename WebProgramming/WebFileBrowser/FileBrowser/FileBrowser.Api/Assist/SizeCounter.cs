using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FileBrowser.Api.Assist
{
    public class SizeCounter
    {
        public static int[] GetFileSizeCounter(DirectoryInfo dir, int[] counters = null)
        {
            counters = counters ?? (new int[] { 0, 0, 0 });
            try
            {
                try
                {
                    FileInfo[] fileInfos = dir.GetFiles();
                    foreach (FileInfo fi in fileInfos)
                    {
                        double length = fi.Length * 0.000001;

                        if (length <= 10)
                            counters[0] += 1;
                        else if (length > 10 && length <= 50)
                            counters[1] += 1;
                        else if (length >= 100)
                            counters[2] += 1;
                    }


                    DirectoryInfo[] dirInfos = dir.EnumerateDirectories().Where(x =>
                    !x.Attributes.HasFlag(FileAttributes.ReparsePoint) && !x.Attributes.HasFlag(FileAttributes.System)
                    ).ToArray();

                    foreach (DirectoryInfo dirInfo in dirInfos)
                    {
                        counters = GetFileSizeCounter(dirInfo, counters);
                    }
                }
                catch (UnauthorizedAccessException)
                {
                }
            }
            catch (System.IO.PathTooLongException)
            {
            }

            return counters;
        }
    }
}