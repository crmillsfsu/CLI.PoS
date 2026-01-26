using CLI.PoS.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.PoS.Services
{
    public class ItemServiceProxy
    {
        private List<Item> items;

        public List<Item> Items
        {
            get
            {
                return items;
            }

            set
            {
                if (items != value)
                {
                    items = value;
                }
            }
        }
        private static ItemServiceProxy? instance;
        private static object instanceLock = new object();

        public static ItemServiceProxy Current
        {
            get
            {
                lock (instanceLock) {
                    if (instance == null)
                    {
                        instance = new ItemServiceProxy();
                    }
                }
                return instance; 
            }
        }
        private ItemServiceProxy() { 
            items = new List<Item>();
        }

    }
}
