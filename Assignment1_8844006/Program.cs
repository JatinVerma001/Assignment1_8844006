using System;

class PetCare
{
    private string petName;
    private int hunger = 3, happiness = 7, health = 8; //Setting initial values for each category

    private const int MinAttributeValue = 0; //setting the minimum attribute value for => health, happiness and hunger
    private const int MaxAttributeValue = 10; //setting the maximum attribute value for => health, happiness and hunger

    public string PetName
    {
        get { return petName; }
        set
        {
            if (int.TryParse(value, out _)) //Applied a Check to ensure pet name is not numeric
            {
                Console.WriteLine("\nError: Pet name cannot be numeric. Please enter a valid name.");
                throw new ArgumentException("Pet name cannot be numeric.");
            }
            petName = value.ToUpper(); // Convert Pets name to uppercase;
        }
    }

    public void SimulateTimePassage()
   {
        // Simulate passage of an hour by reducing and increasing the attributes
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

    //Below are the functions called for respective action selected and called from main function
    public void FeedPet()
    {
        Console.WriteLine($"\n** You Choose to Feed the Pet, {PetName} is being fed......");
        Console.WriteLine($"{PetName}'s Hunger decreases & Health increases slightly :-) ");
        Hunger -= 2;
        Health += 2;
        DisplayStatus();
    }

    public void PlayWithPet()
    {
        Console.WriteLine($"\n** It's funtime, Let's Play with {PetName} now....");
        Console.WriteLine($"You've played with {PetName}'s, but now he is bit Hungry.");
        Hunger += 1;
        Happiness += 2;
        DisplayStatus();
    }
    public void LetPetRest()
    {
        Console.WriteLine($"\n** Nice Choice, Letting your pet Rest is important too, {PetName} is Sleeping now....");
        Console.WriteLine($"Resting increases {PetName}'s health, but now he is bit Hungry.");
        Health += 2;
        Happiness -= 1;
        DisplayStatus();
    }
    public void CheckStatus()
    {
        // Display current status
        DisplayStatus();
    }

    public void DisplayStatus()
    {
        // Display the updated status for each category
        Console.WriteLine($"\n{PetName}'s Current Status:\n- Hunger: {Hunger}\n- Happiness: {Happiness}\n- Health: {Health} \n");
        if (Hunger == 0) Console.WriteLine($"Alert: {PetName} is already full. Let's play with it.");
        if (Hunger >= 8) Console.WriteLine($"Warning: {PetName} is hungry. Let's feed {PetName} before playing with it.");
 
        if (Happiness <= 3) Console.WriteLine($"Warning: {PetName} is getting bored now. Consider playing with {PetName}.");

        if (Health >= 8) Console.WriteLine($"Alert: {PetName}'s health is high. Let's play with {PetName} now.");
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
            // Code below is responsible for populating the choices related to pet types
            Console.WriteLine("\nPlease select the pet you want:\n1. Cat\n2. Dog\n3. Rabbit\n4. Hamster");
            Console.Write("\nEnter the number for your desired pet type (1-4): ");

            //Code to verify if the user selection lies between provided options
            if (!int.TryParse(Console.ReadLine(), out petTypeChoice) || petTypeChoice < 1 || petTypeChoice > 4)
            {
                Console.WriteLine("\n!Error!: Invalid choice. Please enter a number from the given choices.");
                continue;
            }

            //switch cases for pet types
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
                    //Code for Pet name
                    petName = Console.ReadLine();
                    userPet.PetName = petName;
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Invalid pet name. Please enter a non-numeric name.");
                }

            } while (string.IsNullOrEmpty(petName) || int.TryParse(petName, out _)); //loop to verify that the pet name shouldn't be empty & numeric

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

            switch (choice) //code for main menu once the pet type & name is choosen
            {
                case 1: userPet.FeedPet(); break;
                case 2: userPet.PlayWithPet(); break;
                case 3: userPet.LetPetRest(); break;
                case 4: userPet.CheckStatus(); break;
                case 5: Console.WriteLine($"\nThanks for playing with {userPet.PetName}. \nGoodbye!"); break;
                default: Console.WriteLine("Invalid choice. Please enter a number between 1 and 5."); break;
            }
            userPet.SimulateTimePassage();
            //if (choice != 4 && choice != 5) userPet.DisplayStatus();
        } while (choice != 5);
    }
}
