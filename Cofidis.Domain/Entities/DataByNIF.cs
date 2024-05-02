namespace Cofidis.Domain.Entities;

public class DataByNIF
{
    public string NIF { get; set; }

    public decimal Salary { get; set; }

    public bool IsCreditworthy { get; set; }

    public DataByNIF(string nif)
    {
        NIF = nif ?? throw new ArgumentNullException(nameof(nif), "NIF cannot be null");
    }
}