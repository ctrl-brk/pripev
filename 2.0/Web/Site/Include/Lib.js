function LTrim(str) {
    if (!str) return (str);

    var whitespace = " \t\n\r";

    if (whitespace.indexOf(str.charAt(0)) != -1) {
        var j = 0, i = str.length;
        while (j < i && whitespace.indexOf(str.charAt(j)) != -1) j++;
        str = str.substring(j, i);
    }
    return (str);
}

function RTrim(str) {
    if (!str) return (str);

    var whitespace = " \t\n\r";

    if (whitespace.indexOf(str.charAt(str.length - 1)) != -1) {
        var i = str.length - 1;
        while (i >= 0 && whitespace.indexOf(str.charAt(i)) != -1) i--;
        str = str.substring(0, i + 1);
    }
    return (str);
}

function Trim(str) {
    return (RTrim(LTrim(str)));
}

function Redirect(sURL) {
    document.location = sURL;
}

function OfflineAlert(sCmt) {
    if (sCmt && sCmt != "") sCmt = "\n------------------------------\n" + sCmt;
    else sCmt = "";

    alert("Есть вероятность, что в разделе \"Заказы\" Вам помогут." + sCmt);
}

function OnlineAlert() {
    alert("Пока не работает");
}

function CDExists() {
    alert("Этот CD имеется в оригинальном виде.\nТакже можете обратиться в раздел \"Заказы\"");
}

function ShareInfo() {
    Redirect("/ShareInfo.aspx");
}

function PrintEmLink(s, l1, l2, pars) {
    document.write("<a href='ma");
    document.write("ilto");
    document.write(":" + s.substring(0, l1));
    document.write("@");
    document.write(s.substring(l1, l1 + l2));
    document.write(".");
    document.write(s.substring(l1 + l2));
    document.write("'");
    if (pars != "") document.write(" " + pars);
    document.write(">");
}

function ChordsGen() {
    var sURL = "/Chords/ChordsPopup.aspx";

    window.open(sURL, "", "directories=no,height=630,width=520,location=no,menubar=no,status=0,toolbar=no,resizable=yes,scrollbars=yes");
}

function PrintText(nSongId, nTextId) {
   var sURL = "/PrintText.aspx?SongId=" + nSongId + "&TextId=" + nTextId;

   window.open(sURL, "", "directories=no,height=600,width=800,location=no,menubar=no,status=0,toolbar=no,resizable=yes,scrollbars=yes");
}

function OpenChat() {
   var w = window.open("/Chat.aspx", "ChatWindow", "directories=no,height=500,width=700,location=no,menubar=no,status=0,toolbar=no,resizable=no,scrollbars=no");
   w.focus();
}

function CDExists() {
   alert("Этот CD имеется в оригинальном виде.\nТакже можете обратиться в раздел \"Заказы\"");
}

function FileUpload(nTrack, sArtist, sAlbum, sSong) {
    var sURL = "/Upload/Upload.aspx?Artist=" + escape(sArtist) + "&Album=" + escape(sAlbum);

    if (nTrack > 0) sURL += "&Song=" + escape(sSong);
    window.open(sURL, "", "directories=no,height=600,width=750,location=no,menubar=no,status=0,toolbar=no,resizable=yes,scrollbars=yes");
}

function LengthValidator(val) {
   var obCtrl = document.getElementById(val.controltovalidate);
   var minLength = parseInt( val.MinLength );
   return (obCtrl.value.length >= minLength);
}

function EmailValidator(val) {
   var obCtrl = document.getElementById(val.controltovalidate);
   var emailStr = obCtrl.value;
   var checkTLD = 1;
   var knownDomsPat = /^(com|net|org|edu|int|mil|gov|arpa|biz|aero|name|coop|info|pro|museum)$/;
   var emailPat = /^(.+)@(.+)$/;
   var specialChars = "\\(\\)><@,;:\\\\\\\"\\.\\[\\]";
   var validChars = "\[^\\s" + specialChars + "\]";
   var quotedUser = "(\"[^\"]*\")";
   var ipDomainPat = /^\[(\d{1,3})\.(\d{1,3})\.(\d{1,3})\.(\d{1,3})\]$/;
   var atom = validChars + '+';
   var word = "(" + atom + "|" + quotedUser + ")";
   var userPat = new RegExp("^" + word + "(\\." + word + ")*$");
   var domainPat = new RegExp("^" + atom + "(\\." + atom + ")*$");

   var matchArray = emailStr.toLowerCase().match(emailPat);

   if (matchArray == null) {
      //val.errormessage = "Неверный email ( @ или . )";
      return (false);
   }

   var user = matchArray[1];
   var domain = matchArray[2];

   for (var i = 0; i < user.length; i++) {
      if (user.charCodeAt(i) > 127) {
         //alert("Ths username contains invalid characters.");
         return (false);
      }
   }

   for (var i = 0; i < domain.length; i++) {
      if (domain.charCodeAt(i) > 127) {
         //alert("Ths domain name contains invalid characters.");
         return (false);
      }
   }

   if (user.match(userPat) == null) {
      //alert("The username doesn't seem to be valid.");
      return (false);
   }

   var IPArray = domain.match(ipDomainPat);
   if (IPArray != null) {
      for (var i = 1; i <= 4; i++) {
         if (IPArray[i] > 255) {
            //alert("Destination IP address is invalid!");
            return (false);
         }
      }
      return (true);
   }

   var atomPat = new RegExp("^" + atom + "$");
   var domArr = domain.split(".");
   var len = domArr.length;

   for (var i = 0; i < len; i++) {
      if (domArr[i].search(atomPat) == -1) {
         //alert("The domain name does not seem to be valid.");
         return (false);
      }
   }

   if (checkTLD && domArr[domArr.length - 1].length != 2 && domArr[domArr.length - 1].search(knownDomsPat) == -1) {
      //alert("The address must end in a well-known domain or two letter " + "country.");
      return (false);
   }

   if (len < 2) {
      //alert("This address is missing a hostname!");
      return (false);
   }

   return (true);
}

