// See https://aka.ms/new-console-template for more information
using System;

// Ancienne version
namespace Premier_Programme // Note: actual namespace depends on the project name.
{
  internal class Program
  {
    static void Main(string[] args)
    {
      Console.OutputEncoding = System.Text.Encoding.UTF8;

      // DEMANDER LE NOM
      string nom1 = DemanderNom(1);
      string nom2 = DemanderNom(2);

      // DEMANDER AGE
      int age1 = DemanderAge(nom1);
      int age2 = DemanderAge(nom2);

      // AFFICHER INFO PERSONNE
      AfficherInfoPersonne(nom1, age1);
      AfficherInfoPersonne(nom2, age2);

      // Console.WriteLine("Bonjour, vous vous appelez " + nom + " et vous avez " + age + " ans");
      // int age_prochain = age + 1;
      // Console.WriteLine("bientôt vous aurez " + age_prochain + " ans");

      // BOUCLE WHILE
      /*
      int i = 0;
      while (i < 10) {
          Console.WriteLine("Valeur de i : " + i);
          i = i +1;
      }

      Console.WriteLine("Fin de la boucle");*/

    }

    // Afficher info
    static void AfficherInfoPersonne(string nom, int age)
    {
      System.Console.WriteLine();
      System.Console.WriteLine("Bonjour, vous vous appelez " + nom + " et vous avez " + age + " ans.");
      System.Console.WriteLine("Bientôt vous aurez " + (age + 1) + " ans.");

      if (age >= 60)
      {
        System.Console.WriteLine("Vous êtes sénior");
      } 
      else if (age == 18)
      {
        System.Console.WriteLine("Vous êtes tout juste majeur");
      }
      else if (age == 17)
      {
        System.Console.WriteLine("Vous serez bientôt majeur");
      }
      else if (age >= 18)
      {
        System.Console.WriteLine("Vouis êtes majeur");
      }
      else if (age < 10)
      {
        System.Console.WriteLine("Vous êtes un enfant");
      }
      else
      {
        System.Console.WriteLine("Vous êtes mineur");
      }
    }

    // Fonction ajouter un nom
    static string DemanderNom(int numeroPersonne)
    {
      string nom = "";
      while (nom == "")
      {
        Console.Write("Quel est le nom de la personne numéro " + numeroPersonne + " ? ");
        nom = Console.ReadLine();
        nom = nom.Trim();
        if (nom == "")
        {
          Console.WriteLine("Erreur : Le nom ne peut être vide.");
        }

      }
      return nom;
    }

    // Demande l'age de la personne
    static int DemanderAge(string nom)
    {
      int age_num = 0;
      while (age_num <= 0)
      {
        Console.Write(nom + ", quel est ton age ? ");
        string age_str = Console.ReadLine();

        try
        {
          age_num = int.Parse(age_str);
          if (age_num < 0)
          {
            Console.WriteLine("Erreur : L'age ne doit pas être négatif.");
          }
          if (age_num == 0)
          {
            Console.WriteLine("Erreur : L'age ne doit pas être égal à 0");
          }
        }
        catch
        {
          Console.WriteLine("Erreur, vous devez rentrer un age valide. " + age_num);
        }
      }
      return age_num;
    }
  }
}

// Nouvelle version
// Console.WriteLine("Hello, World!");