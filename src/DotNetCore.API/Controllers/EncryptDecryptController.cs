using EncryptionDecryption;
using LoggerService;
using Microsoft.AspNetCore.Mvc;

namespace DotNetCore.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EncryptDecryptController : ControllerBase
    {
        private ILoggerManager _logger;
        private IEncryptDecrypt _encryptDecrypt;

        public EncryptDecryptController(ILoggerManager logger,
            IEncryptDecrypt encryptDecrypt)
        {
            _logger = logger;
            _encryptDecrypt = encryptDecrypt;
        }

        /// <summary>
        /// Encrypt the given text. (Authorization token not required)
        /// </summary>
        /// <param name="key">Key for encryption.</param>
        /// <param name="text">Text for encryption.</param>
        /// <returns>Encrypted text.</returns>
        /// <response code="200">Returns the encrypted text.</response>
        /// <response code="500">If there was an internal server error.</response>
        [HttpGet]
        [Route("Encrypt")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<string> Encrypt(string key, string text)
        {
            return _encryptDecrypt.Encrypt(text, key);
        }

        /// <summary>
        /// Decrypt the given text. (Authorization token not required)
        /// </summary>
        /// <param name="key">Key for decryption.</param>
        /// <param name="text">Text for decryption.</param>
        /// <returns>Decrypted text.</returns>
        /// <response code="200">Returns the decrypted text.</response>
        /// <response code="500">If there was an internal server error.</response>
        [HttpGet]
        [Route("Decrypt")]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<string> Decrypt(string key, string text)
        {
            return _encryptDecrypt.Decrypt(text, key);
        }
    }
}
