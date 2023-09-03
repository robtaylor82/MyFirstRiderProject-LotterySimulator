namespace MyFirstRiderProject;

public static class LotteryNumberGenerator
{
    public static int[] GenerateNumbers(int totalNumbersToGenerate)
    {
        var randomNumberGenerator = new Random();
        var results = new int[totalNumbersToGenerate];

        for (var i = 0; i < totalNumbersToGenerate; i++)
        {
            var isUnique = false;

            while (!isUnique)
            {
                var newNumber = randomNumberGenerator.Next(1, 49);

                if (results.Contains(newNumber))
                {
                    continue;
                }

                isUnique = true;
                results[i] = newNumber;
            }
        }

        results = results.Order().ToArray();

        return results;
    }

    public static int GenerateBonusBall(int[] thisGamesNumbers)
    {
        while (true)
        {
            var bonusBall = new Random();
            var bonusBallValue = bonusBall.Next(1, 49);

            if (!thisGamesNumbers.Contains(bonusBallValue))
            {
                return bonusBallValue;
            }
        }
    }
}