using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._5.BLL;
using NUnit.Framework;

namespace Lab3._5.Tests
{
    public class BigNumberUtilsTests
    {
        [Test]
        public void Multiply_LongNumbers_ReturnsCorrectResult()
        {
            string r = BigNumberUtils.Multiply("123456789", "987654321");
            Assert.AreEqual("121932631112635269", r);
        }

        [Test]
        public void Multiply_ByZero_ReturnsZero()
        {
            Assert.AreEqual("0", BigNumberUtils.Multiply("12345", "0"));
            Assert.AreEqual("0", BigNumberUtils.Multiply("0", "999"));
        }

        [Test]
        public void Multiply_SingleDigit()
        {
            Assert.AreEqual("18", BigNumberUtils.Multiply("3", "6"));
        }

        [Test]
        public void Multiply_DifferentLengthNumbers()
        {
            Assert.AreEqual("56088", BigNumberUtils.Multiply("123", "456"));
        }

        [Test]
        public void Multiply_InvalidCharacters_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                BigNumberUtils.Multiply("12A3", "123"));
        }
    }
}