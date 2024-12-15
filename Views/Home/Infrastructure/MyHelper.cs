

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Helpers
{

    public static class HtmlHelperExtension{

        public static IHtmlContent CustomLabel(this IHtmlHelper htmlHelper,string text){

            // label oluştururken, istenilen değerler verilir
            // kendi label'inizi oluştururken, şirketinize ait kurallar verilebilir

            // Microsoft'un label'i kullanmayıp kendi label'inizi kullanmak isteyebilirsinzi
            // kendi kontrolünüzü yazmak, şirket ile ilgili standartları oturtmak ve aynı zamanda developer kişisinin hata yapmamasını sağlar!!            
            var label ="<label class=text-danger>"+text+"</label>";
            return new HtmlString(label);
        }
        public static IHtmlContent CustomTextBox(this IHtmlHelper htmlHelper,string name,string value,string placeholder){

            string classCss = "form-control";
            var textBox = $"<input type='text' name='{name}' value='{value} placeholder='{placeholder} class='{classCss}'></input>";
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
