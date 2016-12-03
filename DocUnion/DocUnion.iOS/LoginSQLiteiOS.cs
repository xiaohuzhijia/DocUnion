using System;
using System.IO;
using DocUnion.Services.SQLite;

using SQLite;
using Xamarin.Forms;
using DocUnion.iOS;

[assembly: Dependency(typeof(LoginSQLiteiOS))]
namespace DocUnion.iOS
{
    public class LoginSQLiteiOS:ILogin
    {
        public LoginSQLiteiOS() { }


        public SQLiteConnection GetConnection()
        {
            var fileName = "Login.db";
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryPath = Path.Combine(documentsPath, "..", "Library");
            var path = Path.Combine(libraryPath, fileName);
            //var platform = new SQLite.Net.Platform.XamarinIOS.SQLitePlatformIOS();
            var connection = new SQLite.SQLiteConnection(path);

            return connection;

        }
    }
}