using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    class People : CollectionBase,ICloneable,IEnumerable
    {
        public void Add(Person newPerson)
        {
            List.Add(newPerson);
        }

        public void Remove(Person oldPerson)
        {
            List.Remove(oldPerson);
        }

        public People()
        {
        }

        public Person this[int personIndex]
        {
            get { return (Person) List[personIndex]; }
            set { List[personIndex] = value; }
        }

        public People this[string personName]
        {
            get
            {
                People tmp = new People();
                foreach (Person myPerson in List)
                {
                    if (myPerson.Name == personName)
                    {
                        tmp.Add(((Person) List[List.IndexOf(myPerson)]));
                    }
                }
                return tmp;
                throw new ArgumentOutOfRangeException(personName, "Object with name {0} does not exist.");
            }
            set
            {
                foreach (Person myPerson in List)
                {
                    if (myPerson.Name == personName)
                        List[List.IndexOf(myPerson)] = value;
                }
                throw new ArgumentOutOfRangeException(personName, "Object with name {0} does not exist.");
            }
        }
        
        public void CopyTo(People targetPeoples)
        {
            for (int index = 0; index < this.Count; index++)
            {
                targetPeoples[index] = this[index];
            }
        }
        public bool Contains(Person person)
        {
            return InnerList.Contains(person);
        }
        public object Clone()
        {
            People newPeoples = new People();
            foreach (Person sourcePerson in List)
            {
                newPeoples.Add(sourcePerson.Clone() as Person);
            }
            return newPeoples;
        }
        public Person[] GetOldest()
        {
            int count=0,j = 0;
            Person tmp;
            tmp = (Person)List[0];
            for (int i = 1; i < List.Count; i++)
            {
                if (tmp < (Person) List[i])
                {
                    tmp = (Person) List[i];
                    count = 1;
                }
                else if (tmp == (Person) List[i])
                    count++;
            }
            Person[] oldest = new Person[count];
            for (int i = 0; i < List.Count; i++)
            {
                if (tmp == (Person) List[i])
                {
                    oldest[j] = (Person) List[i];
                    j++;
                }
            }
            return oldest;
        }
        public IEnumerable Ages
        {
            get
            {
                for (int index = 0; index <= List.Count-1; index++)
                {
                    yield return ((Person)List[index]).Age;
                }
            }
        }
    }
}
