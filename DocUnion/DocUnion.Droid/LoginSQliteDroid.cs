using System;
using System.IO;
using DocUnion.Droid;
using Xamarin.Forms;

using SQLite;
using DocUnion.Services.SQLite;

[assembly:Dependency(typeof(LoginSQliteDroid))]
namespace DocUnion.Droid
{
    public class LoginSQliteDroid:ILogin
    {
        public LoginSQliteDroid() { }

        public SQLiteConnection GetConnection()
        {
            var filename = "Login.db";
            var documentspath = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentspath, filename);
            //var platform = new SQLite.Net.Platform.XamarinAndroid.SQLitePlatformAndroid();
            var connection = new SQLite.SQLiteConnection(path);
            return connection;
        }

    }
}