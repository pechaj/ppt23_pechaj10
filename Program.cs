Random r = new Random();
int cislo = HadaneCislo();
int hadaneCislo;
//Console.WriteLine(cislo);
bool uhadnuto = false;

Console.WriteLine("Hadej!");

int HadaneCislo() => r.Next(1, 101); // lambda expression

while (!uhadnuto)
{
    try
    {
        string? s = Console.ReadLine();

        if (s == "konec")
        {
            return;
        }

        // int.TryParse(s, out int hadaneCislo){ }
        hadaneCislo = int.Parse(s);

        if (hadaneCislo > cislo)
        {
            Console.WriteLine("Toto cislo je vetsi nez hadane");
            Console.WriteLine("Hadej znovu!");
        }
        else if (hadaneCislo < cislo)
        {
            Console.WriteLine("Toto cislo je mensi nez hadane");
            Console.WriteLine("Hadej znovu!");
        }
        else if (hadaneCislo == cislo)
        {
            Console.WriteLine("Uhadl si cislo! Chces hrat znovu?[y/n]");
            uhadnuto = true;
            s = Console.ReadLine();

            if (s?.ToLower() == "y")
            {
                uhadnuto = false;
                cislo = HadaneCislo();
                Console.Clear();
                Console.WriteLine("Hadej!");
            }
            else
            {
                return;
            }
        }
    }
    catch (System.FormatException)
    {
        Console.WriteLine("Nezadal si zadne cislo. Zkus to znovu.");

    }

}