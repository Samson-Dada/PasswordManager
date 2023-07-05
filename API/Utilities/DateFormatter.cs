using API.Models.UserDto;

namespace API.Utilities
{
    public class DateFormatter
    {
        public  static string DateFormat()
        {
           string date =  DateTime.UtcNow.ToString("yyyy MMMM dd");
            return date;
        }
        //// Format the date of birth
        //string formattedDateOfBirth = userForSignupDto.DateOfBirth.ToString("MMMM dd, yyyy");
        //userForSignupDto.DateOfBirth = DateTime.ParseExact(formattedDateOfBirth, "MMMM dd, yyyy", CultureInfo.InvariantCulture);
    }
}
