namespace MyDictionary
{
    internal class OtusDictionary
    {
        private KVPair[] _myArray = new KVPair[32];
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
                if (_myArray[index] == null)
                {
                    _myArray[index] = new KVPair(key, value);
                }
                else
                {
                    CreateBiggerArray(key, value);
                }
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
            else
            {
                Console.WriteLine($"Found an element '{_myArray[index].Value}' with key {key}");
                return _myArray[index].Value;
            }
        }
    }
}
