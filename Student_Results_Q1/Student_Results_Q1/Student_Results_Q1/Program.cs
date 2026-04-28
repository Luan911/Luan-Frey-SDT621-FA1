using System;

namespace StudentGradingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // 1. Prompt for Student Name
            Console.Write("Enter student name: ");
            string studentName = Console.ReadLine();

            // 2. Prompt for Subject Marks with Validation
            int mark1 = GetValidMark("Enter mark for Subject 1: ");
            int mark2 = GetValidMark("Enter mark for Subject 2: ");
            int mark3 = GetValidMark("Enter mark for Subject 3: ");

            // 3. Calculations
            int totalMarks = mark1 + mark2 + mark3;
            double averageMarks = totalMarks / 3.0;
            string result = (averageMarks >= 50) ? "PASS" : "FAIL";

            // 4. Display Results
            Console.WriteLine("\n===== STUDENT RESULTS =====");
            Console.WriteLine($"Student Name: {studentName}");
            Console.WriteLine($"Total Marks: {totalMarks}");

            // Format average with a comma as a decimal separator to match screenshot
            Console.WriteLine($"Average Marks: {averageMarks:N1}".Replace('.', ','));

            Console.WriteLine($"Result: {result}");

            // Format date and time
            Console.WriteLine($"Result Issued At: {DateTime.Now:dd MMM yyyy HH:mm:ss}");

            // 5. Exit prompt
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        // Helper method to ensure the user enters a valid numeric value.
        static int GetValidMark(string prompt)
        {
            int value;
            while (true)
            {
                Console.Write(prompt);
                if (int.TryParse(Console.ReadLine(), out value))
                {
                    return value;
                }
                Console.WriteLine("Invalid input. Please enter a numeric value.");
            }
        }
    }
}