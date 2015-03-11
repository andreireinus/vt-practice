namespace Web
{
    using System.Web;
    using System.Web.Mvc;

    public static class HtmlExtensions
    {
        public static IHtmlString FormatMoney(this HtmlHelper helper, decimal amount)
        {
            return helper.Raw(string.Format("{0:##.00} €", amount));
        }
    }
}