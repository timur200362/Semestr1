using INF2course.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace INF2course.DAO
{
    internal class DAOAccount: IDAO<AccountInfo>
    {
        const string connectionString = @"Data Source = (localdb)\MSSQLLocalDB;Initial Catalog = RestaurantDB; Integrated Security = True";
        MyORM MyORM = new MyORM(connectionString);
        public void Insert(AccountInfo model)
        {
            MyORM.Insert<AccountInfo>(model);
        }
        public void Delete(AccountInfo model)
        {
            MyORM.Delete<AccountInfo>(model);
        }
        public List<AccountInfo> GetAll()
        {
            return MyORM.Select<AccountInfo>().ToList();
        }
        public AccountInfo GetById(int id)
        {
            return MyORM.AddParameter("@id", id).ExecuteQuery<AccountInfo>($"SELECT * FROM [dbo].[Accounts] WHERE Id = @id").FirstOrDefault();
        }
        
        public AccountInfo GetByColumnValue(string column, object value)
        {
            return MyORM.AddParameter("@columnValue", value).ExecuteQuery<AccountInfo>($"SELECT * FROM [dbo].[Accounts] WHERE {column} = @columnValue").FirstOrDefault();
        }

        internal void SaveAge(int accountId, int age)
        {
            MyORM.AddParameter("@accountId", accountId).AddParameter("@age", age).ExecuteNonQuery
                ($"UPDATE  [dbo].[Accounts] SET Age = @age WHERE Id = @accountId");

        }
        internal void SaveAdress(int accountId, string city)
        {
            MyORM.AddParameter("@accountId", accountId).AddParameter("@city", city).ExecuteNonQuery
                ($"UPDATE  [dbo].[Accounts] SET City = @city WHERE Id = @accountId");

        }
        internal void SaveName(int accountId, string name)
        {
            MyORM.AddParameter("@accountId", accountId).AddParameter("@name", name).ExecuteNonQuery
                ($"UPDATE  [dbo].[Accounts] SET Name = @name WHERE Id = @accountId");

        }
        internal void SaveNumPhone(int accountId, string numphone)
        {
            MyORM.AddParameter("@accountId", accountId).AddParameter("@numphone", numphone).ExecuteNonQuery
                ($"UPDATE  [dbo].[Accounts] SET NumPhone = @numphone WHERE Id = @accountId");

        }
    }
}
