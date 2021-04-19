using System;
using System.Data;
using Pripev.DAL;
using Pripev.Utils;
using log4net;
using log4net.Config;

namespace ResendRegistrations
{
    internal class Program
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(Program).FullName);

        private static void Main()
        {
#if !DEBUG
            try
#endif
            {
                XmlConfigurator.Configure();
                Process();
            }
#if !DEBUG            
            catch (Exception e)
            {
                Log.Error( e.Message );
                Email.ErrorMail("Ошибка при повторной отсылке сообщения о регистрации", e.Message, false);
            }
#endif
        }

        private static void Process()
        {
            const string fmt = @"<html><body>
Здравствуйте!<br><br>

Я дико извиняюсь, но вполне возможно, что Вы не получили сообщение о подтвержении регистрации на сайте Pripev.ru из за технических проблем.<br>
Ниже приводится ссылка для подтверждения регистрации.<br><br>
<a href='{0}'>{0}</a><br><br>
Спасибо за участие.<br>
Администрация Pripev.ru<br>
По всем вопросам пишите <a href='mailto:{1}'>{1}</a>
";
            var dt = DB.ExecuteDataTable(@"select w.Email, w.CreatedOn, w.Name, w.GUID from WebUsers w where w.Status='W' and CreatedOn > '2011-01-01'");
            
            foreach (DataRow dr in dt.Rows)
            {
                var guid = dr.Field<Guid>("GUID");
                var link = Registry.GetString("ServerURL") + "/User/Confirm.aspx?GUID=" + guid.ToString().Replace("{", "").Replace("}", "");
                var msg = String.Format(fmt, link, Registry.GetString("ContactMail"));
                Email.SendMail(Registry.GetString("RegisterMail"), "Служба Припевной регистрации", dr.Field<string>("Email"), dr.Field<string>("Name"), "Подтверждение припевной регистрации", msg, true);
                Log.InfoFormat("{0}. Регистрация {1}", dr.Field<string>("Email"), dr.Field<DateTime>("CreatedOn"));
            }
        }
    }
}
