using System;
using System.Text;
using System.Web;

namespace HtmlEncodingApp
{
    class Program
    {
        private static string WebUrl = "https://localhost:44301";

        static void Main(string[] args)
        {
            var notificationUrl = GetUrlToMasterData();
            var body = GenerateBody("<br>" + notificationUrl);
            Console.WriteLine(body);
        }

        static string GenerateBody(string message)
        {
            message = FromText(message);

            var builder = new StringBuilder();
            builder.Append("<div style='padding: 10px;line-height:18px;font-family:'Lucida Grande',Verdana,Arial,sans-serif;font-size:12px;color:#444444;'>");
            builder.Append("<p>").Append(message).Append("</p>");
            builder.Append("<p>This is an automated report from Chinsay. Please do not reply to this message.</p>");
            builder.Append("<div style='color: #aaaaaa; margin: 10px 0 14px 0; padding-top: 10px; border-top: 1px solid #eeeeee;'>");
            builder.Append("This email is a service from Chinsay.");
            builder.Append("</div></div>");
            return builder.ToString();
        }

        public static string FromText(string text)
        {
            text = HttpUtility.HtmlEncode(text);
            text = text.Replace("\r\n", "\r");
            text = text.Replace("\n", "\r");
            text = text.Replace("\r", "<br />\r\n");
            text = text.Replace("  ", " &nbsp;");
            return text;
        }

        static string GetUrlToMasterData()
        {
            var link = $"{WebUrl}/MasterData";
            var url = $"See <a href='{link}'>Master Data Admin</a> ({link}).";

            return url;
        }
    }
}
