namespace UnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            Assert.False(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(98)));
            Assert.True(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(2)));
            Assert.True(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(97)));
            Assert.False(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(-1)));
            Assert.False(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(0)));
            Assert.False(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(1)));
            Assert.True(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(
                    Tools.Cryptography.KeyExchange.DiffieHellman.GetGroup(Tools.Cryptography.KeyExchange.DiffieHellmanGroup.Modp1536).G));

        }
        [Fact]
        public void Test2()
        {
            Assert.False(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(2)),"Biluð tala");
            Assert.True(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(2)));
            Assert.True(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(97)));
            Assert.False(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(-1)));
            Assert.False(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(0)));
            Assert.False(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(new System.Numerics.BigInteger(1)));
            Assert.True(Tools.Cryptography.NumberTheory.Primality.isProbablyPrime(
                    Tools.Cryptography.KeyExchange.DiffieHellman.GetGroup(Tools.Cryptography.KeyExchange.DiffieHellmanGroup.Modp1536).G));

        }
    }
}