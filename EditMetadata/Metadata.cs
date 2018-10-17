using System;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace EditMetadata
{
    class Metadata
    {
        public static void ChangeDateTime(string path, DateTime newTime)
        {
            var image = Image.FromFile(path);
            var propertyItem = image.PropertyItems.First();

            if (propertyItem != null)
            {
                var newItem = image.PropertyItems[1];
                var newDate = newTime.Year + ":" + newTime.Month.ToString().PadLeft(2, '0') + ":" + newTime.Day.ToString().PadLeft(2, '0') + " 00:00:000";
                var itemData = Encoding.UTF8.GetBytes(newDate);
                itemData[itemData.Length - 1] = 0;
                newItem.Type = 2;
                newItem.Id = 36868;
                newItem.Len = itemData.Length;
                newItem.Value = itemData;

                image.SetPropertyItem(newItem);
                image.Save(string.Concat(path, ".jj"));
                image.Dispose();
                File.Delete(path);
                File.Move(string.Concat(path, ".jj"), path);
                File.Delete(string.Concat(path, ".jj"));
            }
        }

        public static DateTime GetDate(string path)
        {
            var image = Image.FromFile(path);
            var propertyItem = image.PropertyItems.FirstOrDefault(i => i.Id == 36868);

            try
            {
                var encoding = new ASCIIEncoding();
                var date = encoding.GetString(propertyItem.Value, 0, propertyItem.Len - 1);
                image.Dispose();
                return DateTime.ParseExact(date, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture);
            }
            catch (Exception)
            {
                image.Dispose();
                return DateTime.Now;
            }
        }

        public static DateTime ExtractNewDate(string path)
        {
            var filename = path.Split(new [] { "\\" }, StringSplitOptions.None).Last().Split('-').FirstOrDefault();
            try
            {
                if (filename != null && filename.StartsWith("_"))
                {
                    filename = filename.Replace("_", "19");
                }
                else
                {
                    filename = "20" + filename;
                }

                return new DateTime(
                    int.Parse(filename.Substring(0, 4)),
                    int.Parse(filename.Substring(4, 2)),
                    int.Parse(filename.Substring(6, 2)) == 0 ? 1 : int.Parse(filename.Substring(6, 2)));
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }
    }
}