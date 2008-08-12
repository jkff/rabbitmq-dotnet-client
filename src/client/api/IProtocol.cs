// This source code is dual-licensed under the Apache License, version
// 2.0, and the Mozilla Public License, version 1.1.
//
// The APL v2.0:
//
//---------------------------------------------------------------------------
//   Copyright (C) 2007, 2008 LShift Ltd., Cohesive Financial
//   Technologies LLC., and Rabbit Technologies Ltd.
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//       http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License.
//---------------------------------------------------------------------------
//
// The MPL v1.1:
//
//---------------------------------------------------------------------------
//   The contents of this file are subject to the Mozilla Public License
//   Version 1.1 (the "License"); you may not use this file except in
//   compliance with the License. You may obtain a copy of the License at
//   http://www.rabbitmq.com/mpl.html
//
//   Software distributed under the License is distributed on an "AS IS"
//   basis, WITHOUT WARRANTY OF ANY KIND, either express or implied. See the
//   License for the specific language governing rights and limitations
//   under the License.
//
//   The Original Code is The RabbitMQ .NET Client.
//
//   The Initial Developers of the Original Code are LShift Ltd.,
//   Cohesive Financial Technologies LLC., and Rabbit Technologies Ltd.
//
//   Portions created by LShift Ltd., Cohesive Financial Technologies
//   LLC., and Rabbit Technologies Ltd. are Copyright (C) 2007, 2008
//   LShift Ltd., Cohesive Financial Technologies LLC., and Rabbit
//   Technologies Ltd.;
//
//   All Rights Reserved.
//
//   Contributor(s): ______________________________________.
//
//---------------------------------------------------------------------------
using RabbitMQ.Client.Impl;

namespace RabbitMQ.Client
{
    ///<summary>Object describing various overarching parameters
    ///associated with a particular AMQP protocol variant.</summary>
    public interface IProtocol
    {
        ///<summary>Retrieve the protocol's major version number</summary>
        int MajorVersion { get; }
        ///<summary>Retrieve the protocol's minor version number</summary>
        int MinorVersion { get; }
        ///<summary>Retrieve the protocol's API name, used for
        ///printing, configuration properties, IDE integration,
        ///Protocols.cs etc.</summary>
        string ApiName { get; }
        ///<summary>Retrieve the protocol's default TCP port</summary>
        int DefaultPort { get; }

        ///<summary>Returns false if this protocol variant defaults to
        ///permitting Access.Requests to be sent to the peer, or true
        ///if Access.Requests should be suppressed by
        ///default.</summary>
        bool DefaultSuppressAccessRequest { get; }

        ///<summary>Construct a frame handler for a given endpoint.</summary>
        IFrameHandler CreateFrameHandler(AmqpTcpEndpoint endpoint);
        ///<summary>Construct a connection from a given set of
        ///parameters and a frame handler. The "insist" parameter is
        ///passed on to the AMQP connection.open method.</summary>
        IConnection CreateConnection(ConnectionParameters parameters,
                                     bool insist,
                                     IFrameHandler frameHandler);
        ///<summary>Construct a protocol model atop a given session.</summary>
        IModel CreateModel(ISession session);
    }
}