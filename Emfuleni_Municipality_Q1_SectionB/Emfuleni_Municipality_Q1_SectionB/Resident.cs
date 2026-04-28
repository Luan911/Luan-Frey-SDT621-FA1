namespace EmfuleniMunicipality;

public class Resident
{
    public Resident(string name, string address, string accountNumber, double monthlyUtilityUsage)
    {
        Name = name;
        Address = address;
        AccountNumber = accountNumber;
        MonthlyUtilityUsage = monthlyUtilityUsage;
    }

    public string Name { get; }

    public string Address { get; }

    public string AccountNumber { get; }

    public double MonthlyUtilityUsage { get; }
}
