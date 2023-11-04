using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Program.Libary
{
    public class DateMath
    {
        public static bool isCheck(int nam)
        {
            return ((nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0);
        }

        public static int Fun(int thang, int nam)
        {
            switch (thang)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    return 31;
                case 4:
                case 6:
                case 9:
                case 11:
                    return 30;
                case 2:
                    if (isCheck(nam))
                        return 29;
                    else
                        return 28;
            }
            return -1;
        }
    }
}