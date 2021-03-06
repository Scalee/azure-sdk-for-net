// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using System;
using System.Linq;
using Microsoft.WindowsAzure.Management.Compute.Models;

namespace Microsoft.WindowsAzure.Management.Compute.Models
{
    /// <summary>
    /// Objects that are used to create a data disk for a virtual machine.
    /// </summary>
    public partial class DataVirtualHardDisk
    {
        private Microsoft.WindowsAzure.Management.Compute.Models.VirtualHardDiskHostCaching? _hostCaching;
        
        /// <summary>
        /// Optional. Specifies the platform caching behavior of the data disk
        /// blob for read/write efficiency. The default value is ReadOnly.
        /// </summary>
        public Microsoft.WindowsAzure.Management.Compute.Models.VirtualHardDiskHostCaching? HostCaching
        {
            get { return this._hostCaching; }
            set { this._hostCaching = value; }
        }
        
        private string _label;
        
        /// <summary>
        /// Optional. Specifies the friendly name of the VHD used to create the
        /// data disk for the virtual machine.
        /// </summary>
        public string Label
        {
            get { return this._label; }
            set { this._label = value; }
        }
        
        private int? _logicalDiskSizeInGB;
        
        /// <summary>
        /// Optional. Specifies the size, in GB, of an empty VHD to be attached
        /// to the virtual machine. The VHD can be created as part of an
        /// attached disk or created as a virtual machine call by specifying
        /// the value for this property. Azure creates the empty VHD based on
        /// the size preference and attaches the newly created VHD to the
        /// virtual machine.
        /// </summary>
        public int? LogicalDiskSizeInGB
        {
            get { return this._logicalDiskSizeInGB; }
            set { this._logicalDiskSizeInGB = value; }
        }
        
        private int? _logicalUnitNumber;
        
        /// <summary>
        /// Optional. Specifies the Logical Unit Number (LUN) for the data
        /// disk. The LUN specifies the slot in which the data drive appears
        /// when mounted for usage by the virtual machine. This element is
        /// only listed when more than one data disk is attached to a virtual
        /// machine.
        /// </summary>
        public int? LogicalUnitNumber
        {
            get { return this._logicalUnitNumber; }
            set { this._logicalUnitNumber = value; }
        }
        
        private Uri _mediaLink;
        
        /// <summary>
        /// Optional. Optional. If the disk that is being added is already
        /// registered in the subscription or the VHD for the disk already
        /// exists in blob storage, this element is ignored. If a VHD file
        /// does not exist in blob storage, this element defines the location
        /// of the new VHD that is created when the new disk is added.Example:
        /// http://example.blob.core.windows.net/disks/mydatadisk.vhd
        /// </summary>
        public Uri MediaLink
        {
            get { return this._mediaLink; }
            set { this._mediaLink = value; }
        }
        
        private string _name;
        
        /// <summary>
        /// Optional. Specifies the name of the VHD used to create the data
        /// disk for the virtual machine.
        /// </summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }
        
        private Uri _sourceMediaLink;
        
        /// <summary>
        /// Optional. Optional. If the disk that is being added is already
        /// registered in the subscription or the VHD for the disk does not
        /// exist in blob storage, this element is ignored. If the VHD file
        /// exists in blob storage, this element defines the path to the VHD
        /// and a disk is registered from it and attached to the virtual
        /// machine.
        /// </summary>
        public Uri SourceMediaLink
        {
            get { return this._sourceMediaLink; }
            set { this._sourceMediaLink = value; }
        }
        
        /// <summary>
        /// Initializes a new instance of the DataVirtualHardDisk class.
        /// </summary>
        public DataVirtualHardDisk()
        {
        }
    }
}
