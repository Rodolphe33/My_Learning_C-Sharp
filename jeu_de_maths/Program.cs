// See https://aka.ms/new-console-template for more information
namespace jeu_de_maths
{
  class Program
  {
    enum e_Operateur
    {
      ADDITION = 1,
      MULTIPLICATION = 2,
      SOUSTRACTION = 3
    }
    static void Main(string[] args)
    {
      const int NB_QUESTION = 5;
      const int NB_MIN = 1;
      const int NB_MAX = 10;
      int points = 0;

      for (int i = 0; i < NB_QUESTION; i++)
      {
        Console.WriteLine($"Question n°{i + 1}/{NB_QUESTION}");
        bool resonse = PoserQuestion(NB_MIN, NB_MAX);

        if (resonse)
        {
          Console.WriteLine("Bonne réponse");
          points++;
        }
        else
        {
          Console.WriteLine("Mauvaise réponse");
        }
        Console.WriteLine();
      }
      Console.WriteLine($"Votre score est de {points}/{NB_QUESTION}");
      int moyenne = NB_QUESTION / 2;

      if (points == NB_QUESTION)
      {
        Console.WriteLine("Excellent !");
      }
      else if (points == 0)
      {
        Console.WriteLine("Réviser vos maths");
      }
      else if (points > moyenne)
      {
        Console.WriteLine("Très bien");
      }
      else
      {
        Console.WriteLine("Peut mieux faire");
      }

    }

    static bool PoserQuestion(int min, int max)
    {
      int reponseInt = 0;
      Random rand = new Random();
      while (true)
      {
        int a = rand.Next(min, max + 1);
        int b = rand.Next(min, max + 1);
        e_Operateur o = (e_Operateur)rand.Next(1, 4);
        int resultatAttendu;

        switch (o)
        {
          case e_Operateur.ADDITION:
            Console.Write($"{a} + {b} = ");
            resultatAttendu = a + b;
            break;
          case e_Operateur.MULTIPLICATION:
            Console.Write($"{a} x {b} = ");
            resultatAttendu = a * b;
            break;
          case e_Operateur.SOUSTRACTION:
            Console.Write($"{a} - {b} = ");
            resultatAttendu = a - b;
            break;
          default:
            // cas inconnu
            Console.WriteLine("Erreur : :Opérateur inconnue.");
            return false;
        }

        /*if (o == e_Operateur.ADDITION)
        {
          Console.Write($"{a} + {b} = ");
          resultatAttendu = a + b;
        }
        else if (o == e_Operateur.MULTIPLICATION)
        {
          Console.Write($"{a} x {b} = ");
          resultatAttendu = a * b;
        }
        else if (o == e_Operateur.SOUSTRACTION)
        {
          Console.Write($"{a} - {b} = ");
          resultatAttendu = a - b;
        }
        else
        {
          Console.WriteLine("Erreur : :Opérateur inconnue.");
          return false;
        }*/

        string reponse = Console.ReadLine();
        try
        {
          reponseInt = int.Parse(reponse);
          if (reponseInt == resultatAttendu)
          {
            return true;
          }
          return false;
        }
        catch
        {
          Console.WriteLine("Erreur: vous devez rentrer un nombre.");
        }
      }
    }
  }
}