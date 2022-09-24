using System;
using System.Collections.Generic;
using System.Text;

namespace P03_FootballBetting.Data
{
    class Connection
    {
        public const string ConnectionString = @"Server=localhost,1433;
                                                Database=FootballBetting;
                                                User Id=sa;Password=Docker21;
                                                TrustServerCertificate=true";
    }
}
