namespace HuntingTheManticore
{
    internal class Program
    {
        static void Main(string[] args)
        {
            HuntingheManticoreGame();

        }
        static void HuntingheManticoreGame()
        {
            int manticoreHealth = 10;
            int cityHealth = 15;
            int roundNumber = 1;
            int manticoreRangeFromCity = MantiCoreRange("Player 1, how far away from the city do you want to station the Manticore? ");
            Console.Clear();

            int damageToDeal;
            int cannonRange;

            Console.WriteLine("Player 2, it is your turn.");
            while (manticoreHealth > 0 && cityHealth > 0)
            {
                Console.WriteLine("------------------------------------------------------------------");
                Console.WriteLine($"STATUS: Round: {roundNumber} City: {cityHealth}/15 Manticore: {manticoreHealth}/10");


                damageToDeal = DamageToDeal(roundNumber);
                Console.WriteLine($"The cannon is expected to deal {damageToDeal} damage this round");


                Console.Write("Enter desired cannon range: ");
                cannonRange = int.Parse(Console.ReadLine());

                if (CalculateHit(manticoreRangeFromCity, cannonRange))
                {
                    manticoreHealth -= damageToDeal;
                    Console.WriteLine("You hit it!");
                }
                else
                {
                    if (cannonRange > manticoreRangeFromCity)
                    {
                        Console.WriteLine("You overshot");
                    }
                    else
                    {
                        Console.WriteLine("You undershot");
                    }
                }

                if (manticoreHealth > 0) cityHealth--;

                if (manticoreHealth > 0 && cityHealth > 0)
                {
                    roundNumber++;
                }
            }
            if (manticoreHealth > 0)
            {
                Console.WriteLine("The Manticore could not be stopped and destroyed everything in its path. Not a single human survived");
            }
            else
            {
                Console.WriteLine("The Manticore was destroyed! The City was saved!");
            }
        }
        static int MantiCoreRange(string text)
        {
            int range;
            bool hasNumber = true;
            Console.Write(text);
            do
            {
                hasNumber = int.TryParse(Console.ReadLine(), out range);
                if (!hasNumber)
                {
                    Console.WriteLine("HEY! That's not a number?");
                }
                else
                {
                    if (range < 0 || range > 100)
                    {
                        Console.WriteLine("Number need to be: ");
                        Console.WriteLine("A whole number");
                        Console.WriteLine("More than 0");
                        Console.WriteLine("Less than or equal to 100");
                        Console.WriteLine("Press enter if you got it");
                        Console.ReadLine();
                        Console.Clear();
                        hasNumber = false;
                    }
                }

            } while (!hasNumber);
            return range;
        }


        static int DamageToDeal(int round)
        {
            if (round % 3 == 0 && round % 5 == 0) return 10;
            else if (round % 3 == 0 || round % 5 == 0) return 3;
            else return 1;
        }
        static bool CalculateHit(int manticoreRange, int cannonRange)
        {
            if (cannonRange == manticoreRange)
                return true;
            else
                return false;
        }
    }
    //Should have added a custom limit to the number picked, so it could have been more flexible
    //modularity, should have seperated range and getting number to 2 different methods(like he did), what if you need to get a number withour a range?
    //Made a method that display status, just displays one Console.WriteLine();
    //Damage and round are local variables of a while loop instead
    //He used his AskForNumber method again, while the other time another method used it.
    //His display under and over method only writes out text and not calculates, he has an if statement for that
    //He uses expression bodies for all if statements. 
    //He doesn't check if the round should increase or not
    //He used another method to display win/lose
    //He uses more reusable names
}
