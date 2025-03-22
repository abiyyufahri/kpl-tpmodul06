using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tpmodul6_103022300121
{
    public class SayaTubeVideo
    {
        private int id;
        private string title;
        private int playCount;

        public SayaTubeVideo(string title)
        {
            Contract.Requires(title != null, "Judul tidak boleh null.");
            Contract.Requires(title.Length <= 100, "Judul maksimal 100 karakter.");

            Random random = new Random();
            this.id = random.Next(10000, 100000);
            this.title = title;
            this.playCount = 0;

            Contract.Ensures(this.playCount == 0);
        }

        public void IncreasePlayCount(int count)
        {
            Contract.Requires(count >= 0 && count <= 10000000,
                "Penambahan play count harus antara 0 hingga 10.000.000.");
            Contract.EnsuresOnThrow<OverflowException>(this.playCount >= 0);

            int oldPlayCount = this.playCount;
            Contract.Ensures(this.playCount >= oldPlayCount);

            try
            {
                checked
                {
                    this.playCount += count;
                }
            }
            catch (OverflowException e)
            {
                Console.WriteLine("Terjadi overflow saat menambah play count: " + e.Message);
            }
        }


        public void PrintVideoDetails()
        {
            Console.WriteLine("=== Detail Video ===");
            Console.WriteLine($"ID Video     : {this.id}");
            Console.WriteLine($"Judul Video  : {this.title}");
            Console.WriteLine($"Play Count   : {this.playCount}");
            Console.WriteLine("====================");
        }
    }
}
