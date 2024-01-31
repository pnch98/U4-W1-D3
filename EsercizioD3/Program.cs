using System;

namespace EsercizioD3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string resp, name, surname;


            Console.WriteLine("Vuoi aprire un conto?");
            do
            {
                Console.WriteLine("Scegli un'opzione valida tra y/n");
                resp = Console.ReadLine();
            } while (resp != "y" && resp != "n");

            if (resp == "n")
            {
                Console.WriteLine("Va bene, buona serata!");
                Environment.Exit(0);
            }

            Console.WriteLine("Inserisci il tuo nome: ");
            name = Console.ReadLine();
            Console.WriteLine("Inserisci il tuo cognome: ");
            surname = Console.ReadLine();

            ContoCorrente conto = ContoCorrente.GetInstance();
            conto.SetName(name);
            conto.SetSurname(surname);

            int choice;

            do
            {

                Console.WriteLine($"\nConto intestato a: {conto.GetName()} {conto.GetSurname()}");
                Console.WriteLine($"Saldo attuale: {conto.GetCredit()} euro");

                Console.WriteLine("\nChe operazione vuoi effettuare?");
                Console.WriteLine("1) Deposita\n2) Preleva\n0) Esci");
                Console.Write("Inserire numero corrispondente all'operazione desiderata: ");
                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Quanto denaro vuoi depositare?");
                        conto.Deposit(float.Parse(Console.ReadLine()));
                        Console.WriteLine("Deposito effettuato con successo!");
                        break;
                    case 2:
                        Console.WriteLine("Quanto denaro vuoi prelevare?");
                        float quantity = float.Parse(Console.ReadLine());
                        if (conto.GetCredit() >= quantity)
                        {
                            conto.Withdrawal(quantity);
                        }
                        else
                        {
                            Console.WriteLine("Errore! Saldo non disponibile nella quantità richiesta.");
                        }
                        break;
                    case 0:
                        break;
                    default:
                        Console.WriteLine("Opzione non valida.");
                        break;
                }
            } while (choice != 0);

            Console.WriteLine("Esercizio 2:");
            Console.WriteLine("Quanti nomi vuoi inserire?");

            int n;
            int.TryParse(Console.ReadLine(), out n);
            string[] nameArr = new string[n];

            for (int i = 0; i < n; i++)
            {
                Console.Write($"{i + 1}) ");
                nameArr[i] = Console.ReadLine().ToLower();
            }



            Console.WriteLine("\nQuale nome vuoi cercare nell'array?");
            string nameSelected = Console.ReadLine();

            int count = 0;

            for (int i = 0; i < n; i++)
            {
                if (nameArr[i] == nameSelected.ToLower())
                {
                    Console.WriteLine($"Il nome {nameSelected} è presente nell'array in posizione {i + 1}");
                    count++;
                    break;
                }
            }

            if (count == 0) { Console.WriteLine($"Il nome {nameSelected} non è presente nell'array"); }


            Console.WriteLine("\nEsercizio 3:");
            Console.WriteLine("Inserisci dimensione dell'array: ");
            int x = int.Parse(Console.ReadLine());

            int sum = 0;

            int[] numberArr = new int[x];
            for (int i = 0; i < x; i++)
            {
                Console.Write($"{i + 1}) ");
                numberArr[i] = int.Parse(Console.ReadLine());
                sum += numberArr[i];
            }

            Console.WriteLine($"La somma di tutti i numeri è: {sum}. \nLa media aritmetica è: {((float)sum / (float)x)}");
        }
    }
}
