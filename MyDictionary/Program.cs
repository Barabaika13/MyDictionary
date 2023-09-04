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
            //myDict.Add(33, "thirty three");
            //myDict.Add(34, "thirty four");
            //myDict.Add(63, "sixty three");
            //myDict.Add(64, "sixty four");            
            //myDict.Add(15, null);
            //myDict.Add(-23, "minus twenty three");

            myDict[35] = "Hello";
            string value1 = myDict[35];
            Console.WriteLine(value1);
            myDict[65] = "Bye";
            string value2 = myDict[65];


            myDict.Get(31);
            myDict.Get(10);
            myDict.Get(32);
            myDict.Get(0);
            myDict.Get(64);
            myDict.Get(65);
            myDict.Get(345);
            myDict.Get(15);
            myDict.Get(-27);
            myDict.Get(-23);
        }
    }

    internal class OtusDictionary
    {
        private KVPair[] _myArray = new KVPair[32];
        //public int Length { get; private set; }
        //private int Length;

        //public OtusDictionary()
        //{
        //    Length = 32;
        //    _myArray = new KVPair[Length];
        //}

        private class KVPair
        {
            public int Key { get; }
            public string Value { get; }

            public KVPair(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        public string this[int key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Add(key, value);
            }
        }

        public void Add(int key, string value)
        {

            if (value == null)
            {
                Console.WriteLine("Словарь не принимает пустую строку в качестве значения");
                return;
            }
            else
            {
                int index = Math.Abs(key % _myArray.Length);
                //int index = CalculateIndex(key);
                if (_myArray[index] == null)
                {
                    _myArray[index] = new KVPair(key, value);
                }
                else
                {
                    CreateBiggerArray(key, value);
                }

                //if (_myArray[index] != null)
                //{
                //    var e = new Exception("Место занято");
                //    throw e;
                //}
            }

            //try
            //{

            //}
            //catch (ArgumentNullException e)
            //{
            //    Console.WriteLine(e.Message);
            //}               
        }

        //private int CalculateIndex(int key)
        //{
        //    return Math.Abs(key) % _myArray.Length;
        //}


        public void CreateBiggerArray(int key, string value)
        {
            int newLength = _myArray.Length * 2;
            KVPair[] oldArray = _myArray;
            _myArray = new KVPair[newLength];
            for (int i = 0; i < oldArray.Length; i++)
            {
                if (oldArray[i] != null)
                {
                    int newIndexOfOldValue = Math.Abs(oldArray[i].Key % _myArray.Length);
                    //int newIndexOfOldValue = CalculateIndex(key);
                    _myArray[newIndexOfOldValue] = oldArray[i];
                }
            }
            int newIndex = Math.Abs(key % newLength);
            _myArray[newIndex] = new KVPair(key, value);
        }

        public string Get(int key)
        {
            int index = Math.Abs(key % _myArray.Length);
            //int index = CalculateIndex(key);
            if (_myArray[index] == null)
            {
                Console.WriteLine($"Element with key {key} not found");
                return null;
            }
            //else if (_myArray[index].Key != key)
            //{
            //    // элемент есть, но ключ не совпадает
            //    return null;
            //}
            else
            {
                Console.WriteLine($"Found an element '{_myArray[index].Value}' with key {key}");
                return _myArray[index].Value;
            }
        }
    }
}