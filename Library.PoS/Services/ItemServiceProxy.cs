using CLI.PoS.Model;
using System;
using System.Collections;
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
            items = new List<Item> { 
                new Item{ Id = 1, Name = "Something 1", Price = 1 }
                , new Item{ Id = 2, Name = "Something 2", Price = 2 }
                , new Item{ Id = 3, Name = "Something 3", Price = 3 } 
            };
        }

        public void AddOrUpdate(Item? item)
        {
            if (item == null)
            {
                return;
            }

            if(item.Id == 0)
            {
                item.Id = NextKey;
                Items.Add(item);
            }

        }

        public Item? Delete(Item? item)
        {
            if (item == null)
            {
                return null;
            }

            items.Remove(item);

            return item;
        }

        public int NextKey
        {
            get
            {
                if(Items.Any())
                {
                    return Items.Select(i => i.Id).Max() + 1;
                }
                return 1;
            }
        }

    }
}
