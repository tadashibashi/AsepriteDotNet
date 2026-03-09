// Copyright (c) Christopher Whitley. All rights reserved.
// Licensed under the MIT license.
// See LICENSE file in the project root for full license information.

namespace AsepriteDotNet.Aseprite.Types;

/// <summary>
/// Single custom user property.
/// </summary>
public class AsepriteProperty
{
    /// <summary>
    /// Get the name of the property.
    /// </summary>
    public string Name { get; internal set; }

    /// <summary>
    /// Get the data type of the property.
    /// </summary>
    public AsepritePropertyType Type { get; internal set; }

    /// <summary>
    /// Get the value of the property. Check <see cref="Type" /> for the type.
    /// </summary>
    public object Value { get; internal set; }

    internal AsepriteProperty()
    {
        Name = string.Empty;
        Type = AsepritePropertyType.None;
        Value = 0;
    }

    /// <summary>
    /// Get if value is a string.
    /// </summary>
    public bool IsString => Type == AsepritePropertyType.String;

    /// <summary>
    /// Get if value is a boolean.
    /// </summary>
    public bool IsBoolean => Type == AsepritePropertyType.Bool;

    /// <summary>
    /// Get if value is a vector (List of AsepriteUserProperty)
    /// </summary>
    public bool IsVector => Type == AsepritePropertyType.Vector;

    /// <summary>
    /// Get if value is an <see cref="AsepritePropertiesMap" />
    /// </summary>
    public bool IsProperties => Type == AsepritePropertyType.Properties;

    /// <summary>
    /// Get if value is a <see cref="AsepriteDotNet.Common.Point" />
    /// </summary>
    public bool IsPoint => Type == AsepritePropertyType.Point;

    /// <summary>
    /// Get if value is a <see cref="AsepriteDotNet.Common.Size" />
    /// </summary>
    public bool IsSize => Type == AsepritePropertyType.Size;

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
        AsepritePropertyType.Int8 or
        AsepritePropertyType.Int16 or
        AsepritePropertyType.Int32 or
        AsepritePropertyType.Int64;

    /// <summary>
    /// Get if value is a signed type - signed integer or floating point type.
    /// </summary>
    public bool IsSigned => IsSignedIntegral || IsFloatingPoint;

    /// <summary>
    /// Get if Value is an unsigned integral type.
    /// </summary>
    public bool IsUnsigned => Type is
        AsepritePropertyType.UInt8 or
        AsepritePropertyType.UInt16 or
        AsepritePropertyType.UInt32 or
        AsepritePropertyType.UInt64;

