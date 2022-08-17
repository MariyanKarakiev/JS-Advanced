using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.Sql;
namespace Exercise_ADO.NET
{
    public static class Configuration
    {
        public const string CONNECTION_STRING = @"Server=localhost,1433;
                                      Database=MinionsDb; User Id=sa; Password=Docker21; TrustServerCertificate=True;";

        public const string VILLAINS_WITH_MORE_THAN_3_MINIONS = @" 
         SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount  
           FROM Villains AS v 
           JOIN MinionsVillains AS mv ON v.Id = mv.VillainId 
       GROUP BY v.Id, v.Name 
    HAVING COUNT(mv.VillainId) > 3 
    ORDER BY COUNT(mv.VillainId)
";

        public const string VillainWithId = @"SELECT Name FROM Villains WHERE Id = @Id";

        public const string Minions = @"SELECT ROW_NUMBER() OVER (ORDER BY m.[Name]) as RowNum,
                                         m.[Name], 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

        public const string GetTownIDbyName = @"SELECT Id FROM Towns WHERE Name = @townName";
        
        public const string GetVillainIDbyName = @"SELECT Id FROM Villains WHERE Name = @Name";

        public const string GetMinionIDbyName = @"SELECT Id FROM Minions WHERE Name = @name";

        public const string InsertTown = @"INSERT INTO Towns (Name) VALUES (@townName)";
       
        public const string InsertMinion = @"INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)";

        public const string InsertVillain = @"INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)";

        public const string InsertVillainMinion = @"INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)";
    }
}
