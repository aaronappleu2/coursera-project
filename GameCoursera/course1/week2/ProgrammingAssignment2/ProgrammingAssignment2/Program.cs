using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingAssignment2
{
    /// <summary>
    /// Programming Assignment 2 solution
    /// </summary>
    class Program
    {
        /// <summary>
        /// Deals 2 cards to 3 players and displays cards for players
        /// </summary>
        /// <param name="args">command-line arguments</param>
        static void Main(string[] args)
        {
            // print welcome message
            Console.WriteLine("Welcome come to Card Game!(3 player)");
            // create and shuffle a deck
            Deck deck = new Deck();
            deck.Shuffle();

            // deal 2 cards each to 3 players (deal properly, dealing
            // the first card to each player before dealing the
            // second card to each player)
            Card[] player1 = new Card[2];
            Card[] player2 = new Card[2];
            Card[] player3 = new Card[2];
            // deal first card
            Console.WriteLine("Deal first card...");
            player1[0] = deck.TakeTopCard();
            player2[0] = deck.TakeTopCard();
            player3[0] = deck.TakeTopCard();
            // deal second card
            Console.WriteLine("Deal second card...");
            player1[1] = deck.TakeTopCard();
            player2[1] = deck.TakeTopCard();
            player3[1] = deck.TakeTopCard();
            // flip all the cards over
            Console.WriteLine("Flip all the cards over...");
            player1[0].FlipOver();
            player2[0].FlipOver();
            player3[0].FlipOver();
            player1[1].FlipOver();
            player2[1].FlipOver();
            player3[1].FlipOver();
            // print the cards for player 1
            void printCard(Card[] player)
            {
                int i;
                for (i = 0; i < player.Length; i++)
                {
                    Console.WriteLine(player[i].Rank +" "+ player[i].Suit);
                }
            }
            Console.WriteLine("Cards for player 1: ");
            printCard(player1);
            // print the cards for player 2
            Console.WriteLine("Cards for player 2: ");
            printCard(player2);
            // print the cards for player 3
            Console.WriteLine("Cards for player 3: ");
            printCard(player3);
            Console.WriteLine();
        }
    }
}
