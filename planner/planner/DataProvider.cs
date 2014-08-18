using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace planner
{
    public class DataProvider
    {
        private static DataProvider dataProvider;

        private SqlConnection connection;

        private DataProvider()
        {
            this.connection = new SqlConnection(ConfigurationManager.AppSettings["ConnectionString"]);
        }

        public static DataProvider Instance
        {
            get
            {
                if (dataProvider == null)
                {
                    dataProvider = new DataProvider();
                }

                return dataProvider;
            }
        }

        public void AddEntity(string name, double ratings, int reviews, int subCategory, Entity place)
        {
            this.connection.Open();
            SqlTransaction transaction = this.connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = this.connection;
                command.Transaction = transaction;
                command.CommandText = @"INSERT INTO [dbo].[Entity]
            ([Name]
            ,[TotalReviews]
            ,[Rating]
            ,[Address]
            ,[Latitude]
            ,[Longitude]
            ,[Zip]
            ,[PriceLevel]
            ,[PlaceId]
            )
        VALUES
            ((@Name)
            ,(@TotalReviews)
            ,(@Rating)
            ,(@Address)
            ,(@Latitude)
            ,(@Longitude)
            ,(@Zip)
            ,(@PriceLevel)
            ,(@PlaceId)
            )";
                command.Parameters.Add("@Name", System.Data.SqlDbType.NVarChar).Value = name.Replace("'", "''");
                command.Parameters.Add("@TotalReviews", System.Data.SqlDbType.Int).Value = reviews;
                command.Parameters.Add("@Rating", System.Data.SqlDbType.Float).Value = ratings;
                command.Parameters.Add("@Address", System.Data.SqlDbType.NVarChar).Value = place.address;
                command.Parameters.Add("@Latitude", System.Data.SqlDbType.NVarChar).Value = place.lat;
                command.Parameters.Add("@Longitude", System.Data.SqlDbType.NVarChar).Value = place.lng;
                command.Parameters.Add("@Zip", System.Data.SqlDbType.VarChar).Value = place.postal_code;
                command.Parameters.Add("@PriceLevel", System.Data.SqlDbType.SmallInt).Value = place.price_level;
                command.Parameters.Add("@PlaceId", System.Data.SqlDbType.NVarChar).Value = place.place_id;

                int result = command.ExecuteNonQuery();

                SqlCommand command1 = new SqlCommand();
                command1.Connection = this.connection;
                command1.Transaction = transaction;
                command1.CommandText = "select max(EntityId) from Entity";
                int entityId = (int)command1.ExecuteScalar();

                SqlCommand command2 = new SqlCommand();
                command2.Connection = this.connection;
                command2.Transaction = transaction;

                command2.CommandText = string.Format(@"INSERT INTO [dbo].[EntitySubCategory]
           ([EntityId]
           ,[SubCategoryId]
           )
        VALUES
           ({0}
           ,{1}
           )", entityId, subCategory);
                int result2 = command2.ExecuteNonQuery();

                foreach (EntityTiming et in place.EntityTimings)
                {
                    SqlCommand command3 = new SqlCommand();
                    command3.Connection = this.connection;
                    command3.Transaction = transaction;
                    command3.CommandText = @"INSERT INTO [dbo].[EntityTimings]
            ([EntityId]
            ,[DayOfWeek]
            ,[OpenTime]
            ,[CloseTime]
           )
        VALUES
            ((@EntityId)
            ,(@DayOfWeek)
            ,(@OpenTime)
            ,(@CloseTime)
            )";
                    command3.Parameters.Add("@EntityId", System.Data.SqlDbType.Int).Value = entityId;
                    command3.Parameters.Add("@DayOfWeek", System.Data.SqlDbType.SmallInt).Value = et.DayOfWeek;
                    command3.Parameters.Add("@OpenTime", System.Data.SqlDbType.Time).Value = et.OpenTime;
                    command3.Parameters.Add("@CloseTime", System.Data.SqlDbType.Time).Value = et.CloseTime;

                    int result3 = command3.ExecuteNonQuery();
                }
            }
            catch (SqlException)
            {
                transaction.Rollback();
                this.connection.Close();
                return;
            }

            transaction.Commit();
            this.connection.Close();
        }
    }
}