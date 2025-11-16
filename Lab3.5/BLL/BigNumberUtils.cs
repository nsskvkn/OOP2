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
            if (string.IsNullOrWhiteSpace(a) || string.IsNullOrWhiteSpace(b)) return "0";
            if (!a.All(char.IsDigit) || !b.All(char.IsDigit)) throw new System.ArgumentException("Only digits allowed");
            if (a == "0" || b == "0") return "0";

            var A = a.Reverse().Select(c => c - '0').ToArray();
            var B = b.Reverse().Select(c => c - '0').ToArray();
            var res = new int[A.Length + B.Length];

            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < B.Length; j++)
                    res[i + j] += A[i] * B[j];

            for (int i = 0; i < res.Length - 1; i++)
            {
                res[i + 1] += res[i] / 10;
                res[i] %= 10;
            }

            int k = res.Length - 1;
            while (k > 0 && res[k] == 0) k--;
            return string.Concat(res.Take(k + 1).Reverse());
        }
    }
}