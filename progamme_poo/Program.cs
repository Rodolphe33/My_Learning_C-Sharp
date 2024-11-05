using System;

namespace programme_poo
{
    // Créer une classe enfant (Etudiant)
    // Constructeur : nom et l'age; infoEtudes = null
    // Main -> Créer un enfant "Sophie", 7 -> Afficher
    // string classeEcole "CP"
    // Afficher "Enfant en classe de : 
    // AfiicherProfesseurPrincipal

    class Enfant : Etudiant
    {
        string classeEcole;
        Dictionary<string, float> notes;
        public Enfant(string name, int age, string classeEcole, Dictionary<string, float> notes) : base(name, age, null)
        {
            this.classeEcole = classeEcole;
            this.notes = notes;
        }

        public override void Afficher()
        {
            AfficherNomEtAge();
            Console.WriteLine($"  Enfant en classe de {classeEcole}");

            if (notes != null && notes.Count > 0)
            {
                Console.WriteLine($"  Notes moyennes");
                foreach (var note in notes)
                {
                    Console.WriteLine($"    {note.Key} : {note.Value} / 10");
                }
            }
            AfiicherProfesseurPrincipal();
        }
    }

    class Etudiant : Personne
    {
        string infoEtudes;

        public Personne professeurPrincipal;

        public Etudiant(string nom, int age, string infoEtudes) : base(nom, age, "Etudiant")
        {
            this.infoEtudes = infoEtudes;
        }

        public override void Afficher()
        {
            AfficherNomEtAge();
            Console.WriteLine($"  Etudiant en {infoEtudes}");
            AfiicherProfesseurPrincipal();
        }

        protected void AfiicherProfesseurPrincipal()
        {
            if (professeurPrincipal != null)
            {
                Console.WriteLine($"  Le professeur principal est :");
                professeurPrincipal.Afficher();
            }
        }
    }

    public class Personne : IAffichable
    {
        static int nombreDePersonnes = 0;

        public string nom { get; init; }
        public int age { get; init; }
        string emploi;
        protected int numeroPersonne;

        public Personne(string nom, int age, string emploi = null)
        {
            this.nom = nom;
            this.age = age;
            this.emploi = emploi;

            nombreDePersonnes++;
            this.numeroPersonne = nombreDePersonnes;
        }

        public virtual void Afficher()
        {
            AfficherNomEtAge();
            if (emploi == null)
            {
                Console.WriteLine("  Aucun emploi spécifié");
            }
            else
            {
                Console.WriteLine($"  Emploi : {emploi}");
            }
        }

        protected void AfficherNomEtAge()
        {
            Console.WriteLine($"Personne N°{numeroPersonne}");
            Console.WriteLine($"  Nom : {nom}");
            Console.WriteLine($"  Age : {age} ans");
        }

        public static void AfficherNombreDePersonne()
        {
            Console.WriteLine($"Nombre de personne total : {nombreDePersonnes}");
        }
    }

    class TableMultiplication : IAffichable
    {
        int numero;

        public TableMultiplication(int numero)
        {
            this.numero = numero;
        }

        public void Afficher()
        {
            Console.WriteLine($"Table de multiplication de {numero}");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"{numero} x {i} = {numero * i}");
            }
        }
    }

    interface IAffichable
    {
        void Afficher();
    }

    class Program
    {
        public static void Main(string[] args)
        {
            // nom, age, emploi
            /* var noms = new List<string> { "Paul", "John", "David" };
            var ages = new List<int> { 30, 35, 20 };
            var emplois = new List<string> { "Développeur", "Professeur", "Etudiant" };

            for (int i = 0; i < noms.Count; i++)
            {
                AfficherInfoPersonne(noms[i], ages[i], emplois[i]);
            }*/

            // Personne personne1 = new Personne("Paul", 30, "Développeur");
            // personne1.Afficher();

            var elements = new List<IAffichable>
            {
                new Personne("Paul", 30, "Développeur"),
                new Personne("John", 35, "Professeur"),
                new Etudiant("David", 20, "Etudiant"),
                new Enfant("Juliette", 8, "CP", null),
                new TableMultiplication(2)
            };

            // personnes = personnes.OrderBy(p => p.nom).ToList();

            foreach (var element in elements)
            {
                element.Afficher();
            }
            
            Personne.AfficherNombreDePersonne();

            // var personne1 = new Personne("Paul", 30);
            // personne1.Afficher();

            /* var professeur = new Personne("Paul", 30, "Professeur");
            var etudiant = new Etudiant("David", 20, "Ecole d'ingénieur informatique")
            {
                professeurPrincipal = professeur
            };

            etudiant.Afficher();
            var notes = new Dictionary<string, float> { { "Math", 5 }, { "Géo", 8.5f } };
            var enfant = new Enfant("Sophie", 7, "CP", notes);
            enfant.Afficher(); */

            TableMultiplication table_2 = new TableMultiplication(2);
            table_2.Afficher();
        }
    }
}
