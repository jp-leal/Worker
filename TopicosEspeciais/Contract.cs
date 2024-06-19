namespace TopicosEspeciais;

class Contract
{
    public DateTime Date { get; set; }
    public double valuePerHour { get; set; }
    public int hours { get; set; }

    public Contract()
    {
    }

    public Contract(DateTime data, double valuePerHour, int hours)
    {
        this.Date = data;
        this.valuePerHour = valuePerHour;
        this.hours = hours;
    }

    public double TotalValue()
    {
        return valuePerHour * hours;
    }
}