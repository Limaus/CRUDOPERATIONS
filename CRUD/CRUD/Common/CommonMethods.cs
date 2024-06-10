using System.Text;

namespace CRUD.Common
{
    public class CommonMethods
    {
        public static string key = "Lima@78";

        public static string ConvertToEncrypt(string password)
        {
            if (password == null)
            {
                return "";
            }
            else
            {
                password += key;
                var passwordBytes = Encoding.UTF8.GetBytes(password);
                return Convert.ToBase64String(passwordBytes);
            }
        }

        public static string ConvertToDencrypt(string base64EncodeData)
        {
            if (base64EncodeData == null)
            {
                return "";
            }
            else
            {
                var base64EncodeBytes = Convert.FromBase64String(base64EncodeData);
                var result = Encoding.UTF8.GetString(base64EncodeBytes);
                result = result.Substring(0, result.Length - key.Length);
                return result;
            }
        }
    }
}
