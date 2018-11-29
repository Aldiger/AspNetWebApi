using Assecor.Services.Dto;

namespace EagleTM.UPE.Services
{
    internal static class AppSettings
    {
        #region Connection strings

        internal static string UpExchangeConnectionString { get; set; }
        internal static string UpExchangeEdmxConnectionString { get; set; }

        #endregion

        internal static void Init(AppSettingsDto settings)
        {
            #region Connection strings

            UpExchangeConnectionString = settings.UpExchangeConnectionString;
            UpExchangeEdmxConnectionString = settings.UpExchangeEdmxConnectionString;

            #endregion
           
        }
    }
}