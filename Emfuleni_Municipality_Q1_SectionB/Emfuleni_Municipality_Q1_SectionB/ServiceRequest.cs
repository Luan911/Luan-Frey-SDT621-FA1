namespace EmfuleniMunicipality;

public class ServiceRequest
{
    public ServiceRequest(
        Resident resident,
        string requestType,
        int priorityLevel,
        int severityLevel,
        int estimatedResolutionHours)
    {
        Resident = resident;
        RequestType = requestType;
        PriorityLevel = priorityLevel;
        SeverityLevel = severityLevel;
        EstimatedResolutionHours = estimatedResolutionHours;
    }

    public Resident Resident { get; }

    public string RequestType { get; }

    public int PriorityLevel { get; }

    public int SeverityLevel { get; }

    public int EstimatedResolutionHours { get; }
}
