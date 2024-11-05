using System.Net;

namespace programme_reseau {
    class Program {
        static void Main(string[] args) {
            // string url = "https://codeavecjonathan.com/res/example.html";
            // string url = "https://codeavecjonathan.com/res/pizzas1.json";
            string url = "https://codeavecjonathan.com/res/papillon.jpg";

            var webClient = new WebClient();
            
            Console.WriteLine("Accès au réseau...");
            try {
                webClient.DownloadFile(url, "papillon.jpg");
                Console.WriteLine("Téléchargement terminé");
            } catch (WebException we) {
                Console.WriteLine($"ERREUR RESEAU : {we.Message}");
            }

        }
    }
}