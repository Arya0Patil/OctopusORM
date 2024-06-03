using Attributes;
namespace StudentTesting
{
	[Table(Name ="Student")]
    public class Student
    {
		private int _Id;
		private string _Name;
		private int _Marks;

		[Column(Name="Marks", Type ="int")]
		public int Marks
		{
			get { return _Marks; }
			set { _Marks = value; }
		}

        [Column(Name = "Name", Type = "varchar(20)")]
        public string Name
		{
			get { return _Name; }
			set { _Name = value; }
		}

        [Column(Name = "Id", Type = "int")]
        public int Id
		{
			get { return _Id; }
			set { _Id = value; }
		}


	}
}