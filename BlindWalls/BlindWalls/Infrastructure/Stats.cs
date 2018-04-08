﻿using System;
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
    }
}