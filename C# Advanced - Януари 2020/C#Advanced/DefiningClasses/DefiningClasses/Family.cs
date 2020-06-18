using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DefiningClasses
{
    public class Family
    {
		private List<Person> _members = new List<Person>();

		public List<Person> Members
		{
			get { return _members; }
		}

		public void AddMember(Person member)
		{
			this._members.Add(member);
		}

		public Person GetOldestMember()
		{
			var oldest = Members
				.Where(x => x.Age > 30)
				.OrderByDescending(x => x.Age)
				.FirstOrDefault();

			return oldest;
		}
	}
}
