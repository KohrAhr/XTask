using System.Configuration;

namespace Wpf.GridView.Core
{
    public static class CoreData
    {
        public static string EncryptionKey
        {
            get; set;
        }

        public static string RemoteEncyptionServer
        {
            get; set;
        }

        public enum RemoteEncyptionServerTypes
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

        public static RemoteEncyptionServerTypes RemoteEncyptionServerType
        {
            get; set;
        }

        /// <summary>
        ///     Load data from config
        /// </summary>
        public static void Init()
        {
            RemoteEncyptionServer = ConfigurationManager.AppSettings["RemoteEncyptionServer"].ToString();
            RemoteEncyptionServerType = RemoteEncyptionServerTypes.rtBuildInLocalMustBeRemovedBeforeRelease;
        }

        /// <summary>
        ///     Localization user want
        /// </summary>
        public static string RequestedLocale;
    }
}
