// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace AsepriteDotNet.Aseprite.Types;

/// <summary>
/// Single custom user property.
/// </summary>
public class AsepriteUserProperty
{
    /// <summary>
    /// Get the name of the property.
    /// </summary>
    public string Name { get; internal set; }

    /// <summary>
    /// Get the data type of the property.
    /// </summary>
    public AsepriteUserPropertyType Type { get; internal set; }

    /// <summary>
    /// Get the value of the property. Check <see cref="Type" /> for the type.
    /// </summary>
    public object Value { get; internal set; }

    internal AsepriteUserProperty()
    {
        Name = string.Empty;
        Type = AsepriteUserPropertyType.None;
        Value = 0;
    }

    /// <summary>
    /// Get if value is a string.
    /// </summary>
    public bool IsString => Type == AsepriteUserPropertyType.String;

    /// <summary>
    /// Get if value is a boolean.
    /// </summary>
    public bool IsBoolean => Type == AsepriteUserPropertyType.Bool;

    /// <summary>
    /// Get if value is a vector (List of AsepriteUserProperty)
    /// </summary>
    public bool IsVector => Type == AsepriteUserPropertyType.Vector;

    /// <summary>
    /// Get if value is an <see cref="AsepriteDotNet.Aseprite.Types.AsepriteUserPropertiesMap" />
    /// </summary>
    public bool IsProperties => Type == AsepriteUserPropertyType.Properties;

    /// <summary>
    /// Get if value is a <see cref="AsepriteDotNet.Common.Point" />
    /// </summary>
    public bool IsPoint => Type == AsepriteUserPropertyType.Point;

    /// <summary>
    /// Get if value is a <see cref="AsepriteDotNet.Common.Size" />
    /// </summary>
    public bool IsSize => Type == AsepriteUserPropertyType.Size;

    /// <summary>
    /// Get if value is a numeric type.
    /// </summary>
    public bool IsNumeric => IsSigned || IsUnsigned;

    /// <summary>
    /// Get if value is an integer type - signed or unsigned.
    /// </summary>
    public bool IsIntegral => IsSignedIntegral || IsUnsigned;

    /// <summary>
    /// Get if value is a signed integer type.
    /// </summary>
    public bool IsSignedIntegral => Type is
        AsepriteUserPropertyType.Int8 or
        AsepriteUserPropertyType.Int16 or
        AsepriteUserPropertyType.Int32 or
        AsepriteUserPropertyType.Int64;

    /// <summary>
    /// Get if value is a signed type - signed integer or floating point type.
    /// </summary>
    public bool IsSigned => IsSignedIntegral || IsFloatingPoint;

    /// <summary>
    /// Get if Value is an unsigned integral type.
    /// </summary>
    public bool IsUnsigned => Type is
        AsepriteUserPropertyType.UInt8 or
        AsepriteUserPropertyType.UInt16 or
        AsepriteUserPropertyType.UInt32 or
        AsepriteUserPropertyType.UInt64;

    /// <summary>
    /// Get if Value is a floating point type (fixed, float, or double).
    /// </summary>
    public bool IsFloatingPoint => Type is
        AsepriteUserPropertyType.Fixed or
        AsepriteUserPropertyType.Float or
        AsepriteUserPropertyType.Double;

    /// <summary>
    /// Gets the property's value as a string.
    /// </summary>
    public override string ToString()
    {
        return Value?.ToString() ?? "null";
    }

    /// <summary>
    /// Casts value to a boolean.
    /// If value is numeric, 0 returns false, and any other value will return true.
    /// </summary>
    /// <returns>Casted value.</returns>
    /// <exception cref="InvalidCastException">Throws if Value is an aggregate or non-numeric type.</exception>
    public bool ToBoolean()
    {
        return Type switch
        {
            AsepriteUserPropertyType.Bool   => (bool)Value,
            AsepriteUserPropertyType.Int8   => (sbyte)Value != 0,
            AsepriteUserPropertyType.UInt8  => (byte)Value != 0,
            AsepriteUserPropertyType.Int16  => (short)Value != 0,
            AsepriteUserPropertyType.UInt16 => (ushort)Value != 0,
            AsepriteUserPropertyType.Int32  => (int)Value != 0,
            AsepriteUserPropertyType.UInt32 => (uint)Value != 0,
            AsepriteUserPropertyType.Int64  => (long)Value != 0,
            AsepriteUserPropertyType.UInt64 => (ulong)Value != 0,
            AsepriteUserPropertyType.Fixed  => (float)Value != 0,
            AsepriteUserPropertyType.Float  => (float)Value != 0,
            AsepriteUserPropertyType.Double => (double)Value != 0,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to a boolean.")
        };
    }

