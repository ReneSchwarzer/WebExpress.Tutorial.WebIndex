using WebExpress.WebCore.WebMessage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebIndex.WebControl
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

            Add(new ControlFormItemInputTextBox() { Name = "search", Placeholder = "webindex:search.placeholder", Styles = ["width: 30rem;"] });
            AddPrimaryButton(new ControlFormItemButtonSubmit() { Text = "webindex:search.label", Icon = new IconPaperPlane() });
        }
    }
}
