using tpmodul6_103022300121;


static void Test()
{
    try
    {
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – Abiyyu");
        video.PrintVideoDetails();

        Console.WriteLine("Menambahkan play count normal:");
        video.IncreasePlayCount(1000000);
        video.PrintVideoDetails();

        Console.WriteLine("\nMenambahkan play count besar untuk uji overflow:");

        for (int i = 0; i < 30; i++)
        {
            video.IncreasePlayCount(100000000);
        }

        video.PrintVideoDetails();
    }
    catch (Exception ex)
    {
        Console.WriteLine("Exception umum tertangkap: " + ex.Message);
    }
} 

Test();