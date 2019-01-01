using System.Configuration;

namespace Wpf.GridView.Core
{
    public static class CoreData
    {
        public static string EncryptionKey
        {
            get; set;
        }

        public static string RemoteEncryptionServer
        {
            get; set;
        }

        public enum RemoteEncryptionServerTypes
        {
            /// <summary>
            ///     Start :)
            /// </summary>
            rtBuildInLocalMustBeRemovedBeforeRelease,

            /// <summary>
            ///     Most primitive -- first attempt
            /// </summary>
            rtHttpGet,

            /// <summary>
            ///     
            /// </summary>
            rtHttpPost
        };

        public static RemoteEncryptionServerTypes RemoteEncryptionServerType
        {
            get; set;
        }

        /// <summary>
        ///     Load data from config
        /// </summary>
        public static void Init()
        {

            EncryptionKey = ConfigurationManager.AppSettings["SecurityKey"].ToString();
            RemoteEncryptionServer = ConfigurationManager.AppSettings["RemoteEncryptionServer"].ToString();
            RemoteEncryptionServerType = RemoteEncryptionServerTypes.rtBuildInLocalMustBeRemovedBeforeRelease;
        }

        /// <summary>
        ///     Localization user want
        /// </summary>
        public static string RequestedLocale;
    }
}
