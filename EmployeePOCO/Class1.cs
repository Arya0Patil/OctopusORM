using Attributes;

namespace EmployeePOCO
{
    [Table("Employees")]
    public class Employee  
    {
        
        private int _Id;

        [Key]
        [Column("Id")]
        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        [Column("Salary")]
        public int Salary { get; set; }


        [Column("Name", Type = "varchar(20)")]
        public string Name { get; set; }

        [Column("Department", Type = "varchar(20)")]
        public string Department { get; set; }

        public Employee(int id, int salary, string name, string department)
        {
            Id = id;
            Salary = salary;
            Name = name;
            Department = department;
        }
    }
}