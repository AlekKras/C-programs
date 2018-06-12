using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using static System.Math;


namespace TeleprompterConsole
{
    internal class TelePrompterConfig
    {
        
        private static async Task RunTeleprompter()
        {
            var config = new TelePrompterConfig();
            var displayTask = ShowTeleprompter(config);

            var speedTask = ShowTeleprompter(config);
            await Task.WhenAny(displayTask, speedTask);
        }

       

        private static async Task GetInput(TelePrompterConfig config)
        {
            Action work = () =>
            {
                do
                {
                    var key = Console.ReadKey(true);
                    if (key.KeyChar == ">")
                        config.UpdateDelay(-10);
                    else if (key.KeyChar == "<")
                        config.UpdateDelay(10);
                } while  (!config.Done);
            };
            await Task.Run(work);
        }
        private object lockHandle = new object();
        public int DelayInMilliseconds {get; private set;} = 200;

        public void UpdateDelay (int increment) 
        {
            var newDelay = Min(DelayInMilliseconds + increment, 1000);
            newDelay = Max(newDelay, 20);
            lock (lockHandle)
            {
                DelayInMilliseconds = newDelay;
            }
        }
        public bool Done {get; private set; }

        public void SetDone()
        {
            Done = true;
        }
    }
}

