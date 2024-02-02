// Import necessary namespaces
using System;
using System.Threading;

// PetCare class for simulation
class PetCare
{
    private string petName;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Welcome to the Pet Simulator!");

            int petTypeChoice;
            string petType = "";

            do
            {
                Console.WriteLine("\nChoose the type of pet:");
                Console.WriteLine("1. Cat");
                Console.WriteLine("2. Dog");
                Console.WriteLine("3. Rabbit");
                Console.WriteLine("4. Hamster");

                Console.Write("Enter the number for your desired pet type: ");

                if (!int.TryParse(Console.ReadLine(), out petTypeChoice) || petTypeChoice < 1 || petTypeChoice > 4)
                {
                    Console.WriteLine("\nError: Invalid choice. Please enter a number for the given choices.");
                    continue;
                }

                switch (petTypeChoice)
                {
                    case 1:
                        petType = "Cat";
                        break;
                    case 2:
                        petType = "Dog";
                        break;
                    case 3:
                        petType = "Rabbit";
                        break;
                    case 4:
                        petType = "Hamster";
                        break;
                    default:
                        Console.WriteLine("Error: Invalid choice. Please enter a number for the given choices.");
                        break;
                }

            } while (string.IsNullOrEmpty(petType));

            PetCare userPet = new PetCare();
            Console.Write($"Enter your {petType}'s name: ");
            //userPet.PetName = Console.ReadLine();


        }
    }
}
