namespace petmanagment.Services;

public abstract class VeterinaryService
{
    public DateTime ServiceDate { get; set; }
    public decimal Cost { get; set; }

    public VeterinaryService()
    {
        ServiceDate = DateTime.Now;
    }
    public abstract void Attend();
}