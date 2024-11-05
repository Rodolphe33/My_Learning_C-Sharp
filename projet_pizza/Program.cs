using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace projet_pizza
{
    class PizzaPersonnalisee : Pizza
    {
        static int nbPizzaPersonnalisee = 0;

        public PizzaPersonnalisee() : base("Personnalisée", 5f, false, null)
        {
            nbPizzaPersonnalisee++;
            nom = $"Personnalisée {nbPizzaPersonnalisee}";
            ingredients = new List<string>();

            while (true)
            {
                Console.Write($"Rentrer un ingrédient pour la pizza personnalisée {nbPizzaPersonnalisee} (ENTERE pour terminer):");
                var ingredient = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(ingredient))
                {
                    break;
                }

                if (ingredients.Contains(ingredient))
                {
                    Console.WriteLine($"ERREUR : Cet ingrédient est déjà dans la liste.");
                }
                else
                {
                    this.ingredients.Add(ingredient);
                    Console.WriteLine(string.Join(", ", ingredients));
                }

                Console.WriteLine();
            }
            prix += ingredients.Count * 1.5f;
        }
    }

    class Pizza
    {
        public string nom { get; protected set; }
        public float prix { get; protected set; }
        public bool vegetarienne { get; protected set; }
        public List<string> ingredients { get; protected set; }

        public Pizza(string nom, float prix, bool vegetarienne, List<string> ingredients)
        {
            this.nom = nom;
            this.prix = prix;
            this.vegetarienne = vegetarienne;
            this.ingredients = ingredients;
        }

        public void Afficher()
        {
            string vege = vegetarienne ? " (V)" : "";

            string nomAfficher = FormatPremiereLettreMajuscule(nom);

            /*
            var listIngredients = new List<string>();
            foreach (string ingredient in ingredients)
            {
                listIngredients.Add(FormatPremiereLettreMajuscule(ingredient));
            }
            */
            var listIngredients = ingredients.Select(FormatPremiereLettreMajuscule).ToList();  // équivalent à la boucle foreach et la méthode Add() 

            Console.WriteLine($"{nomAfficher}{vege} - {prix}€");
            Console.WriteLine(string.Join(", ", listIngredients));
            Console.WriteLine();
        }

        public static string FormatPremiereLettreMajuscule(string s)
        {
            if (string.IsNullOrEmpty(s)) return s;

            string minuscule = s.ToLower();
            string majuscule = s.ToUpper();
            string resultat = majuscule[0] + minuscule[1..];
            return resultat;
        }

        public bool ContientIngredient(string ingredient)
        {
            return ingredients.Where(i => i.ToLower().Contains(ingredient)).ToList().Count > 0;
        }
    }

    class Program
    {
        static List<Pizza> GetPizzaFromCode()
        {
            var pizzas = new List<Pizza>
            {
                new Pizza("4 fromages", 11.5f, true, new List<string> {"mozzarella", "bleu", "chèvre", "comté"}),
                new Pizza("margherita", 9.5f, true, new List<string> {"mozzarella", "sauce tomates", "basilic"}),
                new Pizza("calzone", 14f, false, new List<string> {"mozzarella", "sauce tomate", "jambon", "oeuf"}),
                new Pizza("hawaïenne", 12f, false, new List<string> {"mozzarella", "fromage", "creme", "ananas"}),
                new Pizza("pepperoni", 9.5f, false, new List<string> {"mozzarella", "fromage", "tomates", "pepperoni"}),
                new Pizza("végétarienne", 8f, true, new List<string> {"mozzarella", "courgette", "tomates", "basilic", "aubergine"}),
                // new PizzaPersonnalisee(),  // pizza personnalisée
                // new PizzaPersonnalisee()  // pizza personnalisée
            };
            return pizzas;
        }

        static List<Pizza> GetPizzaFromFile(string filename)
        {
            string json = null;
            try
            {
                json = File.ReadAllText(filename);
            }
            catch
            {
                Console.WriteLine($"Erreur de lecture du fichier : {filename}");
                return null;
            }

            List<Pizza> pizzas = null;
            try
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
            }
            catch
            {
                Console.WriteLine("Erreur ; Les données json ne sont pas valide");
                return null;
            }

            return pizzas;
        }

        static void GenerateJsonFile(List<Pizza> pizzas, string filename)
        {
            var json = JsonConvert.SerializeObject(pizzas);
            File.WriteAllText(filename, json);
        }

        /* Ma version qui fonctionne
        static List<Pizza> GetPizzasFromUrl(string url)
        {
            var webClient = new WebClient();
            List<Pizza> pizzas = null;

            try
            {
                webClient.DownloadFile(url, "pizzas2.json");
                pizzas = GetPizzaFromFile("pizzas2.json");
            }
            catch
            {
                Console.WriteLine($"Erreur de lecture depuis l'URL : {url}");
                return null;
            }

            return pizzas;
        }
        */

        // La version de Jonathan
        static List<Pizza> GetPizzasFromUrl(string url)
        {
            var webClient = new WebClient();

            string json = null;
            try
            {
                json = webClient.DownloadString(url);
            }
            catch
            {
                Console.WriteLine("Erreur réseau");
                return null;
            }

            List<Pizza> pizzas = null;
            try
            {
                pizzas = JsonConvert.DeserializeObject<List<Pizza>>(json);
            }
            catch
            {
                Console.WriteLine("Erreur ; Les données json ne sont pas valide");
                return null;
            }

            return pizzas;
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            var filename = "pizzas.json";

            // pizzas.OrderBy(p => p.prix).ToList();
            // pizzas.OrderByDescending(p => p.prix).ToList();  // tri par prix décroissant;

            // var pizzas = GetPizzaFromCode();
            // GetPizzaFromFile(pizzas, filename);
            // var pizzas = GetPizzaFromFile(filename);
            var pizzas = GetPizzasFromUrl("https://codeavecjonathan.com/res/pizzas2.json");

            if (pizzas != null)
            {
                foreach (var pizza in pizzas)
                {
                    pizza.Afficher();
                }
            }

        }
    }
}