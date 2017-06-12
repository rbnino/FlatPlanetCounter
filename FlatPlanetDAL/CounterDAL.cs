using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FlatPlanetDAL
{
    public class CounterDAL
    {
        public int CounterInsert(int prmCounter)
        {
            try
            {
                var connectionStringSettings = ConfigurationManager.ConnectionStrings["CounterDBConnection"];

                using (var connection = new SqlConnection(connectionStringSettings.ToString()))
                {
                    using (var command = new SqlCommand("usp_CounterInsert", connection))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@paramCounterValue ", prmCounter);
                        connection.Open();

                        return command.ExecuteNonQuery();
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
