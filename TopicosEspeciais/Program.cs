using System.Globalization;
using TopicosEspeciais;

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
    Console.WriteLine($"Enter #{i + 1} contract data: ");
    Console.WriteLine("Date (DD/MM/YYYY: ");
    DateTime d1;
    while (true)
    {
        try
        {
            string data = Console.ReadLine();
            d1 = DateTime.Parse(data);
            break;
        }
        catch (FormatException e)
        {
            Console.WriteLine(e.Message);

        }
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


