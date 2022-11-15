using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace HRC.Desktop
{
    /// <summary>
    /// Commanding in binding on generig type
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DelegateCommand<T> : ICommand
    {
        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// The action to execute
        /// </summary>
        private readonly Action<T> executeAction;
        /// <summary>
        /// The evaluation on can execute command
        /// </summary>
        private readonly Func<bool> canExecute;
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeAction">The execute action.</param>
        public DelegateCommand(Action<T> executeAction):this(executeAction, null){}
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeAction">The execute action.</param>
        /// <param name="canExecute">The can execute.</param>
        public DelegateCommand(Action<T> executeAction, Func<bool> canExecute)
        {
            this.executeAction = executeAction;
            this.canExecute = canExecute;
        }
        /// <summary>
        /// Raises the <see cref="CanExecuteChanged" /> event.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
        #region ICommand Members
        /// <summary>
        /// Defines the method that determines whether the command 
        /// can execute in its current state.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. 
        /// If the command does not require data to be passed,
        /// this object can be set to null.
        /// </param>
        /// <returns>
        /// true if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return canExecute == null ? true : canExecute();
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">
        /// Data used by the command. 
        /// If the command does not require data to be passed, 
        /// this object can be set to null.
        /// </param>
        public void Execute(object parameter)
        {
            executeAction((T)parameter);
        }
        #endregion
    }
}
