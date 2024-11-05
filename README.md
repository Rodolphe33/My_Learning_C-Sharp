# My learning C#

Formation et minis projets en C# réalisé sur le cours Udemy :

- [Développeur C# | Formation Complète 2024](https://www.udemy.com/course/developpeur-cs-formation-complete)

## Les collections

### Les tableaux (array)

```c#
int[] - string[] - float[] - bool[]

* int[] t = new int[**taille du tableau**];
* int[] t = {0,1,2,3,4,5,};
```

### Les listes (list)

```C#
List<int>, List<string>, List<float>, List<bool>

* List<int> liste = new List<int>(); ou var liste = new List<int>();
```

Ajouter un élément : **List.add(** element **)**

Supprimmer un élémenet : **List.remove(** element **)**

Supprimmer un élémenet par son index: **List.removeAt(** index **)**

Récupérer certrains éléments : **List.GetRange(** index, count **)**

### ArrayList

C'est un tableau qui accépte tous les types : string, bool, int, float, double, ...

```C#
ArrayList a = new ArrayList();
```

Il faut éviter de l'utiliser car compliquer à débbuger.

### Listes de listes

```C#
var pays = new List<List<string>>();

pays.Add(new List<string> {"France", "Paris", "Toulouse", "Bordeaux", "Lille"});
pays.Add(new List<string> {"Etats-Unis", "New-York","Chicago", "Los Angeles", "San Francisco", "Seatles"};
pays.Add(new List<string> {"Italie", "Rome", "Milan", "Pise", "Venise"});
```

### Le dictionnaire

```C#
var  d = new Dictionary<string, string>();
d.Add("Jean", "06666666666");
d.Add("marie", "07777777777");
d["Martin"] = "08888888888";
```

### La boucle Foreach

```C#
```

### Tris

```C#
// List
var villes = new List<string> { "Paris", "Toulouse", "Nice", "Bordeaux", "Lille", "Pau" };
villes.Sort();

// Array
var villes = new string[] { "Paris", "Toulouse", "Nice", "Bordeaux", "Lille", "Pau" };
Array.Sort(villes);

// Tri alphabétique
var villeTries = villes.OrderBy(nom => nom).ToArray(); // Array
var villeTries2 = villes.OrderByDescending(nom => nom).ToList(); // List

// Tri alphabétique sur la dernière lettre
var villeTries = villes.OrderBy(nom => nom[nom.Length-1]); 
```

### Linq

```C#
var villes = new List<string> { "Paris", "Toulouse", "Nice", "Bordeaux", "Lille", "Pau" };
villes = villes.Where(v => v[v.Length - 1] == 'e').ToArray();
```

### Passage par valeur ou références

Dans une fonction avec un paramêtre, ce paramêtre est lié à la fonction.
Si le paramêtre est typé (list, array, etc)

```C#
static void PassageValeurOuRef()
{
    // Valeur
    int a = 5;
    FunctionOne(a); // Passage par Valeur
    // a = 5

    // Référence
    var b = new List<int> {5};
    FunctionTwo(b); // Passage par Référence
    // b = 10 
}

static void FonctionOne(int v)
{
    // v = 5
    v = 10;
}

static void FonctionTwo(List<int> v)
{
    // v = 5
    v[0] = 10; // ici modification de l'intérieur de la liste
}

```

Si dans une fonction le paramêtre est précédé de 'out', la valeur du paramêtre est retourné.

```C#
static void PassageValeurOuRef()
{
    // Référence
    int a = 5;
    Function(out a); // Passage par Référence
    // b = 10 
}

static void Fonction(out int v)
{
    // v = 5
    v = 10;
}
```
