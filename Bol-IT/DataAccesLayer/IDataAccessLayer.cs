using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using BusinessLayer.Classes;

namespace DataAccessLayer
{
    public interface IDataAccessLayer
    {
        void CreateEntry(DataType dataType);

        void EditEntry(int id, DataType dataType);

        DataType GetEntry(int id);
    }
}
