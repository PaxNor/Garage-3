using System.Text;

namespace Garage_3.Auxiliary
{
    static class StringFormatter
    {
        // removes white space and convert to upper case
        public static string CompactLicensePlate(string userString) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in userString) {
                if (char.IsWhiteSpace(c) == false) {
                    sb.Append(c);
                }
            }
            return sb.ToString().ToUpper();
        }

        // removes white space and dashes
        public static string CompactPersonNumber(string userString) {
            StringBuilder sb = new StringBuilder();
            foreach (char c in userString) {
                if (char.IsWhiteSpace(c) == false && c != '-') {
                    sb.Append(c);
                }
            }
            return sb.ToString();
        }

        // prints compact person number as yyyymmdd-xxxx
        public static string PrettyPrintPersonNumber(string personNumber) {
            return personNumber.Substring(0, 8) + "-" + personNumber.Substring(8, 4);
        }
    }
}
