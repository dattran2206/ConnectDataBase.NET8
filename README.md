# ConnectDataBase.NET8
Kết nối và Excute StoreProcedure ở SQL 

#HDSD: 

      Truyền ConnectionString:
      DataAccess.Globals.ConnectionString = <<ConecttionString>>;

      Thường ở WebAPI .Net 8 ConnectionString được lấy từ File appsettings.json
  
      Ví dụ: 
      (Recommand) Hàm được sử dụng để lấy ConnectionString

      public static class ConfigurationHelper
      {
          private static IConfigurationRoot configuration;
      
          static ConfigurationHelper()
          {
              // Xây dựng cấu hình
              configuration = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                  .AddJsonFile("appsettings.json")
                  .Build();
          }
      
          public static string GetConnectionString(string name)
          {
              return configuration.GetConnectionString(name);
          }
      }

      Thực thi:
              DataAccess.Globals.ConnectionString = ConfigurationHelper.GetConnectionString("DefaultConnection");
