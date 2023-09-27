namespace MyDictionary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myDict = new OtusDictionary();
            myDict.Add(1, "one");
            myDict.Add(129, "one hundred twenty nine");
            myDict.Add(65, "sixty five");
            myDict.Add(64, "sixty four");
            myDict.Add(0, "zero");
            myDict.Add(34, "thirty four");
            myDict.Add(64, "sixty four");
            myDict.Add(-23, "minus twenty three");

            myDict[35] = "Hello";
            string value1 = myDict[35];            
            myDict[65] = "Привет";
            string value2 = myDict[65];            
            myDict[258] = "Two hundred fifty eight";
            string value3 = myDict[258];

            myDict.Get(34);
            myDict.Get(10);            
            myDict.Get(0);            
            myDict.Get(65);
            myDict.Get(345);           
            myDict.Get(-27);
            myDict.Get(-23);
        }
    }   
}