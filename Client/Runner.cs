using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Client.Algs.Numbers;
using Client.Algs.Search;
using Client.Algs.Strings;
using Client.Threading;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Client
{
    [TestClass]
    public class Runner
    {
        [TestMethod]
        public void AlgTest()
        {
            var are = new Triangle().Find(new int[]{9,3,10,7,1,8,10,4});
        }
    }
}
