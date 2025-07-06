using WebExpress.WebCore.WebMessage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebIndex.WebControl
{
    /// <summary>
    /// Represents a search form control.
    /// </summary>
    internal class SearchForm : ControlForm
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SearchForm"/> class.
        /// </summary>
        public SearchForm()
            : base("searchform")
        {
            FormLayout = TypeLayoutForm.Inline;
            Method = RequestMethod.GET;

            Add(new ControlFormItemInputText()
            {
                Name = "search",
                Placeholder = "webexpress.tutorial.webindex:search.placeholder",
                Styles = ["width: 30rem;"]
            });

            AddPrimaryButton(new ControlFormItemButtonSubmit()
            {
                Text = "webexpress.tutorial.webindex:search.label",
                Icon = new IconPaperPlane()
            });
        }
    }
}
