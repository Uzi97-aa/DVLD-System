using System;
using System.Configuration;

namespace DVLD_DataAccess
{
    static class clsDataAccessSettings
    {
    //  public static string ConnectionString = "Server=.;Database=DVLD;User Id=sa;Password=sa123456;";

       public static string ConnectionString { get { return ConfigurationManager.ConnectionStrings["connectionstring"].ConnectionString; } }

    }
}
