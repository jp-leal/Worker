using System.Globalization;

Departament logistica = new Departament(Departament.idCounter, "Logistica");
double salario;
string  name, departament;
int contracts;


Console.WriteLine("Enter departament's name: ");
departament = Console.ReadLine();
Console.WriteLine("Enter worker name: ");
name = Console.ReadLine();
Console.WriteLine("Enter worker's level (Junior/MidLevel/Senior): ");
Level level = Enum.Parse<Level>(Console.ReadLine());
Console.WriteLine("Base Salary: ");
salario = Convert.ToDouble(Console.ReadLine(), CultureInfo.InvariantCulture);
Console.WriteLine("How many contracts?: ");
contracts = Convert.ToInt32(Console.ReadLine());
Worker worker = new Worker(new Departament(Departament.idCounter, departament), name, salario, level);

for (int i = 0; i < contracts; i++)
{
    Console.WriteLine($"Enter #{i} contract data: ");
    Console.WriteLine("Date (DD/MM/YYYY: ");
    DateTime d1;
    try
    {
        string data = Console.ReadLine();
        d1 = DateTime.Parse(data);
    }
    catch (FormatException e)
    {
        Console.WriteLine(e.Message);
        continue;
    }
    
        Console.WriteLine("Value Per Hour: ");
        double wage = Convert.ToDouble(Console.ReadLine());
        Console.WriteLine("Duration (hours): ");
        int duration = Convert.ToInt32(Console.ReadLine());
        Contract contract = new Contract(d1, wage, duration);
        worker.AddContract(contract);
    
}

Console.WriteLine("Enter month and year to calculate income(MM/YYYY): ");
string info = Console.ReadLine();
int month = int.Parse(info.Substring(0,2));
int year = int.Parse(info.Substring(3));


Console.WriteLine($"Worker: {worker.Name}");
Console.WriteLine($"Departament: {worker.Departamento.Dept}");
Console.WriteLine($"Income for {info}: {worker.Income(year, month)}");


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


class Departament
{
    public int Id { get; set; }
    public string Dept { get; set; }
    public static int idCounter = 0;

    public Departament(int Id, string Dept)
    {
        this.Id = Id;
        this.Id = idCounter++;
        
        this.Dept = Dept;
    }
}

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


enum Level : int
{
    Junior = 0,
    MidLevel = 1,
    Senior = 2,
}