using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic
{
    public class ShortCollection<T> : IList<T>
    {
        private List<T> myList = new List<T>();
        public List<T> MyList
        {
            get { return myList; }
        }

        public void AddRange(List<T> tmp)
        {
            if (tmp.Count <= (myList.Capacity - myList.Count))
                myList.AddRange(tmp);
            else
            {
                throw new ArgumentOutOfRangeException("tmp","Your collection if full or not enogh free space to adding array! Remove some elements to make possible adding new elements!");
            }
        }

        public ShortCollection(params object[] list)
        {
            if (list.Length==0)
                myList.Capacity = 10;
            else 
            if (list.Length == 1)
            {
                if (list[0].GetType() == typeof (List<T>))
                {
                    myList.Capacity = 10;
                    try
                    {
                        AddRange(list[0] as List<T>);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0}", e.Message);
                    }
                }
                if (list[0].GetType() == typeof (int))
                    myList.Capacity = (int)list[0];
            }
            else
            if (list.Length >= 2)
            {
                for (int i = 0; i <= 1; i++)
                    if (list[i] is int)
                        myList.Capacity = (int)list[i];

                for (int i = 0; i <= 1; i++)
                    if (list[i] is List<T>)
                    {
                        try
                        {
                            AddRange(list[i] as List<T>);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("{0}", e);
                        }
                    } 
            }

        }

        public IEnumerator<T> GetEnumerator()
        {
            return myList.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return myList.GetEnumerator();
        }

        public void Add(T item)
        {
            try
            {
                if (myList.Count != myList.Capacity)
                    myList.Add(item);
                else
                    throw new ArgumentOutOfRangeException("myList",
                        "Your collection if full! Remove some elements to make possible adding new elements!");
            }
            catch (Exception e)
            {
                Console.WriteLine("{0}",e.Message);
            }
        }

        public void Clear()
        {
            myList.Clear();
        }

        public bool Contains(T item)
        {
            return myList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            return myList.Remove(item);
        }

        public int Count
        {
            get { return myList.Count(); }
        }
        public bool IsReadOnly { get; private set; }
        public int IndexOf(T item)
        {
            return myList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            if (myList.Count != myList.Capacity)
                myList.Insert(index, item);
            else throw new ArgumentOutOfRangeException("Your collection if full! Remove some elements to make possible adding new elements!");
        }

        public void RemoveAt(int index)
        {
            myList.RemoveAt(index);
        }

        public T this[int index]
        {
            get { return myList[index]; }
            set { myList[index] = value; }
        }
        public int  Capacity 
        {
            get { return myList.Capacity; }
            set { myList.Capacity = value; }
        }
    }
}
