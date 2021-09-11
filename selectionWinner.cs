using System;
using System.Collections.Generic;
using System.Text;

namespace itransition_labs_3
{
    class selectionWinner
    {
        public string returnWinner(string[] turns, int computerTurn, int userTurn)
        {
            if (computerTurn == userTurn) return "0";
            int range = turns.Length / 2;
            int temp = userTurn + 1;
            int rangeCheck = 1;
            while (rangeCheck <= range)
            {
                if (temp >= turns.Length)
                {
                    temp = 0;
                }
                if (temp == computerTurn)
                {
                    return "-1";
                }
                rangeCheck++;
                temp++;
            }
            return "1";
        }
    }
}
