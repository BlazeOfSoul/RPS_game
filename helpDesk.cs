using System;
using ConsoleTables;

namespace itransition_labs_3
{
    class helpDesk
    {
        public void printDesk(string[] turns)
        {
            Console.WriteLine();
            string[] tempString = new string[turns.Length + 1];
            tempString[0] = "V PC / User >";
            for (int i = 0, j = 1; i < turns.Length; i++)
            {
                tempString[j++] = turns[i];
            }
            var desk = new ConsoleTable(tempString);
            var tempWinner = new selectionWinner();

            for (int i = 0; i < turns.Length; i++)
            {
                for (int j = 0; j < tempString.Length; j++)
                {
                    if (j == 0)
                    {
                        tempString[j] = turns[i];
                    }
                    else
                    {
                        switch (tempWinner.returnWinner(turns, i, j - 1))
                        {
                            case "1":
                                tempString[j] = "LOSE";
                                break;
                            case "-1":
                                tempString[j] = "WIN";
                                break;
                            case "0":
                                tempString[j] = "DRAW";
                                break;
                        }
                    }
                }
                string[] copyString = new string[turns.Length + 1];
                copyString = (string[])tempString.Clone();
                desk.AddRow(copyString);
            }
            desk.Write(Format.Alternative);
        }
    }
}
