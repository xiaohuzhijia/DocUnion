using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;

namespace DocUnion.Services.SQLite
{
    public class LoginQuery
    {
         SQLiteConnection _sqLiteConnection;

        public static object Locker { get; set; } = new object();

        public LoginQuery()
        {
            _sqLiteConnection = DependencyService.Get<ILogin>().GetConnection();
            _sqLiteConnection.Execute("CREATE TABLE IF NOT EXISTS UserDB(Id                     integer primary key autoincrement," +
                                                                      "Username                 varchar(20)," +
                                                                      "Password                 varchar(20)," +
                                                                      "Email                    varchar(20)," +
                                                                       "Sex                     CHAR(10) CHECK (Sex IN ('Mail','Femail'))," +
                                                                      "Tel_number               integer," +
                                                                      "Hospital                 varchar(30)," +
                                                                      "Department               varchar(30)," +
                                                                      "Title                    varchar(20)," +
                                                                      "years_of_medical_work    integer," +
                                                                      "areas_of_expertise       varchar(100)," +
                                                                      "fields_of_interest       varchar(100)," +
                                                                      "HeadImage                varchar(100)," +
                                                                      "MaxCard                  varchar(100))");

        }

        public int InsertDetails(UserDb userDb)
        {
            lock (Locker)
            {
                return _sqLiteConnection.Insert(userDb);
            }
           
        }


        public int UpdateDetails(UserDb userDb)
        {
            lock (Locker)
            {
                return _sqLiteConnection.Update(userDb);
            }
        }


        //Delete Note
        public int DeleteUser(int id)
        {
            lock (Locker)
            {
                return _sqLiteConnection.Delete<UserDb>(id);
            }
        }
        //Get all Notes
        public IEnumerable<UserDb> GetAllUser()
        {
            lock (Locker)
            {
                return (from i in _sqLiteConnection.Table<UserDb>() select i).ToList();
                
            }
        }

        //Get specific Note by ID
        public UserDb GetUserId(int id)
        {
            lock (Locker)
            {
                return _sqLiteConnection.Table<UserDb>().FirstOrDefault(t => t.Id == id);
            }
        }
        //Get specific Note by Username

        public string GetPasswordByUser(string username)
        {
            lock (Locker)
            {
                var apple = from s in _sqLiteConnection.Table<UserDb>()
                    where s.Username.StartsWith(username)
                    select s;
                return apple.FirstOrDefault().Password;
            }
        }

        //Dispose
        public void Dispose()
        {
            lock (Locker)
            {
                _sqLiteConnection.Dispose();
            }
        }
    }
}