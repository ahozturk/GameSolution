Console.WriteLine("Welcome, to the guessing game!");

// Random number generation

Console.Write("Please enter the starting point: ");

int startPoint = Convert.ToInt32(Console.ReadLine()); // int check can be added

Console.Write("Please enter the ending point: ");

int endPoint = Convert.ToInt32(Console.ReadLine());

// Game logic

bool gameFinished = false;
int guessCount = 0;
//73
while (!gameFinished)
{
    int guessedNumber = startPoint + Convert.ToInt32((endPoint - startPoint + 1) * 0.65); 
    guessCount++;
    Console.WriteLine("Start: " + startPoint);
    Console.WriteLine("End: " + endPoint);

    Console.Write("Is the number " + guessedNumber + "? yes (y) / greater (g) / less (l): ");

    string input = Console.ReadLine();

    if (input == "y")
    {
        Console.WriteLine("I won!");
        Console.WriteLine("Guess count: " + guessCount);
        gameFinished = true;
    }
    else if (input == "g")
    {
        startPoint = guessedNumber + 1;
    }
    else if (input == "l")
    {
        endPoint = guessedNumber - 1;
    }
    else
    {
        Console.WriteLine("Invalid input. Please try again.");
    }
    
}

