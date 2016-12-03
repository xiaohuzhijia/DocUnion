using SQLite;

namespace DocUnion.Services.SQLite
{
    public interface ILogin
    {
        SQLiteConnection GetConnection();
    }
}