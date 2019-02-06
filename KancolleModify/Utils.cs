using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KancolleModify
{
    class Utils
    {
        public static List<string> GetSimilarFileList(string path, string name)
        {
            List<string> lst = new List<string>();
            try
            {
                string[] files = Directory.GetFiles(path);
                foreach (string file in files)
                {
                    string _file = file.Replace(path + (path.EndsWith("\\") ? "" : "\\"), "");
                    if (_file.StartsWith(name + "_"))
                        lst.Add(_file);
                }
            }
            catch { }
            return lst;
        }

        public static Image GetImageFromByteArray(byte[] A)
        {
            Image image = null;
            using (var ms = new MemoryStream(KancolleModify.Properties.Resources.map_bottom_banner))
            {
                image = Image.FromStream(ms);
            }
            return image;
        }

    }
}
