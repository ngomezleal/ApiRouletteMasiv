using System;

namespace ApiRouletteMasiv.Miscellaneous
{
    public static class GeneralMethods
    {
        public static bool IsNumeric(object valor)
        {
            bool isNum;
            double retNum;
            isNum = Double.TryParse(Convert.ToString(valor), out retNum);
            return isNum;
        }
    }
}
