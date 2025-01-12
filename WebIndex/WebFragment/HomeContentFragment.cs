using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;
using WebIndex.WebPage;

namespace WebIndex.WebFragment
{
    /// <summary>
    /// Represents the home content fragment which includes a search form.
    /// </summary>
    [Section<SectionContentPrimary>]
    [Scope<HomePage>]
    public sealed class HomeContentFragment : FragmentControlPanelFlexbox
    {
        /// <summary>
        /// Returns the control image for the home content fragment.
        /// </summary>
        private ControlImage Image { get; } = new ControlImage()
        {
            Width = 400,
            Classes = ["rounded"],
            Margin = new PropertySpacingMargin(PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.None, PropertySpacing.Space.Two)
        };

        /// <summary>
        /// Returns the search formular.
        /// </summary>
        public ControlForm Form { get; } = new ControlForm("searchform")
        {
            FormLayout = TypeLayoutForm.Inline,
            Justify = TypeJustifiedFlexbox.Center,
        };

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public HomeContentFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Layout = TypeLayoutFlexbox.Default;
            Align = TypeAlignFlexbox.Center;
            Justify = TypeJustifiedFlexbox.Center;
            Direction = TypeDirection.Vertical;

            Add(Image);
            Add(Form);

            Image.Uri = fragmentContext.ApplicationContext.ContextPath.Append("/assets/img/webindexlogo.png");

            Form.Add(new ControlFormItemInputTextBox() { Name = "search", Placeholder = "webindex:search.placeholder", Styles = ["width: 30rem;"] });
            Form.Method = RequestMethod.POST;
            Form.AddPrimaryButton(new ControlFormItemButtonSubmit() { Text = "webindex:search.label", Icon = new PropertyIcon(TypeIcon.PaperPlane) });
            Form.ProcessForm += (s, e) =>
            {

            };
        }

        /// <summary>
        /// Converts the fragment to an HTML representation.
        /// </summary>
        /// <param name="renderContext">The context in which the control is rendered.</param>
        /// <param name="visualTree">The visual tree representing the control's structure.</param>
        /// <returns>An HTML node representing the rendered control.</returns>
        public override IHtmlNode Render(IRenderControlContext renderContext, IVisualTreeControl visualTree)
        {
            return base.Render(renderContext, visualTree);
        }
    }
}