    /// <summary>
    /// Casts value to an sbyte.
    /// </summary>
    /// <returns>Casted value.</returns>
    /// <exception cref="InvalidCastException">Throws if Value is an aggregate or non-numeric type.</exception>
    public sbyte ToInt8()
    {
        return Type switch
        {
            AsepriteUserPropertyType.Bool   => (sbyte)((bool)Value ? 1 : 0),
            AsepriteUserPropertyType.Int8   => (sbyte)Value,
            AsepriteUserPropertyType.UInt8  => (sbyte)(byte)Value,
            AsepriteUserPropertyType.Int16  => (sbyte)(short)Value,
            AsepriteUserPropertyType.UInt16 => (sbyte)(ushort)Value,
            AsepriteUserPropertyType.Int32  => (sbyte)(int)Value,
            AsepriteUserPropertyType.UInt32 => (sbyte)(uint)Value,
            AsepriteUserPropertyType.Int64  => (sbyte)(long)Value,
            AsepriteUserPropertyType.UInt64 => (sbyte)(ulong)Value,
            AsepriteUserPropertyType.Fixed  => (sbyte)(float)Value,
            AsepriteUserPropertyType.Float  => (sbyte)(float)Value,
            AsepriteUserPropertyType.Double => (sbyte)(double)Value,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to an sbyte.")
        };
    }

    /// <summary>
    /// Casts value to a byte.
    /// </summary>
    /// <returns>Casted value.</returns>
    /// <exception cref="InvalidCastException">Throws if Value is an aggregate or non-numeric type.</exception>
    public byte ToUInt8()
    {
        return Type switch
        {
            AsepriteUserPropertyType.Bool   => (byte)((bool)Value ? 1u : 0u),
            AsepriteUserPropertyType.Int8   => (byte)(sbyte)Value,
            AsepriteUserPropertyType.UInt8  => (byte)Value,
            AsepriteUserPropertyType.Int16  => (byte)(short)Value,
            AsepriteUserPropertyType.UInt16 => (byte)(ushort)Value,
            AsepriteUserPropertyType.Int32  => (byte)(int)Value,
            AsepriteUserPropertyType.UInt32 => (byte)(uint)Value,
            AsepriteUserPropertyType.Int64  => (byte)(long)Value,
            AsepriteUserPropertyType.UInt64 => (byte)(ulong)Value,
            AsepriteUserPropertyType.Fixed  => (byte)(float)Value,
            AsepriteUserPropertyType.Float  => (byte)(float)Value,
            AsepriteUserPropertyType.Double => (byte)(double)Value,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to a byte.")
        };
    }

    /// <summary>
    /// Casts value to a short.
    /// </summary>
    /// <returns>Casted value.</returns>
    /// <exception cref="InvalidCastException">Throws if Value is an aggregate or non-numeric type.</exception>
    public short ToInt16()
    {
        return Type switch
        {
            AsepriteUserPropertyType.Bool   => (short)((bool)Value ? 1 : 0),
            AsepriteUserPropertyType.Int8   => (short)(sbyte)Value,
            AsepriteUserPropertyType.UInt8  => (short)(byte)Value,
            AsepriteUserPropertyType.Int16  => (short)Value,
            AsepriteUserPropertyType.UInt16 => (short)(ushort)Value,
            AsepriteUserPropertyType.Int32  => (short)(int)Value,
            AsepriteUserPropertyType.UInt32 => (short)(uint)Value,
            AsepriteUserPropertyType.Int64  => (short)(long)Value,
            AsepriteUserPropertyType.UInt64 => (short)(ulong)Value,
            AsepriteUserPropertyType.Fixed  => (short)(float)Value,
            AsepriteUserPropertyType.Float  => (short)(float)Value,
            AsepriteUserPropertyType.Double => (short)(double)Value,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to a short.")
        };
    }

