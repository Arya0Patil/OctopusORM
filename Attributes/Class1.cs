namespace Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class Key : Attribute
    {
        
    }
    [AttributeUsage(AttributeTargets.Class)]
    public class Table : Attribute
    {
        private string _Name;

        public Table(string name)
        {
            _Name = name;
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


    }

    [AttributeUsage(AttributeTargets.Property)]
    public class Column : Attribute
    {
        private string _Name;
        private string _Type;

        public Column(string name, string type="int")
        {
            Name = name;
            Type = type;

        }

        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }


        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }


    }
}