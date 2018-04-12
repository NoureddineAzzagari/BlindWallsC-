using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindWalls.Infrastructure
{
    public class Stats
    {
        private Stats()
        {
            // Prevent outside instantiation
        }

        private static readonly Stats _stats = new Stats();
        private int loggedUsers;
        private int amountSearch;

        public static Stats GetSingleton()
        {
            return _stats;
        }

        public void addUser()
        {
            loggedUsers++;
        }
        public void removeUser()
        {
            loggedUsers--;
        }
        public int amountUser()
        {
            int test = loggedUsers;
            return test;
        }

        public void addSearch()
        {
            amountSearch++;
        }
        public int amountSearched()
        {
            int test = amountSearch;
            return test;
        }

    }
}