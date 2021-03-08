using System;

namespace number_guessing_game
{
    class Program
    {
        static void Main(string[] args)
        {  
            Console.WriteLine("~~ Number Guessing Game ~~");

            // initialising a while loop (and its deciding variable) so that the user can keep playing if they like
            bool playWhileTrue = true;

            while (playWhileTrue)
            {   
            // setting ranges the user would like to guess in, and the number of guesses they'd like
            Console.WriteLine("Let's set a range of numbers for you to guess between!");
            Console.WriteLine("Please enter the lower (inclusive) limit of numbers you'd like to guess between.");
            var lowerRange = int.Parse(Console.ReadLine().Trim());
            Console.WriteLine($"{lowerRange}, great! Next, please enter the upper (inclusive) limit of numbers you'd like to guess between.");
            var upperRange = int.Parse(Console.ReadLine().Trim());
            Console.WriteLine($"Alright, you'd like to guess between {lowerRange} and {upperRange} inclusive!");
            
            // making sure the user picks a valid number of guesses
            Console.WriteLine("Just one more thing: how many guesses do you think you can do it in? (If you ask for more than 50 guesses, I won't set a limit on the amount of guesses you have.)");
            var numberOfGuesses = int.Parse(Console.ReadLine().Trim());

            bool invalidGuesses = true;
            while (invalidGuesses)
            {
            if (numberOfGuesses > 50)
            {
                Console.WriteLine("Alright, I won't limit the number of guesses you can make. Let's go!");
                invalidGuesses = false;
            }
            else if (numberOfGuesses <= 0)
            {
                Console.WriteLine("Can't have zero or negative quantities of guesses! Try again!");
                var newNumberOfGuesses = int.Parse(Console.ReadLine().Trim());
                numberOfGuesses = newNumberOfGuesses;
            }
            else
            {
                Console.WriteLine($"So you think you can do it in {numberOfGuesses} guesses, huh? Alright, let's go!");
                invalidGuesses = false;
            }
            }
            Console.WriteLine("~~~~~~~~~~");

            // the computer picks a random number
            var randomNumberGenerator = new Random();
            var randomNumber = randomNumberGenerator.Next(lowerRange,upperRange + 1);


            // you make your first guess
            Console.WriteLine($"I am thinking of a number between {lowerRange} and {upperRange} inclusive. Can you guess what it is?");
            if (numberOfGuesses > 50)
            {
                Console.WriteLine("You've got unlimited guesses!");
            }
            else
            {
                Console.WriteLine($"You have {numberOfGuesses} guesses left!");
            }
            var guess = int.Parse(Console.ReadLine().Trim());

            // analyse guesses
            int a = 0;
            while (guess != randomNumber) 
            {
            if (guess > upperRange || guess < lowerRange)
            {
                Console.WriteLine($"Whoops! I was looking for a number between {lowerRange} and {upperRange} inclusive. Try again!");
            }
            else if (guess < randomNumber)
            {
                Console.WriteLine($"Ooh, good guess! Try going higher!");
            }
            else if (guess > randomNumber)
            {   
                Console.WriteLine($"Ooh, good guess! Try going lower!");
            }
            a++;
            if (numberOfGuesses <= a)
            {
                break;
            }
            else
            {   
            if (numberOfGuesses < 51)
            {}
                Console.WriteLine($"You have {numberOfGuesses - a} guesses left!");
            }
            var nextGuess = int.Parse(Console.ReadLine().Trim());
            guess = nextGuess;
            }
            }
            // did the user guess the number in the number of guesses alloted?
            if (guess == randomNumber && (a <= numberOfGuesses || numberOfGuesses > 50))      
            {
                Console.WriteLine($"That's right! I was thinking of {randomNumber}!");
            }
            else
            {
                Console.WriteLine($"Better luck next time, the number I chose was {randomNumber}!");
            }
            Console.WriteLine("Thanks for playing!");

            // the program asks the user if they would like to keep playing
            Console.WriteLine("Hey, would you like to play again?");
        
            string playAgain = Console.ReadLine().Trim().ToLower();

            if (playAgain == "y" || playAgain == "yes")
            {
                continue;
            }                
            else
            {
                playWhileTrue = false;
                Console.WriteLine("Thanks for playing! See you next time!");
            }

            }       

        }
    }
}
