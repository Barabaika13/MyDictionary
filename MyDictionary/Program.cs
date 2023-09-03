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
            myDict.Add(15, null);
            myDict.Add(-23, "minus twenty three");

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
            public int Key { get; set; }
            public string Value { get; set; }

            public KVPair(int key, string value)
            {
                Key = key;
                Value = value;
            }
        }

        public void Add(int key, string value)
        {
            try
            {
                if (value == null)
                {
                    throw new ArgumentNullException(nameof(value));
                }
                else
                {
                    int index = Math.Abs(key % _myArray.Length);
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
            }
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
        }

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
                    _myArray[newIndexOfOldValue] = oldArray[i];
                }
            }
            int newIndex = Math.Abs(key % newLength);
            _myArray[newIndex] = new KVPair(key, value);
        }

        public string Get(int key)
        {
            int index = Math.Abs(key % _myArray.Length);
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