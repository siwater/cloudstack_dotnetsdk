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
    /// Create Volume Request
    /// </summary>
    public class CreateVolumeRequest : APIRequest
    {
        /// <summary>
        /// Initializes a new instance of the CreateVolumeRequest class. 
        /// </summary>
        public CreateVolumeRequest()
            : base("createVolume", true)
        {
        }

        /// <summary>
        /// Get or set the Disk Offering Id
        /// </summary>
        public string DiskOfferingId
        {
            get { return GetParameterValue("diskofferingid"); }
            set { SetParameterValue("diskofferingid", value); }
        }

        /// <summary>
        /// Get or set the Name of the volume
        /// </summary>
        public string Name
        {
            get { return GetParameterValue("name"); }
            set { SetParameterValue("name", value); }
        }

        /// <summary>
        /// Get or set the size of the volume
        /// </summary>
        public int Size
        {
            get { return GetIntParameterValue("size"); }
            set { SetParameterValue("size", value); }
        }

        /// <summary>
        /// Get or set the Zone Id
        /// </summary>
        public string ZoneId
        {
            get { return GetParameterValue("zoneid"); }
            set { SetParameterValue("zoneid", value); }
        }
    }
}
