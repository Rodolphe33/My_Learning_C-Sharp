// See https://aka.ms/new-console-template for more information

using System.Collections;

namespace programme_collections
{
    class Program
    {
        static void Main(string[] args)
        {
            // Tableaux();
            // Listes();
            // ArrayList();
            // ListeDeListes();
            // Dictionnaire();
            // BoucleForeach();
            TrisEtLinq();
        }

        static void TrisEtLinq()
        {
            // List
            // var villes = new List<string> { "Paris", "Toulouse", "Nice", "Bordeaux", "Lille", "Pau" };
            // villes.Sort();

            // Array
            var villes = new string[] { "Paris", "Toulouse", "Nice", "Bordeaux", "Lille", "Pau" };
            // Array.Sort(villes);

            // var villeTries = villes.OrderBy(nom => nom).ToArray();
            // var villeTries2 = villes.OrderByDescending(nom => nom).ToList();

            // Linq
            villes = villes.Where(ville => ville[ville.Length - 1] == 'e').ToArray();

            foreach (var v in villes)
            {
                Console.WriteLine(v);

            }
        }

        static void BoucleForeach()
        {
            var d = new Dictionary<string, string>();
            d.Add("Jean", "06666666666");
            d.Add("marie", "07777777777");
            d["Martin"] = "08888888888";

            foreach (var e in d)
            {
                Console.WriteLine($"{e.Key} : {e.Value}");
            }
        }

        static void Dictionnaire()
        {
            var d = new Dictionary<string, string>();
            d.Add("Jean", "06666666666");
            d.Add("marie", "07777777777");
            d["Martin"] = "08888888888";

            Console.WriteLine($"{d["marie"]}");

        }

        static void ListeDeListes()
        {
            // France : Paris, Toulouse, Nice, Bordeaux, Lille
            // Etats-Unis : New-York, Chicago, Los Angeles, Washington
            // Espagne : Madrid, Séville, Barcelone
            // Italie : Venise, Florence, Turin, Milan

            /// <List<string>>
            /*var villes = new List<string>();
            villes.Add("France : Paris, Toulouse, Nice, Bordeaux, Lille");
            villes.Add("Etats-Unis : New-York, Chicago, Los Angeles, Washington");
            villes.Add("Espagne : Madrid, Séville, Barcelone");
            villes.Add("Italie : Venise, Florence, Turin, Milan");*/

            /// List<List<string>>
            var pays = new List<List<string>>();

            pays.Add(new List<string> { "France", "Paris", "Toulouse", "Nice", "Bordeaux", "Lille" });
            pays.Add(new List<string> { "Etats-Unis", "New-York", "Chicago", "Los Angeles", "Washington" });
            pays.Add(new List<string> { "Espagne", "Madrid", "Séville", "Barcelone" });
            pays.Add(new List<string> { "Italie", "Venise", "Florence", "Turin", "Milan" });

            for (int i = 0; i < pays.Count; i++)
            {
                var p = pays[i];
                Console.WriteLine($"{p[0]} - {p.Count - 1} villes");
                for (int j = 0; j < p.Count; j++)
                {
                    Console.WriteLine($"  {p[j]}");

                }
            }

            // AfficherListe(pays);
        }

        static void ArrayList()
        {
            ArrayList a = new ArrayList();
            a.Add("Toto");
            a.Add(42);
            a.Add(true);

            for (int i = 0; i < a.Count; i++)
            {
                Console.WriteLine(a[i]);
            }
        }

        static void Listes()
        {
            /*List<int> liste = new List<int>();

            liste.Add(5);
            liste.Add(8);
            liste.Add(2);*/

            /*var noms = new List<string>();
            while (true)
            {
                Console.Write("Rentrez un nom (ENTER pour finir) : ");
                string nom = Console.ReadLine();

                if(nom == "")
                {
                    break;
                }

                if (noms.Contains(nom))
                {
                    Console.WriteLine($"ERREUR : le nom {nom} est déjà présent dans la liste.");
                    Console.WriteLine();
                }
                else
                {
                    noms.Add(nom);
                }
            }

            // List <string> lesPremiersNoms = noms.GetRange(0,3);
            // AfficherListe(lesPremiersNoms);

            for(int i = noms.Count - 1; i >= 0; i--)
            {
                string nom = noms[i];
                if (nom[nom.Length - 1] == 'e')
                {
                    noms.RemoveAt(i);
                }
            }
            AfficherListe(noms, true);*/

            var liste1 = new List<string>() { "maxence", "enzo", "pierre", "esteban", "raphael" };
            var liste2 = new List<string>() { "jhunan", "leny", "maxence", "theo", "enzo" };

            AfficherElementCommus(liste1, liste2);
        }

        static void AfficherElementCommus(List<string> list1, List<string> list2)
        {
            for (int i = 0; i < list1.Count; i++)
            {
                string nom = list1[i];
                if (list2.Contains(nom))
                {
                    Console.WriteLine(nom);
                }
            }
        }

        static void AfficherListe(List<string> liste, bool ordreDescendant = false)
        {
            if (!ordreDescendant)
            {
                for (int i = 0; i < liste.Count; i++)
                {
                    Console.WriteLine(liste[i]);
                }
            }
            else
            {
                for (int i = liste.Count - 1; i >= 0; i--)
                {
                    Console.WriteLine(liste[i]);
                }
            }

            string nomLePlusLong = "";
            for (int i = 0; i < liste.Count; i++)
            {
                if (liste[i].Length > nomLePlusLong.Length)
                {
                    nomLePlusLong = liste[i];
                }
            }
            Console.WriteLine($"Le nom le plus long est : {nomLePlusLong}");
        }

        static void Tableaux()
        {
            // int[] t = { 200, 40, 15, 8, 12 };
            const int TAILLE_TABLEAU = 20;
            int[] t = new int[TAILLE_TABLEAU];
            Random rand = new Random();
            for (int i = 0; i < TAILLE_TABLEAU; i++)
            {
                t[i] = rand.Next(1, 101);
            }
            AfficherTableau(t);
            AfficherValeurMaximal(t);
        }

        static void AfficherTableau(int[] tableau)
        {
            for (int i = 0; i < tableau.Length; i++)
            {
                Console.WriteLine($"[{i}] {tableau[i]}");
            }
        }

        static void AfficherValeurMaximal(int[] tableau)
        {
            Console.WriteLine();
            Console.WriteLine($"La valeur maximale est : {tableau.Max()}");
        }

        static int SommeTableau(int[] t)
        {
            int somme = 0;
            for (int i = 0; i < t.Length; i++)
            {
                somme += t[i];
            }
            return somme;
        }
    }
}
