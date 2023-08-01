namespace API.Utilities
{
    public static class EmailContent
    {

        public  static string Emailbody()
        {
            string body = "Congratulation uoi have save new password";
            return body;
        }
        public static string EmailSubject()
        {
            string subject = "Saved new password";
            return subject;
        }
        public static string EmailRecipent()
        {
            string recipentEmail = "samsonworkspace09@gmail.com";
            return recipentEmail;
        }
    }
}
