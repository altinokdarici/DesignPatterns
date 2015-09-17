using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadSingletonPattern
{
   sealed class SocketManager
    {
        static readonly object syncRoot = new object();
        public DateTime CreatedAt { get; private set; }
        public SocketManager()
        {
            CreatedAt = DateTime.Now;
        }

        /// <summary>
        /// Bu degisken sayesinde uygulama acik oldugu surece SocketManager hayatta kalacak ve bir daha (hata yapılmadığı sürece) yeni bir ornegi yaratılmayacak.
        /// </summary>
        private static SocketManager activeConnection;
        public static SocketManager GetSocketManager()
        {
            if (activeConnection == null)
            {
                lock (syncRoot)
                {
                    //eger daha once connection yaratilmamis ise yeni bir connection yaratiyoruz.
                    if (activeConnection == null)
                        activeConnection = new SocketManager();
                }
            }

            //yeni yaratilan veya zaten var olan, sonuc olarak tek bir tane olan active connection'i return ediyoruz.
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
            
                Console.WriteLine("Enter to see the time that Socket manager has been created");
                Console.ReadLine();
                SocketManager sm = SocketManager.GetSocketManager();

                Console.WriteLine("Date:{0}\n", sm.CreatedAt);

                Console.WriteLine("Press CTRL+C to exit");
            }


        }
    }
}
