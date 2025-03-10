Console.WriteLine("Welcome to the guessing game!");

Console.Write("Please enter the starting point: ");
int startPoint = Convert.ToInt32(Console.ReadLine());

Console.Write("Please enter the ending point: ");
int endPoint = Convert.ToInt32(Console.ReadLine());

// Console.Write("Enter the target number (hidden from AI): ");
// int targetNumber = Convert.ToInt32(Console.ReadLine());

// Console.WriteLine("\nMethod 1: 65% Strategy");
// PlayGame(startPoint, endPoint, targetNumber, GuessNumberWith65Method);

// Console.WriteLine("\nMethod 2: Binary Search Strategy");
// PlayGame(startPoint, endPoint, targetNumber, GuessNumberWith50Method);

Console.WriteLine("\nMethod 1: 65% Strategy");
Console.WriteLine($"Average guesses: {GetAveragePerformance(startPoint, endPoint, GuessNumberWith65Method)}");

Console.WriteLine("\nMethod 2: Binary Search Strategy");
Console.WriteLine($"Average guesses: {GetAveragePerformance(startPoint, endPoint, GuessNumberWith50Method)}");

static int PlayGame(int start, int end, int target, Func<int, int, int> guessMethod)
{
    List<int> guesses = new List<int>();
    int guessCount = 0;
    bool gameFinished = false;
    while (!gameFinished)
    {
        int guessedNumber = guessMethod(start, end);
        guesses.Add(guessedNumber);
        // Console.WriteLine($"Guessing {guessedNumber}...");
        guessCount++;
        if (guessedNumber == target)
        {
            // Console.WriteLine($"Correct! The number is {guessedNumber}. Guess Count: {guessCount} - ({string.Join(", ", guesses)})");
            gameFinished = true;
            return guessCount;
        }
        else if (guessedNumber < target)
        {
            start = guessedNumber + 1;
            // Console.WriteLine("Incorrect! The number is higher.");
        }
        else
        {
            end = guessedNumber - 1;
            // Console.WriteLine("Incorrect! The number is lower.");
        }
    }

    throw new Exception("Game should have finished by now.");
}

static int GuessNumberWith65Method(int start, int end)
{
    if (start == end) return start; // Ensure it doesn't get stuck
    return start + Math.Max(1, Convert.ToInt32((end - start + 1) * 0.65));
}

static int GuessNumberWith50Method(int start, int end)
{
    return (start + end) / 2;
}

static float GetAveragePerformance(int start, int end, Func<int, int, int> guessMethod) // 1, 100
{
    float totalGuesses = 0;
    for (int i = start; i <= end; i++) // 1
    {
        totalGuesses += PlayGame(start, end, i, guessMethod);
    }
    return totalGuesses / (end - start + 1);
}