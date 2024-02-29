using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopSystem.Models
{
    public class Store 
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }
        public string Location { get; set; }
        public int IdUser { get; set; }

        public Store() { }

        public Store(string name, string location)
        {
            Name = name;
            Location = location;
        }
        public Store(string name, string description,string location)
        {
            Name = name;
            Description = description;
            Location = location;
        }

        public Store(string name, string? description, string location,string? url )
        {
            Name = name;
            Description = description;
            Url = url;
            Location = location;
        }

        public override string ToString()
        {
            string url = (Url == "" || Url == null) ? "\nSem site cadastrado" : "\nSite: " + Url;
            return  "Nome/Razão social: " + Name+ "\nPiso: " + Location + "\nDescrição:" + Description + url ;
        }
    }
}
