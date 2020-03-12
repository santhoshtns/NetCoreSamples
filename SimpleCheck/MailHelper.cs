using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;

namespace SimpleCheck
{
    class MailHelper
    {
        public string WildcardCharacter { get; } = "*";

        public bool WhiteListContainsExactOrWildcardedEmail(string address, IEnumerable<string> whiteList)
        {
            if (string.IsNullOrEmpty(address) || whiteList == null ||
                !ConvertToEmailAddress(address, out var emailAddress))
            {
                return false;
            }

            foreach (var item in whiteList.ToList())
            {
                if (item.StartsWith(WildcardCharacter) &&
                    ContainsWildcardedEmail(emailAddress.Address, item))
                {
                    return true;
                }

                if (WhiteListContainsExactEmail(emailAddress.Address, item))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool ConvertToEmailAddress(string email, out MailAddress mailAddress)
        {
            try
            {
                mailAddress = new MailAddress(email);
            }
            catch (Exception) //Invalid Email
            {
                mailAddress = null;
                return false;
            }

            return true;
        }

        private bool ContainsWildcardedEmail(string address, string whiteListItem)
        {
            return address.ToLower().EndsWith(whiteListItem.ToLower().Replace(WildcardCharacter, ""));
        }

        private bool WhiteListContainsExactEmail(string address, string whiteListItem)
        {
            return address.ToLower().Equals(whiteListItem.ToLower());
        }
    }
}
