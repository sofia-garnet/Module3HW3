using System;
using System.Collections.Generic;
using System.Linq;

namespace Module3HW33
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var list = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("C", "+380921243672"),
                new KeyValuePair<string, string>("A", "+380921244432"),
                new KeyValuePair<string, string>("D", "+380921243230"),
                new KeyValuePair<string, string>("E", "+380944212432"),
                new KeyValuePair<string, string>("B", "+380921244345"),
                new KeyValuePair<string, string>("C", "+380921243600")
            };
            
            //FirstOrDtfault
            var firstOrDefault = list
                .FirstOrDefault(e => e.Key.Equals("C"));
            
            Console.WriteLine($"{firstOrDefault.Value} {Environment.NewLine}");
            
            var query = from element in list
                where element.Key != "C"
                select element;

            var keyValuePairs = query.ToList();
            foreach (var element in keyValuePairs)
            {
                Console.WriteLine(element);
            }
            Console.WriteLine();
            
            
            //OrderBy
            var orderedEnumerable = list
                .OrderBy(e => e.Key);
            foreach (var element in orderedEnumerable)
            {
                Console.WriteLine(element);
            }
   
            //Select To Array
            var strings = list
                .Select(e => e.Value)
                .ToArray();
            
            foreach (var t in strings)
            {
                Console.WriteLine(t);
            }

            Join();
            
            Func<int, int, int> operation;
            operation = Add;
            operation += Add;
            var program = new Program();
            var delegList = operation.GetInvocationList();
            var sum = 0;
            foreach (var item in delegList)
            {
                var resultInTypeObj = item.DynamicInvoke(2, 3);
                Console.WriteLine(resultInTypeObj);
                sum += (int)resultInTypeObj;
            }
            Console.WriteLine(sum);
        }

        static int Add(int x1, int x2)
        {
            return x1 + x2;
        }

        class Developer
        {
            public string Name { get; set; }
            public Technology Technology { get; set; }
        }

        class Technology
        {
            public string Name { get; set; }
        }

        public static void Join()
        {
            var tech1 = new Technology { Name = "JS"};
            var tech2 = new Technology { Name = "C#"};
            var tech3 = new Technology { Name = "JAVA"};

            var dev1 = new Developer { Name = "Dev1", Technology = tech1};
            var dev2 = new Developer { Name = "Dev2", Technology = tech2};
            var dev3 = new Developer { Name = "Dev3", Technology = tech3};
            var dev4 = new Developer { Name = "Dev4", Technology = tech1};
            var dev5 = new Developer { Name = "Dev5", Technology = tech2};
            var dev6 = new Developer { Name = "Dev5", Technology = tech3};

           var techList = new List<Technology> { tech1, tech2, tech3 };
            var devList = new List<Developer> { dev1, dev2, dev3, dev4, dev5, dev6 };
            
            var query =
                techList.Join(devList,
                    technology => technology,
                    dev => dev.Technology,
                    (technology, dev) =>
                        new { Technology = technology.Name, Developer = dev.Name });

            foreach (var obj in query)
            {
                Console.WriteLine(
                    "{0} - {1}",
                    obj.Technology,
                    obj.Developer);
            }
        }

    }
}