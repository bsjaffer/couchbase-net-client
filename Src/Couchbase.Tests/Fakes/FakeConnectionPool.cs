﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Couchbase.Authentication.SASL;
using Couchbase.Configuration.Client;
using Couchbase.Core;
using Couchbase.IO;
using Couchbase.Utils;

namespace Couchbase.Tests.Fakes
{
    internal class FakeConnectionPool : IConnectionPool
    {
        private readonly List<IConnection> _connections = new List<IConnection>();

        public FakeConnectionPool()
        {
            EndPoint = UriExtensions.GetEndPoint("127.0.01:8091");
        }

        public PoolConfiguration Configuration { get; private set; }

        public IPEndPoint EndPoint { get; set; }

        public Uri Uri { get; set; }

        public IEnumerable<IConnection> Connections
        {
            get { return _connections; }
        }

        public void AddConnection(IConnection connection)
        {
            _connections.Add(connection);
        }

        public void Clear()
        {
            _connections.Clear();
        }

        public IConnection Acquire()
        {
            if (!_connections.Any())
            {
                _connections.Add(new FakeConnection());
            }
            return _connections.First();
        }

        public void Release(IConnection connection)
        {
        }

        public int Count()
        {
            return _connections.Count;
        }

        public void Initialize()
        {
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public IServer Owner { get; set; }


        public bool InitializationFailed { get; protected set; }

        public ISaslMechanism SaslMechanism { get; set; }
	    public bool SupportsEnhancedAuthentication { get; set; }
    }
}

#region [ License information          ]

/* ************************************************************
 *
 *    @author Couchbase <info@couchbase.com>
 *    @copyright 2014 Couchbase, Inc.
 *
 *    Licensed under the Apache License, Version 2.0 (the "License");
 *    you may not use this file except in compliance with the License.
 *    You may obtain a copy of the License at
 *
 *        http://www.apache.org/licenses/LICENSE-2.0
 *
 *    Unless required by applicable law or agreed to in writing, software
 *    distributed under the License is distributed on an "AS IS" BASIS,
 *    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *    See the License for the specific language governing permissions and
 *    limitations under the License.
 *
 * ************************************************************/

#endregion