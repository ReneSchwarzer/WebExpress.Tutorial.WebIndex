using System;
using WebExpress.WebUI.WebControl;
using WebIndex.Model;

namespace WebExpress.WebApp.WebControl
{
    /// <summary>
    /// Represents a modal form control for the initial page settings.
    /// </summary>
    internal sealed class InitialPageModalFormularControl : ControlModalForm
    {
        /// <summary>
        /// Returns the control element for entering the login identifier.
        /// </summary>
        private ControlFormItemInputTextBox Url { get; } = new ControlFormItemInputTextBox()
        {
            Label = "webindex:setting.initialpage.add.label",
            Placeholder = "webindex:setting.initialpage.add.placeholder",
            Name = "url"
        };

        /// <summary>
        /// Returns the control element for entering the login identifier.
        /// </summary>
        private ControlFormItemButtonSubmit Submit { get; } = new ControlFormItemButtonSubmit()
        {
        };


        /// <summary>
        /// Initializes a new instance of the <see cref="InitialPageModalFormularControl"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public InitialPageModalFormularControl(string id = null)
            : base(id)
        {
            //Url.Validation += OnUrlValidation;

            Form.Add(Url);
            Form.AddPrimaryButton(Submit);

            Form.ProcessForm += OnConfirm;

            Header = "webindex:setting.initialpage.add.header";
        }

        /// <summary>
        /// Called when the entered login identifier needs to be validated.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnUrlValidation(object sender, ValidationEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Url.Value))
            {
                e.Results.Add(new ValidationResult(TypesInputValidity.Error, "webexpress.webapp:setting.usermanager.user.add.login.error.empty"));
            }
        }

        /// <summary>
        /// Called when the delete action has been confirmed.
        /// </summary>
        /// <param name="sender">The trigger of the event.</param>
        /// <param name="e">The event argument.</param>
        private void OnConfirm(object sender, FormEventArgs e)
        {
            var page = new InitialPageItem()
            {
                Id = Guid.NewGuid(),
                Url = Url.Value
            };

            ViewModel.AddInitialPage(page);

            //e.Context.Redirecting(e.Context.Uri);
        }
    }
}
