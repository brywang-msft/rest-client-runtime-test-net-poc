﻿using System.Collections.Generic;

namespace Microsoft.Rest.ClientRuntime.Test.Azure
{
    public sealed class AzureRequest
    {
        public AzureRequestInfo Info { get; }

        public System.Uri BaseUri { get; }

        public IEnumerable<AzureParam> ParamList { get; }

        public AzureRequest(
            AzureRequestInfo info,
            System.Uri baseUri,
            IEnumerable<AzureParam> paramList)
        {
            Info = info;
            BaseUri = baseUri;
            ParamList = paramList;
        }
    }
}