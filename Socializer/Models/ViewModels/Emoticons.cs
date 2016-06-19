using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Socializer.Models.ViewModels
{
    public class Emoticons
    {

        public static string formatString(string text) { 

                text = text.Replace(":)", "<img src='/Images/Smileys/happy.png' alt='Happy!' height='20' width='20' />");
                text = text.Replace(":(", "<img src='/Images/Smileys/sad.png' alt='Sad...' height='20' width='20' />");
                text = text.Replace(":D", "<img src='/Images/Smileys/tears.png' alt='tears...' height='20' width='20' />");
                text = text.Replace(":P", "<img src='/Images/Smileys/tongue.png' alt='tongue...' height='20' width='20' />");

            return text;
        }
    }
}