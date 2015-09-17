using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaticInitializationSingletonPattern
{
    sealed class SocketManager
    {
        public DateTime CreatedAt { get; private set; }
        public SocketManager()
        {
            CreatedAt = DateTime.Now;
        }

        private static readonly SocketManager activeConnection= new SocketManager();
     
        public static SocketManager GetSocketManager()
        {
            return activeConnection;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                // dongu icerisinde surekli olarak getsocketmanager kullanıyorum, geri donen socket manager ilk defasında yaaratılan oluyor. 
                //Bu gibi durumlarda Singleton kullanmak ileride developerlarin hata yapmasına engel oluyor.
                SocketManager sm = SocketManager.GetSocketManager();

                Console.WriteLine("Enter to see the time that Socket manager has been created");
                Console.ReadLine();
                Console.WriteLine("Date:{0}\n", sm.CreatedAt);

                Console.WriteLine("Press CTRL+C to exit");
            }


        }
    }
}
