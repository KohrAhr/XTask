using System;
using System.Security;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Lib.System
{
    public static class UserFunctions
    {
        public static string GetDomainName()
        {
            string result = "";

            try
            {
                Domain domain = Domain.GetComputerDomain();
                result = domain.Name;
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                result = "";
            }

            return result;
        }

        public static string GetPcName()
        {
            string result = "";

            try
            {
                result = Environment.MachineName;
            }
            catch (InvalidOperationException)
            {
                result = "";
            }

            return result;
        }

        public static string GetUsername()
        {
            return Environment.UserName;
        }

        public static string GetDomainOrPcName()
        {
            return InDomain() ? GetDomainName() : GetPcName();
        }

        public static string GetFQDN()
        {
            return 
                String.Format(
                    @"{0}\{1}",
                    GetDomainOrPcName(), 
                    GetUsername()
                );
        }

        /// <summary>
        ///     Validate username and password combination    
        ///     <para>Following Windows Services must be up</para>
        ///     <para>LanmanServer; TCP/IP NetBIOS Helper</para>
        /// </summary>
        /// <param name="userName">
        ///     Fully formatted UserName.
        ///     In AD: Domain + Username
        ///     In Workgroup: Username or Local computer name + Username
        /// </param>
        /// <param name="securePassword"></param>
        /// <returns></returns>
        public static bool ValidateUsernameAndPassword(string userName, SecureString securePassword)
        {
            bool result = false;

            ContextType contextType = ContextType.Machine;

            if (InDomain())
            {
                contextType = ContextType.Domain;
            }

            try
            {
                using (PrincipalContext principalContext = new PrincipalContext(contextType))
                {
                    result = principalContext.ValidateCredentials(
                        userName, 
                        new NetworkCredential(string.Empty, securePassword).Password
                    );
                }
            }
            catch (PrincipalOperationException)
            {
                // Account disabled? Considering as Login failed
                result = false;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }


        /// <summary>
        ///     Validate: computer connected to domain?   
        /// </summary>
        /// <returns>
        ///     True -- computer is in domain
        ///     <para>False -- computer not in domain</para>
        /// </returns>
        public static bool InDomain()
        {
            bool result = true;

            try
            {
                Domain domain = Domain.GetComputerDomain();
            }
            catch (ActiveDirectoryObjectNotFoundException)
            {
                result = false;
            }

            return result;
        }

    }
}
