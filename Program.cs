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
            Console.WriteLine("What folder do you want to write to?");
            string input;
            while(true)
            {
                input = Console.ReadLine();
                if(Directory.Exists(input))
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not a valid path!");
                Console.ResetColor();
            }
            string writePath = input;
            Console.WriteLine("What file do you want to write to");
            input = "";
            while(true)
            {
                input = Console.ReadLine();
                if(input.Split('.')[input.Split('.').Length - 1] == ".ass" || input.Split('.')[input.Split('.').Length - 1] == ".ssa")
                    break;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("That's not a valid SubStaiton Alpha file extension!\nPlease use \".ass\" or \".ssa\".");
                Console.ResetColor();
            }
            writePath = "/" + input;

            // Prepare subtitle file with header information
            File.WriteAllLines(writePath, File.ReadAllLines("D:/Chinese Art Video Subs/header.txt"));

            // Get the text
            string[] text = File.ReadAllLines("D:/Chinese Art Video Subs/translations.txt");

            string endTime = "09:27";
            string[] current;
            string[] next = null;
            bool alt = false;
            string time1 = "";
            string time2;
            string line1;
            string line2 = "";
            for(int i = 0; i < text.Length; i++)
            {
                current = text[i].Split('\t');
                if(i != text.Length - 1)
                    next = text[i + 1].Split('\t');

                if(current[0].Contains(' '))
                    alt = true;

                time1 = onscreenPattern.Match(current[0]).Captures[0].Value;
                if(next != null)
                {
                    time2 = onscreenPattern.Match(next[0]).Captures[0].Value;
                    if(alt)
                    {
                        line1 = $"Dialogue: 0,0:{time1}.00,0:{time2}.00,Alt Dialogue,,0,0,0,,{{\\be2}}{current[1]}";
                        if(current[2] != "")
                            line2 = $"Dialogue: 0,0:{time1}.00,0:{time2}.00,Notes,,0,0,0,,{{\\be2}}{current[2]}";
                    }
                    else
                    {
                        line1 = $"Dialogue: 0,0:{time1}.00,0:{time2}.00,Default,,0,0,0,,{{\\be2}}{current[1]}";
                        if (current[2] != "")
                            line2 = $"Dialogue: 0,0:{time1}.00,0:{time2}.00,Notes,,0,0,0,,{{\\be2}}{current[2]}";
                    }
                }
                else
                {
                    if(alt)
                    {
                        line1 = $"Dialogue: 0,0:{time1}.00,0:{endTime}.00,Alt Dialogue,,0,0,0,,{{\\be2}}{current[1]}";
                        if(current[2] != "")
                            line2 = $"Dialogue: 0,0:{time1}.00,0:{endTime}.00,Notes,,0,0,0,,{{\\be2}}{current[2]}";
                    }
                    else
                    {
                        line1 = $"Dialogue: 0,0:{time1}.00,0:{endTime}.00,Default,,0,0,0,,{{\\be2}}{current[1]}";
                        if(current[2] != "")
                            line2 = $"Dialogue: 0,0:{time1}.00,0:{endTime}.00,Notes,,0,0,0,,{{\\be2}}{current[2]}";
                    }
                }

                if(line2 != "")
                    File.AppendAllLinesAsync(writePath, new string[] { line1, line2 });
                else
                    File.AppendAllLinesAsync(writePath, new string[] { line1 });

                line1 = "";
                line2 = "";
            }
        }
    }
}
