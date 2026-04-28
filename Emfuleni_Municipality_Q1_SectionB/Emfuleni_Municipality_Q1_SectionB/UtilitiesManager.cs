using System;
using System.Collections.Generic;

namespace EmfuleniMunicipality;

public class UtilitiesManager
{
    public double CalculateUrgencyScore(ServiceRequest request)
    {
        double priorityWeight = request.PriorityLevel * 2.0;
        double severityWeight = request.SeverityLevel * 3.0;
        double timeFactor = 24.0 / request.EstimatedResolutionHours;

        return priorityWeight + severityWeight + timeFactor;
    }

    public void GenerateReport(ServiceRequest request)
    {
        double urgency = CalculateUrgencyScore(request);

        Console.WriteLine("\n=== Processed Service Request Report ===");
        Console.WriteLine($"Resident Name: {request.Resident.Name}");
        Console.WriteLine($"Address: {request.Resident.Address}");
        Console.WriteLine($"Account Number: {request.Resident.AccountNumber}");
        Console.WriteLine($"Monthly Utility Usage: {request.Resident.MonthlyUtilityUsage:F2}");
        Console.WriteLine($"Request Type: {request.RequestType}");
        Console.WriteLine($"Priority Level: {request.PriorityLevel}");
        Console.WriteLine($"Severity Level: {request.SeverityLevel}");
        Console.WriteLine($"Estimated Resolution Hours: {request.EstimatedResolutionHours}");
        Console.WriteLine($"Urgency Score: {urgency:F2}");
    }

    public void PrintSummary(List<ServiceRequest> resolvedRequests)
    {
        Console.WriteLine("\n=== Final Summary ===");

        if (resolvedRequests.Count == 0)
        {
            Console.WriteLine("No requests were processed.");
            return;
        }

        ServiceRequest highestUrgencyRequest = resolvedRequests[0];
        double highestUrgencyScore = CalculateUrgencyScore(highestUrgencyRequest);

        Console.WriteLine("Resolved Requests:");
        for (int i = 0; i < resolvedRequests.Count; i++)
        {
            ServiceRequest request = resolvedRequests[i];
            double urgencyScore = CalculateUrgencyScore(request);
            Console.WriteLine(
                $"{i + 1}. {request.RequestType} | Resident: {request.Resident.Name} | Urgency: {urgencyScore:F2}");

            if (urgencyScore > highestUrgencyScore)
            {
                highestUrgencyScore = urgencyScore;
                highestUrgencyRequest = request;
            }
        }

        Console.WriteLine("\nHighest Urgency Request:");
        Console.WriteLine($"Type: {highestUrgencyRequest.RequestType}");
        Console.WriteLine($"Resident: {highestUrgencyRequest.Resident.Name}");
        Console.WriteLine($"Urgency Score: {highestUrgencyScore:F2}");
    }
}
