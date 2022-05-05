
using System;
using Crackto_Wallet;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            APICaller apiCaller = new APICaller();
            Console.WriteLine(apiCaller.GetCoinValue(CoinType.BTCBUSD));
        }
    }
}
