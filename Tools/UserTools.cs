using NLog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProject.Tools {
    public class UserTools {
        private static readonly ILogger Log = LogManager.GetCurrentClassLogger();

        public void TestUserAccount() {
            
            Log.Trace(IsLocalUser(CurrentUser));
            


        }

        public string CurrentUser => System.Security.Principal.WindowsIdentity.GetCurrent().Name;


        bool IsLocalUser(string accountName) {
            var domainContext = new PrincipalContext(ContextType.Machine);
            return Principal.FindByIdentity(domainContext, accountName) != null;
        }

        bool IsDomainUser(string accountName) {
            var domainContext = new PrincipalContext(ContextType.Domain);
            return Principal.FindByIdentity(domainContext, accountName) != null;
        }

        public ArrayList GetUserGroups(string sUserName) {

            sUserName = CurrentUser;

            ArrayList myItems = new ArrayList();
            UserPrincipal oUserPrincipal = GetUser(sUserName);

            PrincipalSearchResult<Principal> oPrincipalSearchResult = oUserPrincipal.GetGroups();

            foreach (Principal oResult in oPrincipalSearchResult) {
                myItems.Add(oResult.Name);
            }
            return myItems;
        }

        public static UserPrincipal GetUser(string sUserName) {
            PrincipalContext oPrincipalContext = GetPrincipalContext();

            UserPrincipal oUserPrincipal = UserPrincipal.FindByIdentity(oPrincipalContext, sUserName);
            return oUserPrincipal;
        }
        public static PrincipalContext GetPrincipalContext() {
            PrincipalContext oPrincipalContext = new PrincipalContext(ContextType.Machine);
            return oPrincipalContext;
        }

    }
}
