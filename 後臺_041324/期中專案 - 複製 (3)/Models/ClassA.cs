using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Package2.Models
{
    public class ClassA
    {
        public class CImageCopy
        {

            private string _imagePath;

            public string ImagePath { get { 
                    return _imagePath; } }

            public Image SelectImage()
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                    if (openFileDialog.ShowDialog() != DialogResult.OK)
                        return null;

                    _imagePath = DateTime.Now.ToString("yyyyMMddHHmmss") + Path.GetExtension(openFileDialog.FileName);
                    string path = Path.Combine(Application.StartupPath, "packageImages");
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);

                    File.Copy(openFileDialog.FileName, Path.Combine(path, _imagePath));
                    return new Bitmap(Path.Combine(path, _imagePath));
                }
            }

        }

        public class StyleItem
        {
            public string StyleName { get; set; }
            public int PStyleID { get; set; }

            public override string ToString()
            {
                return StyleName; // 在 ComboBox 中显示 StyleName
            }
        }

        public class colorItem
        {
            public string colorName { get; set; }
            public int colorID { get; set; }

            public override string ToString()
            {
                return colorName; // 在 ComboBox 中显示 StyleName
            }
        }


    }
}
