// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using System.Diagnostics.CodeAnalysis;

namespace AsepriteDotNet.Aseprite.Types;

/// <summary>
/// Contains a dictionary of custom user properties.
/// </summary>
public class AsepriteUserPropertiesMap
{
    /// <summary>
    /// Get the property map key:
    ///    value == 0: user data;
    ///    value != 0: extension ID
    /// </summary>
    public uint Key { get; internal set; }

    internal Dictionary<string, AsepriteUserProperty> PropertyMap { get; init; }

    /// <summary>
    /// Get an enumerable of each property.
    /// </summary>
    public IEnumerable<AsepriteUserProperty> Values => PropertyMap.Values;

    /// <summary>
    /// Get a property by key.
    /// </summary>
    /// <param name="key">Key of the property to find.</param>
    /// <exception cref="KeyNotFoundException">Throws if key is not found.</exception>
    public AsepriteUserProperty this[string key] => PropertyMap[key];

    /// <summary>
    /// Try getting a property by key.
    /// </summary>
    /// <param name="key">Key of the property to find.</param>
    /// <param name="property">The retrieved property.</param>
    /// <returns>Whether property was found.</returns>
    public bool TryGetValue(string key, [MaybeNullWhen(false)] out AsepriteUserProperty property)
    {
        return PropertyMap.TryGetValue(key, out property);
    }

    internal AsepriteUserPropertiesMap()
    {
        Key = 0;
        PropertyMap = new Dictionary<string, AsepriteUserProperty>();
    }
}