    /// <summary>
    /// Casts value to a ushort.
    /// </summary>
    /// <returns>Casted value.</returns>
    /// <exception cref="InvalidCastException">Throws if Value is an aggregate or non-numeric type.</exception>
    public ushort ToUInt16()
    {
        return Type switch
        {
            AsepriteUserPropertyType.Bool   => (ushort)((bool)Value ? 1u : 0u),
            AsepriteUserPropertyType.Int8   => (ushort)(sbyte)Value,
            AsepriteUserPropertyType.UInt8  => (ushort)(byte)Value,
            AsepriteUserPropertyType.Int16  => (ushort)(short)Value,
            AsepriteUserPropertyType.UInt16 => (ushort)Value,
            AsepriteUserPropertyType.Int32  => (ushort)(int)Value,
            AsepriteUserPropertyType.UInt32 => (ushort)(uint)Value,
            AsepriteUserPropertyType.Int64  => (ushort)(long)Value,
            AsepriteUserPropertyType.UInt64 => (ushort)(ulong)Value,
            AsepriteUserPropertyType.Fixed  => (ushort)(float)Value,
            AsepriteUserPropertyType.Float  => (ushort)(float)Value,
            AsepriteUserPropertyType.Double => (ushort)(double)Value,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to a ushort.")
        };
    }

    /// <summary>
    /// Casts value to an int.
    /// </summary>
    /// <returns>Casted value.</returns>
    /// <exception cref="InvalidCastException">Throws if Value is an aggregate or non-numeric type.</exception>
    public int ToInt32()
    {
        return Type switch
        {
            AsepriteUserPropertyType.Bool   => (int)((bool)Value ? 1 : 0),
            AsepriteUserPropertyType.Int8   => (int)(sbyte)Value,
            AsepriteUserPropertyType.UInt8  => (int)(byte)Value,
            AsepriteUserPropertyType.Int16  => (int)(short)Value,
            AsepriteUserPropertyType.UInt16 => (int)(ushort)Value,
            AsepriteUserPropertyType.Int32  => (int)Value,
            AsepriteUserPropertyType.UInt32 => (int)(uint)Value,
            AsepriteUserPropertyType.Int64  => (int)(long)Value,
            AsepriteUserPropertyType.UInt64 => (int)(ulong)Value,
            AsepriteUserPropertyType.Fixed  => (int)(float)Value,
            AsepriteUserPropertyType.Float  => (int)(float)Value,
            AsepriteUserPropertyType.Double => (int)(double)Value,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to an int.")
        };
    }

    /// <summary>
    /// Casts value to a uint.
    /// </summary>
    /// <returns>Casted value.</returns>
    /// <exception cref="InvalidCastException">Throws if Value is an aggregate or non-numeric type.</exception>
    public uint ToUInt32()
    {
        return Type switch
        {
            AsepriteUserPropertyType.Bool   => (uint)((bool)Value ? 1u : 0u),
            AsepriteUserPropertyType.Int8   => (uint)(sbyte)Value,
            AsepriteUserPropertyType.UInt8  => (uint)(byte)Value,
            AsepriteUserPropertyType.Int16  => (uint)(short)Value,
            AsepriteUserPropertyType.UInt16 => (uint)(ushort)Value,
            AsepriteUserPropertyType.Int32  => (uint)(int)Value,
            AsepriteUserPropertyType.UInt32 => (uint)Value,
            AsepriteUserPropertyType.Int64  => (uint)(long)Value,
            AsepriteUserPropertyType.UInt64 => (uint)(ulong)Value,
            AsepriteUserPropertyType.Fixed  => (uint)(float)Value,
            AsepriteUserPropertyType.Float  => (uint)(float)Value,
            AsepriteUserPropertyType.Double => (uint)(double)Value,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to a uint.")
        };
    }

