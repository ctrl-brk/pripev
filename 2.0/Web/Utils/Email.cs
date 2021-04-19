using System;
using System.Text;
using System.Web;

namespace Pripev.Utils.Web
{
    public class Email
    {
        private static HttpRequest Request
        {
            get { return (HttpContext.Current.Request); }
        }

        public static void RegisterMail(String to, String toName, Guid guid, bool bHtml)
        {
            String body;
            var link = Registry.GetString("ServerURL") + "/User/Confirm.aspx?GUID=" + guid.ToString().Replace("{", "").Replace("}", "");

            if (bHtml)
                body = @"<html><body>
                     Здравствуйте!<br>
                     Спасибо за регистрацию на сервере &laquo;Припев!&raquo;<br>
                     Для подтверждения регистрации нажмите на эту ссылку:<br>
                     <a href='" + link + "'>" + link + @"</a><br><br>
                     Если Вы не подтвердите регистрацию в течение двух недель, то она будет автоматически удалена.<br>
                     Спасибо за участие.<br>
                     По всем вопросам пишите <a href='mailto:" + Registry.GetString("ContactMail") + "'>" + Registry.GetString("ContactMail") + @"</a><br>
                     </body></html>";
            else
                body = @"Здравстуйте!
                     Спасибо за регистрацию на сервере ""Припев!""
                     Для подверждения регистрации используйте эту ссылку:\n" +
                         link + @"\n
                     Если Вы не подтвердите регистрацию в течение двух недель, она будет автоматически удалена.
                     Спасибо за участие.
                     По всем вопросам пишите " + Registry.GetString("ContactMail") + "\n";

            Utils.Email.SendMail(Registry.GetString("RegisterMail"), "Служба Припевной регистрации", to, toName, "Подтверждение припевной регистрации", body, bHtml);
        }

        public static void RemindPasswordMail(String to, String toName, String password)
        {
            String body = "Ваш логин на Pripev.ru:\n\n" +
                          "Email: " + to + "\n" +
                          "Пароль:" + password;


            Utils.Email.SendMail(Registry.GetString("RegisterMail"), "Служба Припевной регистрации", to, toName, "Ваш логин на Pripev.ru", body, false);
        }

        public static String CreateErrorEmailBody(Exception objErr, int? userId)
        {
            var body = new StringBuilder(@"
<html>
   <head>
      <style>
         body {font: 8pt/11pt Verdana; background: white}
         .Norm {font: 8pt/11pt Verdana;}
         .Err {font: 8pt/11pt Verdana; font-weight: bold;}
         .Src {font: 10px Courier}
      </style>
      <title>Pripev.ru error</title>
   </head>
<body>
<b>Script error 500 occured on " + DateTime.Now + @"</b><br><br>
<table border='0'>
");

            if (userId != null)
                body.Append("   <tr><td class='Norm'>User:</td><td class='Norm'>" + userId + "</td></tr>");

            body.Append(@"
   <tr><td class='Norm'>Error:</td><td class='Norm'>" + objErr.Message + @"</td></tr>
   <tr><td class='Norm'>Method:</td><td class='Norm'>" + Request.ServerVariables["REQUEST_METHOD"] + @"</td></tr>
   <tr><td class='Norm'>Client:</td><td class='Norm'>" + Request.ServerVariables["REMOTE_ADDR"] + @"</td></tr>
   <tr><td colspan='2'><hr size='1'>
   <tr><td class='Norm'>Url:</td><td class='Norm'>" + Request.Url + @"</td></tr>
   <tr><td class='Norm'>ReqStr:</td><td class='Norm'>" + Request.QueryString + @"</td></tr>
   <tr><td class='Norm'>Stack:</td><td class='Norm'>" + objErr.StackTrace + @"</td></tr>
   <tr><td class='Norm'>Form:</td><td class='Norm'>" + Request.Form + @"</td></tr>
   <tr><td colspan='2'><hr size='1'>
</table>");

            body.Append("<h3>Request Values</h3><table border=1 cellspacing=0 cellpadding=2>");
            foreach (string key in Request.QueryString.Keys)
            {
                body.Append("<tr><td>" + key + "</td><td>" + Request.QueryString[key] + "</td></tr>");
            }
            body.Append("</table>");

            body.Append("<h3>Form Values</h3><table border=1 cellspacing=0 cellpadding=2>");
            foreach (string key in Request.Form.Keys)
            {
                body.Append("<tr><td>" + key + "</td><td>" + Request.Form[key] + "</td></tr>");
            }
            body.Append("</table>");

            body.Append("<h3>Server variables</h3><table border=1 cellspacing=0 cellpadding=2>");
            for (var i = 0; i < Request.ServerVariables.Count; i++)
            {
                body.Append("<tr><td>" + Request.ServerVariables.Keys[i] + "</td><td>" + Request.ServerVariables[Request.ServerVariables.Keys[i]] + "</td></tr>");
            }
            body.Append("</table>");

            body.Append("</body></html>");

            return (body.ToString());
        }

        public static String EmailLink(String type)
        {
            var aName = Registry.GetString(type).Split(new[] { '@' });
            var aDomain = aName[1].Split(new[] { '.' });

            return ("<script language='javascript'>PrintEmLink('" + aName[0] + aDomain[0] + aDomain[1] + "'," + aName[0].Length + "," + aDomain[0].Length + ");</script>");
        }
    }
}
