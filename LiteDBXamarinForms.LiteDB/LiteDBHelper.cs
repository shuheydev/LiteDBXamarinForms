using LiteDB;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiteDBXamarinForms.LiteDB
{
    public class LiteDBHelper
    {
        private static LiteDatabase _dbInstance;
        private LiteDBHelper()
        {

        }

        public static LiteDatabase GetInstance(string dbPath)
        {
            return _dbInstance = _dbInstance ?? new LiteDatabase(dbPath);
        }
    }
}
