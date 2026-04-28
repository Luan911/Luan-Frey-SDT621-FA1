using System;

namespace SimpleATMSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===== CTU SIMPLE ATM SYSTEM =====");
            Console.WriteLine();

            // 1. Get User Name
            Console.WriteLine("HI , WHAT IS YOUR NAME?");
            string name = Console.ReadLine();
            Console.WriteLine();

            // 2. Welcome Message (Uppercase as per screenshot)
            Console.WriteLine($"WELCOME {name.ToUpper()}!");

            // 3. Get Account Balance
            Console.Write("Enter account balance: ");
            double balance;
            while (!double.TryParse(Console.ReadLine(), out balance))
            {
                Console.Write("Invalid input. Enter a numeric account balance: ");
            }

            // 4. Get Withdrawal Amount
            Console.Write("Enter withdrawal amount: ");
            double withdrawal;
            while (!double.TryParse(Console.ReadLine(), out withdrawal))
            {
                Console.Write("Invalid input. Enter a numeric withdrawal amount: ");
            }
            Console.WriteLine();

            // 5. Perform Transaction and Display Results
            if (withdrawal <= balance)
            {
                double updatedBalance = balance - withdrawal;

                Console.WriteLine("Withdrawal successful!");

                // Format: N2 gives 2 decimal places, Replace handles the comma separator seen in screenshot
                Console.WriteLine($"Updated Balance: {updatedBalance:N2}".Replace('.', ','));

                // Display Current Date and Time
                Console.WriteLine($"Transaction Time: {DateTime.Now:dd MMM yyyy HH:mm:ss}");
            }
            else
            {
                Console.WriteLine("Transaction failed: Insufficient funds.");
            }

            // Keep console open
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}