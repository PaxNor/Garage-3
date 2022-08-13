using System.Text;

namespace Garage_2._0.Auxilary
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
    }
}
