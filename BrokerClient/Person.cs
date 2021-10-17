namespace BrokerTest
{
    using System;

    public class Person
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Print(TableDependency.SqlClient.Base.Enums.ChangeType changeType) => $"Person {changeType}" + Environment.NewLine +
                                                                                           $"ID: {ID}" + Environment.NewLine +
                                                                                           $"Name: {Name}" + Environment.NewLine +
                                                                                           $"Surname {Surname}";
    }
}