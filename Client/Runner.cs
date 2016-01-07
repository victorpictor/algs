using System;
using System.Collections.Generic;
using System.Linq;
using Client.Algs.Search;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Client
{

    //Count the number of occurrences of an element in a sorted array
    //1 3 4 5 5 5 5 5 5 8 9 10 

    [TestClass]
    public class Runner
    {
        [TestMethod]
        public void AlgTest()
        {
            var i = new BinaryFind(new[] {2,4,5,5,6,7,7,7,7,7,7,7, 8,9, 9, 10}).FindKey(9);
        }
    }
}
