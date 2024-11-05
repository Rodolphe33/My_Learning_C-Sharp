// See https://aka.ms/new-console-template for more information
using System;
using FormationCS;

namespace generateur_mot_de_passe
{
    class Program
    {
        static void Main(string[] args)
        {
            const int NB_MOT_DE_PASSE = 10;

            // 1 - Demander la longueur du mot de passe => int longueur_mot_de_passe =
            int longueurMotDePasse1 = outils.DemanderNombrePositifNonNull("Longueur du mot de passe : ");
            Console.WriteLine();
            int typeMotDePasse = outils.DemanderNombreEntre("Vous voulez un mot de passe avec : \n" +
                "1 - Uniquement des caractères en minuscules \n" +
                "2 - Des caractères en minuscules et majuscules \n" +
                "3 - Des caractères et des chiffres \n" +
                "4 - Caractères, chiffres et caractères spéciaux\n" +
                "Votre choix : ", 1, 4);

            // 2 - alphabet "abcd1234
            // 3- comment choisir un caractére aléatoire
            string minuscules = "abcdefghijklmnopqrstuvwxyz";
            string majuscules = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string chiffres = "0123456789";
            string caracteresSpeciaux = "!@#$%&*()-_=+[{]}<>?";
            string alphabet = "";

            switch (typeMotDePasse)
            {
                case 1:
                    alphabet = minuscules;
                    break;
                case 2:
                    alphabet = minuscules + majuscules;
                    break;
                case 3:
                    alphabet = minuscules + majuscules + chiffres;
                    break;
                case 4:
                    alphabet = minuscules + majuscules + chiffres + caracteresSpeciaux;
                    break;
            }
            
            string motDePasse = "";
            int longueurAlphabet = alphabet.Length;
            Random rand = new Random();

            for(int n = 0; n < NB_MOT_DE_PASSE; n++)
            {
                for (int i = 0; i < longueurMotDePasse1; i++)
                {
                    int index = rand.Next(0, longueurAlphabet);
                    motDePasse += alphabet[index];
                }

                Console.WriteLine($"Mot de passe : {motDePasse}");
                motDePasse = "";
            }
            

            // 4 - générer le mot de passe
            // 5 - Améliorations : choix alphabet
        }

    }
}