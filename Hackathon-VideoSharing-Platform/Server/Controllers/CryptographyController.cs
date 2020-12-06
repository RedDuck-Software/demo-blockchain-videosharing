using Hackathon.VideoSharing.Platform.Shared.DTOs;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Hackathon.VideoSharing.Platform.Server.Controllers
{
    [ApiController]
    [Route("api/crypto")]
    public class CryptographyController : ControllerBase
    {
        [HttpPost]
        [Route("encrypt")]
        public string Encrypt(CryptoRequest req) => Operation(req, false);

        [HttpPost]
        [Route("decrypt")]
        public string Decrypt(CryptoRequest req) => Operation(req, true);

        public string Operation(CryptoRequest req, bool isDecryption)
        {
            Chilkat.Crypt2 crypt = new Chilkat.Crypt2
            {
                CryptAlgorithm = "aes",
                CipherMode = "cbc",
                KeyLength = 256,
                PaddingScheme = 0,
                EncodingMode = "hex"
            };

            var data = Convert.FromBase64String(req.Data64);
            crypt.SetSecretKeyViaPassword(req.Password);

            var operated = isDecryption ? crypt.DecryptBytes(data) : crypt.EncryptBytes(data);

            return Convert.ToBase64String(operated);
        }
    }
}
