using Newtonsoft.Json;

namespace MyNamespace
{
    class Personne
    {
        public string nom { get; private set; }
        public int age { get; private set; }
        public bool majeur { get; private set; }

        public Personne(string nom, int age, bool majeur)
        {
            this.nom = nom;
            this.age = age;
            this.majeur = majeur;
        }

        public void Afficher()
        {
            Console.WriteLine($"Nom : {nom}, Age : {age} ans");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            var person1 = new Personne("Toto", 20, true);
            person1.Afficher();

            string json = JsonConvert.SerializeObject(person1);
            Console.WriteLine(json);
            
            string jsonTiti = "{\"nom\":\"Titi\",\"age\":20,\"majeur\":true}";
            Personne titi = JsonConvert.DeserializeObject<Personne>(jsonTiti);
            titi.Afficher();
            */
            /*
            var persons = new List<Personne>() {
                new Personne("Rodolphe", 27, true),
                new Personne("Mélina", 25,true),
                new Personne("Isa", 44, true),
                new Personne("Sophie", 3, false)
            };

            string jsonPersons = JsonConvert.SerializeObject(persons);
            File.WriteAllText("persons.txt", jsonPersons);
            */

            string json = File.ReadAllText("persons.txt");
            var persons = JsonConvert.DeserializeObject<List<Personne>>(json);

            foreach (var person in persons) {
                person.Afficher();
            }
        }
    }
}