using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Loho.Utils
{
    public class Timer // welcome to a fucking messy shitty code
    {
        private int _waitingTime;
        public int WaitingTime
        {
            get => _waitingTime;
            set
            {
                if (value >= 100 && value <= 2500) _waitingTime = value;
            }
        }
        private int _tempWaitingTime;
        public int TempWaitingTime
        {
            get => _tempWaitingTime;
            set
            {
                if (value >= 100 && value <= 2500) _tempWaitingTime = value;
            }
        }
        public string Text => " Durée d'action : " + (double) TempWaitingTime / 1000 + "s ";
        private bool RestartWatch { get; set; }
        private int CursorLeftPos { get; set; }
        private int CursorTopPos { get; set; }
        private int ActionsDuringThisWait { get; set; }

        public Timer()
        {
            WaitingTime = 1300;
            RestartWatch = false;
            CursorLeftPos = 0;
            CursorTopPos = 0;
            ActionsDuringThisWait = 0;
            TempWaitingTime = 1300;
        }

        public void Wait()
        {
            ActionsDuringThisWait = 0;
            var sw = Stopwatch.StartNew();
            while (sw.ElapsedMilliseconds <= WaitingTime)
            {
                // need to display only when bool checking changes is true, following code is an insane non-sense shit
                ListenKeyboardInc(this, sw);
                ListenKeyboardDec(this, sw);
                if (RestartWatch)
                {
                    sw.Restart();
                    Display();
                    ActionsDuringThisWait++;
                    RestartWatch = false;
                }
            }
            sw.Stop();
            WaitingTime = TempWaitingTime;
        }

        private static async Task ListenKeyboardInc(Timer timer, Stopwatch sw)
        // need a rework to repeat tasks infinitely into a specific waiting duration
        {
            await Task.Factory.StartNew(() =>
            {
                while (Console.ReadKey(true).Key != ConsoleKey.DownArrow) { }
                timer.WaitingTime = 1500;
                sw.Restart();
                if (timer.TempWaitingTime <= 100) return;
                timer.TempWaitingTime -= 300; // rework this, need to apply this into the wait using var - & var +
                timer.RestartWatch = true;
            });
        }

        private static async Task ListenKeyboardDec(Timer timer, Stopwatch sw)
        {
            await Task.Factory.StartNew(() =>
            {
                while (Console.ReadKey(true).Key != ConsoleKey.UpArrow) { }
                timer.WaitingTime = 1500;
                sw.Restart();
                if (timer.TempWaitingTime >= 2500) return;
                timer.TempWaitingTime += 300;
                timer.RestartWatch = true;
            });
        }

        private void Display()
        {
            if (ActionsDuringThisWait > 0)
            {
                Console.SetCursorPosition(CursorLeftPos, CursorTopPos);
                Console.WriteLine(Environment.NewLine);
                Console.Write("   ");
                for (var i = 0; i <= Text.Length + 1; i++) Console.Write(" ");
                Console.SetCursorPosition(CursorLeftPos, CursorTopPos);
            }
            else
            {
                CursorLeftPos = Console.CursorLeft;
                CursorTopPos = Console.CursorTop;
            }
            Console.WriteLine(Environment.NewLine);
            Console.Write("   ");
            Style.NiceColors();
            Console.WriteLine(Text);
            Style.BaseColors();
            Console.WriteLine();
        }
    }
}