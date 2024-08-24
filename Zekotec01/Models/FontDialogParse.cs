using IniParser;
using IniParser.Model;
using System;
using System.Drawing;
using System.IO;

namespace Zekotec01.Models
{
    class FontDialogParse
    {

        public Font GetFont()
        {
            var parser = new FileIniDataParser();
            string filePath = "FontSetting.ini";

            if (File.Exists(filePath))
            {
                try
                {
                    IniData data = parser.ReadFile(filePath);
                    string fontType = data["GridFont"]["fontType"];
                    int fontSize = int.Parse(data["GridFont"]["fontSize"]);
                    return new Font(fontType, fontSize);
                }
                catch (Exception ex)
                {
                    // Log the exception if necessary
                    Console.WriteLine("Error reading font settings: " + ex.Message);
                    // Return a default font if there's an error
                    return new Font("Arial", 10);
                }
            }
            else
            {
                // File does not exist, return a default font
                return new Font("Arial", 10);
            }
        }

        public bool SaveFont(Font dlg)
        {
            var parser = new FileIniDataParser();
            IniData data = parser.ReadFile("FontSetting.ini");
            data["GridFont"]["fontSize"] = Math.Ceiling(dlg.Size).ToString(); ;
            data["GridFont"]["fontType"] = dlg.FontFamily.Name;
            parser.WriteFile("FontSetting.ini", data);
            return true;
        }

    }
}
