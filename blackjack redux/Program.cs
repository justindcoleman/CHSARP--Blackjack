using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blackjack_redux
{
    class Program
    {
        static void Main(string[] args)
        {
            //here's some big
            //dumb
            //comments to test gitub with
            #region variables
            string suit;
            List<Card> unshuffledDeck = new List<Card>();
            Card currCard;
            Person player = new Person(false, true);
            Person dealer = new Person(true, false);
            bool gameOver = false;
            bool firstDeal = true;
            bool playerFinalCard = false;
            bool dealerFinalCard = false;
            #endregion
            #region build deck
            for (int i = 0; i < 4; i++)
            {
                #region generate suit
                if (i == 0)
                    suit = "Hearts";
                else if (i == 1)
                    suit = "Diamonds";
                else if (i == 2)
                    suit = "Clubs";
                else
                    suit = "Spades";
                #endregion

                #region generate face & value
                for (int j = 0; j < 13; j++)
                {
                    currCard = new Card();
                    currCard.Suit = suit;

                    if (j == 0)
                    {
                        currCard.Face = "Ace";
                        currCard.Value = 1;
                    }
                    else if (j > 0 && j < 10)
                    {
                        currCard.Face = (j + 1).ToString();
                        currCard.Value = j + 1;
                    }
                    else if (j == 10)
                    {
                        currCard.Face = "Jack";
                        currCard.Value = 10;
                    }
                    else if (j == 11)
                    {
                        currCard.Face = "Queen";
                        currCard.Value = 10;
                    }
                    else
                    {
                        currCard.Face = "King";
                        currCard.Value = 10;
                    }
                    unshuffledDeck.Add(currCard);
                }
                #endregion
                #endregion
                #region randomize deck
                List<Card> randomDeck = unshuffledDeck.OrderBy(x => Guid.NewGuid()).ToList();
                #endregion
                #region while loop
                while (!gameOver)
                {
                    #region show game board
                    foreach (Card c in player.Hand)
                    {
                        Console.WriteLine("{0} of {1}", c.Face, c.Suit);
                    }
                    #endregion
                    #region ask to hit
                    string wouldLikeToHit = Console.ReadLine();
                    if (string.IsNullOrEmpty(wouldLikeToHit))
                    {
                        Console.WriteLine("Please enter Yes or No");
                    }
                    else
                    {
                        wouldLikeToHit = wouldLikeToHit.ToLower();
                        char wouldLikeToChar = wouldLikeToHit[0];
                        if (wouldLikeToChar == 'y')
                        {
                            playerMath(player, ref firstDeal, ref randomDeck);
                        }
                        else if (wouldLikeToChar == 'n')
                        {
                            playerFinalCard = true;
                            //anyoneWon(player, dealer, playerFinalCard, dealerfinalCard, ref gameOver)
                        }
                        else
                        {
                            Console.WriteLine("Please enter yes or no.");
                            Console.Readkey();
                        }
                    }
                    #endregion
                }
                #endregion
            }
        }
        public class Card
        {
            private string _suit;
            private string _face;
            private int _value;

            public string Suit
            {
                get { return _suit; }

                set { _suit = value; }
            }

            public string Face
            {
                get { return _face; }

                set { _face = value; }
            }

            public int Value
            {
                get { return _value; }

                set { _value = value; }
            }
        }
        public class Person
        {
            public Person(bool winsPushCon, bool displayWholeHandCon)
            {
                _winsPush = winsPushCon;
                _displayWholeHand = displayWholeHandCon;
                _hand = new List<Card>();
            }
            private List<Card> _hand;
            private bool _winsPush;
            private bool _displayWholeHand;

            public bool WinsPush
            {
                get { return _winsPush; }

                set { _winsPush = value; }
            }

            public List<Card> Hand
            {
                get { return _hand; }

                set { _hand = value; }
            }

            public bool DisplayWholeHand
            {
                get { return _displayWholeHand; }

                set { _displayWholeHand = value; }
            }

            public int handTotal()
            {
                int cardTotalTemp = 0;
                foreach (Card c in _hand)
                {
                    cardTotalTemp = cardTotalTemp + c.Value;
                }
                return cardTotalTemp;
            }
        }
        #region methods
        static int playerMath(Person player, ref bool playerFirstDeal, ref List<Card> randomDeck)
        {
            if (playerFirstDeal == true)
            {
                player.Hand.Add(randomDeck[0]);
                randomDeck.RemoveAt(0);
                player.Hand.Add(randomDeck[0]);
                randomDeck.RemoveAt(0);
                playerFirstDeal = false;
                //dealerMath();
            }
            else if (playerFirstDeal != true)
            {
                player.Hand.Add(randomDeck[0]);
                randomDeck.RemoveAt(0);
                //dealerMath()
            }
            else
            {
                Console.WriteLine("YOU SHOULDN'T HAVE GOTTEN THIS ERROR FROM playerMath()");
            }
            return 0;
        }

        dealerMath(Person dealer, ref bool dealerFirsthand, ref List<Card> randomDeck)
        {

        }

        //moreCards()

        //anyoneBust()

        //compareHand()

        //gameState()
        #endregion
    }
}
