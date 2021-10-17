namespace BrokerTest
{
    using System;

    public class Order
    {
        public int ID { get; set; }

        public int PersonFK { get; set; }

        public DateTime Date { get; set; }

        public string Print(TableDependency.SqlClient.Base.Enums.ChangeType changeType) => $"Order {changeType}" + Environment.NewLine +
                                                                                           $"ID: {ID}" + Environment.NewLine +
                                                                                           $"PersonFK: {PersonFK}" + Environment.NewLine +
                                                                                           $"Date {Date.ToShortDateString()}";
    }
}