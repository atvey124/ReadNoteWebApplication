using System.Globalization;
using System.Text.RegularExpressions;

namespace ReadNoteWebApplication.Data.Validations
{
    public class UserValidation
    {
        public (bool,string) RegisterValidation(string email,string password,string username)
        {

            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(username))
            {
                return (false,"Password or username is empty");
            }


            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasMiniMaxChar = new Regex(@".{5,10}");
            Regex hasLowerChar = new Regex(@"[a-z]+");


            if (!hasUpperChar.IsMatch(password) || !hasUpperChar.IsMatch(username))
            {
                return (false, "Password and username does have a upper char");
            }

            else if (!hasMiniMaxChar.IsMatch(password))
            {
                return (false, "Password and username does have a 5 character minimum and 10 character maximum");
            }

            else if (!hasLowerChar.IsMatch(password) || !hasLowerChar.IsMatch(username))
            {
                return (false, "Password and username does have a upper char");
            }

            else if (!EmailValidation(email))
            {
                return (false, "email is inccorect");
            }

            return (true,null)!;
        }

        public bool EmailValidation(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                email = Regex.Replace(email, @"(@)(.+)$", DomainMapper, RegexOptions.None, TimeSpan.FromMilliseconds(200));

                string DomainMapper(Match match)
                {
                    var idn = new IdnMapping();
                    string domainName = idn.GetAscii(match.Groups[2].Value);

                    return match.Groups[1].Value + domainName;
                }
            }
            catch (RegexMatchTimeoutException e)
            {
                return false;
            }
            catch (ArgumentException e)
            {
                return false;
            }

            try
            {
                return Regex.IsMatch(email,@"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase, TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }
    }
}
