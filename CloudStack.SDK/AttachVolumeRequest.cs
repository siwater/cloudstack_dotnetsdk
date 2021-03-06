﻿// Licensed to the Apache Software Foundation (ASF) under one
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
    using System.Linq;
 
    /// <summary>
    /// Attach Volume Request
    /// </summary>
    public class AttachVolumeRequest : APIRequest
    {
        /// <summary>
        /// Initializes a new instance of the AttachVolumeRequest class. 
        /// </summary>
        public AttachVolumeRequest()
            : base("attachVolume")
        {
        }

        /// <summary>
        /// Get or set the volume Id
        /// </summary>
        public string Id
        {
            get { return GetParameterValue("id"); }
            set { SetParameterValue("id", value); }
        }

        /// <summary>
        /// Get or set the Name of the virtual machine
        /// </summary>
        public string VirtualMachineId
        {
            get { return GetParameterValue("virtualmachineid"); }
            set { SetParameterValue("virtualmachineid", value); }
        }

        /// <summary>
        /// Get or set the device id
        /// </summary>
        public string DeviceId
        {
            get { return GetParameterValue("deviceid"); }
            set { SetParameterValue("deviceid", value); }
        }
    }
}
