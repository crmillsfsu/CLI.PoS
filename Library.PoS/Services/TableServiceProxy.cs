using CLI.PoS.Model;
using Library.PoS.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace Library.PoS.Services
{
    public class TableServiceProxy
    {
        private List<Table> tables;
        private TableServiceProxy()
        {
            tables = new List<Table> { 
                new Table{Id = 1, Capacity = 4, CurrentPartySize = 0, Status = TableState.Ready}
                , new Table{Id = 2, Capacity = 4, CurrentPartySize = 0, Status = TableState.Ready}
                , new Table{Id = 3, Capacity = 8, CurrentPartySize = 0, Status = TableState.Ready}
            };
        }

        public Table? AddOrUpdate(Table? table)
        {
            if(table == null)
            {
                return null;
            }

            if(table.Id == 0)
            {
                table.Id = NextKey;
            }

            tables.Add(table);

            return table;
        }

        public Table? Delete(int id)
        {
            var tableToDelete = Tables.FirstOrDefault(t => t.Id == id);
            if(tableToDelete == null)
            {
                return null;
            }

            tables.Remove(tableToDelete);
            return tableToDelete;
        }

        public int NextKey
        {
            get
            {
                if (Tables.Any())
                {
                    return Tables.Select(i => i.Id).Max() + 1;
                }
                return 1;
            }
        }

        public List<Table> Tables => tables;

        private static object _instanceLock = new object();
        private static TableServiceProxy? instance;
        public static TableServiceProxy Current {
            get
            {
                lock (_instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new TableServiceProxy();
                    }
                }

                return instance;
            }
        }
    }
}
