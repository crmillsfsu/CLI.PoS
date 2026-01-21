using System;
using System.Collections.Generic;
using System.Text;

namespace CLI.PoS.Model
{
    public class Item
    {
        private int id;
        public int Id {
            get {
                return id;
            }
            set {
                if (id != value)
                {
                    id = value;
                }
            }    
                
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price;

        public override string ToString()
        {
            return $"[{Price:C}] {Name} - {Description}";
        }

        public string Display => ToString() ?? string.Empty;

        public Item()
        {
        }
    }
}
