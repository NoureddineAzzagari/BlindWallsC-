using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlindWalls.Models
{
    public class LastViewedList
    {
        public List<Mural> mementoList = new List<Mural>();

        public void Add(Mural state)
        {
            mementoList.Add(state);
        }

        public Mural get(int index)
        {
            return mementoList[index];
        }
        public List<Mural> getLastviewed()
        {
            List<Mural> m = new List<Mural>();

            int size = mementoList.Count();
            if (size <= 5)
            {
                for (int i = 0; i < size; i++)
                {
                    m.Add(mementoList[i]);
                }
            }
            else
            {
                int start = size - 5;
                for (int i = start; i < size; i++)
                {
                    m.Add(mementoList[i]);
                }
            }
            return m;
        }
    }
}