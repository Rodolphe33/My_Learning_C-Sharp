namespace FormationCS
{
    static class outils
    {
        public static int DemanderNombrePositifNonNull(string question)
        {
            // 1er méthode
            /* int nombre = DemanderNombre(question);
            *  if (nombre > 0)
            *  {
            *      return nombre;
            *  }
            *  Console.WriteLine("Erreur : Le nombre doit être supérieur à 0");
            *  return DemanderNombrePositifNonNull(question);
            */

            // 2ème méthode
            return DemanderNombreEntre(question, 1, int.MaxValue, "ERREUR : Le nombre doit être positif");
        }

        public static int DemanderNombreEntre(string question, int min, int max, string messageErreurPersonnalise = null)
        {
            int nombre = DemanderNombre(question);
            if (nombre >= min && nombre <= max)
            {
                return nombre;
            }
            if (messageErreurPersonnalise == null)
            {
                Console.WriteLine($"Erreur : Vous devez rentrer un nombre entre {min} et {max}");
            } else
            {
                Console.WriteLine(messageErreurPersonnalise);
            }
            Console.WriteLine();
            return DemanderNombreEntre(question, min, max, messageErreurPersonnalise);
        }

        public static int DemanderNombre(string question)
        {
            // poser la question
            // récupérer la reponse
            // convertir
            // gérérer l'erreur de convertion
            // boucler tant qu'on a pas reçu une réponse valide (qui contient que des chiffres)
            Console.Write(question);
            while (true)
            {
                string reponse = Console.ReadLine();
                try
                {
                    int reponseInt = int.Parse(reponse);
                    return reponseInt;
                }
                catch
                {
                    Console.WriteLine("Erreur : Vous devez rentrer un nombre");
                }
            }
        }
    }
}