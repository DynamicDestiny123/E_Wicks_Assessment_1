using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Pack
    {
        //Creates the list for the pack of cards
        private static List<Card> pack = new List<Card>(52);
        //integer used to track how many cards have been dealt to prevent repeats
        private static int cards_dealt = 0;

        public Pack()
        {
            //Initialise the card pack here

            //Creates a card object for every value in each suit using for loops
            //Adds the created object to the list pack.

            for (int suit = 1; suit <= 4; suit++)
            {
                for (int value = 1; value <= 13; value++)
                {
                    Card card = new Card();
                    card.Suit = suit;
                    card.Value = value;
                    pack.Add(card);
                }
            }
        }

        public static bool shuffleCardPack(int typeOfShuffle)
        {
            //Shuffles the pack based on the type of shuffle

            //Uses an if statement to determine if the value is a valid option

            //If Fisher-Yates is chosen
            if (typeOfShuffle == 1)
            {

                //For every position in pack up until n-2

                for (int i = pack.Count - 1; i >= 1; i--)
                {

                    //Generate a random number between i and n
                    Random random = new Random();
                    int to_swap = random.Next(0, i);

                    //Create a temporary card variable to hold the card at position i
                    Card temp_card = pack[i];
                    //Replace the card at position i with the card in a random position
                    pack[i] = pack[to_swap];
                    //Replace the card in the random position with the temporary variable for the card at i
                    pack[to_swap] = temp_card;
                }

                //Return true to indicate the shuffle is finished
                return true;

            }

            //If Riffle is chosen
            else if (typeOfShuffle == 2)
            {

                //Create variable to indicate the split halfway through the deck.
                int mid = (pack.Count / 2);
                //Create a new list to store the cards as they are added
                List<Card> shuffled_pack = new List<Card>(52);
                //For the first card in the pack up until the middle of the pack
                for (int i = 0; i < mid; i++)
                {
                    //Add to shuffled pack the current card in the first half of pack
                    shuffled_pack.Add(pack[i]);
                    //Add to shuffled pack the current card in the second half of the pack
                    shuffled_pack.Add(pack[mid + i]);
                }

                //Replace cards in pack with the new shuffled pack
                pack = shuffled_pack;

                //Return true to indicate the shuffle is finished
                return true;

            }

            //If No Shuffle is chosen
            else if (typeOfShuffle == 3)
            {

                //Perform no changes to the pack
                //Return true to indicate the method is finished
                return true;

            }

            //If the option entered isn't available, return false
            else { return false; }

        }
        public static Card deal()
        {
            //Checks to see if the pack is empty
            if (cards_dealt == pack.Count)
            {
                //If so, returns empty card object
                return new Card();
            }
            //Otherwise increase cards_dealt counter by one and deal one card
            cards_dealt++;
            return pack[cards_dealt - 1];
        }
        public static List<Card> dealCard(int amount)
        {

            //Checks to see if the amount to be dealt is greater than how many cards are left
            if ((cards_dealt + amount) >= pack.Count)
            {

                //Then checks to see if there are any cards left that can be dealt
                if (cards_dealt < pack.Count)
                {

                    //If so it changes amount to the number of cards remaining
                    amount = pack.Count - cards_dealt;

                }

                //If not it returns an empty list
                else { return new List<Card>(); }

            }

            //Creates a list of cards that will be dealt with the size 'amount'
            List<Card> to_deal = new List<Card>(amount);
            //Deals the number of cards specified by 'amount'
            for (int i = cards_dealt; i < cards_dealt + amount; i++)
            {
                //By adding them to the new list created
                to_deal.Add(pack[i]);
            }

            //Increase the cards dealt counter
            cards_dealt += amount + 1;

            //Then return the list of cards that have been dealt
            return to_deal;

        }

        //Returns the pack of cards so that they can be compared in Testing Class
        public static List<Card> returnPack() { return pack; }

    }
}
