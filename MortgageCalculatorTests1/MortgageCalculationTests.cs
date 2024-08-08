using Microsoft.VisualStudio.TestTools.UnitTesting;
using MortgageCalculator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MortgageCalculator.Tests
{
    [TestClass()]
    public class MortgageCalculationTests
    {
        [TestMethod()]
        public void CalculateMonthlyPaymentsTest()
        {
            //arrange
            int expectedTerm = 360;
            double expectedInterestRate = 4.5;
            double expectedLoan = 200000;

            //act
            MortgageCalculation mortgage = new MortgageCalculation(expectedTerm, expectedInterestRate, expectedLoan);

            //assert
            Assert.AreEqual(expectedTerm, mortgage.Term);
            Assert.AreEqual(expectedInterestRate, mortgage.InterestRate);
            Assert.AreEqual(expectedLoan, mortgage.Loan);
        }
    }
}