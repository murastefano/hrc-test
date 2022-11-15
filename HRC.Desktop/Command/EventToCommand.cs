using Microsoft.Xaml.Behaviors;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;

namespace HRC.Desktop
{
    /// <summary>
    /// Class to convert a routed event to a command.
    /// </summary>
    public class EventToCommand : TriggerAction<FrameworkElement>
    {
        #region Variables
        private ICommand _command;
        private object _commandParameter;
        private bool _disableAssociatedObjectOnCannotExecute;
        private BindingListener _commandBindingListener;
        private BindingListener _commandParameterBindingListener;
        private BindingListener _disableAssociatedObjectOnCannotExecuteBindingListener;
        #endregion

        #region Constructor & destructor
        /// <summary>
        /// Initializes a new instance of the <see cref="EventToCommand"/> class.
        /// </summary>
        public EventToCommand()
        {
            _disableAssociatedObjectOnCannotExecute = true;
        }
        #endregion

        #region Properties

        /// <summary>
        /// Gets or sets a value indicating whether the <see cref="EventArgs"/> passed to the event handler
        /// should be passed to the command as well.
        /// </summary>
        /// <value>
        /// 	<c>true</c> if the <see cref="EventArgs"/> passed to the event handler should be passed to the command; otherwise, <c>false</c>.
        /// </value>
        public bool PassEventArgsToCommand { get; set; }


        /// <summary>
        /// Gets or sets a value indicating whether the associated object should be disabled when the command
        /// cannot be executed.
        /// </summary>
        /// <remarks>
        /// Wrapper for the DisableAssociatedObjectOnCannotExecute dependency property.
        /// </remarks>
        public bool DisableAssociatedObjectOnCannotExecute
        {
            get { return (bool)GetValue(DisableAssociatedObjectOnCannotExecuteProperty); }
            set { SetValue(DisableAssociatedObjectOnCannotExecuteProperty, value); }
        }

        /// <summary>
        /// DependencyProperty definition as the backing store for DisableAssociatedObjectOnCannotExecute.
        /// </summary>
        public static readonly DependencyProperty DisableAssociatedObjectOnCannotExecuteProperty =
            DependencyProperty.Register("DisableAssociatedObjectOnCannotExecute", typeof(bool), typeof(EventToCommand), new PropertyMetadata(true,
                (sender, e) => ((EventToCommand)sender).OnDisableAssociatedObjectOnCannotExecuteChanged((bool)e.NewValue)));



        /// <summary>
        /// Gets or sets the associated Command.
        /// </summary>
        /// <remarks>
        /// Wrapper for the Command dependency property.
        /// </remarks>
        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        /// <summary>
        /// DependencyProperty definition as the backing store for Command.
        /// </summary>
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(EventToCommand), new PropertyMetadata(null,
                (sender, e) => ((EventToCommand)sender).OnCommandChanged(e.NewValue as ICommand)));


        /// <summary>
        /// Gets or sets the command parameter.
        /// </summary>
        /// <remarks>
        /// Wrapper for the CommandParameter dependency property.
        /// </remarks>
        public Binding CommandParameter
        {
            get { return (Binding)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        /// <summary>
        /// DependencyProperty definition as the backing store for CommandParameter.
        /// </summary>
        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(Binding), typeof(EventToCommand), new PropertyMetadata(null,
                (sender, e) => ((EventToCommand)sender)._commandParameterBindingListener.Binding = e.NewValue as Binding));
        #endregion

        #region Methods
        /// <summary>
        /// Called when the <see cref="DisableAssociatedObjectOnCannotExecute"/> property has changed.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        private void OnDisableAssociatedObjectOnCannotExecuteChanged(bool newValue)
        {
            _disableAssociatedObjectOnCannotExecute = newValue;

            UpdateElementState();
        }

        /// <summary>
        /// Called when the <see cref="Command"/> property has changed.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        private void OnCommandChanged(ICommand newValue)
        {
            if (_command != null)
            {
                _command.CanExecuteChanged -= OnCommandCanExecuteChanged;
            }

            _command = newValue;

            if (_command != null)
            {
                _command.CanExecuteChanged += OnCommandCanExecuteChanged;
            }

            UpdateElementState();
        }

        /// <summary>
        /// Called when the <see cref="CommandParameter"/> property has changed.
        /// </summary>
        /// <param name="newValue">The new value.</param>
        private void OnCommandParameterChanged(object newValue)
        {
            _commandParameter = newValue;

            UpdateElementState();
        }

        /// <summary>
        /// Called when the <c>CanExecute</c> state of a command has changed.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void OnCommandCanExecuteChanged(object sender, EventArgs e)
        {
            UpdateElementState();
        }

        /// <summary>
        /// Invokes the action without any parameter.
        /// </summary>
        public void Invoke()
        {
            Invoke(null);
        }

        /// <summary>
        /// Invokes the action.
        /// </summary>
        /// <param name="parameter">The parameter to the action. If the Action does not require a parameter, the parameter may be set to a null reference.</param>
        protected override void Invoke(object parameter)
        {
            if (IsAssociatedObjectDisabled() || (_command == null))
            {
                return;
            }

            object commandParameter = _commandParameter;
            if ((commandParameter == null) && PassEventArgsToCommand)
            {
                commandParameter = parameter;
            }

            if (_command.CanExecute(commandParameter))
            {
                _command.Execute(commandParameter);
            }
        }

        /// <summary>
        /// Checks whether the associated object is disabled or not.
        /// </summary>
        /// <returns><c>true</c> if the associated object is disabled; otherwise <c>false</c>.</returns>
        private bool IsAssociatedObjectDisabled()
        {
            return false;
        }

        /// <summary>
        /// Updates the state of the associated element.
        /// </summary>
        private void UpdateElementState()
        {
            if ((AssociatedObject == null) || (_command == null))
            {
                return;
            }
        }

        /// <summary>
        /// Called when this trigger is attached to a <see cref="FrameworkElement"/>.
        /// </summary>
        protected override void OnAttached()
        {
            base.OnAttached();
            UpdateElementState();
        }

        /// <summary>
        /// Called when the action is being detached from its AssociatedObject, but before it has actually occurred.
        /// </summary>
        protected override void OnDetaching()
        {
            base.OnDetaching();
            if (_command != null)
            {
                _command.CanExecuteChanged -= OnCommandCanExecuteChanged;
            }

            _command = null;
            ClearValue(CommandProperty);

            _commandParameter = null;
            ClearValue(CommandParameterProperty);
        }
        #endregion
    }
}
