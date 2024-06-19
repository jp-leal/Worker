namespace TopicosEspeciais;

class Worker
{
    public List<Contract> WorkerContract { get; set; }
    public Departament Departamento { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }

    public Level WorkerLevel { get; set; }

    public void AddContract(Contract contract)
    {
        WorkerContract.Add(contract);
    }

    public void RemoveContract(Contract contract)
    {
        WorkerContract.Remove(contract);
    }

    public double Income(int year, int month)
    {
        double sum = Salary;
        foreach (Contract contract in WorkerContract)
        {
            if (contract.Date.Year == year && contract.Date.Month == month)
            {
                sum += contract.TotalValue();
            }
        }

        return sum;
    }

    public Worker(Departament departament, string name, double salary, Level level)
    {
        WorkerContract = new List<Contract>();
        Departamento = departament;
        Name = name;
        Salary = salary;
        WorkerLevel = level;
    }
}