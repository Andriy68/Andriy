using System;
class Car
{
    public string name;
    public string spead;
}
class Comp
{
    public string name = "";
    public string posada = "";
    public string paymant = "";
}
class Mash
{
    public string name = "";
    public string type = "";
}
class Family
{
    public string name = "";
    public string data = "";
    class Person
    {

        Car car = new Car();
        Comp company = new Comp();
        Mash[] pokers = new Mash[1];


        Family[] children = new Family[1];
        Family[] family = new Family[1];
        public int p = 0, f = 0, ch = 0;
        public string name = "";
        public void AddCar(string nam, string spead)
        {
            car.name = nam;
            car.spead = spead;
        }
        public void AddComp(string name, string posada, string paymant)
        {
            company.name = name;
            company.posada = posada;
            company.paymant = paymant;
        }
        public void AddPoker(string name, string type)
        {
            if (p == 0)
            {
                pokers[0] = new Mash();
                p++;
                return;
            }
            Array.Resize(ref pokers, p);

            pokers[p - 1] = new Mash();
            pokers[p - 1].name = name;
            pokers[p - 1].type = type;
            p++;
        }
        public void AddFam(string name, string datee)
        {
            if (f == 0)
            {
                family[0] = new Family();
                f++;
                return;
            }
            Array.Resize(ref family, f);

            family[f - 1] = new Family();
            family[f - 1].name = name;
            family[f - 1].data = datee;
            f++;
        }
        public void AddChild(string name, string data)
        {
            if (ch == 0)
            {
                children[0] = new Family();
                ch++;
                return;
            }
            Array.Resize(ref children, ch);

            children[ch - 1] = new Family();
            children[ch - 1].name = name;
            children[ch - 1].data = data;
            ch++;
        }
        public void Rest(int n, Person[] arr)
        {
            arr[n] = new Person();
        }
        public void Print(Person bitch)
        {
            Console.WriteLine();
            Console.WriteLine($"{bitch.name}\n Comp: {bitch.company.name} {bitch.company.posada} {bitch.company.paymant}\n Car: {bitch.car.name} {bitch.car.spead}\n");

            Console.WriteLine("Pokemons:");
            for (int i = 0; i < bitch.pokers.Length; i++)
            {
                Console.WriteLine($"{bitch.pokers[i].name} {bitch.pokers[i].type}");
            }
            Console.WriteLine("Perents:");
            for (int i = 0; i < bitch.family.Length; i++)
            {
                Console.WriteLine($"{bitch.family[i].name} {bitch.family[i].data}");
            }
            Console.WriteLine("Children:");
            for (int i = 0; i < bitch.children.Length; i++)
            {
                Console.WriteLine($"{bitch.children[i].name} {bitch.children[i]}");

                Console.WriteLine();
            }
        }

        class Prog
        {

