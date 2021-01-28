namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Repository
    {
        public Dictionary<int, Person> Data { get; set; }

        public int Count { get { return this.Data.Count; } }

        public Repository()
        {
            this.Data = new Dictionary<int, Person>();
        }

        public void Add(Person person)
        {
            if (!this.Data.ContainsValue(person))
            {
                this.Data.Add(Data.Count, person);
            }
        }

        public Person Get(int id)
        {
            return this.Data.First(x => x.Key == id).Value;
        }

        public bool Update(int id, Person newPerson)
        {
            if (this.Data.ContainsKey(id))
            {
                this.Data[id] = newPerson;
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (this.Data.ContainsKey(id))
            {
                this.Data.Remove(id);
                return true;
            }
            return false;
        }
    }
}
