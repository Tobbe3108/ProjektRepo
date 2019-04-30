using System;
using System.Collections.Generic;
using System.Text;
using BusinessLayer.Classes;
using System.Data.SqlClient;

namespace DataAccessLayer.Classes
{
    public class CaseDataAccessLayer : IDataAccessLayer
    {
        //Singleton instance af Form1
        static CaseDataAccessLayer _instance;
        public static CaseDataAccessLayer Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CaseDataAccessLayer();
                }
                return _instance;
            }
        }
        public void CreateEntry(DataType dataType)
        {
            using (SqlConnection connection = DataAccessLayerFacade.GetConnection())
            {
                using (SqlCommand command = new SqlCommand())
                {

                }
            }
        }

        public void EditEntry(int id, DataType dataType)
        {
            throw new NotImplementedException();
        }

        public DataType GetEntry(int id)
        {
            throw new NotImplementedException();
        }
    }
}
