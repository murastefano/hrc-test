using System;
using System.Windows.Input;

namespace HRC.Desktop
{
    /// <summary>
    /// Commanding in binding
    /// </summary>
    public class DelegateCommand : ICommand
    {
        /// <summary>
        /// Occurs when changes occur that affect whether the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged;
        /// <summary>
        /// The action to execute
        /// </summary>
        private readonly Action executeAction;
        /// <summary>
        /// The evaluation on can execute command
        /// </summary>
        private readonly Func<bool> canExecute;
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeAction">The execute action.</param>
        public DelegateCommand(Action executeAction):this(executeAction, null){}
        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand"/> class.
        /// </summary>
        /// <param name="executeAction">The execute action.</param>
        /// <param name="canExecute">The can execute.</param>
        public DelegateCommand(Action executeAction, Func<bool> canExecute)
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
            executeAction();
        }
        #endregion
    }
}
