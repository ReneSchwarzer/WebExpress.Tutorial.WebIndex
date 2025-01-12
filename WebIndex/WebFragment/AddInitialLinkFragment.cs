using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebCore.WebHtml;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;
using WebExpress.WebUI.WebPage;
using WebIndex.WebSettingPage;

namespace WebIndex.WebFragment
{
    /// <summary>
    /// Represents a fragment control button link for adding an initial link.
    /// </summary>
    [Section<SectionHeadlineSecondary>]
    [Scope<GeneralSettingPage>]
    public sealed class AddInitialLinkFragment : FragmentControlButtonLink
    {
        /// <summary>
        /// Returns the modal dialog for adding a user.
        /// </summary>
        private InitialPageModalFormularControl ModalDlg = new InitialPageModalFormularControl("add_initialpage");

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public AddInitialLinkFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = "webindex:add.label";
            Margin = new PropertySpacingMargin(PropertySpacing.Space.Two);
            BackgroundColor = new PropertyColorButton(TypeColorButton.Primary);
            Icon = new PropertyIcon(TypeIcon.Plus);
            Modal = new PropertyModal(TypeModal.Modal, ModalDlg);
        }

        /// <summary>
        /// Converts the control to an HTML representation.
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
