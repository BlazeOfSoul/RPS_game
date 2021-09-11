using System;
using System.Linq;
using System.Text.RegularExpressions;


namespace itransition_labs_3
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                if (args.Length < 3)
                {
                    throw new Exception("The number of turns is less than three, enter turns again");
                }
                if(args.Length % 2 == 0)
                {
                    throw new Exception("The number of turns is even, but odd is required. Try again");
                }
                bool flag = true;
                foreach(var turn in args)
                {
                    if(args.Where(p => p == turn).Count() >= 2)
                    {
                        throw new Exception("You have two identical moves, enter all moves different");
                    }
                }
                if (!flag)
                {
                    continue;
                }
                break;
            }

            Random randGenerator = new Random();
            int computerTurnNumber = randGenerator.Next(0, args.Length);
            string computerTurnName = args[computerTurnNumber];
            MyHmac keyHMAC = new MyHmac();
            Console.WriteLine("HMAC:");
            Console.WriteLine(keyHMAC.returnHMAC(computerTurnName));

            Console.WriteLine("Available moves:");
            for(int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(i + 1 + " - " + args[i]);
            }
            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");
            string answer, userTurnName;
            int userTurnNumber = 0;
            while (true) {
                Console.WriteLine("Enter your move: ");
                answer = Console.ReadLine();
                if (answer.All(char.IsDigit) && answer != "0" && Convert.ToInt32(answer) <= args.Length)
                {
                    userTurnName = answer;
                    userTurnNumber = Convert.ToInt32(userTurnName) - 1;
                    break;
                }
                if(answer == "?")
                {
                    var desk = new helpDesk();
                    desk.printDesk(args);
                    continue;
                }
                if(answer == "0")
                {
                    Console.WriteLine("Thank you for game!");
                    return;
                }
                Console.WriteLine("Bad type of answer, try to choose again");
                continue;
            }
            
            Console.WriteLine("Your move - " + args[userTurnNumber]);
            Console.WriteLine("Computer move - " + computerTurnName);
            selectionWinner Winner = new selectionWinner();
            switch (Winner.returnWinner(args, computerTurnNumber, userTurnNumber))
            {
                case "1":
                    Console.WriteLine("You win!");
                    break;
                case "-1":
                    Console.WriteLine("You lose :(");
                    break;
                case "0":
                    Console.WriteLine("Draw.");
                    break;
            }
            Console.Write("HMAC key: " + keyHMAC.returnCharKey());
        }
    }
}
