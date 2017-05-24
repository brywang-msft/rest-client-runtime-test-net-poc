﻿namespace Microsoft.Rest.ClientRuntime.Test.Azure
{
    public sealed class AzureParam
    {
        public string Name { get; }

        public object Value { get; }

        public AzureParam(string name, object value)
        {
            Name = name;
            Value = value;
        }
    }
}
