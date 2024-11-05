namespace generateur_phrases_aleatoires
{
    class Program
    {
        static string ObtenirElementAleatoire(string[] t)
        {
            Random rnd = new Random();
            var s = t[rnd.Next(0, t.Length)];
            return s;
        }
        public static void Main(string[] args)
        {
            // sujet   verbe   complement
            var sujets = new string[] {
                "Un lapin",
                "Un chien",
                "Un chat",
                "Un oiseau",
                "Un renard",
                "Un tigre",
                "Un cheval",
                "Une étoile",
            };

            var verbes = new string[] {
                "mange",
                "boit",
                "court",
                "fait",
                "dort",
                "chasse",
                "vol",
                "tourne",
                "s'accroche à",
            };

            var complements = new string[] {
                "un arbre",
                "un livre",
                "une pomme",
                "une cloche",
                "une feuille",
                "un poulpe",
                "un chien",
                "le soleil",
                "la lune",
                "le ciel",
            };


            const int NB_PHRASE = 100;
            var phrasesUniques = new List<string>();
            int doublonsEvites = 0;

            while (phrasesUniques.Count < NB_PHRASE)
            {
                var sujet = ObtenirElementAleatoire(sujets);
                var verbe = ObtenirElementAleatoire(verbes);
                var complement = ObtenirElementAleatoire(complements);
                var phrase = $"{sujet} {verbe} {complement}";
                phrase = phrase.Replace("à le", "au");

                if (!phrasesUniques.Contains(phrase))
                {
                    phrasesUniques.Add(phrase);
                }
                else
                {
                    doublonsEvites++;
                }
            }
            
            foreach (var pu in phrasesUniques)
            {
                Console.WriteLine(pu);
            }
            Console.WriteLine();
            Console.WriteLine($"Nombre de phrases unique : {phrasesUniques.Count}");
            Console.WriteLine($"Nombre de doublons évité : {doublonsEvites}");
        }
    }
}