using System;
using WebExpress.Tutorial.WebIndex.Model;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebIndex.WebControl
{
    /// <summary>
    /// Represents a modal form control for the initial page settings.
    /// </summary>
    internal sealed class SeedForm : ControlModalForm
    {
        /// <summary>
        /// Returns the control element for entering the login identifier.
        /// </summary>
        private ControlFormItemInputText Url { get; } = new ControlFormItemInputText()
        {
            Name = nameof(Seed.Url),
            Label = "webexpress.tutorial.webindex:setting.seed.add.label",
            Placeholder = "webexpress.tutorial.webindex:setting.seed.add.placeholder",
            Help = "webexpress.tutorial.webindex:setting.seed.add.help"
        };

        /// <summary>
        /// Returns the control element for entering the login identifier.
        /// </summary>
        private ControlFormItemButtonSubmit Submit { get; } = new ControlFormItemButtonSubmit()
        {
        };

        /// <summary>
        /// Initializes a new instance of the <see cref="SeedForm"/> class.
        /// </summary>
        /// <param name="id">The id.</param>
        public SeedForm(string id)
            : base(id)
        {
            Header = "webexpress.tutorial.webindex:setting.seed.add.header";

            Add(Url);

            AddPrimaryButton(Submit);

            Url.Validate(x =>
            {
                x.Add
                    (
                        string.IsNullOrWhiteSpace(x.Value.Text),
                        "webexpress.tutorial.webindex:setting.seed.add.empty",
                        TypeInputValidity.Error
                    );
            });

            Url.Process(x =>
            {
                var page = new Seed()
                {
                    Id = Guid.NewGuid(),
                    Url = x.Value.Text
                };

                ViewModel.AddSeed(page);
            });

            Conformation = new ControlText()
            {
                Text = "webexpress.tutorial.webindex:setting.seed.add.confirmation",
            };
        }
    }
}
