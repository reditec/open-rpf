using System;

namespace RPF
{
    abstract class Calculator
    {

        public static String CalculateSize(int size)
        {
            if (size == 0)
            {
                return "0 KB";
            }
            //formatting
            else if (size >= 1024)
            {

                return String.Format("{0:n0}", Math.Round(size / 1024.0)) + " KB";
            }
            else
            {
                return "1 KB";
            }



        }

    }
}
