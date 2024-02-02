using System;

class PetCare
{
    private string petName;
    private int hunger = 3;
    private int happiness = 7;
    private int health = 8;

    public string PetName
    {
        get { return petName; }
        set
        {
            if (int.TryParse(value, out _))
            {
                Console.WriteLine("\nError: Pet name cannot be numeric. Please enter a valid name.");
                throw new ArgumentException("Pet name cannot be numeric.");
            }
            else
            {
                petName = value.ToUpper(); // Convert to uppercase;
            }
        }
    }

    public int Hunger
    {
        get { return hunger; }
        set { hunger = value; }
    }

    public int Happiness
    {
        get { return happiness; }
        set { happiness = value; }
    }

    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public void FeedPet()
    {
        if (Hunger == 0)
        {
            Console.WriteLine($"{PetName} is already full. Try something else.");
            return;
        }

        Console.WriteLine($"{PetName} is being fed.");
        Hunger -= 2;
        Health += 3;
    }

    public void PlayWithPet()
    {
        Console.WriteLine($"{PetName} is playing.");

        if (Hunger >= 8)
        {
            Console.WriteLine($"{PetName} is getting hungry. Consider feeding {PetName}.");
        }

        Hunger += 1;
        Happiness += 2;

        if (Happiness <= 3)
        {
            Console.WriteLine($"{PetName} is not very happy. Consider playing with {PetName}.");
        }
    }

    public void LetPetRest()
    {
        Console.WriteLine($"{PetName} is resting.");

        if (Happiness <= 3)
        {
            Console.WriteLine($"{PetName} is not very happy. Consider playing with {PetName}.");
        }

        Health += 3;
        Happiness -= 1;

        if (Health >= 8)
        {
            Console.WriteLine($"{PetName}'s health is high. Consider other actions.");
        }
    }

    public void CheckStatus()
    {
        Console.WriteLine($"{PetName}'s Status:");
        Console.WriteLine($"Hunger: {Hunger}");
        Console.WriteLine($"Happiness: {Happiness}");
        Console.WriteLine($"Health: {Health}");

        if (Hunger >= 8)
        {
            Console.WriteLine($"{PetName} is getting hungry. Consider feeding {PetName}.");
        }

        if (Health >= 8)
        {
            Console.WriteLine($"{PetName}'s health is high. Consider other actions.");
        }
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("Welcome to the Pet Simulator!");

        int petTypeChoice;
        string petType = "";
        string petName = null; // Initialize petName to null
        PetCare userPet = new PetCare(); // Declare userPet outside the loop

        do
        {
            Console.WriteLine("\nChoose the type of pet:");
            Console.WriteLine("1. Cat");
            Console.WriteLine("2. Dog");
            Console.WriteLine("3. Rabbit");
            Console.WriteLine("4. Hamster");

            Console.Write("\nEnter the number for your desired pet type: ");

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

            do
            {
                Console.Write($"\nEnter your {petType}'s name: ");
                try
                {
                    petName = Console.ReadLine();
                    userPet.PetName = petName;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid pet name. Please enter a non-numeric name.");
                }

            } while (string.IsNullOrEmpty(petName) || int.TryParse(petName, out _));

        } while (string.IsNullOrEmpty(petType));

        userPet.PetName = petName;

        int choice;

        do
        {
            Console.WriteLine("\nChoose your PetCare option:");
            Console.WriteLine($"1. Feed {userPet.PetName}");
            Console.WriteLine($"2. Play with {userPet.PetName}");
            Console.WriteLine($"3. Let {userPet.PetName} rest");
            Console.WriteLine($"4. Check {userPet.PetName}'s Status");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice (1-5): ");
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1:
                    userPet.FeedPet();
                    break;
                case 2:
                    userPet.PlayWithPet();
                    break;
                case 3:
                    userPet.LetPetRest();
                    break;
                case 4:
                    userPet.CheckStatus();
                    break;
                case 5:
                    Console.WriteLine("Goodbye!");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                    break;
            }

        } while (choice != 5);

    }
}

