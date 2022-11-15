using System;
using System.Windows;

namespace HRC.Desktop
{
    /// <summary>
    /// Event args for when binding values change.
    /// </summary>
    public class BindingChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="e"></param>
        public BindingChangedEventArgs(DependencyPropertyChangedEventArgs e)
        {
            this.EventArgs = e;
        }

        /// <summary>
        /// Original event args.
        /// </summary>
        public DependencyPropertyChangedEventArgs EventArgs
        {
            get;
            private set;
        }
    }
}
