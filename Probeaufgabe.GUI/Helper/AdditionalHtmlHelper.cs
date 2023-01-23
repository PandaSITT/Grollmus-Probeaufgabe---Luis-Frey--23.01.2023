namespace Probeaufgabe.GUI.Helper
{
    public static class AdditionalHtmlHelper
    {
        public static string BoolToIcon(bool inputBool)
        {
            if (inputBool)
            {
                return "<i class=\"fa-solid fa-check\"></i>";
            }
            else
            {
                return "<i class=\"fa-solid fa-xmark\"></i>";
            }
        }

        public static string BoolToText(bool inputBool)
        {
            if (inputBool)
            {
                return "Ja";
            }
            else
            {
                return "Nein";
            }
        }

        public static string TempRangeToString(int tempMin, int tempMax)
        {
            return $"{tempMin} - {tempMax} °C";
        }
    }
}
