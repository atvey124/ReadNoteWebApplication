using System.Text.RegularExpressions;

namespace ReadNoteWebApplication.Data.Validations
{
    public class NoteValidation
    {
        public (bool, string) CreatValidation(string text, string title)
        {

            if (string.IsNullOrEmpty(text) || string.IsNullOrEmpty(title))
            {
                return (false, "Password or username is empty");
            }


            Regex hasUpperChar = new Regex(@"[A-Z]+");
            Regex hasMiniMaxCharText = new Regex(@".{5,200}");
            Regex hasMiniMaxCharTitle = new Regex(@".{5,30}");
            Regex hasLowerChar = new Regex(@"[a-z]+");


            if (!hasUpperChar.IsMatch(text) || !hasUpperChar.IsMatch(title))
            {
                return (false, "Text and title does have a upper char");
            }

            else if (!hasMiniMaxCharText.IsMatch(text))
            {
                return (false, "Text does have a 5 character minimum and 200 character maximum");
            }

            else if (!hasMiniMaxCharTitle.IsMatch(title))
            {
                return (false, "Title does have a 5 character minimum and 30 character maximum");
            }

            else if (!hasLowerChar.IsMatch(title) || !hasLowerChar.IsMatch(text))
            {
                return (false, "Text and title does have a upper char");
            }

            return (true, null)!;
        }
    }
}
