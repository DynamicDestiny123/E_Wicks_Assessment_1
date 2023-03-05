using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903M_A01_2223
{
    class Card
    {
        //Base for the Card class.
        //Value: numbers 1 - 13
        //Suit: numbers 1 - 4
        //No validation here as the integers that get entered are limited by a for loop in Pack
        public int Value { get; set; }
        public int Suit { get; set; }



    }
}
