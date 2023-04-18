namespace Sat.Recruitment.Api.Infrastructure.Helpers
{
    public static class StringUtilities
    {
        public static string NormalizeEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return email;

            return RemoveInvalidCharacters(email.Substring(email.IndexOf("@"), email.Length - 1));
        }

        public static string RemoveInvalidCharacters(string strChain)
        {
            return strChain.Replace(".", string.Empty).Replace(" ", string.Empty);
        }
    }

}
