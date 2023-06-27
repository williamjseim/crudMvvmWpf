using DataAccessLibrary;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class TempDataGetter
    {
        private readonly ISqlDataAccess _db;

        public TempDataGetter(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task<List<shitModel>> GetData()
        {
            string sql = "select * from Shit";

            return _db.LoadData <shitModel, dynamic > (sql, new { });
        }

        public Task EditData(DialogViewModel model)
        {
            string sql = $"update Shit set username = '{model.Username}', password = '{model.Password}' where id = {model.id}";

            return _db.SaveData(sql, model);
        }

        public Task DeleteData(shitModel model)
        {
            string sql = $"delete from Shit where id = {model.id}";

            return _db.SaveData(sql, model);
        }

        public Task CreateNewUser(DialogViewModel model)
        {
            string sql = $"insert into Shit (userName, password) values('{model.Username}','{model.Password}')";

            return _db.SaveData(sql, model);
        }

        //public Task InsertData(/*sql data model*/ /* variable name */)
        //{
        //    string sql = @"insert into dbo.lots(rented,lotSize)
        //                   values(@Rented,@lotsize);";

        //    return _db.SaveData(sql, /* Insertdata variable */);
        //}
    }
}
