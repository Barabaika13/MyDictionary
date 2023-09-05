namespace MyDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myDict = new OtusDictionary();
            myDict.Add(1, "one");
            myDict.Add(2, "two");
            myDict.Add(31, "thirty one");
            myDict.Add(32, "thirty two");
            myDict.Add(0, "zero");
            myDict.Add(33, "thirty three");
            myDict.Add(34, "thirty four");
            myDict.Add(63, "sixty three");
            myDict.Add(64, "sixty four");            
            myDict.Add(-23, "minus twenty three");

            myDict[35] = "Hello";
            string value1 = myDict[35];
            Console.WriteLine(value1);
            myDict[65] = "Привет";
            string value2 = myDict[65];
            Console.WriteLine(value2);
            myDict[129] = "129";
            string value3 = myDict[129];

            myDict.Get(31);
            myDict.Get(10);
            myDict.Get(32);
            myDict.Get(0);
            myDict.Get(64);
            myDict.Get(65);
            myDict.Get(345);           
            myDict.Get(-27);
            myDict.Get(-23);
        }
    }   
}