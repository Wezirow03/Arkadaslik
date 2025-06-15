using System;
using System.Collections.Generic;

public class MyConcurrentDictionary
{
   
    private Dictionary<string, int> data = new Dictionary<string, int>();

   
    private object myLock = new object();

    
    public void Add(string name, int grade)
    {
        lock (myLock)
        {
            if (!data.ContainsKey(name))
            {
                data[name] = grade;
                Console.WriteLine($"{name} added.");
            }
            else
            {
                Console.WriteLine($"{name} It is have in the Dictionary");
            }
        }
    }

   
    public int? Get(string name)
    {
        lock (myLock)
        {
            if (data.ContainsKey(name))
            {
                return data[name];
            }
            else
            {
                Console.WriteLine($"{name} Dont finded.");
                return null;
            }
        }
    }

   
    public void Update(string name, int newGrade)
    {
        lock (myLock)
        {
            if (data.ContainsKey(name))
            {
                data[name] = newGrade;
                Console.WriteLine($"{name} updated.");
            }
            else
            {
                Console.WriteLine($"{name} dont finded.");
            }
        }
    }

  
    public void Remove(string name)
    {
        lock (myLock)
        {
            if (data.ContainsKey(name))
            {
                data.Remove(name);
                Console.WriteLine($"{name} Removed.");
            }
            else
            {
                Console.WriteLine($"{name} Dont finded.");
            }
        }
    }

   
    public void PrintAll()
    {
        lock (myLock)
        {
            Console.WriteLine("All student:");
            foreach (var pair in data)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }
    }
    class Program
    {
        static void Main()
        {
            MyConcurrentDictionary myDict = new MyConcurrentDictionary();

            myDict.Add("Ali", 90);
            myDict.Add("Ayşe", 85);
            myDict.Add("Muhammad", 65);
            myDict.Add("Madina", 70);

            int? not = myDict.Get("Ali");
            Console.WriteLine($"Grade of Ali: {not}");

            myDict.Update("Ali", 70);
            myDict.Remove("Ayşe");

            myDict.PrintAll();
        }
    }

}
