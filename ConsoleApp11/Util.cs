using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Microsoft.VisualBasic;

namespace ConsoleApp11
{
    public class Util
    {
        public static String ArrayToString(Array arr)
        {
            if (arr.Length < 1)
            {
                return "[]";
            }

            StringBuilder sb = new StringBuilder("[");

            if (arr.Rank == 1)
            {
                foreach (var item in arr)
                {
                    switch (item)
                    {
                        case null:
                            sb.Append("null, ");
                            break;
                        default:
                            sb.Append(item).Append(", ");
                            break;
                    }
                }
            }
            else
            {
                int columnLength = arr.GetUpperBound(0)+1;
                int currentIndex = 0;
                sb.Append("[");
                foreach (var item in arr)
                {
                    switch (item)
                    {
                        case null:
                            sb.Append("null, ");
                            break;
                        default:
                            sb.Append(item).Append(", ");
                            break;
                    }
                    if (++currentIndex == columnLength)
                    {
                        sb.Remove(sb.Length - 2, 2).Append("]\n[");
                        currentIndex = 0;
                    }
                }
            }

            sb.Remove(sb.Length - 2, 2).Append(']');
            return sb.ToString();
        }

        public static void TempCollections<T>(ICollection<T> collection)
        {
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
}