using BepInEx;
using System;
using System.Timers;

/**
 * https://gist.github.com/lcnvdl/43bfdcb781d799df6b7e8e66fe3792db
 * Example:
 *
 * public void MouseMove(object sender, EventArgs event)
 * {
 *     this.debouncer.Debounce(() => this.DoSomeHeavyTask());
 * }
 *
 */
namespace SaveFolderEditor.Utils
{
    public class Debouncer : IDisposable
    {
        private Timer timer;
        private Action action;
        private int delay = 250; // Default delay
        private bool isRunning = false;

        public void Debounce(Action action, int delay = 250)
        {
            this.action = action;
            this.delay = delay;

            if (!this.isRunning)
            {
                this.isRunning = true;
                this.timer = new Timer(this.delay);
                this.timer.AutoReset = false; // Timer should only fire once
                this.timer.Elapsed += OnTimerElapsed;
                this.timer.Start();
            }
            else
            {
                // If the timer is already running, restart it
                this.timer.Stop();
                this.timer.Start();
            }
        }

        private void OnTimerElapsed(object sender, ElapsedEventArgs e)
        {
            this.isRunning = false;

            // Using BepInEx's threading helper to invoke the action on the main Unity thread
            ThreadingHelper.Instance.StartSyncInvoke(() => {
                this.action?.Invoke();
            });
        }

        public void Dispose()
        {
            this.timer?.Stop();
            this.timer?.Dispose();
        }
    }
}