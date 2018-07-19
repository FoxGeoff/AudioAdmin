using System;

namespace Base64
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = "01==";
            var array = Convert.FromBase64String(str);
        }
    }
}
