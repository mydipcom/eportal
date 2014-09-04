using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace MS.ECP.Web.WebHelp
{
    public static class HtmlHelpExtend
    {

        public static string UrlLink(this HtmlHelper help, string action, string control)
        {
            var urlHelper = new UrlHelper(help.ViewContext.RequestContext);
            return urlHelper.Action(action, control);
        }

        public static IHtmlString DisplayId<TModel, TValue>(
      this HtmlHelper<TModel> html,
      Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            return new HtmlString(metadata.PropertyName);
        }


        public static IHtmlString DisplayName<TModel, TValue>(
            this HtmlHelper<TModel> html,
            Expression<Func<TModel, TValue>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, html.ViewData);
            return new HtmlString(metadata.DisplayName);
        }


        public static string RenderPartialToString(this ControllerBase controller, string partialViewName, object model,
            ViewDataDictionary viewData, TempDataDictionary tempData) 
        {
            var view = ViewEngines.Engines.FindPartialView(controller.ControllerContext, partialViewName).View;
            controller.ViewData.Model = model;
            using (var writer = new StringWriter())
            {
                var viewContext = new ViewContext(controller.ControllerContext, view, controller.ViewData,
                    controller.TempData, writer);
                viewContext.View.Render(viewContext, writer);
                return writer.ToString();
            }
        }


        #region InnerTextBoxFor

        private const string Innertextkey = "innertext";

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString InnerTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var htmltextbox = htmlHelper.TextBoxFor(expression);
            return InnerTextBoxForBuilder(htmlHelper, expression, htmltextbox);
        }


        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString InnerTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, object htmlAttributes)
        {
            var htmltextbox = htmlHelper.TextBoxFor(expression, htmlAttributes);
            return InnerTextBoxForBuilder(htmlHelper, expression, htmltextbox);
        }

        [SuppressMessage("Microsoft.Design", "CA1006:DoNotNestGenericTypesInMemberSignatures",
            Justification = "This is an appropriate nesting of generic types")]
        public static MvcHtmlString InnerTextBoxFor<TModel, TProperty>(this HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, IDictionary<string, object> htmlAttributes)
        {
            var htmltextbox = htmlHelper.TextBoxFor(expression, htmlAttributes);
            return InnerTextBoxForBuilder(htmlHelper, expression, htmltextbox);
        }

        #region private method



        private static IList<object> GetAttributes<TModel, TProperty>(HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression)
        {
            var name = ExpressionHelper.GetExpressionText(expression);
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);
            var clientRules = ModelValidatorProviders.Providers.GetValidators(
                metadata ?? ModelMetadata.FromStringExpression(name, htmlHelper.ViewData), htmlHelper.ViewContext)
                .SelectMany(v => v.GetClientValidationRules());
            return (from rule in clientRules
                    where rule.ValidationParameters.ContainsKey(Innertextkey)
                    select rule.ValidationParameters[Innertextkey]).ToList();
        }


        private static MvcHtmlString InnerTextBoxForBuilder<TModel, TProperty>(HtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TProperty>> expression, MvcHtmlString htmltextbox)
        {
            var validator = GetAttributes(htmlHelper, expression);
            if (validator.Count != 1)
                return htmltextbox;
            var htmltextboxstr = htmltextbox.ToHtmlString();
            return new MvcHtmlString(htmltextboxstr.Replace("value=\"\"",
                String.Format("value=\"{0}\"", validator.First())));
        }

        #endregion

        #endregion
    }
}