using System;

namespace number_guessing_game
{
    class Program
    {
        static void Main(string[] args)
        {  
            Console.WriteLine("~~ Number Guessing Game ~~"); // title; not part of the big while loop so will not appear in the next cycle

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
                var assignedNumberOfGuesses = int.Parse(Console.ReadLine().Trim());

                bool invalidGuesses = true;
                while (invalidGuesses)
                {
                    if (assignedNumberOfGuesses > 50)
                    {
                        Console.WriteLine("Alright, I won't limit the number of guesses you can make. Let's go!");
                        invalidGuesses = false;
                    }
                    else if (assignedNumberOfGuesses <= 0)
                    {
                        Console.WriteLine("Can't have zero or negative quantities of guesses! Try again!");
                        var newNumberOfGuesses = int.Parse(Console.ReadLine().Trim());
                        assignedNumberOfGuesses = newNumberOfGuesses;
                    }
                    else
                    {
                        Console.WriteLine($"So you think you can do it in {assignedNumberOfGuesses} guesses, huh? Alright, let's go!");
                        invalidGuesses = false;
                    }
                }

                Console.WriteLine("~~~~~~~~~~");

                // the computer picks a random number
                var randomNumberGenerator = new Random();
                var randomNumber = randomNumberGenerator.Next(lowerRange,upperRange + 1);


                // user makes their first guess
                Console.WriteLine($"I am thinking of a number between {lowerRange} and {upperRange} inclusive. Can you guess what it is?");
                    if (assignedNumberOfGuesses > 50)
                    {
                        Console.WriteLine("You've got unlimited guesses!");
                    }
                    else
                    {
                        Console.WriteLine($"You have {assignedNumberOfGuesses} guesses left!");
                    }
                var guess = int.Parse(Console.ReadLine().Trim());

                // check if guesses are right or wrong, how close they are, and keep track of guess count
                int guessCounter = 0;
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

                    guessCounter++;
                    
                    if (assignedNumberOfGuesses <= guessCounter) // user guessed correctly in less than the assigned number of guesses
                    {
                        break;
                    }
                    else // remove new guess count if user has unlimited guesses, and assign new guess to 'guess', the variable being checked
                    {   
                        if (assignedNumberOfGuesses < 51)
                        {
                            Console.WriteLine($"You have {assignedNumberOfGuesses - guessCounter} guesses left!");
                        }
                        var nextGuess = int.Parse(Console.ReadLine().Trim());
                        guess = nextGuess;
                    }
                }

                // did the user guess the number in the number of guesses alloted?
                if (guess == randomNumber && (guessCounter <= assignedNumberOfGuesses || assignedNumberOfGuesses > 50))  
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

                if (playAgain == "y" || playAgain == "yes") // the program returns to the start of the while loop, so the user can guess again
                {
                    continue;
                }                
                else // exit
                {
                    playWhileTrue = false;
                    Console.WriteLine("Thanks for playing! See you next time!");
                }

            }       

        }
    }
}
