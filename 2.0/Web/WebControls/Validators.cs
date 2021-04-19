using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Pripev.Web.UI.WebControls
{
    public class LengthValidator : BaseValidator
    {
        public int MinLength
        {
            get { return (ViewState["MinLength"] == null ? 0 : Convert.ToInt32( ViewState["MinLength"] )); }
            set { ViewState["MinLength"] = value; }
        }

        public override String ToolTip
        {
            get { return (String.IsNullOrEmpty( base.ToolTip ) ? String.Format( "Введите {0} или больше символов", MinLength ) : base.ToolTip); }
            set { base.ToolTip = value; }
        }

        protected override void AddAttributesToRender( HtmlTextWriter writer )
        {
            base.AddAttributesToRender( writer );

            if ( !RenderUplevel ) return;

// ReSharper disable PossibleNullReferenceException
            writer.AddAttribute( "evaluationfunction", "LengthValidator" );
// ReSharper restore PossibleNullReferenceException
            writer.AddAttribute( "MinLength", MinLength.ToString() );
        }

        protected override bool EvaluateIsValid()
        {
            var val = GetControlValidationValue( ControlToValidate );
            if ( val.Length >= MinLength ) return (true);
            ErrorMessage = String.Format( "Введите {0} или больше символов", MinLength );
            return (false);
        }
    }

    public class EmailValidator : BaseValidator
    {
        public override String ToolTip
        {
            get { return (String.IsNullOrEmpty( base.ToolTip ) ? "Введите корректный email адрес" : base.ToolTip); }
            set { base.ToolTip = value; }
        }

        protected override void AddAttributesToRender( HtmlTextWriter writer )
        {
            base.AddAttributesToRender( writer );

            if ( !RenderUplevel ) return;
// ReSharper disable PossibleNullReferenceException
            writer.AddAttribute( "evaluationfunction", "EmailValidator" );
// ReSharper restore PossibleNullReferenceException
        }

        protected override bool EvaluateIsValid()
        {
            var emailStr = GetControlValidationValue( ControlToValidate );
            const string knownDomsPat = @"^(com|net|org|edu|int|mil|gov|arpa|biz|aero|name|coop|info|pro|museum)$";
            const string emailPat = @"^(.+)@(.+)$";
            const string specialChars = "\\(\\)><@,;:\\\\\\\"\\.\\[\\]";
            const string validChars = "[^\\s" + specialChars + "]";
            const string quotedUser = "(\"[^\"]*\")";
            const string ipDomainPat1 = @"\b\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}\b";
            const string ipDomainPat2 = @"\b(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\b";
            var atom = validChars + '+';
            var word = "(" + atom + "|" + quotedUser + ")";
            var userPat = "^" + word + "(\\." + word + ")*$";
            //var domainPat = "^" + atom + "(\\." + atom + ")*$";

            var matchArray = Regex.Match( emailStr.ToLower(), emailPat );
            if ( matchArray.Groups.Count < 3 )
            {
                ErrorMessage = "Неверный email ( проверьте @ и . )";
                return (false);
            }

            var user = matchArray.Groups[1];
            var domain = matchArray.Groups[2];

            for ( var i = 0; i < user.Length; i++ )
            {
                if ( user.Value[i] <= 127 ) continue;

                ErrorMessage = "Имя содержит недопустимые символы.";
                return (false);
            }

            for ( var i = 0; i < domain.Length; i++ )
            {
                if ( domain.Value[i] <= 127 ) continue;

                ErrorMessage = "Домен содержит недопустимые символы.";
                return (false);
            }

            if ( !Regex.IsMatch( user.Value, userPat ) )
            {
                ErrorMessage = "Недопустимое имя";
                return (false);
            }

            if ( Regex.IsMatch( domain.Value, ipDomainPat1 ) )
            {
                if ( !Regex.IsMatch( domain.Value, ipDomainPat2 ) )
                {
                    ErrorMessage = "Неверный IP адрес";
                    return (false);
                }
                ErrorMessage = "";
                return (true);
            }

            var atomPat = "^" + atom + "$";
            var domArr = domain.Value.Split( new[] {'.'} );
            var len = domArr.Length;

            for ( var i = 0; i < len; i++ )
            {
                if ( Regex.IsMatch( domArr[i], atomPat ) ) continue;

                ErrorMessage = "Неверное имя домена";
                return (false);
            }

            if ( domArr[domArr.Length - 1].Length != 2 && !Regex.IsMatch( domArr[domArr.Length - 1], knownDomsPat ) )
            {
                ErrorMessage = "Адрес должен заканчиваться известным доменом или двумя буквами страны";
                return (false);
            }

            if ( len < 2 )
            {
                ErrorMessage = "Не указано имя хоста";
                return (false);
            }

            return (true);
        }
    }
}
