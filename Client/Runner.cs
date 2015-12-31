﻿using System;
using Client.Algs.Strings;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Client
{

    public class OptimalGame
    {
        private int[,] game;
        public int[] coins;

        public OptimalGame(int[] coins)
        {
            this.coins = coins;
            game = new int[coins.Length, coins.Length];
        }

        public int Play(int i, int j)
        {
            if (i > j)
                return 0;

            if (i == j)
                return game[i, j] = coins[i];

            if (i+1 == j)
                return game[i, j] = Math.Max(coins[i], coins[j]);

            if (game[i, j] != 0)
                return game[i, j];

            return Math.Max(coins[i] + Math.Min(Play(i + 2, j), Play(i + 1, j - 1)),
                            coins[j] + Math.Min(Play(i, j-2), Play(i + 1, j - 1)));

        }

       
    }

    [TestClass]
    public class Runner
    {
        [TestMethod]
        public void AlgTest()
        {
            var c = new OptimalGame(new[] { 8, 15, 3, 7 }).Play(0,3);
        }
    }
}
