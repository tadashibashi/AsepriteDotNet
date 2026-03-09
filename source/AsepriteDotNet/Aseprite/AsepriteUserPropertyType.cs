// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

using AsepriteDotNet.Aseprite.Types;

namespace AsepriteDotNet.Aseprite;

/// <summary>
/// Indicates the type of value stored in an AsepriteUserProperty.
/// </summary>
public enum AsepriteUserPropertyType : ushort
{
    /// <summary>No type, invalid.</summary>
    None,
    /// <summary>Value is a `bool`</summary>
    Bool,
    /// <summary>Value is an `sbyte`</summary>
    Int8,
    /// <summary>Value is a `byte`</summary>
    UInt8,
    /// <summary>Value is a `short`</summary>
    Int16,
    /// <summary>Value is a `ushort`</summary>
    UInt16,
    /// <summary>Value is an `int`</summary>
    Int32,
    /// <summary>Value is a `uint`</summary>
    UInt32,
    /// <summary>Value is an `long`</summary>
    Int64,
    /// <summary>Value is an `ulong`</summary>
    UInt64,
    /// <summary>Value is an `float`</summary>
    Fixed,
    /// <summary>Value is an `float`</summary>
    Float,
    /// <summary>Value is an `double`</summary>
    Double,
    /// <summary>Value is a `string`</summary>
    String,
    /// <summary>Value is a <see cref="AsepriteDotNet.Common.Point" /></summary>
    Point,
    /// <summary>Value is a <see cref="AsepriteDotNet.Common.Size" /></summary>
    Size,
    /// <summary>Value is a <see cref="AsepriteDotNet.Common.Rectangle" /></summary>
    Rect,
    /// <summary>
    /// Value is a <see cref="List{T}" /> of type <see cref="AsepriteDotNet.Aseprite.Types.AsepriteUserProperty" />
    /// </summary>
    Vector,
    /// <summary>Value is a <see cref="AsepriteUserPropertiesMap" /></summary>
    Properties,
    /// <summary>Value is a `byte[16]`</summary>
    Uuid,
}