    /// <summary>
    /// Get if Value is a floating point type (fixed, float, or double).
    /// </summary>
    public bool IsFloatingPoint => Type is
        AsepritePropertyType.Fixed or
        AsepritePropertyType.Float or
        AsepritePropertyType.Double;

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
            AsepritePropertyType.Bool   => (bool)Value,
            AsepritePropertyType.Int8   => (sbyte)Value != 0,
            AsepritePropertyType.UInt8  => (byte)Value != 0,
            AsepritePropertyType.Int16  => (short)Value != 0,
            AsepritePropertyType.UInt16 => (ushort)Value != 0,
            AsepritePropertyType.Int32  => (int)Value != 0,
            AsepritePropertyType.UInt32 => (uint)Value != 0,
            AsepritePropertyType.Int64  => (long)Value != 0,
            AsepritePropertyType.UInt64 => (ulong)Value != 0,
            AsepritePropertyType.Fixed  => (float)Value != 0,
            AsepritePropertyType.Float  => (float)Value != 0,
            AsepritePropertyType.Double => (double)Value != 0,
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
            AsepritePropertyType.Bool   => (sbyte)((bool)Value ? 1 : 0),
            AsepritePropertyType.Int8   => (sbyte)Value,
            AsepritePropertyType.UInt8  => (sbyte)(byte)Value,
            AsepritePropertyType.Int16  => (sbyte)(short)Value,
            AsepritePropertyType.UInt16 => (sbyte)(ushort)Value,
            AsepritePropertyType.Int32  => (sbyte)(int)Value,
            AsepritePropertyType.UInt32 => (sbyte)(uint)Value,
            AsepritePropertyType.Int64  => (sbyte)(long)Value,
            AsepritePropertyType.UInt64 => (sbyte)(ulong)Value,
            AsepritePropertyType.Fixed  => (sbyte)(float)Value,
            AsepritePropertyType.Float  => (sbyte)(float)Value,
            AsepritePropertyType.Double => (sbyte)(double)Value,
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
            AsepritePropertyType.Bool   => (byte)((bool)Value ? 1u : 0u),
            AsepritePropertyType.Int8   => (byte)(sbyte)Value,
            AsepritePropertyType.UInt8  => (byte)Value,
            AsepritePropertyType.Int16  => (byte)(short)Value,
            AsepritePropertyType.UInt16 => (byte)(ushort)Value,
            AsepritePropertyType.Int32  => (byte)(int)Value,
            AsepritePropertyType.UInt32 => (byte)(uint)Value,
            AsepritePropertyType.Int64  => (byte)(long)Value,
            AsepritePropertyType.UInt64 => (byte)(ulong)Value,
            AsepritePropertyType.Fixed  => (byte)(float)Value,
            AsepritePropertyType.Float  => (byte)(float)Value,
            AsepritePropertyType.Double => (byte)(double)Value,
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
            AsepritePropertyType.Bool   => (short)((bool)Value ? 1 : 0),
            AsepritePropertyType.Int8   => (short)(sbyte)Value,
            AsepritePropertyType.UInt8  => (short)(byte)Value,
            AsepritePropertyType.Int16  => (short)Value,
            AsepritePropertyType.UInt16 => (short)(ushort)Value,
            AsepritePropertyType.Int32  => (short)(int)Value,
            AsepritePropertyType.UInt32 => (short)(uint)Value,
            AsepritePropertyType.Int64  => (short)(long)Value,
            AsepritePropertyType.UInt64 => (short)(ulong)Value,
            AsepritePropertyType.Fixed  => (short)(float)Value,
            AsepritePropertyType.Float  => (short)(float)Value,
            AsepritePropertyType.Double => (short)(double)Value,
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
            AsepritePropertyType.Bool   => (ushort)((bool)Value ? 1u : 0u),
            AsepritePropertyType.Int8   => (ushort)(sbyte)Value,
            AsepritePropertyType.UInt8  => (ushort)(byte)Value,
            AsepritePropertyType.Int16  => (ushort)(short)Value,
            AsepritePropertyType.UInt16 => (ushort)Value,
            AsepritePropertyType.Int32  => (ushort)(int)Value,
            AsepritePropertyType.UInt32 => (ushort)(uint)Value,
            AsepritePropertyType.Int64  => (ushort)(long)Value,
            AsepritePropertyType.UInt64 => (ushort)(ulong)Value,
            AsepritePropertyType.Fixed  => (ushort)(float)Value,
            AsepritePropertyType.Float  => (ushort)(float)Value,
            AsepritePropertyType.Double => (ushort)(double)Value,
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
            AsepritePropertyType.Bool   => (int)((bool)Value ? 1 : 0),
            AsepritePropertyType.Int8   => (int)(sbyte)Value,
            AsepritePropertyType.UInt8  => (int)(byte)Value,
            AsepritePropertyType.Int16  => (int)(short)Value,
            AsepritePropertyType.UInt16 => (int)(ushort)Value,
            AsepritePropertyType.Int32  => (int)Value,
            AsepritePropertyType.UInt32 => (int)(uint)Value,
            AsepritePropertyType.Int64  => (int)(long)Value,
            AsepritePropertyType.UInt64 => (int)(ulong)Value,
            AsepritePropertyType.Fixed  => (int)(float)Value,
            AsepritePropertyType.Float  => (int)(float)Value,
            AsepritePropertyType.Double => (int)(double)Value,
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
            AsepritePropertyType.Bool   => (uint)((bool)Value ? 1u : 0u),
            AsepritePropertyType.Int8   => (uint)(sbyte)Value,
            AsepritePropertyType.UInt8  => (uint)(byte)Value,
            AsepritePropertyType.Int16  => (uint)(short)Value,
            AsepritePropertyType.UInt16 => (uint)(ushort)Value,
            AsepritePropertyType.Int32  => (uint)(int)Value,
            AsepritePropertyType.UInt32 => (uint)Value,
            AsepritePropertyType.Int64  => (uint)(long)Value,
            AsepritePropertyType.UInt64 => (uint)(ulong)Value,
            AsepritePropertyType.Fixed  => (uint)(float)Value,
            AsepritePropertyType.Float  => (uint)(float)Value,
            AsepritePropertyType.Double => (uint)(double)Value,
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
            AsepritePropertyType.Bool   => (long)((bool)Value ? 1L : 0L),
            AsepritePropertyType.Int8   => (long)(sbyte)Value,
            AsepritePropertyType.UInt8  => (long)(byte)Value,
            AsepritePropertyType.Int16  => (long)(short)Value,
            AsepritePropertyType.UInt16 => (long)(ushort)Value,
            AsepritePropertyType.Int32  => (long)(int)Value,
            AsepritePropertyType.UInt32 => (long)(uint)Value,
            AsepritePropertyType.Int64  => (long)Value,
            AsepritePropertyType.UInt64 => (long)(ulong)Value,
            AsepritePropertyType.Fixed  => (long)(float)Value,
            AsepritePropertyType.Float  => (long)(float)Value,
            AsepritePropertyType.Double => (long)(double)Value,
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
            AsepritePropertyType.Bool   => (ulong)((bool)Value ? 1UL : 0UL),
            AsepritePropertyType.Int8   => (ulong)(sbyte)Value,
            AsepritePropertyType.UInt8  => (ulong)(byte)Value,
            AsepritePropertyType.Int16  => (ulong)(short)Value,
            AsepritePropertyType.UInt16 => (ulong)(ushort)Value,
            AsepritePropertyType.Int32  => (ulong)(int)Value,
            AsepritePropertyType.UInt32 => (ulong)(uint)Value,
            AsepritePropertyType.Int64  => (ulong)(long)Value,
            AsepritePropertyType.UInt64 => (ulong)Value,
            AsepritePropertyType.Fixed  => (ulong)(float)Value,
            AsepritePropertyType.Float  => (ulong)(float)Value,
            AsepritePropertyType.Double => (ulong)(double)Value,
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
            AsepritePropertyType.Bool   => (bool)Value ? 1.0 : 0,
            AsepritePropertyType.Int8   => (float)(sbyte)Value,
            AsepritePropertyType.UInt8  => (float)(byte)Value,
            AsepritePropertyType.Int16  => (float)(short)Value,
            AsepritePropertyType.UInt16 => (float)(ushort)Value,
            AsepritePropertyType.Int32  => (float)(int)Value,
            AsepritePropertyType.UInt32 => (float)(uint)Value,
            AsepritePropertyType.Int64  => (float)(long)Value,
            AsepritePropertyType.UInt64 => (float)(ulong)Value,
            AsepritePropertyType.Fixed  => (float)Value,
            AsepritePropertyType.Float  => (float)Value,
            AsepritePropertyType.Double => (float)(double)Value,
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
            AsepritePropertyType.Bool   => (bool)Value ? 1.0 : 0,
            AsepritePropertyType.Int8   => (sbyte)Value,
            AsepritePropertyType.UInt8  => (byte)Value,
            AsepritePropertyType.Int16  => (short)Value,
            AsepritePropertyType.UInt16 => (ushort)Value,
            AsepritePropertyType.Int32  => (int)Value,
            AsepritePropertyType.UInt32 => (uint)Value,
            AsepritePropertyType.Int64  => (long)Value,
            AsepritePropertyType.UInt64 => (ulong)Value,
            AsepritePropertyType.Fixed  => (float)Value,
            AsepritePropertyType.Float  => (float)Value,
            AsepritePropertyType.Double => (double)Value,
            _ => throw new InvalidCastException($"The type {Type} could not be casted to an double.")
        };
    }
}
