using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WikiDataProvider.Data.Extensions;
using WikiDataProvider.Data.Interfaces;
using System.Linq;
using System.Web;
using TRUX.Models;


namespace TRUX.Services
{   
    //LATER have instantiate from Base Service class, create Base Service
    public class TruxService
    {
        //SELECT ALL
        public List<Truck> SelectAll()
        {
            List<Truck> trucks = new List<Truck>();
            DataProvider.ExecuteCmd(
                GetConnection,
                "dbo.Trux_SelectAll",
                inputParamMapper: null,
                map: delegate (IDataReader reader, short set)
                {
                    Truck t = MapTruck(reader);
                    trucks.Add(t);
                });
            return trucks;
        }

        //INSERT
        public int Insert(Truck t)
        {
            int i = 0;
            DataProvider.ExecuteNonQuery(
                GetConnection,
                "dbo.Trux_Insert",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Rfid", t.Rfid);
                    paramCollection.AddWithValue("@Location", t.Location);
                    paramCollection.AddWithValue("@Destination", t.Destination);
                    paramCollection.AddWithValue("@StartTime", t.StartTime);
                    paramCollection.AddWithValue("@EndTime", t.EndTime);

                    SqlParameter parm = new SqlParameter("@Id", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    paramCollection.Add(parm);
                },
                returnParameters: delegate (SqlParameterCollection paramCollection)
                {
                    int.TryParse(paramCollection["@Id"].Value.ToString(), out i);
                });
            return i;
        }

        //UPDATE
        public void Update(Truck t)
        {
            DataProvider.ExecuteNonQuery(
                GetConnection,
                "dbo.Trux_Update",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", t.Id);
                    paramCollection.AddWithValue("@Rfid", t.Rfid);
                    paramCollection.AddWithValue("@Location", t.Location);
                    paramCollection.AddWithValue("@Destination", t.Destination);
                    paramCollection.AddWithValue("@StartTime", t.StartTime);
                    paramCollection.AddWithValue("@EndTime", t.EndTime);
                },
                returnParameters: null);
        }

        //SELECT BY ID
        public Truck SelectById(int id)
        {
            Truck newTruck = null;

            Action<SqlParameterCollection> inputMapper = delegate (SqlParameterCollection parameters)
            {
                parameters.AddWithValue("@id", id);
            };
            Action<IDataReader, short> resultMapper = delegate (IDataReader reader, short set)
            {
                newTruck = MapTruck(reader);
            };
            DataProvider.ExecuteCmd(GetConnection, "dbo.Trux_SelectById", inputMapper, resultMapper);
            return newTruck;
        }

        //DELETE 
        public void Delete(int id)
        {
            DataProvider.ExecuteNonQuery(
                GetConnection,
                "dbo.Trux_Delete",
                inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                },
                returnParameters: null);
        }

        //Create a private variable to be only used by the TruxService class
        private Truck MapTruck(IDataReader reader)
        {
            Truck t = new Truck();
            int startingIndex = 0;
            t.Id = reader.GetSafeInt32(startingIndex++);
            t.Rfid = reader.GetSafeString(startingIndex++);
            t.Location = reader.GetSafeString(startingIndex++);
            t.Destination = reader.GetSafeString(startingIndex++);
            t.StartTime = reader.GetSafeUtcDateTime(startingIndex++);
            t.EndTime = reader.GetSafeUtcDateTime(startingIndex++);

            return t;
        }

        //Alternatively, create a BaseService class 
        // add this method to the base class
        protected static IDao DataProvider
        {
            get { return WikiDataProvider.Data.DataProvider.Instance; }
        }

        // Alternatively, create a BaseService class 
        // add this method to the base class
        protected static SqlConnection GetConnection()
        {
            return new System.Data.SqlClient.SqlConnection(
                System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
        }
    }
}