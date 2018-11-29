using Assecor.Services.Dto;
using System.Collections.Generic;
using System.Configuration;

namespace Assecor.WebApi
{
    public static class AppSettings
    {

        #region General Application Settings

        public static string ApplicationName => ConfigurationManager.AppSettings["ApplicationName"];


        #endregion

        #region Connection strings

        public static string UpExchangeEdmxConnectionString => ConfigurationManager.ConnectionStrings["UPExchangeEntities"].ConnectionString;
        public static string UpExchangeConnectionString => ConfigurationManager.ConnectionStrings["UPExchange"].ConnectionString;

        #endregion


        public static AppSettingsDto ToServicesAppSettingsDto()
        {
            var dto = new AppSettingsDto();

            #region Connection strings

            dto.UpExchangeConnectionString = UpExchangeConnectionString;
            dto.UpExchangeEdmxConnectionString = UpExchangeEdmxConnectionString;

            #endregion
            

            return dto;
        }
    }
}