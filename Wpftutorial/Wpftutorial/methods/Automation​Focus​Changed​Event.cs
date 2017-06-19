
using System.Windows.Automation;
using System.Diagnostics;
using Wpftutorial;
using System;
using System.ComponentModel;

namespace Wpftutorial.methods
{
    class Automation​Focus​Changed​Event
    {
        AutomationFocusChangedEventHandler focusHandler = null;

        /// <summary>
        /// Create an event handler and register it.
        /// </summary>
        public void SubscribeToFocusChange(MainWindow window)
        {
            focusHandler = new AutomationFocusChangedEventHandler(window.OnFocusChange);
            Automation.AddAutomationFocusChangedEventHandler(focusHandler);
        }


        /// <summary>
        /// Cancel subscription to the event.
        /// </summary>
        public void UnsubscribeFocusChange(MainWindow window)
        {
            if (focusHandler != null)
            {
                Automation.RemoveAutomationFocusChangedEventHandler(window.OnFocusChange);
                focusHandler = null;
            }
        }

        public string getprocessinfo()
        {

            return Process.GetCurrentProcess().ProcessName;
        }
    }
}
