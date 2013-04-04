// <copyright company="Citrix Systems, Inc">
//   Copyright © Citrix Systems, Inc.  All rights reserved.
// </copyright>

namespace Citrix.CloudStack.SDK
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;
    using System.Linq;
    using System.Net;
    using System.Security;
    using System.Text;
    using System.Xml;
    using System.Xml.Linq;
    using System.Xml.Serialization;

    /// <summary>
    /// Common commands implemented in type safe methods.
    /// </summary>
    public sealed class Commands
    {
        private Commands()
        {
        }    

        /// <summary>
        /// deployVirtualMachine API call
        /// </summary>
        /// <param name="session">Client connection to CloudStack API</param>
        /// <param name="templateid">Cloud resource identifier for vm template</param>
        /// <param name="serviceofferingid">CPU / memory architecture for VM.</param>
        /// <param name="securityGroups">Optional list of security groups to apply to the VM, used in basic networking scenarios.</param>
        /// <param name="zoneid">Zone on which to place the VM</param>
        /// <param name="displayname">Optional display name to provide to the new instance.</param>
        /// <param name="network">Optional identifier for network to put VM on.</param>
        /// <param name="userdata">Optional data to pass to newly created VM</param>
        /// <param name="createStopped">Created VM should be initiallty stopped</param>
        /// <returns>Cloud resource identifier for the new VM.</returns>
        public static string DeployVirtualMachine(Client session, string templateid, string serviceofferingid, IList<string> securityGroups, string zoneid, string displayname, string network, string userdata, bool createStopped)
        {
            APIRequest req = new APIRequest("deployVirtualMachine");
            req.Parameters["serviceOfferingid"] = serviceofferingid;
            req.Parameters["templateid"] = templateid;
            req.Parameters["zoneid"] = zoneid;
            
            if (createStopped)
            {
                req.Parameters.Add("startvm", "false");
            }

            if (displayname != null)
            {
                req.Parameters.Add("displayname", displayname);
            }

            if (securityGroups != null && securityGroups.Count > 0)
            {
                StringBuilder securityGroupList = new StringBuilder();
                foreach (string grp in securityGroups)
                {
                    if (!string.IsNullOrEmpty(grp))
                    {
                        securityGroupList.Append(grp + ",");
                    }
                }
                if (securityGroupList.Length > 0)
                {
                    if (securityGroupList[securityGroupList.Length - 1] == ',')
                    {
                        securityGroupList.Remove(securityGroupList.Length - 1, 1);
                    }
                    req.Parameters.Add("securitygroupids", securityGroupList.ToString());
                }
            }

            if (network != null)
            {
                req.Parameters.Add("networkids", network);
            }

            if (userdata != null)
            {
                string base64String = EncodeUserData(userdata);
                req.Parameters.Add("userdata", base64String);
            }
            return AsyncSupport.WaitForNewResourceIdFromAsyncCmd(session, req);
        }

        private static string EncodeUserData(string userdata)
        {
            byte[] base64Bytes = System.Text.Encoding.UTF8.GetBytes(userdata);
            return Convert.ToBase64String(base64Bytes);
        }
    }
}
