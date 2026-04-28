using System;
using System.Collections.Generic;

namespace EmfuleniMunicipality;

internal class Program
{
    private static void Main(string[] args)
    {
        var manager = new UtilitiesManager();
        var residents = new List<Resident>();
        var pendingRequests = new List<ServiceRequest>();
        var resolvedRequests = new List<ServiceRequest>();

        Console.WriteLine("=== Emfuleni Municipality Service Management ===");

        int residentCount = ReadInt("Enter the number of residents: ", 1, int.MaxValue);
        for (int i = 0; i < residentCount; i++)
        {
            Console.WriteLine($"\nResident {i + 1} details:");
            string name = ReadText("Name: ");
            string address = ReadText("Address: ");
            string accountNumber = ReadText("Account Number: ");
            double monthlyUsage = ReadDouble("Monthly utility usage: ", 0, double.MaxValue);

            residents.Add(new Resident(name, address, accountNumber, monthlyUsage));
        }

        int requestCount = ReadInt("\nEnter number of service requests: ", 1, int.MaxValue);
        for (int i = 0; i < requestCount; i++)
        {
            Console.WriteLine($"\nService Request {i + 1}:");
            Console.WriteLine("Select resident by index:");
            for (int j = 0; j < residents.Count; j++)
            {
                Console.WriteLine($"{j}: {residents[j].Name} ({residents[j].AccountNumber})");
            }

            int residentIndex = ReadInt("Resident index: ", 0, residents.Count - 1);
            string requestType = ReadText("Request type: ");
            int priorityLevel = ReadInt("Priority level (1-5): ", 1, 5);
            int severityLevel = ReadInt("Severity level (1-10): ", 1, 10);
            int estimatedResolutionHours = ReadInt("Estimated resolution hours: ", 1, int.MaxValue);

            pendingRequests.Add(
                new ServiceRequest(
                    residents[residentIndex],
                    requestType,
                    priorityLevel,
                    severityLevel,
                    estimatedResolutionHours));
        }

        while (pendingRequests.Count > 0)
        {
            Console.WriteLine("\n--- Pending Service Requests ---");
            for (int i = 0; i < pendingRequests.Count; i++)
            {
                double urgency = manager.CalculateUrgencyScore(pendingRequests[i]);
                Console.WriteLine(
                    $"{i}: {pendingRequests[i].RequestType} | Resident: {pendingRequests[i].Resident.Name} | Urgency: {urgency:F2}");
            }

            int choice = ReadInt("Select request index to process: ", 0, pendingRequests.Count - 1);
            ServiceRequest selectedRequest = pendingRequests[choice];
            pendingRequests.RemoveAt(choice);
            resolvedRequests.Add(selectedRequest);

            manager.GenerateReport(selectedRequest);
        }

        manager.PrintSummary(resolvedRequests);
    }

    private static string ReadText(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(input))
            {
                return input.Trim();
            }

            Console.WriteLine("Input cannot be empty. Please try again.");
        }
    }

    private static int ReadInt(string prompt, int min, int max)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Enter a whole number between {min} and {max}.");
        }
    }

    private static double ReadDouble(string prompt, double min, double max)
    {
        while (true)
        {
            Console.Write(prompt);
            string? input = Console.ReadLine();
            if (double.TryParse(input, out double value) && value >= min && value <= max)
            {
                return value;
            }

            Console.WriteLine($"Enter a number between {min} and {max}.");
        }
    }
}