//
//  FakeExtension.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) 2017 Jarl Gullberg
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
//

using System.Collections.Generic;
using System.Collections.Specialized;
using Remora.OAuth2.Abstractions.OAuthExtensions;
using Remora.OAuth2.Abstractions.OAuthExtensions.DeviceAuthorizationGrant;
using Remora.OAuth2.Abstractions.OAuthExtensions.TokenRevocation;

namespace Remora.OAuth.Tests.Fakes;

/// <summary>
/// Represents a fake request extension that adds a single new field.
/// </summary>
public class FakeExtension :
    IAuthorizationRequestExtension,
    IAccessTokenRequestExtension,
    IDeviceAuthorizationAuthorizationRequestExtension,
    IDeviceAuthorizationAccessTokenRequestExtension,
    ITokenRevocationRequestExtension
{
    /// <summary>
    /// Gets the name of the extension field.
    /// </summary>
    public static string Name => "fake";

    /// <summary>
    /// Gets the value of the extension field.
    /// </summary>
    public static string Value => "value";

    /// <inheritdoc />
    public void AddParameters(NameValueCollection collection)
    {
        collection.Add(Name, Value);
    }

    /// <inheritdoc cref="IAccessTokenRequestExtension.AddParameters" />
    public void AddParameters(IDictionary<string, string> collection)
    {
        collection.Add(Name, Value);
    }
}
