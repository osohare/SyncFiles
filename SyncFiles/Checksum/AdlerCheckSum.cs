using System;
using System.Security.Cryptography;
using System.Text;

/// <summary>
/// This class derives from HashAlgorithm, this was the CLR takes care of all operations including handling of CryptoStream
/// </summary>
public class Adler32Managed : HashAlgorithm
{
    private ushort o_sum_1;
    private ushort o_sum_2;

    /// <summary>
    /// Default constuctor
    /// </summary>
    public Adler32Managed()
    {
        Initialize();
    }

    /// <summary>
    /// 32 by default
    /// </summary>
    public override int HashSize
    {
        get
        {
            return 32;
        }
    }

    /// <summary>
    /// Initilize IV and any others
    /// </summary>
    public override void Initialize()
    {
        // reset the sum values
        o_sum_1 = 1;
        o_sum_2 = 0;
    }

    /// <summary>
    /// Default Hash function for hashing a block
    /// </summary>
    /// <param name="p_array">Array to hash</param>
    /// <param name="p_start_index">Where to start the hashing</param>
    /// <param name="p_count">How long will hashing take in positions</param>
    protected override void HashCore(byte[] p_array, int p_start_index, int p_count)
    {
        // process each byte in the array
        for (int i = p_start_index; i < p_count; i++)
        {
            o_sum_1 = (ushort)((o_sum_1 + p_array[i]) % 65521);
            o_sum_2 = (ushort)((o_sum_1 + o_sum_2) % 65521);
        }
    }

    /// <summary>
    /// Hash the final block with any byte[] leftovers
    /// </summary>
    /// <returns></returns>
    protected override byte[] HashFinal()
    {
        // concat the two 16 bit values to form
        // one 32-bit value
        uint x_concat_value = (uint)((o_sum_2 << 16) | o_sum_1);
        // use the bitconverter class to render the
        // 32-bit integer into an array of bytes
        return BitConverter.GetBytes(x_concat_value);
    }
}