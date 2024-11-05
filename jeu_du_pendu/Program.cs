using System.Collections.Generic;
using AsciiArt;

namespace jeu_du_pendu
{
    class Program
    {
        static void AfficherMot(string mot, List<char> lettres)
        {
            for (int i = 0; i < mot.Length; i++)
            {
                char lettre = mot[i];
                if (lettres.Contains(lettre))
                {
                    Console.Write(lettre + " ");
                }
                else
                {
                    Console.Write("_ ");
                }
            }
            Console.WriteLine();
        }

        static bool ToutesLesLettresDevinees(string mot, List<char> lettres)
        {
            // true -> toutes les lettres ont été trouvées -> gagné
            // false
            foreach (var lettre in lettres)
            {
                mot = mot.Replace(lettre.ToString(), "");
            }

            if (mot.Length == 0)
            {
                return true;
            }
            return false;
        }

        static char DemanderUneLettre(string message = "Rentrez une lettre : ")
        {
            // Demander une lettre
            // convertir  en majuscule
            // controller si c'est une lettre et si il n'y a qu'un seul caractere
            while (true)
            {
                Console.Write(message);
                string reponse = Console.ReadLine();

                if (reponse.Length == 1)
                {
                    reponse = reponse.ToUpper();
                    return reponse[0];
                }
                Console.WriteLine($"ERREUR : Vous devez rentrer une lettre");
            }
        }

        static void DevinerMot(string mot)
        {
            var lettresDevinees = new List<char>();
            var mauvaiseLettres = new List<char>();
            const int NB_VIES = 6;
            int viesRestantes = NB_VIES;

            while (viesRestantes > 0)
            {
                Console.WriteLine(Ascii.PENDU[NB_VIES - viesRestantes]);
                AfficherMot(mot, lettresDevinees);
                Console.WriteLine();
                var lettre = DemanderUneLettre();
                Console.Clear();

                if (mot.Contains(lettre))
                {
                    Console.WriteLine("Cette lettre est dans le mot");
                    lettresDevinees.Add(lettre);
                    // GAGNE
                    if (ToutesLesLettresDevinees(mot, lettresDevinees))
                    {
                        // Console.WriteLine("Gagné !!!");
                        // return;
                        break;
                    }
                }
                else
                {
                    if(!mauvaiseLettres.Contains(lettre))
                    {
                        viesRestantes--;
                        mauvaiseLettres.Add(lettre);
                    }
                    Console.WriteLine($"Vies restantes : {viesRestantes}");

                }
                if(mauvaiseLettres.Count > 0)
                {
                    Console.WriteLine($"Le mot ne contient pas les lettres : {String.Join(", ", mauvaiseLettres)}");
                }
                Console.WriteLine();
            }
            Console.WriteLine(Ascii.PENDU[NB_VIES - viesRestantes]);

            if (viesRestantes == 0)
            {
                Console.WriteLine($"PERDU ! Le mot etait : {mot}");
            }
            else
            {
                AfficherMot(mot, lettresDevinees);
                Console.WriteLine();
                Console.WriteLine("Gagné !!!");
            }
        }

        static string[] ChargerLesMots(string nomFichier)
        {
            try
            {
                return File.ReadAllLines(nomFichier);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur de lecture du fichier : {nomFichier} ({ex.Message})");
            }
            return null;
        }

        static bool DemanderDeRejouer()
        {
            char reponse = DemanderUneLettre("Vouler-vous rejouer ? (o) oui / (n) non : ");

            if (reponse == 'o' || reponse == 'O')
            {
                return true;
            }
            else if (reponse == 'n' || reponse == 'N')
            {
                return false;
            }
            else
            {
                Console.WriteLine("ERREUR : Vous devez répondre par o ou n");
                return DemanderDeRejouer();
            }
        }

        public static void Main(string[] args)
        {
            var mots = ChargerLesMots("mots.txt");

            if (mots == null || mots.Length == 0)
            {
                Console.WriteLine($"La liste de mots est vide");
            }
            else
            {
                while (true)
                {
                    Random rdm = new Random();
                    int i = rdm.Next(0, mots.Length);
                    string mot = mots[i].Trim().ToUpper();
                    DevinerMot(mot);
                    if (!DemanderDeRejouer())
                    {
                        break;
                    }
                    Console.Clear();
                }
                Console.WriteLine();
                Console.WriteLine("Merci et à bientôt");
                
            }
        }
    }
}
