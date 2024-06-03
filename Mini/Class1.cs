using System;
using System.Data.Common;
using System.Reflection;
using Attributes;

namespace Mini
{
    public class Octopus
    {
       

        Dal dal =new Dal();
       
        public  void ConnectSql(string connectionString)
        {
            
            dal.Connect(connectionString);
        }
        public  void SelectAll(Object obj) {
            string sqlQuery = "";
            Type type = obj.GetType();
            sqlQuery += "Select * from " + type.Name + ";";
            dal.FireQuery(sqlQuery);
        }
        
        public  void Create(Object obj)
        {
             string sqlQuery = "";
            //Assembly assembly = Assembly.Load(obj.GetType().FullName);
            Type types = obj.GetType();

            IEnumerable<Attribute> classAttr = types.GetCustomAttributes();
            foreach (Attribute attr in classAttr)
            {
                Console.WriteLine(attr.GetType().Name+" "+attr.TypeId+" ");
                if (attr is Table)
                {
                    Table tabletable = (Table)attr;
                    sqlQuery += "Create table " + tabletable.Name + "(";
                }


            }
            PropertyInfo[] pInfo = types.GetProperties();
            foreach (PropertyInfo pi in pInfo)
            {
                IEnumerable<Attribute> attrs = pi.GetCustomAttributes();
                foreach (Attribute attr in attrs)
                {
                    if (attr is Column)
                    {
                        Column column = (Column)attr;
                        sqlQuery += column.Name + " " + column.Type + " ,";

                    }
                
                }
            }
            sqlQuery =  sqlQuery.TrimEnd(',');
            sqlQuery +=  " );";
            Console.WriteLine(sqlQuery);
            dal.FireQuery(sqlQuery);
        }

        public  void Insert(Object obj) {
             string sqlQuery = "";
            Type types = obj.GetType();

            IEnumerable<Attribute> classAttr = types.GetCustomAttributes();
            foreach (Attribute attr in classAttr)
            {
                if (attr is Table)
                {
                    Table tabletable = (Table)attr;
                    sqlQuery += "Insert into " + tabletable.Name + " values (";
                }
            }

            PropertyInfo[] pInfo = types.GetProperties();
            foreach (PropertyInfo pi in pInfo)
            {
                if (pi.GetValue(obj) is String)   sqlQuery +="'"+ pi.GetValue(obj)+"'"+",";
                else sqlQuery += pi.GetValue(obj) + ",";



            }
            sqlQuery = sqlQuery.TrimEnd(',');
            sqlQuery += " );";
            Console.WriteLine(sqlQuery);
            dal.FireQuery(sqlQuery);
        }

        public  void Update( Object obj)
        {
            string sqlQuery = "";
            Type type = obj.GetType();
            IEnumerable<Attribute> attr = type.GetCustomAttributes();
            foreach (Attribute item in attr)
            {
                if (item is Table)
                {
                    Table table = (Table)item;
                    sqlQuery += " Update " + table.Name + " SET ";
                }
                
            }

            PropertyInfo[] properties = type.GetProperties();
            int sid=-1;
            int flag = 0;
            string att = "";
            foreach (PropertyInfo property in properties)
            {
                string xx = "";
                IEnumerable<Attribute> attr1 = property.GetCustomAttributes();
                foreach (Attribute attribute in attr1)
                {
                    if(attribute is Column)
                    {
                        Column col = (Column)attribute;
                        xx = "" + property.Name.ToString() + "=" + ((col.Type.Contains("varchar")) ? (" '" + property.GetValue(obj) + "' ") : (property.GetValue(obj))) + ",";
                    }
                    if (attribute is Key)
                    {
                        flag = 1;
                    }
                
                }
              
                if (flag == 0) {
                    sqlQuery +=  xx;
                }
                if (flag == 1) { sid = Convert.ToInt32(property.GetValue(obj)); flag = 0; att = property.Name; }
            }

            sqlQuery = sqlQuery.TrimEnd(',');
            sqlQuery += " where " + att + " = " + sid + ";";


            Console.WriteLine(sqlQuery);
            dal.FireQuery(sqlQuery);
        }



        public  void Delete(Object obj)
        {
           
                string sqlQuery = "";
                Type type = obj.GetType();
                IEnumerable<Attribute> attr = type.GetCustomAttributes();
                foreach (Attribute item in attr)
                {
                    if (item is Table)
                    {
                        Table table = (Table)item;
                        sqlQuery += " Delete from " + table.Name;
                    }

                }

                PropertyInfo[] properties = type.GetProperties();
                int sid = -1;
                int flag = 0;
                string att = "";
                foreach (PropertyInfo property in properties)
                {
                    string xx = "";
                    IEnumerable<Attribute> attr1 = property.GetCustomAttributes();
                    foreach (Attribute attribute in attr1)
                    {
                        if (attribute is Column)
                        {
                       }
                        if (attribute is Key)
                        {
                            flag = 1;
                        }
                       
                    }

                   
                    if (flag == 1) { sid = Convert.ToInt32(property.GetValue(obj)); flag = 0; att = property.Name; }
                }

                sqlQuery = sqlQuery.TrimEnd(',');
                sqlQuery += " where " + att + " = " + sid + ";";
                

                Console.WriteLine(sqlQuery);
            dal.FireQuery(sqlQuery);
        }

        }
        }

    
    
