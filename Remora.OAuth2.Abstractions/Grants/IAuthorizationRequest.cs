//
//  IAuthorizationRequest.cs
//
//  Author:
//       Jarl Gullberg <jarl.gullberg@gmail.com>
//
//  Copyright (c) Jarl Gullberg
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

using System;
using System.Collections.Generic;
using System.Net.Http;
using JetBrains.Annotations;
using Remora.Rest.Core;

namespace Remora.OAuth2.Abstractions;

/// <summary>
/// Represents the common public interface of an authorization request.
/// </summary>
/// <remarks>
/// This interface is designed to be extended into a specialized authorization
/// request adapted for one of the defined OAuth2 grant methods.
/// </remarks>
[PublicAPI]
public interface IAuthorizationRequest
{
    /// <summary>
    /// Gets the requested response type.
    /// </summary>
    string ResponseType { get; }

    /// <summary>
    /// Gets the identifier of the client.
    /// </summary>
    string ClientID { get; }

    /// <summary>
    /// Gets the URI which the user agent should be redirected back to when the
    /// authorization server has completed its interaction with the resource
    /// owner.
    /// </summary>
    Optional<Uri> RedirectUri { get; }

    /// <summary>
    /// Gets the requested scope of the access token.
    /// </summary>
    Optional<IReadOnlyList<string>> Scope { get; }

    /// <summary>
    /// Gets an opaque value used to maintain state between the request and
    /// callback.
    /// </summary>
    Optional<string> State { get; }

    /// <summary>
    /// Creates an HTTP request from the information contained in the request object.
    /// </summary>
    /// <param name="authorizationEndpoint">The authorization endpoint to use when constructing the request URI.</param>
    /// <returns>The constructed URI.</returns>
    HttpRequestMessage ToRequest(Uri authorizationEndpoint);
}
