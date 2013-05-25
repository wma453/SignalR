﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Client.Transports;

namespace Microsoft.AspNet.SignalR.Tests.Common.Infrastructure
{
    public interface ITestHost : IDisposable
    {
        string Url { get; }

        IClientTransport Transport { get; set; }

        TextWriter ClientTraceOutput { get; set; }

        IList<IDisposable> Disposables { get; }

        IDictionary<string, string> ExtraData { get; }

        Func<IClientTransport> TransportFactory { get; set; }

        IDependencyResolver Resolver { get; set; }

        void Initialize(int? keepAlive = -1,
                        int? connectionTimeout = 110,
                        int? disconnectTimeout = 30,
                        bool enableAutoRejoiningGroups = false,
                        MessageBusType messageBusType = MessageBusType.Default,
                        int scaleoutStreams = 1);

        Task Get(string uri, bool disableWrites);

        Task Post(string uri, IDictionary<string, string> data);

        void Shutdown();
    }
}
