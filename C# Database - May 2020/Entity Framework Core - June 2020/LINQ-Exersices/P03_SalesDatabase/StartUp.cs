using System;
using P03_SalesDatabase.Data;

namespace P03_SalesDatabase
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var db = new SalesContext();

            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
        }
    }
}
