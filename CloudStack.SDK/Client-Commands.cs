// Licensed to the Apache Software Foundation (ASF) under one
// or more contributor license agreements.  See the NOTICE file
// distributed with this work for additional information
// regarding copyright ownership.  The ASF licenses this file
// to you under the Apache License, Version 2.0 (the
// "License"); you may not use this file except in compliance
// with the License.  You may obtain a copy of the License at
//
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing,
// software distributed under the License is distributed on an
// "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, either express or implied.  See the License for the
// specific language governing permissions and limitations
// under the License.

namespace CloudStack.SDK
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.Linq;
    using System.Xml.Linq;

    /// <summary>
    /// Partial implementation (extension) of Client class to provide typed API
    /// </summary>
    public partial class Client
    {
        #region Disk Offering
        /// <summary>
        /// List the disk offerings
        /// </summary>
        public ListDiskOfferingsResponse ListDiskOfferings(ListDiskOfferingsRequest request)
        {
            return DeserialiseResponse<ListDiskOfferingsResponse>(() => SendRequest(request), request.Command);
        }

        #endregion

        #region Network

        /// <summary>
        /// List the network offerings
        /// </summary>
        public ListNetworkOfferingsResponse ListNetworkOfferings(ListNetworkOfferingsRequest request)
        {
            return DeserialiseResponse<ListNetworkOfferingsResponse>(() => SendRequest(request), request.Command);
        }

        /// <summary>
        /// List the networks
        /// </summary>
        public ListNetworksResponse ListNetworks(ListNetworksRequest request)
        {
            return DeserialiseResponse<ListNetworksResponse>(() => SendRequest(request), request.Command);
        }
        #endregion

        #region Security Groups

        /// <summary>
        /// Create a cloud stack security group
        /// </summary>
        /// <param name="request">The request object</param>
        /// <returns>The response object</returns>
        public CreateSecurityGroupResponse CreateSecurityGroup(CreateSecurityGroupRequest request)
        {
            return DeserialiseResponse<CreateSecurityGroupResponse>(() => SendRequest(request), request.Command);
        }

        /// <summary>
        /// Authorize ingress to a security group 
        /// </summary>
        /// <param name="request">The request object</param>
        public SecurityGroupResponse AuthorizeSecurityGroupIngress(AuthorizeSecurityGroupIngressRequest request)
        {
            XContainer response = AsyncSupport.RunAsyncJob(this, request);
            return DeserialiseResponse<SecurityGroupResponse>(response, request.Command);
        }

        /// <summary>
        /// List the security groups
        /// </summary>
        public ListSecurityGroupsResponse ListSecurityGroups(ListSecurityGroupsRequest request)
        {
            return DeserialiseResponse<ListSecurityGroupsResponse>(() => SendRequest(request), request.Command);
        }

        #endregion

        #region Service Offering
        /// <summary>
        /// List the service offerings
        /// </summary>
        public ListServiceOfferingsResponse ListServiceOfferings(ListServiceOfferingsRequest request)
        {
            return DeserialiseResponse<ListServiceOfferingsResponse>(() => SendRequest(request), request.Command);
        }
        #endregion

        #region Templates
        /// <summary>
        /// List the templates
        /// </summary>
        public ListTemplatesResponse ListTemplates(ListTemplatesRequest request)
        {
            return DeserialiseResponse<ListTemplatesResponse>(() => SendRequest(request), request.Command);
        }
        #endregion

        #region Virtual Machines

        /// <summary>
        /// Deploy a virtual machines
        /// </summary>
        /// <returns>id of the new virtual machine</returns>
        public string DeployVirtualMachine(DeployVirtualMachineRequest request)
        {
           return AsyncSupport.WaitForResourceIdFromAsyncJob(this, request);
        }

        /// <summary>
        /// Destroy Virtual Machine
        /// </summary>
        /// <param name="vmId">Virtual machine identifier.</param>
        public void DestroyVirtualMachine(string vmId)
        {
            APIRequest request = new APIRequest("destroyVirtualMachine");
            request.Parameters["id"] = vmId;
            SendRequest(request);
        }

        /// <summary>
        /// startVirtualMachine API call
        /// </summary>
        /// <param name="vmId">Cloud resource identifier for VM</param>
        public void StartVirtualMachine(string vmId)
        {
            APIRequest req = new APIRequest("startVirtualMachine");
            req.Parameters["id"] = vmId;
            SendRequest(req);
        }

        /// <summary>
        /// Stop Virtual Machine 
        /// </summary>
        /// <param name="vmId">Cloud resource identifier for VM</param>
        /// <param name="forced">Indicate whether the VM should be forced to stop</param>
        public void StopVirtualMachine(string vmId, bool forced)
        {
            APIRequest request = new APIRequest("stopVirtualMachine");
            request.Parameters["id"] = vmId;
            request.Parameters["forced"] = forced ? "true" : "false";
            SendRequest(request);     
        }

        /// <summary>
        /// Reboot Virtual Machine 
        /// </summary>
        /// <param name="vmId">Cloud resource identifier for VM</param>
        public void RebootVirtualMachine(string vmId)
        {
            APIRequest request = new APIRequest("rebootVirtualMachine");
            request.Parameters["id"] = vmId;
            SendRequest(request);
        }

        /// <summary>
        /// List the virtual machines
        /// </summary>
        public ListVirtualMachinesResponse ListVirtualMachines(ListVirtualMachinesRequest request)
        {
            return DeserialiseResponse<ListVirtualMachinesResponse>(() => SendRequest(request), request.Command);
        }

        #endregion

        #region Volumes

        /// <summary>
        /// Create a volume
        /// </summary>
        /// <returns>id of the new virtual machine</returns>
        public string CreateVolume(CreateVolumeRequest request)
        {
            return AsyncSupport.WaitForResourceIdFromAsyncJob(this, request);
        }

        /// <summary>
        /// Attach a volume to a Virtual Machine
        /// </summary>
        public void AttachVolume(AttachVolumeRequest request)
        {
            AsyncSupport.WaitForResourceIdFromAsyncJob(this, request);
        }

        /// <summary>
        /// Detach Volume 
        /// </summary>
        public void DetachVolume(DetachVolumeRequest request)
        {
            AsyncSupport.WaitForResourceIdFromAsyncJob(this, request);
        }

        /// <summary>
        /// Delete Volume
        /// </summary>
        /// <param name="volumeId">Cloud resource identifier</param>
        public void DeleteVolume(string volumeId)
        {
            APIRequest request = new APIRequest("deleteVolume");
            request.Parameters["id"] = volumeId;
            SendRequest(request);
        }
      
        /// <summary>
        /// List the volumes
        /// </summary>
        public ListVolumesResponse ListVolumes(APIRequest request)
        {
            return DeserialiseResponse<ListVolumesResponse>(() => SendRequest(request), request.Command);
        }
        #endregion

        #region Zones
        /// <summary>
        /// List the zones
        /// </summary>
        public ListZonesResponse ListZones(ListZonesRequest request)
        {
            return DeserialiseResponse<ListZonesResponse>(() => SendRequest(request), request.Command);
        }
        #endregion
    }
}