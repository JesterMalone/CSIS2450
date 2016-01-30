using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Dan Perkins & Jesse Maynes


namespace hangman
{
    class Hangman
    {
        static int _playerLives = 6;
        static string _answer;
        static char[] _blankAnswer;
        static char guess;
        static int _blankCount;

        static void Main(string[] args)
        {
            GameBoard newGameBoard = new GameBoard();
            WordsForGame words = new WordsForGame();
            _answer = words.wordGenerator();
            _blankAnswer = words.blankWord(_answer);

            //debug
            //Console.WriteLine(_answer);

            while(_blankCount > 0 && _playerLives >= 0)
            {
                newGameBoard.drawGallows(_playerLives);
                Console.WriteLine(_blankAnswer);
                Console.WriteLine("\nEnter a letter to guess");
                guess = Console.ReadKey().KeyChar;
                words.checkGuessAgainstWord(_answer, _blankAnswer, guess);
                
                Console.Clear();
            }

            if (_blankCount == 0)
            {
                Console.WriteLine("Hooray, you win");
            }
            
            else
            {
                Console.WriteLine("Something has gone horribly wrong");
            }

            Console.ReadLine();
        }

        
        public class GameBoard
        {
            StringBuilder lineOne = new StringBuilder();
            StringBuilder lineTwo = new StringBuilder();
            StringBuilder lineThree = new StringBuilder();
            StringBuilder lineFour = new StringBuilder();
            StringBuilder lineFive = new StringBuilder();

            public GameBoard ()
            {
                Console.WriteLine("Let's Play Hangman! \n");
                
            }
            
            //draws gallows
            public void drawGallows(int lives)
            {
                lineOne.Clear();
                lineTwo.Clear();
                lineThree.Clear();
                lineFour.Clear();
                lineFive.Clear();
               
                switch (lives)
                {
                    case 6:
                      
                        lineOne.Append  (" ;---,");
                        lineTwo.Append  (" |" );
                        lineThree.Append(" |" );
                        lineFour.Append (" |" );
                        lineFive.Append ("_|___");
                        break;
                    case 5:
                        lineOne.Append  (" ;---,");
                        lineTwo.Append  (" |   O");
                        lineThree.Append(" |" );
                        lineFour.Append (" |" );
                        lineFive.Append ("_|___");
                        break;
                    case 4:
                        lineOne.Append  (" ;---,");
                        lineTwo.Append  (" |   O" );
                        lineThree.Append(" |   |");
                        lineFour.Append (" |" );
                        lineFive.Append ("_|___" );
                        break;
                    case 3:
                        lineOne.Append  (" ;---,");
                        lineTwo.Append  (" |   O" );
                        lineThree.Append(" |  /|" );
                        lineFour.Append (" |" );
                        lineFive.Append( "_|___" );
                        break;
                    case 2:
                        lineOne.Append  (" ;---,");
                        lineTwo.Append  (" |   O" );
                        lineThree.Append(" |  /|\\");
                        lineFour.Append (" |" );
                        lineFive.Append ("_|___");
                        break;
                    case 1:
                        lineOne.Append  (" ;---," );
                        lineTwo.Append  (" |   O" );
                        lineThree.Append(" |  /|\\");
                        lineFour.Append (" |  /" );
                        lineFive.Append ("_|___");
                        break;
                    case 0:
                        lineOne.Append  (" ;---," );
                        lineTwo.Append  (" |   O" );
                        lineThree.Append(" |  /|\\" );
                        lineFour.Append (" |  / \\" );
                        lineFive.Append ("_|___" );
                        break;
                }
                
                Console.WriteLine(lineOne);
                Console.WriteLine(lineTwo);
                Console.WriteLine(lineThree);
                Console.WriteLine(lineFour);
                Console.WriteLine(lineFive + "\n");

            }
       }



            public class WordsForGame
            {
                                 
                //add words to list for words to guess
                public string wordGenerator()
                {
                    List<string> wordList = new List<string> { "grapefruit", "orange", "apple", "banana", "pineapple", "kiwi", "strawberry", "fish" };
                    Random r = new Random();
                    int randomNum = r.Next(0, 8);

                    _blankCount = wordList.ElementAt(randomNum).ToCharArray().Count();

                    return wordList.ElementAt(randomNum);
                }

                //replaces characters with underscores
                public char[] blankWord(string answer)
                {
                    char [] word = answer.ToCharArray();
                    for (int i = 0; i < word.Length; i++)
                    {
                        word[i] = '_';
                    }

                    return word;
                }

                public char[] checkGuessAgainstWord(string answer, char[] charAnswer, char guess)
                {
                    char[] solution = answer.ToCharArray();
                  
                    if (!answer.Contains(guess))
                    {
                        _playerLives--;
                    }
                    
                    for (int i = 0; i < answer.Length; i++)
                    {
                        if (guess.Equals(answer[i]))
                        {
                            charAnswer[i] = guess;
                            _blankCount--;
                        }
                      
                    }
                    return charAnswer;
                }
            }
        }
    }