function GetControlValue(sId, bNoWarn, bLastLetter) {
    var obCtrl = document.getElementById(sId);
    var Ret = null;

    if (!obCtrl) {
        if ( !bNoWarn ) alert("GetControlValueDiretct error: Control is null");
        return (false);
    }

    if (obCtrl.type == "radio") {
        var obParent = document.forms[0];

        for (var i = 0; i < obParent.elements.length; i++) {
            if (obParent.elements[i].type == "radio" && obParent.elements[i].name == obCtrl.name) {
                if (obParent.elements[i].checked) {
                    Ret = obParent.elements[i].value;
                    break;
                }
            }
        }
    }
    else if (obCtrl.type == "select" || obCtrl.type == "select-one") {
        if (obCtrl.selectedIndex != -1)
            Ret = obCtrl.options[obCtrl.selectedIndex].value;
    }
    else if (obCtrl.type == "select-multiple") {
        for (var i = 0; i < obCtrl.length; i++) {
            if (obCtrl.options[i].selected) {
                if (!Ret) Ret = "";
                if (Ret != "") Ret += ", ";
                Ret += obCtrl.options[i].value;
            }
        }
    }
    else if (obCtrl.type == "text" || obCtrl.type == "textarea" || obCtrl.type == "hidden" || obCtrl.type == "password" || obCtrl.type == "file") {
        Ret = "" + obCtrl.value;
        var len = parseInt(Ret.length, 10);
        if (len > 0) {
            for (var i = len - 1; i >= 0; i--) {
                if (Ret.charAt(i) != " ") break;
            }
            if (i > -1) Ret = Ret.substring(0, i + 1);
        }
    }
    else if (obCtrl.type == "checkbox") {
        if (obCtrl.checked) Ret = "on";
    }

    else alert("GetControlValueDirect error: Unknown object type '" + obCtrl.type + "'" + obCtrl.name);

    if (Ret) {
        Ret = Trim(Ret);
        if (Ret.toString() == "") Ret = null;
        if ( Ret && bLastLetter ) Ret = Ret.charAt( Ret.length - 1 )
    }
    return (Ret);
}

function SetControlValue(sId, sValue, bNoWarn) {
   var obCtrl = document.getElementById( sId );

   if (!obCtrl) {
      if (!bNoWarn) alert("SetControlValue error: Object '" + sName + "' not found");
      return (null);
   }

   if (obCtrl.type == "file") return (obCtrl);

   if (obCtrl.type == "text" || obCtrl.type == "textarea" || obCtrl.type == "hidden" || obCtrl.type == "password" || obCtrl.type == "file") obCtrl.value = sValue;
   else if (obCtrl.type == "select-one") {
      for (var i = 0; i < obCtrl.options.length; i++) {
         if (obCtrl.options[i].value == sValue) {
            obCtrl.selectedIndex = i;
            break;
         }
      }
   }
   else if (obCtrl.type == "select-multiple") {
      var aOpt = sValue.split(", ");

      for (var i = 0; i < obCtrl.options.length; i++) obCtrl.options[i].selected = false;

      for (i = 0; i < obCtrl.options.length; i++) {
         for (var j = 0; j < aOpt.length; j++) {
            if (obCtrl.options[i].value == aOpt[j]) obCtrl.options[i].selected = true;
         }
      }
   }
   else if (obCtrl.type == "radio") {
      var obParent = document.forms[0];

      for (var i = 0; i < obParent.elements.length; i++) {
         if (obParent.elements[i].type == "radio" && obParent.elements[i].name == sName) {
            if (obParent.elements[i].value == sValue || obParent.elements[i].value.toString() == (sValue.toString() == "True" ? "1" : "0")) {
               obParent.elements[i].checked = true;
               break;
            }
            else obParent.elements[i].checked = false;
         }
      }
   }
   else if (obCtrl.type == "checkbox") {
      if (typeof (sValue) == "boolean") obCtrl.checked = sValue;
      else if (typeof (sValue) == "string") {
         sValue = sValue.toLowerCase();
         if (sValue == "true" || sValue == "on" || sValue == "yes" || sValue == "y") obCtrl.checked = true;
         else if (sValue == "" || sValue == "false" || sValue == "off" || sValue == "no" || sValue == "n") obCtrl.checked = false;
      }
      else {
         var nValue = parseInt(sValue, 10);
         if (isNaN(nValue)) nValue = 0;
         if (nValue == 0) obCtrl.checked = false;
         else obCtrl.checked = true;
      }
   }
   else if (obCtrl.type == "button") {
      if (typeof (sValue) == "string") obCtrl.value = sValue;
   }

   else alert("SetControlValue error: Unknown object type '" + obCtrl.type + "'");

   return (obCtrl);
}

function Request(key) {
   var qs = window.location.search.substring(1);
   var aPars = qs.split("&");
   for (i = 0; i < aPars.length; i++) {
      var aPair = aPars[i].split("=");
      if (aPair[0] == key) return aPair[1];
   }
   return (null);
}
