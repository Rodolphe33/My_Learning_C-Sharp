#nullable enable

public class Program
{

    public static void Main()
    {
        Random rand = new Random();
        const int NB_MIN = 1;
        const int NB_MAX = 10;
        int NB_MAGIQUE = rand.Next(NB_MIN, NB_MAX + 1);
        int nombre = 0;
        int NB_VIES = 4;

        while (NB_VIES > 0)
        {
            Console.WriteLine();
            Console.WriteLine($"Vies restantes : {NB_VIES}");
            nombre = DemanderNombre(NB_MIN, NB_MAX);

            if (nombre < NB_MAGIQUE)
            {
                Console.WriteLine("Le nombre magique est plus grand");
            }
            else if (nombre > NB_MAGIQUE)
            {
                Console.WriteLine("Le nombre magique est plus petit");
            }
            else
            {
                Console.WriteLine("Bravo, vous avez trouvez le nombre magique");
                break;
            }
            NB_VIES--;
        }

        if (NB_VIES == 0)
        {
            Console.WriteLine($"Vous avez perdu, le nombre magique était {NB_MAGIQUE}");
        }
    }

    static int DemanderNombre(int min, int max)
    {
        int num = min - 1;
        while (num < min || num > max)
        {
            Console.Write($"Rentrer un nombre entre {min} et {max} : ");
            string reponse = Console.ReadLine();

            try
            {
                num = Convert.ToInt32(reponse);
                if (num < min || num > max)
                {
                    Console.WriteLine($"Erreur : le nombre doit-être entre {min} et {max}");
                }
            }
            catch
            {
                Console.WriteLine("Erreur : Ce nombre n'est pas valide");
            }
        }
        // retourner la valeur (int)
        return num;
    }
}