    /// <summary>
    /// Casts value to a long.
    /// </summary>
    /// <returns>Casted value.</returns>
    /// <exception cref="InvalidCastException">Throws if Value is an aggregate or non-numeric type.</exception>
    public long ToInt64()
    {
        return Type switch
        {
            AsepriteUserPropertyType.Bool   => (long)((bool)Value ? 1L : 0L),
            AsepriteUserPropertyType.Int8   => (long)(sbyte)Value,
            AsepriteUserPropertyType.UInt8  => (long)(byte)Value,
            AsepriteUserPropertyType.Int16  => (long)(short)Value,
            AsepriteUserPropertyType.UInt16 => (long)(ushort)Value,
            AsepriteUserPropertyType.Int32  => (long)(int)Value,
            AsepriteUserPropertyType.UInt32 => (long)(uint)Value,
            AsepriteUserPropertyType.Int64  => (long)Value,
            AsepriteUserPropertyType.UInt64 => (long)(ulong)Value,
            AsepriteUserPropertyType.Fixed  => (long)(float)Value,
            AsepriteUserPropertyType.Float  => (long)(float)Value,
            AsepriteUserPropertyType.Double => (long)(double)Value,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to a long.")
        };
    }

    /// <summary>
    /// Casts value to a ulong.
    /// </summary>
    /// <returns>Casted value.</returns>
    /// <exception cref="InvalidCastException">Throws if value is an aggregate or non-numeric type.</exception>
    public ulong ToUInt64()
    {
        return Type switch
        {
            AsepriteUserPropertyType.Bool   => (ulong)((bool)Value ? 1UL : 0UL),
            AsepriteUserPropertyType.Int8   => (ulong)(sbyte)Value,
            AsepriteUserPropertyType.UInt8  => (ulong)(byte)Value,
            AsepriteUserPropertyType.Int16  => (ulong)(short)Value,
            AsepriteUserPropertyType.UInt16 => (ulong)(ushort)Value,
            AsepriteUserPropertyType.Int32  => (ulong)(int)Value,
            AsepriteUserPropertyType.UInt32 => (ulong)(uint)Value,
            AsepriteUserPropertyType.Int64  => (ulong)(long)Value,
            AsepriteUserPropertyType.UInt64 => (ulong)Value,
            AsepriteUserPropertyType.Fixed  => (ulong)(float)Value,
            AsepriteUserPropertyType.Float  => (ulong)(float)Value,
            AsepriteUserPropertyType.Double => (ulong)(double)Value,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to a ulong.")
        };
    }

    /// <summary>
    /// Casts value to a float.
    /// </summary>
    /// <returns>Casted value.</returns>
    /// <exception cref="InvalidCastException">Throws if value is an aggregate or non-numeric type.</exception>
    public double ToFloat()
    {
        return Type switch
        {
            AsepriteUserPropertyType.Bool   => (bool)Value ? 1.0 : 0,
            AsepriteUserPropertyType.Int8   => (float)(sbyte)Value,
            AsepriteUserPropertyType.UInt8  => (float)(byte)Value,
            AsepriteUserPropertyType.Int16  => (float)(short)Value,
            AsepriteUserPropertyType.UInt16 => (float)(ushort)Value,
            AsepriteUserPropertyType.Int32  => (float)(int)Value,
            AsepriteUserPropertyType.UInt32 => (float)(uint)Value,
            AsepriteUserPropertyType.Int64  => (float)(long)Value,
            AsepriteUserPropertyType.UInt64 => (float)(ulong)Value,
            AsepriteUserPropertyType.Fixed  => (float)Value,
            AsepriteUserPropertyType.Float  => (float)Value,
            AsepriteUserPropertyType.Double => (float)(double)Value,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to an float.")
        };
    }

    /// <summary>
    /// Casts value to a double.
    /// </summary>
    /// <returns>Casted value.</returns>
    /// <exception cref="InvalidCastException">Throws if Value is an aggregate or non-numeric type.</exception>
    public double ToDouble()
    {
        return Type switch
        {
            AsepriteUserPropertyType.Bool   => (bool)Value ? 1.0 : 0,
            AsepriteUserPropertyType.Int8   => (sbyte)Value,
            AsepriteUserPropertyType.UInt8  => (byte)Value,
            AsepriteUserPropertyType.Int16  => (short)Value,
            AsepriteUserPropertyType.UInt16 => (ushort)Value,
            AsepriteUserPropertyType.Int32  => (int)Value,
            AsepriteUserPropertyType.UInt32 => (uint)Value,
            AsepriteUserPropertyType.Int64  => (long)Value,
            AsepriteUserPropertyType.UInt64 => (ulong)Value,
            AsepriteUserPropertyType.Fixed  => (float)Value,
            AsepriteUserPropertyType.Float  => (float)Value,
            AsepriteUserPropertyType.Double => (double)Value,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to an double.")
        };
    }
}
