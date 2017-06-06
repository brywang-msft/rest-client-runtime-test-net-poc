﻿namespace Microsoft.Rest.ClientRuntime.Test.Azure
{
    public sealed class AzureParamInfo
    {
        public string Name { get; }

        public AzureParamLocation Location { get; }

        public bool IsRequired { get; }

        public AzureParamInfo(string name, AzureParamLocation location, bool isRequired)
        {
            Name = name;
            Location = location;
            IsRequired = isRequired;
        }
    }
}
