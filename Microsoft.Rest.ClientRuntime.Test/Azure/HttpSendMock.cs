﻿using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Rest.ClientRuntime.Test.JsonRpc;
using System;
using System.IO;
using System.Diagnostics;
using Microsoft.Rest.ClientRuntime.Test.Utf8;

namespace Microsoft.Rest.ClientRuntime.Test.Azure
{
    public static class HttpSendMock
    {
        private static Lazy<Io> _Io = new Lazy<Io>(() =>
        {
            var serverPath = Environment.GetEnvironmentVariable("SDK_REMOTE_SERVER");
            var processInfo = new ProcessStartInfo
            {
                FileName = Environment.GetEnvironmentVariable("SDK_REMOTE_SERVER"),
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
            };

            var process = new Process { StartInfo = processInfo };
            process.Start();

            // processInfo.Environment.Add("AZURE_TENANT_ID", Environment.GetEnvironmentVariable("AZURE_TENANT_ID"));
            // processInfo.Environment.Add("AZURE_CLIENT_ID", Environment.GetEnvironmentVariable("AZURE_CLIENT_ID"));
            // processInfo.Environment.Add("AZURE_CLIENT_SECRET", Environment.GetEnvironmentVariable("AZURE_CLIENT_SECRET"));

            return process.CreateIo();
        });

        /// <summary>
        /// TODO:
        ///     - ask Joel to have encrypted credentials
        ///     - create log.
        ///     - read credentials from the same ENV varaible.
        ///     - instantiate a service if needed.
        ///     - publish logs on appveyor.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request)
        {
            var method = request.Method.Method;
            var paramsStr = request.Content.AsString();
            var @params = JsonConvert.DeserializeObject<Dictionary<string, object>>(paramsStr);
            using (var writer = File.AppendText("mock.log"))
            {
                writer.WriteLine(method);
                writer.WriteLine(paramsStr);
            }
            var remoteServer = new RemoteServer(_Io.Value, new Marshalling(null, null));
            var response = await remoteServer.Call<JsonToken>(request.Method.Method, @params);
            return null;
        }
    }
}
