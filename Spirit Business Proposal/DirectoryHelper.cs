using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Web;

namespace Spirit_Business_Proposal
{
    public static class DirectoryHelper
    {
        public static string GetFullUserName(string account)
        {
            try
            {
                var result = GetUserObject(account);
                if (result != null)
                {
                    return (string)result.Properties["givenname"][0];
                }
            }
            catch{}
            return account;
        }

        public static string GetUserEmail(string account)
        {
            try
            {
                var result = GetUserObject(account);
                if (result != null)
                {
                    return (string)result.Properties["mail"][0];
                }
            }
            catch { }
            return string.Empty;
        }

        private static SearchResult GetUserObject(string account)
        {
            var domains = EnumerateDomainControllers();
            var entry = new DirectoryEntry(string.Format("LDAP://{0}", domains[2]), @"SC_NET\Deepak.Begrajka", "Dawn007@");
            var srch = new DirectorySearcher(entry);
            srch.Filter = String.Format("(&(objectClass=person)(sAMAccountName={0}))",account.Substring(account.IndexOf("\\", StringComparison.Ordinal) + 1));
            var result = srch.FindOne();
            return result;
        }



        public static IEnumerable<string> GetTcEmails()
        {
            return new[] { "CoastalTCRegion@spiritcom.com", "MidlandsTCRegion@spiritcom.com", "UpstateTCRegion@spiritcom.com", "NCTCRegion@spiritcom.com", "WilmingtonTCRegion@spiritcom.com" };
            //var domains = EnumerateDomainControllers();
            //var entry = new DirectoryEntry(string.Format("LDAP://{0}", domains[2]), "sa_geomap", "3aTHUspu");
            //var srch = new DirectorySearcher(entry) {Filter = "(&(objectClass=group)(name=Technical Consultants))"};
            //var group = srch.FindOne();

            //if (group != null)
            //{
            //    foreach (string member in group.Properties["member"])
            //    {
            //        var user = new DirectoryEntry(string.Format("LDAP://{0}", member), "sa_geomap", "3aTHUspu");
            //        yield return (string)user.Properties["mail"][0];
            //    }
            //}
        } 

        public static ArrayList EnumerateDomainControllers()
        {
            ArrayList alDcs = new ArrayList();
            Domain domain = Domain.GetCurrentDomain();
            foreach (DomainController dc in domain.DomainControllers)
            {
                alDcs.Add(dc.Name);
            }
            return alDcs;
        }
    }
}