            static void Main(string[] args)
            {
                Person[] rip = new Person[1];
                rip[0] = new Person();
                Person chek = new Person();

                string naming = "null";
                string comand = "null";
                int i = 0, l = -1;
                string time1 = "";
                string time2 = "";
                string time3 = "";
                string time4 = "";
                while (comand != "End")
                {
                    naming = Console.ReadLine();

                    if (naming != "End")
                    {
                        comand = Console.ReadLine();
                        if (i == 0)
                        {
                            rip[i].name = naming;
                            rip[i].AddPoker("", "");
                            rip[i].AddFam("", "");
                            rip[i].AddChild("", "");
                            if (comand == "company")
                            {
                                time1 = Console.ReadLine();
                                time2 = Console.ReadLine();
                                time3 = Console.ReadLine();
                                rip[i].AddComp(time1, time2, time3);
                                time1 = "";
                                time2 = "";
                                time3 = "";
                                comand = "";
                                naming = "";
                            }
                            if (comand == "parents")
                            {
                                time1 = Console.ReadLine();
                                time2 = Console.ReadLine();
                                rip[i].AddFam(time1, time2);
                                time1 = "";
                                time2 = "";
                                comand = "";
                                naming = "";
                            }
                            if (comand == "children")
                            {
                                time1 = Console.ReadLine();
                                time2 = Console.ReadLine();
                                rip[i].AddChild(time1, time2);
                                time1 = "";
                                time2 = "";
                                comand = "";
                                naming = "";
                            }
                            if (comand == "car")
                            {
                                time1 = Console.ReadLine();
                                time2 = Console.ReadLine();
                                rip[i].AddCar(time1, time2);
                                time1 = "";
                                time2 = "";
                                comand = "";
                                naming = "";
                            }
                            if (comand == "pokemon")
                            {
                                time1 = Console.ReadLine();
                                time2 = Console.ReadLine();
                                rip[i].AddPoker(time1, time2);
                                time1 = "";
                                time2 = "";
                                comand = "";
                                naming = "";
                            }
                        }
                        for (int j = 0; j < rip.Length; j++)
                        {
                            if (rip[j].name == naming && i != j)
                            {
                                l = j;
                            }
                        }
                        if (l != -1)
                        {
                            rip[l].name = naming;
                            if (comand == "company")
                            {
                                time1 = Console.ReadLine();
                                time2 = Console.ReadLine();
                                time3 = Console.ReadLine();
                                rip[l].AddComp(time1, time2, time3);
                                time1 = "";
                                time2 = "";
                                time3 = "";
                            }
                            if (comand == "parents")
                            {
                                time1 = Console.ReadLine();
                                time2 = Console.ReadLine();
                                rip[l].AddFam(time1, time2);
                                time1 = "";
                                time2 = "";
                            }
                            if (comand == "children")
                            {
                                time1 = Console.ReadLine();
                                time2 = Console.ReadLine();
                                rip[l].AddChild(time1, time2);
                                time1 = "";
                                time2 = "";
                            }
                            if (comand == "car")
                            {
                                time1 = Console.ReadLine();
                                time2 = Console.ReadLine();
                                rip[l].AddCar(time1, time2);
                                time1 = "";
                                time2 = "";
                            }
                            if (comand == "pokemon")
                            {
                                time1 = Console.ReadLine();
                                time2 = Console.ReadLine();
                                rip[l].AddPoker(time1, time2);
                                time1 = "";
                                time2 = "";
                            }
                            comand = "";
                            naming = "";
                            l = -1;
                        }
                        else
                        {
                            Array.Resize(ref rip, rip.Length + 1);
                            i++;
                            chek.Rest(i, rip);
                            if (i > 0)
                            {
                                rip[i].name = naming;
                                if (comand == "company")
                                {
                                    time1 = Console.ReadLine();
                                    time2 = Console.ReadLine();
                                    time3 = Console.ReadLine();
                                    rip[i].AddComp(time1, time2, time3);
                                    time1 = "";
                                    time2 = "";
                                    time3 = "";
                                    comand = "";
                                    naming = "";
                                }
                                if (comand == "parents")
                                {
                                    time1 = Console.ReadLine();
                                    time2 = Console.ReadLine();
                                    rip[i].AddFam(time1, time2);
                                    time1 = "";
                                    time2 = "";
                                    comand = "";
                                    naming = "";
                                }
                                if (comand == "children")
                                {
                                    time1 = Console.ReadLine();
                                    time2 = Console.ReadLine();
                                    rip[i].AddChild(time1, time2);
                                    time1 = "";
                                    time2 = "";
                                    comand = "";
                                    naming = "";
                                }
                                if (comand == "car")
                                {
                                    time1 = Console.ReadLine();
                                    time2 = Console.ReadLine();
                                    rip[i].AddCar(time1, time2);
                                    time1 = "";
                                    time2 = "";
                                    comand = "";
                                    naming = "";
                                }
                                if (comand == "pokemon")
                                {
                                    time1 = Console.ReadLine();
                                    time2 = Console.ReadLine();
                                    rip[i].AddPoker(time1, time2);
                                    time1 = "";
                                    time2 = "";
                                    comand = "";
                                    naming = "";
                                }
                            }

                        }

                    }
                    else
                    {
                        break;
                    }
                }
                Console.WriteLine("Kogo Ishim");
                naming = Console.ReadLine();
                for (int j = 0; j < rip.Length; j++)
                {
                    if (rip[j].name == naming)
                    {
                        l = j;
                    }
                }
                chek.Print(rip[l]);
                Console.ReadLine();

            }
        }
    }
}
