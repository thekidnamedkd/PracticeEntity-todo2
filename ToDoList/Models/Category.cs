using System.Collections.Generic;

namespace ToDoList.Models
{
    public class Category
    {
        public Category()
        {
            this.Items = new HashSet<Item>(); // HashSet = unordered collection of unique elements - hashset = more performant than a list  - helps avoid exceptions with the 'many' side of relationship
        
        }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Item> Items { get; set; }
        // Icollection = a generic interface built into .NET framework
        // interface  = collection of method signatures bundled together
    }
}