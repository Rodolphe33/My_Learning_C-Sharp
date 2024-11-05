// fonction async => Delegates
// using System.Net;


using System.Globalization;

namespace NotionsComplementaires
{    
        public class Program
        {
            // DateTime
            static void Main(string[] args)
            {
                DateTime date = DateTime.Now;
                Console.WriteLine(date.Day);
                Console.WriteLine(date.Year);
                Console.WriteLine(date.Month);

                Console.WriteLine("----------------------------------------------------------------");
                
                Console.WriteLine(date.ToString("dd/MM/yy HH:mm:ss"));
                Console.WriteLine("----------------------------------------------------------------");
                Console.WriteLine(date.ToString("dddd dd MMMM yyyy HH:mm:ss"));
                Console.WriteLine("----------------------------------------------------------------");
                // Transforme la langue
                // CultureInfo cultureInfo = CultureInfo.GetCultureInfo("en-US");
                CultureInfo cultureInfo = CultureInfo.GetCultureInfo("fr-FR");
                Console.WriteLine(date.ToString("dddd dd MMMM yyyy HH:mm:ss", cultureInfo));
                Console.WriteLine("----------------------------------------------------------------");
                DateTime dateDemain = date.AddDays(1);
                Console.WriteLine($"Demain : {dateDemain.ToString("dddd dd MMMM yyyy HH:mm:ss", cultureInfo)}");

                var diff = dateDemain - date;
                Console.WriteLine($"Différence heures : {diff.TotalHours}");
                
            }


            /*
            // fonction async => Delegates

            static bool downloading = false;
            public static void Main(string[] args)
            {
                var webClient = new WebClient();
                string url = "https://codeavecjonathan.com/res/bateau.jpg";

                Console.Write("Téléchargement...");

                // Téléchargement séquenciel
                // webClient.DownloadFile(url, "bateau.jpg");
                
                // Téléchargement asynchrone
                downloading = true;
                webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
                webClient.DownloadFileAsync(new Uri(url), "bateau.jpg");

                while (downloading)
                {
                    Thread.Sleep(500);
                    if (downloading) {
                        Console.Write(".");
                    }
                }

                Console.WriteLine("Fin du programme");
            }

        private static void WebClient_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            Console.WriteLine("Téléchargement terminé");
            downloading = false;
        }
        */

        // fonction async => Async/Await
        /*
        static async Task Main(string[] args)
        {
            string url1 = "https://codeavecjonathan.com/res/dummy.txt";
            string url2 = "https://codeavecjonathan.com/res/pizzas1.json";

            Console.Write("Téléchargement...");
            // DisplayProgress().Wait();
            // DownloadData().Wait();

            var displayTask = DisplayProgress();
            var downloadTask1 = DownloadData(url1);
            var downloadTask2 = DownloadData(url2);

            // await downloadTask1;
            // await downloadTask2;
            // =
            await Task.WhenAll(downloadTask1, downloadTask2);

            Console.WriteLine("FIN DU PROGRAMME");
        }

        static async Task DownloadData(string url)
        {
            var httplient = new HttpClient();
            

            // var task = httplient.GetStringAsync(url);
            // task.Wait();
            // Console.WriteLine(task.Result);

            var resultat = await httplient.GetStringAsync(url);

            Console.WriteLine("OK -> " + url);

            // Console.WriteLine(resultat);
        }

        static async Task DisplayProgress()
        {
            while (true)
            {
                await Task.Delay(500);
                Console.Write(".");
            }
        }
        */
    }
}