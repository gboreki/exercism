using System;
using System.Numerics;

public static class DiffieHellman
{
    //9:36-10:01
    public static BigInteger PrivateKey(BigInteger primeP) 
    {
        var prime = primeP.ToByteArray();
        byte[] randBytes = new byte[prime.Length];
        var r = new Random();
        BigInteger result;
        do
        {
            r.NextBytes(randBytes);
            result = new BigInteger(randBytes);
        } while (result.CompareTo(primeP) > 0 || result.CompareTo(new BigInteger(1)) < 0);

        return result;
    }

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) 
    {
        // primeG ** privateKey mod primeP
        return BigInteger.ModPow(primeG, privateKey, primeP);
    }

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey) 
    {
        // A**b mod p
        return BigInteger.ModPow(publicKey, privateKey, primeP);
    }
}