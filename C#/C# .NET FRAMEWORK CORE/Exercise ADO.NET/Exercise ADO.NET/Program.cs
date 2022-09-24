using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

namespace Exercise_ADO.NET
{
    class Program
    {
        static async Task Main(string[] args)
        {
            SqlConnection sqlConnection = new SqlConnection(Configuration.CONNECTION_STRING);
            sqlConnection.Open();

            int minionId = await AddMinion(sqlConnection);

            int villainId = await AddVillain(sqlConnection);

            await AddVillianMinion(sqlConnection, minionId, villainId);

        }

        private static async Task VillainsWithMoreThan3Minions(SqlConnection sqlConnection)
        {
            SqlCommand sqlCommand = new SqlCommand(Configuration.VILLAINS_WITH_MORE_THAN_3_MINIONS, sqlConnection);

            SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync();

            await using (sqlDataReader)
            {
                while (await sqlDataReader.ReadAsync())
                {
                    string villainName = sqlDataReader.GetString(0);
                    int minions = sqlDataReader.GetInt32(1);

                    Console.WriteLine($"{villainName} - {minions}");
                }
            }

        }
        private static async Task VillainWithId(SqlConnection sqlConnection, int villainId)
        {
            var sqlCommandVillainName = new SqlCommand(Configuration.VillainWithId, sqlConnection);

            sqlCommandVillainName.Parameters.AddWithValue("@Id", villainId);

            var villainObject = await sqlCommandVillainName.ExecuteScalarAsync();

            if (villainObject == null)
            {
                Console.WriteLine($"No villain with ID {villainId} exists in the database.");
                return;
            }

            string villainName = (string)villainObject;
            Console.WriteLine($"Villain: {villainName}");

            var sqlCommandMinions = new SqlCommand(Configuration.Minions, sqlConnection);
            sqlCommandMinions.Parameters.AddWithValue("@Id", villainId);

            var minions = await sqlCommandMinions.ExecuteReaderAsync();

            await using (minions)
            {
                if (minions.FieldCount == 0)
                {

                    Console.WriteLine("(no minions)");
                }
                while (await minions.ReadAsync())
                {
                    var id = minions.GetInt64(0);
                    var name = minions.GetString(1);
                    var years = minions.GetInt32(2);

                    Console.WriteLine($"{id}. {name} {years}");
                }
            }
        }
        private static async Task<int> AddMinion(SqlConnection sqlConnection)
        {
            Console.WriteLine("Enter minion info:");
            string[] minion = Console.ReadLine().Split();

            string minionName = minion[1];
            int age = int.Parse(minion[2]);
            string town = minion[3];

            //adding town to db
            var addTown = new SqlCommand(Configuration.GetTownIDbyName, sqlConnection);
            addTown.Parameters.AddWithValue("@townName", town);

            var townIdObject = await addTown.ExecuteScalarAsync();

            if (townIdObject == null)
            {
                var insertTown = new SqlCommand(Configuration.InsertTown, sqlConnection);

                insertTown.Parameters.AddWithValue("@townName", town);

                int rowsAffected = await insertTown.ExecuteNonQueryAsync();

                if (rowsAffected == 0)
                {
                    Console.WriteLine("Problem occured while inserting new town into " +
                        "the database!");
                }
                else
                {
                    Console.WriteLine($"Town {town} was added to the database.");
                }
            }
            int townId = (int)townIdObject;


            //adding minion to db
            var minionGetId = new SqlCommand(Configuration.GetMinionIDbyName, sqlConnection);

            minionGetId.Parameters.AddWithValue("@name", minionName);

            var minionObjId = await minionGetId.ExecuteScalarAsync();

            if (true)
            {
                var addMinion = new SqlCommand(Configuration.InsertMinion, sqlConnection);

                addMinion.Parameters.AddWithValue("@name", minionName);
                addMinion.Parameters.AddWithValue("@age", age);
                addMinion.Parameters.AddWithValue("@townId", townId);

                int affectedRows = await addMinion.ExecuteNonQueryAsync();

                if (affectedRows == 0)
                {
                    Console.WriteLine("Problem occured while inserting new minion into " +
                     "the database!");
                }

                else
                {
                    Console.WriteLine($"Minion {minionName} was added to the database.");
                }
            }
            return (int)minionObjId;
        }
        private static async Task<int> AddVillain(SqlConnection sqlConnection)
        {
            Console.WriteLine("Enter villain info:");
            string[] villain = Console.ReadLine().Split();

            string villainName = villain[1];

            var villainGetId = new SqlCommand(Configuration.GetVillainIDbyName, sqlConnection);
            villainGetId.Parameters.AddWithValue("@Name", villainName);

            var villainObjId = await villainGetId.ExecuteScalarAsync();

            if (villainObjId == null)
            {
                var addVillain = new SqlCommand(Configuration.InsertVillain, sqlConnection);

                addVillain.Parameters.AddWithValue("@villainName", villainName);

                int affectedrows = await addVillain.ExecuteNonQueryAsync();

                if (affectedrows == 0)
                {
                    Console.WriteLine("Problem occured while inserting new villain into " +
                       "the database!");
                }

                else
                {
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }
            }
            return (int)villainObjId;
        }
        private static async Task AddVillianMinion(SqlConnection sqlConnection, int minionId
                                                   , int villainId)
        {
            //add primary key to VillianMnions table
            var pk = new SqlCommand(Configuration.InsertVillainMinion, sqlConnection);

            pk.Parameters.AddWithValue("@minionId", (int)minionId);
            pk.Parameters.AddWithValue("@villainId", (int)villainId);

            int affectedRows = await pk.ExecuteNonQueryAsync();

            if (affectedRows == 0)
            {
                throw new ArgumentException("Problem occured while inserting new PrimaryKey for VillainMinion table into " +
                    "the database!");
            }
            else
            {
                Console.WriteLine("Primary key created successfully!");
            }
        }
    }
}
