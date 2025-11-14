using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3._5.BLL
{
    public static class BigNumberUtils
    {
        public static string Multiply(string a, string b)
        {
            if (a == "0" || b == "0") return "0";
            if (!a.All(char.IsDigit) || !b.All(char.IsDigit))
                throw new ArgumentException();

            var A = a.Reverse().Select(c => c - '0').ToArray();
            var B = b.Reverse().Select(c => c - '0').ToArray();

            var result = new int[A.Length + B.Length];

            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < B.Length; j++)
                    result[i + j] += A[i] * B[j];

            for (int i = 0; i < result.Length - 1; i++)
            {
                result[i + 1] += result[i] / 10;
                result[i] %= 10;
            }

            int k = result.Length - 1;
            while (k > 0 && result[k] == 0) k--;

            return string.Concat(result.Take(k + 1).Reverse());
        }
    }
}
