using MyFirstRiderProject;

// How likely are you to win the lottery?

// Lets pick some number first....

var myNumbers = LotteryNumberGenerator.GenerateNumbers(6);

Console.WriteLine($@"Your numbers are {myNumbers[0]}, {myNumbers[1]}, {myNumbers[2]}, {myNumbers[3]}, {myNumbers[4]} and {myNumbers[5]}");
Console.WriteLine("Lets start Playing the Lottery...");

// Declare some variables to track the cost
var totalPlays = 0;
var totalCost = 0;
var totalWinnings = 0;
var hasWon = false;

// Lets start playing until we win
while (!hasWon)
{
    totalPlays += 1;
    totalCost += 2;

    var thisGamesNumbers = LotteryNumberGenerator.GenerateNumbers(6);

    var results = myNumbers.Union(thisGamesNumbers).Count();

    switch(results)
    {
        case 6: 
            Console.WriteLine("YOU WIN!!!!!!!!!!!!");
            totalWinnings += 5_000_000;
            hasWon = true;
            Console.ReadLine();
            break;
        case 7:
            var bonusBallNumber = LotteryNumberGenerator.GenerateBonusBall(thisGamesNumbers);
            var myRemainingNumber = myNumbers.Except(thisGamesNumbers).First();

            if (myRemainingNumber == bonusBallNumber)
            {
                Console.WriteLine("Million Pound Prize!!!!!");
                totalWinnings += 1_000_000;
            }
            else
            {
                totalWinnings += 1_750;
            }

            break;
        case 8: 
            totalWinnings += 140;
            break;
        case 9: 
            totalWinnings += 30;
            break;
    }
    
    Console.WriteLine($@"Playing for {totalPlays / 730} years, P/L: £{(totalWinnings - totalCost):N0}");
}