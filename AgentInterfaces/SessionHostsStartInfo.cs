﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.Azure.Gaming.AgentInterfaces
{
    using System;
    using System.Collections.Generic;
    using Docker.DotNet.Models;

    public class SessionHostsStartInfo
    {
        public int Count { get; set; }

        public bool IsLegacy { get; set; }

        public string AssignmentId { get; set; }

        public HostConfig HostConfigOverrides { get; set; }

        /// <summary>
        /// Metadata set on the deployment and passed on to the game session through GSDK.
        /// </summary>
        /// <remarks>
        /// This can be used by developers to pass information to session hosts while they are starting up 
        /// (unlike a session cookie which is passed during allocation).
        /// For example, the Sandbox that a game is assigned to can be part of the deployment metadata and passed to the session host
        /// which it can use to determine other config values and/or report to the game lobby service.
        /// There are limits enforced on the number of entries (30), the max key length (50char) and max value length (100).
        /// </remarks>
        public IDictionary<string, string> DeploymentMetadata { get; set; }

        /// <summary>
        /// The details about where to retrieve the image from
        /// </summary>
        public ContainerImageDetails ImageDetails { get; set; }

        /// <summary>
        /// The details about where the image needs to be pushed to.
        /// If null, the agent is not required to replicate the image
        /// </summary>
        public ContainerImageDetails ImageReplicationDetails { get; set; }

        /// <summary>
        /// A list of assets to download and their mount paths.
        /// </summary>
        public AssetDetail[] AssetDetails { get; set; }

        /// <summary>
        /// A command we will use to start the game executable, it replaces
        /// any existing CMD instructions in the dockerfile. This command should
        /// include the full path to the executable and any required arguments.
        /// </summary>
        public string StartGameCommand { get; set; }

        public string PublicIpV4Address { get; set; }

        /// <summary>
        /// The fully qualified domain name for the Vm.
        /// </summary>
        public string FQDN { get; set; }

        /// <summary>
        /// Indicates how the game server is hosted on the VM.
        /// </summary>
        public SessionHostType SessionHostType { get; set; }

        /// <summary>
        /// The set of ports available on the Node to be mapped to game ports on the container.
        /// Each element of the list contains all required port mappings for a single container.
        /// As such, the total length of the outer list must equal the total number of requested containers.
        /// </summary>
        public List<List<PortMapping>> PortMappingsList { get; set; }

        public LogUploadParameters LogUploadParameters { get; set; }

        /// <summary>
        /// List of certificates we want installed on each container
        /// </summary>
        public CertificateDetail[] GameCertificates { get; set; }

        /// <summary>
        /// The XBLC certificate, required by legacy titles that use Xbox Live
        /// </summary>
        public CertificateDetail XblcCertificate { get; set; }

        /// <summary>
        /// The certificate used by some legacy titles for the IPSec protocol.
        /// </summary>
        public CertificateDetail IpSecCertificate { get; set; }

        /// <summary>
        /// The duration that a session host is allowed to be in any given state.
        /// </summary>
        /// <remarks>There are overrides in VmAgent for specific states (such as terminating) that are separate from this setting.</remarks>
        public TimeSpan SessionHostMaxAllowedStateDuration { get; set; }

        /// <summary>
        /// List of processes to be monitored when metrics collection is turned on.
        /// Used in Windows instrumentation, ignored in Linux VMs
        /// </summary>
        /// <remarks>A base set of processes to monitor are defined in the VmAgent. This list is specific to each
        /// title/build which is why it is passed in here and it will be added to the base set defined in VmAgent.</remarks>
        public string[] PerformanceMetricsCollectionProcessesToMonitor { get; set; }

        /// <summary>
        /// specified properties used for instrumentation in Linux VMs
        /// ignored in Windows VMs
        /// </summary>
        public LinuxInstrumentationConfiguration LinuxInstrumentationConfiguration { get; set; }
        
        /// <summary>
        /// The working directory on Windows VM. If this is not provided
        /// we will do a best effort to retrieve it from the start game
        /// command.
        /// </summary>
        public string GameWorkingDirectory { get; set; }

        /// <summary>
        /// Flag to indicate the build should use in memory asset download
        /// and decompression. 
        /// </summary>
        public bool DownloadAssetsInStreaming { get; set; }

        /// <summary>
        /// Flag to indicate the build should not replicate assets for each of the session hosts. 
        /// </summary>
        public bool UseReadOnlyAssets { get; set; }
    }

    public class LogUploadParameters
    {
        // For example: https://account.blob.core.windows.net/
        public string BlobServiceEndpoint { get; set; }

        public string SharedAccessSignatureToken { get; set; }
    }
    
    public class LinuxInstrumentationConfiguration
    {
        /// <summary>
        /// Is Linux instrumentation enabled
        /// </summary>
        public bool IsEnabled { get; set; }
    }
}
