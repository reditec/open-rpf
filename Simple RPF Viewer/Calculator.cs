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
            else if (size >= 1024)
            {

                return Math.Round(size / 1024.0).ToString() + " KB";
            }
            else
            {
                return "1 KB";
            }



        }

    }
}
