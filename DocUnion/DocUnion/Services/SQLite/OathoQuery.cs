using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using Xamarin.Forms;
using DocUnion.Models;

namespace DocUnion.Services.SQLite
{
    public class OathoQuery
    {
        static object locker = new object();
        SQLiteConnection database;

        public OathoQuery()
        {
            database = DependencyService.Get<ILogin>().GetConnection();
            database.CreateTable<OauthInfo>();

        }

        public IEnumerable<OauthInfo> GetOathinfos()
        {
            lock (locker)
            {
                return (from s in database.Table<OauthInfo>() select s).ToList();
            }
        }

        public OauthInfo GetOathinfo(string Tel)
        {
            lock (locker)
            {
                return database.Table<OauthInfo>().FirstOrDefault(x => x.Telephone == Tel);
            }
        }

        public int SetOathNotDefault(OauthInfo OauthInfo)
        {
            lock (locker)
            {
                OauthInfo.IsDefault = false;

                try
                {
                    database.Update(OauthInfo);
                    return 1;
                }
                catch( Exception ex)
                {
                    return 0;
                }
            }
        }


        public IEnumerable<OauthInfo> GetOathinfoNotTel(string Tel)
        {
            lock (locker)
            {
                return database.Query<OauthInfo>("select * from OauthInfo where Telephone <> ? ", Tel);
            }
        }

        public string GetDefaltTel()
        {
            lock (locker)
            {
                var ss= (database.Table<OauthInfo>().FirstOrDefault(x => x.IsDefault ==true)).Telephone;
                //var ss= database.Query<OauthInfo>("select Telephone from OauthInfo where Telephone =  true");
                return ss;
              
            }
        }
        public bool IsExistTel(string Tel)
        {
            lock (locker)
            {

                var num = (from s in database.Table<OauthInfo>()
                           where s.Telephone.Equals(Tel)
                           select s).Count();
                if (num == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }

            }
        }


        public bool IsExitItems()
        {
            lock (locker)
            {

                var num = (from s in database.Table<OauthInfo>()
                           select s).Count();

                if (num == 0)
                {
                    return false;
                }
                else {
                    return true;
                }


            }


        }


        //public int DeletOathinfo(string Tel)
        //{
        //    lock (locker)
        //    {
                
        //    }
        //}



        
            


        public int SaveOath0Info(OauthInfo OauthInfo)
        {
            //新插入返回1；
            //更新返回0；
            lock (locker)
            {
                int  m= 0;
                //database.Insert(OauthInfo);
                var info = from s in database.Table<OauthInfo>()
                           where s.Telephone.StartsWith(OauthInfo.Telephone)
                           select s;


                foreach (var s in info)
                {
                    m = s.UserId;
                }
                OauthInfo.UserId = m;
                
                if (info.Count() == 0)
                {
                    database.Insert(OauthInfo);
                    return 1;
                }
                else
                {
                    
                    database.Update(OauthInfo);
                    return 0;


                }

            }
        }







    }
}
