using System;
using static Loho.Utils.LineBreak;
using static Loho.Utils.TextAlign;

namespace Loho.Utils
{
    public static class Style // I guess it's disgusting code but I find it useful. Made when I learnt C# basics.
    {
        public static void AlignText(string text, TextAlign textAlign)
        {
            if (textAlign != Center) return;
            var nbSpaces = (Console.WindowWidth - text.Length) / 2;
            Console.SetCursorPosition(nbSpaces, Console.CursorTop);
        }

        public static void Write(string text = "", LineBreak lineBreak = None, TextAlign textAlign = Center)
        {
            var length = "";

            for (var i = 0; i < text.Length; i++)
            {
                length += " ";
            }

            if (lineBreak == Before || lineBreak == Both)
            {
                AlignText(length, textAlign);
                Console.WriteLine(length);
            }

            AlignText(text, textAlign);
            Console.WriteLine(text);

            if (lineBreak != After && lineBreak != Both) return;
            AlignText(length, textAlign);
            Console.WriteLine(length);
        }

        public static bool ReadBool(string optionalText = "", LineBreak lineBreak = None, TextAlign textAlign = Center)
        {
            Cc();
            while (true)
            {
                if (optionalText != "")
                    Write(optionalText, lineBreak, textAlign);

                if (textAlign == Center)
                {
                    var nbSpaces = (Console.WindowWidth - optionalText.Length) / 2;
                    Console.SetCursorPosition(nbSpaces, Console.CursorTop);
                }

                var input = Console.ReadKey().Key;

                if (input == ConsoleKey.O || input == ConsoleKey.N)
                {
                    switch (input)
                    {
                        case ConsoleKey.O:
                            return true;
                        case ConsoleKey.N:
                            return false;
                    }
                }
                else
                {
                    Write();
                    ErrorColors();
                    Write("  Error : the input is empty or non-compliant  ", Both, textAlign);
                    BaseColors();
                    Pause("retry");
                }
            }
        }

        public static int ReadInt(int? min, int? max, string optionalText = "", LineBreak lineBreak = None, TextAlign textAlign = Center)
        {
            Cc();
            int res;
            while (true)
            {
                if (optionalText != "")
                    Write(optionalText, lineBreak, textAlign);

                if (textAlign == Center)
                {
                    var nbSpaces = (Console.WindowWidth - optionalText.Length) / 2;
                    Console.SetCursorPosition(nbSpaces, Console.CursorTop);
                }

                if (int.TryParse(Console.ReadLine(), out res))
                {
                    ErrorColors();
                    if ((min == null && max == null) || (min != null && max != null && res >= min && res <= max) || (min == null && res <= max) || (max == null && res >= min))
                    {
                        BaseColors();
                        break;
                    }

                    if (min != null && res < min)
                    {
                        Write();
                        Write("  Error : the input should be at least " + min + "  ", Both, textAlign);
                        BaseColors();
                        Pause("retry");
                    }
                    else if (max != null && res > max)
                    {
                        Write();
                        Write("  Error : the input should be at most " + max + "  ", Both, textAlign);
                        BaseColors();
                        Pause("retry");
                    }
                    else
                    {
                        Write();
                        Write("  Error : the input should be between " + min + " and " + max + "  ", Both, textAlign);
                        BaseColors();
                        Pause("retry");
                    }
                }
                else
                {
                    Write();
                    ErrorColors();
                    Write("  Error : the input is empty, isn't an integer or is too big  ", Both, textAlign);
                    BaseColors();
                    Pause("retry");
                }
            }
            return res;
        }

        public static void Cc()
        {
            Console.Clear();
        }

        public static void Pause(string option = "continue", TextAlign textAlign = Center)
        {
            Write("--Press any key to " + option + "--", Before, textAlign);
            if (textAlign == Center)
            {
                var nbSpaces = Console.WindowWidth / 2;
                Console.SetCursorPosition(nbSpaces, Console.CursorTop);
            }
            while (Console.ReadKey().Key == null) { }
            Cc();
        }

        public static void BaseColors()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.BackgroundColor = ConsoleColor.White;
        }

        public static void NiceColors()
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void ErrorColors()
        {
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}