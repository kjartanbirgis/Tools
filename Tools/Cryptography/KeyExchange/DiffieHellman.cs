using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Tools.Cryptography.KeyExchange
{
    public class DiffieHellman
    {
        //https://www.rfc-editor.org/rfc/rfc3526 Groups

        private static readonly BigInteger P1536 = BigInteger.Parse(
            "FFFFFFFFFFFFFFFFC90FDAA22168C234C4C6628B80DC1CD1" +
            "29024E088A67CC74020BBEA63B139B22514A08798E3404DD" +
            "EF9519B3CD3A431B302B0A6DF25F14374FE1356D6D51C245" +
            "E485B576625E7EC6F44C42E9A637ED6B0BFF5CB6F406B7ED" +
            "EE386BFB5A899FA5AE9F24117C4B1FE649286651ECE45B3D" +
            "C2007CB8A163BF0598DA48361C55D39A69163FA8FD24CF5F" +
            "83655D23DCA3AD961C62F356208552BB9ED529077096966D" +
            "670C354E4ABC9804F1746C08CA237327FFFFFFFFFFFFFFFF", 
            System.Globalization.NumberStyles.HexNumber);

        private static readonly BigInteger P2048 = BigInteger.Parse(
            "FFFFFFFFFFFFFFFFC90FDAA22168C234C4C6628B80DC1CD1" +
            "29024E088A67CC74020BBEA63B139B22514A08798E3404DD" +
            "EF9519B3CD3A431B302B0A6DF25F14374FE1356D6D51C245" +
            "E485B576625E7EC6F44C42E9A637ED6B0BFF5CB6F406B7ED" +
            "EE386BFB5A899FA5AE9F24117C4B1FE649286651ECE45B3D" +
            "C2007CB8A163BF0598DA48361C55D39A69163FA8FD24CF5F" +
            "83655D23DCA3AD961C62F356208552BB9ED529077096966D" +
            "670C354E4ABC9804F1746C08CA18217C32905E462E36CE3B" +
            "E39E772C180E86039B2783A2EC07A28FB5C55DF06F4C52C9" +
            "DE2BCBF6955817183995497CEA956AE515D2261898FA0510" +
            "15728E5A8AACAA68FFFFFFFFFFFFFFFF",
        System.Globalization.NumberStyles.HexNumber);

        public static (BigInteger P, BigInteger G) GetGroup(DiffieHellmanGroup group)
        {
            switch (group)
            {
                case DiffieHellmanGroup.Modp2048:
                    return (P2048, new BigInteger(2) );
                case DiffieHellmanGroup.Modp1536:
                    return (P1536, new BigInteger(2) );

                default:
                    throw new NotImplementedException($"DH group {group} not implemented");
            }
        }

    }
    
    public enum DiffieHellmanGroup
    {
        Modp1536 = 13,
        Modp2048 = 14
    }
}
