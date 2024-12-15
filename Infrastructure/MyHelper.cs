

using System.Linq.Expressions;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helpers
{

    public static class StringExtension
    {

        //This string ifadesi ile , Reverse metodu, string sınıfına ait bir metot olmuş olacaktır
        // This ifadesi ile, istenilen bir sınıfa metot enjeksiyonu yapılabilir!!

        // string sıfına extension metot yazdık!!
        public static string Reverse(this string value)
        {

            string reString = "";
            for (int i = value.Length - 1; i >= 0; i--)
            {
                reString += value[i];
            }
            return reString;
        }

        // Random sınıfına extension metot yazdık
        public static string NextString(this Random value, int count)
        {

            string randomString = "";
            Random rnd = new Random();
            for (int i = 0; i <= count; i++)
            {
                randomString += ((char)rnd.Next('A', 'Z')).ToString();
            }
            return randomString;

        }
    }
    public static class HtmlHelperExtension
    {

        // kendi textboxforumuzu yazıyoruz1!

        /*    IHtmlContent TextBoxFor<TResult>(
        Expression<Func<TModel, TResult>> expression,
        string format,
        object htmlAttributes);*/
        public static IHtmlContent WissenTextBoxFor<TModel, TPropery>
        (
            this IHtmlHelper<TModel> htmlHelper,
            Expression<Func<TModel, TPropery>> expression,
            string placeholder,
            string cssClass,
            object htmlAtrributes
            )
        {
            var metadata = htmlHelper.ViewData.ModelMetadata
            .Properties.FirstOrDefault(s => s.PropertyName == ((MemberExpression)expression.Body)
            .Member.Name);
            string name = htmlHelper.NameFor(expression).ToString();
            string value = htmlHelper.ValueFor(expression).ToString();

            var tagBuilder = new TagBuilder("input");
            tagBuilder.Attributes.Add("type", "text");
            tagBuilder.Attributes.Add("name", name);
            tagBuilder.Attributes.Add("value", value);
            tagBuilder.Attributes.Add("placeholder", placeholder);
            tagBuilder.Attributes.Add("class", cssClass);

            return tagBuilder;
        }

        // IHtml Helper sıfına extension metotlar yazdık!!

        // Not : HtmlHelper sınıfı, Razor tarafındaki, @Html. sınıfıdır!!

        // kendi custom controlleriniz yazmak için, Extension metot kullanabilirsiniz!!
        public static IHtmlContent CustomLabel(this IHtmlHelper htmlHelper, string text)
        {

            // label oluştururken, istenilen değerler verilir
            // kendi label'inizi oluştururken, şirketinize ait kurallar verilebilir

            // Microsoft'un label'i kullanmayıp kendi label'inizi kullanmak isteyebilirsinzi
            // kendi kontrolünüzü yazmak, şirket ile ilgili standartları oturtmak ve aynı zamanda developer kişisinin hata yapmamasını sağlar!!            
            var label = "<label class=text-danger>" + text + "</label>";
            return new HtmlString(label);
        }
        public static IHtmlContent CustomTextBox(this IHtmlHelper htmlHelper, string name, string value, string placeholder)
        {

            string classCss = "form-control";
            var textBox = $"<input type='text' name='{name}' value='{value}' placeholder='{placeholder}' class='{classCss}'></input>";
            return new HtmlString(textBox);

        }

    }
    public static class MyHelper
    {
        public static string FormatDate(DateTime date)
        {

            return date.ToLongTimeString();
        }
        public static string ToUpperCase(string text)
        {

            return text.ToUpper();
        }

    }

}
