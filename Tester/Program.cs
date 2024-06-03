using EmployeePOCO;
using Mini;


namespace Tester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Employee emp1 = new Employee(2,2000,"shu","tech");
            Employee emp2 = new Employee(1,2000,"arya","tech");
            Employee emp3 = new Employee(3,2000,"avdhut","hr");
            Employee emp4 = new Employee(3,2000,"avdhutSakhre","hr");
            
            Octopus octupus = new Octopus();
            octupus.ConnectSql("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=dickDb");
            //octupus.Create(emp3);
            //octupus.Insert(emp3);
            //octupus.Insert(emp2);
            //octupus.Insert(emp1);
            //octupus.Update(emp4);
            octupus.Delete(emp2);
            //octupus.SelectAll(emp);




        }
    }
}