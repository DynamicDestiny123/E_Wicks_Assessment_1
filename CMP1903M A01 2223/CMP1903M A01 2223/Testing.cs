using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Testing
    {

        //This class will be a list of private methods that will all be used within a final, public method called runTests
        //The tests will return a boolean value to state whether the test passed or not

        //Creates an empty list that will be used to store the pack of cards
        private static List<Card> test_pack = new List<Card>(52);
        //Creates a variable that tracks the cards dealt, so that the tests for checking dealing the cards can be performed
        private static int cards_dealt = 0;

        //createPack will run the constructor for pack and it will compare each value in the pack to be sure they have been created in order
        //The order is all values in a suit before moving on to the next suit
        private static bool createPack()
        {

            //Writes to console what test is being run
            Console.WriteLine("TESTING CREATING A PACK...");
            //Creates a new pack object
            Pack test = new Pack();
            //Creates the check values for the test
            int check_value = 1;
            int check_suit = 1;
            //Calls returnPack to provide the created list within Pack
            foreach (Card card in Pack.returnPack())
            {
                test_pack.Add(card);
            }
            //For every card in the pack...
            foreach (Card card in test_pack)
            {
                //If either the value or the suit is incorrect
                if (card.Value != check_value || card.Suit != check_suit)
                {
                    //Write to console that the test failed and return false
                    Console.WriteLine("TEST FAILED...");
                    return false;
                }
                else
                {
                    //Otherwise check to see if the card that was just checked is at the end of the suit
                    if (check_value == 13)
                    {
                        //If so increase the suit and reset the check value back to 1 
                        check_suit++;
                        check_value = 1;
                    }
                    //If not only increase the check_value
                    else
                    {
                        check_value++;
                    }
                }
            }
            //Write to the console that the test was passed then return true
            Console.WriteLine("TEST PASSED\n");
            return true;
        }

        //This test runs through the Fisher-Yates shuffle.
        //It checks that the method returns true then will compare the shuffled pack to the test_pack to see if a shuffle actually occured
        private static bool fisherShuffle()
        {
            //Writes to console what test is being run
            Console.WriteLine("TESTING FISHER-YATES SHUFFLE...");
            //Creates a variable that stores the returned value from running the shuffle method
            bool is_shuffled = Pack.shuffleCardPack(1);
            //Creates a list to store the shuffled pack
            List<Card> shuffled_pack = Pack.returnPack();

            //If the returned value was true
            if (is_shuffled)
            {
                //Writes to console that the first check in the test was successful
                Console.WriteLine("METHOD RAN SUCCESSFULLY\nCHECKING CARDS ARE SHUFFLED...");

                //Creates a count variable for test_pack
                int count = 0;
                //For every card in the shuffled pack compare it to the current card in test_pack. If a card is out of place count as true.
                foreach (Card card in shuffled_pack)
                {
                    //If they are the different
                    if (card != test_pack[count])
                    {
                        //Writes to the console that the cards shuffled then returns true
                        Console.WriteLine("CARDS SHUFFLED\nTEST PASSED\n");
                        //Replaces the test_pack with the shuffled pack as the pack is not reset between tests.
                        test_pack = shuffled_pack;
                        return true;
                    }
                    else
                    {
                        //Otherwise increase the counter for test_pack by 1
                        count++;
                    }
                }

                //Once all cards are checked it writes to console that the cards were not shuffled and returns false.
                Console.WriteLine("CARDS NOT SHUFFLED\nTEST FAILED...");
                return false;
            }
            else
            {
                //Otherwise writes to console that the test failed and returns false
                Console.WriteLine("METHOD UNSUCCESSFUL\nTEST FAILED...");
                return false;
            }

        }

        //This test runs through the Riffle Shuffle
        //It checks that the method returns true then will compare the shuffled pack to the test_pack to see if a shuffle actually occured
        private static bool riffleShuffle()
        {
            //Writes to the console what test is being run
            Console.WriteLine("TESTING RIFFLE SHUFFLE...");
            //Creates a variable that stores the returned value from running the shuffle method
            bool is_shuffled = Pack.shuffleCardPack(2);
            //Creates a list to store the shuffled pack
            List<Card> shuffled_pack = Pack.returnPack();

            //If the returned value was true
            if (is_shuffled)
            {
                //Writes to console that the first check in the test was successful
                Console.WriteLine("METHOD RAN SUCCESSFULLY\nCHECKING CARDS ARE SHUFFLED...");

                //Creates a count variable for test_pack
                int count = 0;
                //For every card in the shuffled pack compare it to the current card in test_pack. If a card is out of place count as true.
                foreach (Card card in shuffled_pack)
                {
                    //If they are the different
                    if (card != test_pack[count])
                    {
                        //Writes to the console that the cards shuffled then returns true
                        Console.WriteLine("CARDS SHUFFLED\nTEST PASSED\n");
                        //Replaces the test_pack with the shuffled pack as the pack is not reset between tests.
                        test_pack = shuffled_pack;
                        return true;
                    }
                    else
                    {
                        //Otherwise increase the counter for test_pack by 1
                        count++;
                    }
                }

                //Once all cards are checked it writes to console that the cards were not shuffled and returns false.
                Console.WriteLine("CARDS NOT SHUFFLED\nTEST FAILED...");
                return false;
            }
            else
            {
                //Otherwise writes to console that the test failed and returns false
                Console.WriteLine("METHOD UNSUCCESSFUL\nTEST FAILED...");
                return false;
            }

        }

        //This test runs through the no shuffle option
        //It checks that the method returns true then will compare the shuffled pack to the test_pack to see if they are still the same
        private static bool noShuffle()
        {

            //Writes to the console what test is being run
            Console.WriteLine("TESTING NO SHUFFLE...");
            //Creates a variable that stores the returned value from running the shuffle method
            bool is_shuffled = Pack.shuffleCardPack(3);
            //Creates a list to store the shuffled pack
            List<Card> shuffled_pack = Pack.returnPack();

            //If the returned value was true
            if (is_shuffled)
            {
                //Writes to console that the first check in the test was successful
                Console.WriteLine("METHOD RAN SUCCESSFULLY\nCHECKING CARDS ARE THE SAME...");

                //Creates a count variable for test_pack
                int count = 0;
                //For every card in the shuffled pack compare it to the current card in test_pack. If a card is out of place count as false.
                foreach (Card card in shuffled_pack)
                {
                    //If they are the different
                    if (card != test_pack[count])
                    {
                        //Writes to the console that the cards shuffled then returns false
                        Console.WriteLine("CARDS SHUFFLED\nTEST FAILED...");
                        return false;
                    }
                    else
                    {
                        //Otherwise increase the counter for test_pack by 1
                        count++;
                    }
                }

                //Once all cards are checked it writes to console that the cards were not shuffled and returns true.
                Console.WriteLine("CARDS NOT SHUFFLED\nTEST PASSED\n");
                //test_pack does not need to be changed as the pack has not been shuffled
                return true;
            }
            else
            {
                //Otherwise writes to console that the test failed and returns false
                Console.WriteLine("METHOD UNSUCCESSFUL\nTEST FAILED...");
                return false;
            }
        }

        //This test runs through dealing a single card
        //It compares the returned card to the first card in test pack
        private static bool deal()
        {
            //Writes to console what test is being run
            Console.WriteLine("TESTING DEALING A SINGLE CARD...");
            //Creates a card object to store the dealt card
            Card card = Pack.deal();
            //If the dealt card matches the card in the current position is test_pack
            if (card == test_pack[cards_dealt])
            {
                //Write to console that the test passed, increase cards_dealt by one, then return true
                Console.WriteLine("CARD DEALT WAS CORRECT\nTEST PASSED\n");
                cards_dealt++;
                return true;
            }
            else
            {
                //Otherwise write to console that the test failed and return false
                Console.WriteLine("WRONG CARD DEALT\nTEST FAILED...");
                return false;
            }
        }

        //This test runs through dealing multiple cards
        //It will deal 5 cards and compares each returned card to the card in test_pack at the index specified by cards_dealt
        private static bool dealCard()
        {
            //Writes to console what test is being run and how many cards it's dealing
            Console.WriteLine("TESTING DEALING MULTIPLE CARDS...\nDEALING 5 CARDS...");
            //Creates a list to store the returned cards
            List<Card> cards = Pack.dealCard(5);
            //For every card in the list
            foreach (Card card in cards)
            {
                //If the card is the same as the current card in test_pack
                if (card == test_pack[cards_dealt])
                {
                    //Increase cards_dealt so that the next cards can be compared
                    cards_dealt++;
                }
                else
                {
                    //Otherwise write to console the card dealt is wrong and that the test failed. Return false
                    Console.WriteLine("CARD DOES NOT MATCH\nTEST FAILED...");
                    return false;
                }
            }

            //Write to console that the test was passed and return true
            Console.WriteLine("ALL CARDS MATCH\nTEST PASSED\n");
            return true;
        }

        //This is the public method for testing
        //It will run through each test only if the previous test was passed
        //If all tests are passed it returns true, otherwise it returns false
        public static bool runTests()
        {
            Console.WriteLine("RUNNING ALL TESTS...\n");
            if (createPack())
            {
                if (fisherShuffle())
                {
                    if (riffleShuffle())
                    {
                        if (noShuffle())
                        {
                            if (deal())
                            {
                                if (dealCard())
                                {
                                    Console.WriteLine("ALL TESTS PASSED...\n");
                                    return true;
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine("ONE TEST FAILED...\n");
            return false;
        }

    }
}
