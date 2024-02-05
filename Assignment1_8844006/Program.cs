using System;

class PetCare
{
    private string petName;
    private int hunger = 3, happiness = 7, health = 8; //Set initial values to each category here

    private const int MinAttributeValue = 0; //change values here to set the minimum attribute value
    private const int MaxAttributeValue = 10; //change values here to set the maximum attribute value

    public string PetName
    {
        get { return petName; }
        set
        {
            if (int.TryParse(value, out _)) //Check to ensure pet name is not numeric
            {
                Console.WriteLine("\nError: Pet name cannot be numeric. Please enter a valid name.");
                throw new ArgumentException("Pet name cannot be numeric.");
            }
            petName = value.ToUpper(); // Convert Pets name to uppercase;
        }
    }

    public void SimulateTimePassage()
   {
        // Simulate passage of an hour
        Hunger = LimitAttributeValue(Hunger + 1);
        Happiness = LimitAttributeValue(Happiness - 1);
        Health = LimitAttributeValue(Health - 1);

    }

    public int Hunger
    {
        get { return hunger; }
        private set { hunger = LimitAttributeValue(value); }
    }

    public int Happiness
    {
        get { return happiness; }
        private set { happiness = LimitAttributeValue(value); }
    }

    public int Health
    {
        get { return health; }
        private set { health = LimitAttributeValue(value); }
    }

    private int LimitAttributeValue(int value)
    {
        return Math.Max(MinAttributeValue, Math.Min(MaxAttributeValue, value));
    }

    public void FeedPet()
    {
        Console.WriteLine($"\n*You Choose to Feed the Pet, {PetName} is being fed......");
        Hunger -= 2;
        Health += 2;
    }

    public void PlayWithPet()
    {
        Console.WriteLine($"\n*It's funtime, Let's Play with {PetName} now....");
        Hunger += 1;
        Happiness += 2;
    }
    public void LetPetRest()
    {
        Console.WriteLine($"\n*Nice Choice, Rest is required too for the Pets, {PetName} is Sleeping now....");
        Health += 2;
        Happiness -= 1;
    }
    public void CheckStatus()
    {
        // Display current status
        DisplayStatus();
    }

    public void DisplayStatus()
    {
        // Display updated status for each category
        Console.WriteLine($"\n{PetName}'s Current Status:\n- Hunger: {Hunger}\n- Happiness: {Happiness}\n- Health: {Health} \n");
        if (Hunger == 0) Console.WriteLine($"Alert: {PetName} is already full. Let's play with it.");
        if (Hunger >= 8) Console.WriteLine($"Warning: {PetName} is hungry. Let's feed {PetName} before playing with it.");
 
        if (Happiness <= 3) Console.WriteLine($"Warning: {PetName} is getting bored now. Consider playing with {PetName}.");

        if (Health >= 8) Console.WriteLine($"Alert: {PetName}'s health is high. Let's either play or let {PetName} rest now.");
        if (Health <= 3) Console.WriteLine($"Warning: {PetName}'s health degrading. Let's either feed {PetName} or Let it rest now.");
    }
}
class Program
{
    static PetCare userPet = new PetCare();

    static void Main()
    {
        Console.WriteLine("Welcome to the Pet Simulator!");

        int petTypeChoice;
        string petType = "", petName = null;

        do
        {
            Console.WriteLine("\nChoose the pet you want:\n1. Cat\n2. Dog\n3. Rabbit\n4. Hamster");
            Console.Write("\nEnter the number for your desired pet type (1-4): ");

            if (!int.TryParse(Console.ReadLine(), out petTypeChoice) || petTypeChoice < 1 || petTypeChoice > 4)
            {
                Console.WriteLine("\nError: Invalid choice. Please enter a number from the given choices.");
                continue;
            }

            petType = petTypeChoice switch
            {
                1 => "Cat",
                2 => "Dog",
                3 => "Rabbit",
                4 => "Hamster",
                _ => "Error"
            };

            do
            {
                Console.Write($"\nYou have Choosen {petType} as your Pet, Let's pick a name for it. \nEnter your {petType}'s name: ");
                //Console.Write($"\nEnter your {petType}'s name: ");
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
            Console.WriteLine("\n---------------------------");
            Console.WriteLine($"Choose your PetCare option:\n1. Feed {userPet.PetName} \n2. Play with {userPet.PetName} " +
                $"\n3. Let {userPet.PetName} rest \n4. Check {userPet.PetName}'s Status \n5. Exit");
            Console.WriteLine("---------------------------");
            Console.Write("\nEnter your choice (1-5): ");
            
            int.TryParse(Console.ReadLine(), out choice);

            switch (choice)
            {
                case 1: userPet.FeedPet(); break;
                case 2: userPet.PlayWithPet(); break;
                case 3: userPet.LetPetRest(); break;
                case 4: userPet.CheckStatus(); break;
                case 5: Console.WriteLine($"Thanks for playing with {userPet.PetName} Goodbye!"); break;
                default: Console.WriteLine("Invalid choice. Please enter a number between 1 and 5."); break;
            }
            userPet.SimulateTimePassage();
            if (choice != 4 && choice != 5) userPet.DisplayStatus();
        } while (choice != 5);
    }
}
