using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab3._5.BLL;

namespace Lab3._5.Tests
{
    [TestFixture]
    public class BigNumberUtilsTests
    {
        [Test]
        public void Multiply_LongNumbers_ReturnsCorrectResult()
        {
            string r = BigNumberUtils.Multiply("123456789", "987654321");
            Assert.That(r, Is.EqualTo("121932631112635269"));
        }

        [Test]
        public void Multiply_ByZero_ReturnsZero()
        {
            Assert.That(BigNumberUtils.Multiply("12345", "0"), Is.EqualTo("0"));
            Assert.That(BigNumberUtils.Multiply("0", "999"), Is.EqualTo("0"));
        }

        [Test]
        public void Multiply_SingleDigit()
        {
            Assert.That(BigNumberUtils.Multiply("3", "6"), Is.EqualTo("18"));
        }

        [Test]
        public void Multiply_DifferentLengthNumbers()
        {
            Assert.That(BigNumberUtils.Multiply("123", "456"), Is.EqualTo("56088"));
        }

        [Test]
        public void Multiply_InvalidCharacters_Throws()
        {
            Assert.Throws<ArgumentException>(() =>
                BigNumberUtils.Multiply("12A3", "123"));
        }
    }
}