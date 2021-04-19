using System;
using System.Web.UI;

namespace Pripev.Web.Temp
{
    public partial class TestMail : Page
    {
        protected override void OnLoad(EventArgs e)
        {
            if (!IsPostBack) return;

            const string subj = "Тестовый email";
            const string body = "Вот тут типа тест email и все такое...";
            const string fromName = "Припевный webmaster";
            const string toName = "Припевному tester";

            if (!String.IsNullOrEmpty(txtEmail1.Text))
                Utils.Email.SendMail("webmaster@pripev.ru", fromName, txtEmail1.Text, toName, subj, body, cbHtml.Checked);
            if (!String.IsNullOrEmpty(txtEmail2.Text))
                Utils.Email.SendMail("webmaster@pripev.ru", fromName, txtEmail2.Text, toName, subj, body, cbHtml.Checked);
            if (!String.IsNullOrEmpty(txtEmail3.Text))
                Utils.Email.SendMail("webmaster@pripev.ru", fromName, txtEmail3.Text, toName, subj, body, cbHtml.Checked);
            if (!String.IsNullOrEmpty(txtEmail4.Text))
                Utils.Email.SendMail("webmaster@pripev.ru", fromName, txtEmail4.Text, toName, subj, body, cbHtml.Checked);
        }
    }
}
