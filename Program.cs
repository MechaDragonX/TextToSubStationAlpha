using System;
using System.IO;
using System.Text.RegularExpressions;

namespace TextToSubStationAlpha
{
    class Program
    {
        private static Regex onscreenPattern = new Regex("([^\\s]+)", RegexOptions.Compiled);

        static void Main(string[] args)
        {
            string writePath = "D:/Chinese Art Video Subs/subtitles.txt";

            // Prepare subtitle file with header information
            File.WriteAllLines(writePath, File.ReadAllLines("D:/Chinese Art Video Subs/header.txt"));

            // Get the text
            string[] text = File.ReadAllLines("D:/Chinese Art Video Subs/translations.txt");

            string endTime = "09:27";
            string[] current;
            string[] next = null;
            string time1 = "";
            string time2;
            string line1;
            string line2 = "";
            for(int i = 0; i < text.Length; i++)
            {
                current = text[i].Split('\t');
                if(i != text.Length - 1)
                    next = text[i + 1].Split('\t');

                time1 = onscreenPattern.Match(current[0]).Captures[0].Value;
                if (next != null)
                {   
                    time2 = onscreenPattern.Match(next[0]).Captures[0].Value;

                    line1 = $"Dialogue: 0,0:{time1}.00,0:{time2}.00,Default,,0,0,0,,{{\\be2}}{current[1]}";
                    if (current[2] != "")
                        line2 = $"Dialogue: 0,0:{time1}.00,0:{time2}.00,Notes,,0,0,0,,{{\\be2}}{current[2]}";
                }
                else
                {
                    line1 = $"Dialogue: 0,0:{time1}.00,0:{endTime}.00,Default,,0,0,0,,{{\\be2}}{current[1]}";
                    if (current[2] != "")
                        line2 = $"Dialogue: 0,0:{time1}.00,0:{endTime}.00,Notes,,0,0,0,,{{\\be2}}{current[2]}";
                }

                if(line2 != "")
                    File.AppendAllLinesAsync(writePath, new string[] { line1, line2 });
                else
                    File.AppendAllLinesAsync(writePath, new string[] { line1 });

                if (line2 == "")
                    Console.WriteLine(line1);
                else
                    Console.WriteLine(line1 + "\n" + line2);
            }
        }
    }
}
