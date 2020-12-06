using Nethereum.Web3;
using System.Threading.Tasks;
using Contracts.Contracts.HackatonStorage;
using Contracts.Contracts.HackatonStorage.ContractDefinition;

namespace CommonLib
{
    public class NethereumContract
    {
        private readonly Web3 web3;
        private readonly HackatonStorageService contract;

        public NethereumContract(Web3 web3, string contractAddress)
        {
            this.web3 = web3;
            this.contract = new HackatonStorageService(web3, contractAddress);
        }

        /// <summary>
        /// 1st page
        /// </summary>
        /// <param name="etherPrice"></param>
        /// <param name="ipfsHash"></param>
        /// <param name="contractAddress"></param>
        /// <returns></returns>
        public async Task PublishVideoRequestAsync(decimal etherPrice, string ipfsHash)
        {
            var receipt = await contract.SetIpfsHashRequestAndWaitForReceiptAsync(new SetIpfsHashFunction
            {
                IpfsHash = ipfsHash
            });

            var receipt2 = await contract.SetPriceRequestAndWaitForReceiptAsync(new SetPriceFunction()
            {
                Price = Web3.Convert.ToWei(etherPrice, Nethereum.Util.UnitConversion.EthUnit.Ether),
                IpfsHash = ipfsHash                
            });
        }

        /// <summary>
        /// 2nd page
        /// </summary>
        /// <param name="publicKey"></param>
        /// <param name="contractAddress"></param>
        /// <returns></returns>
        public async Task BuyRequestAsync(string publicKey, string ipfsHash)
        {
            var receipt = await contract.PayRequestAndWaitForReceiptAsync(new PayFunction()
            {
                PubKey = publicKey,
                IpfsHash = ipfsHash,
            });
        }

        /// <summary>
        /// 3rd page
        /// </summary>
        /// <param name="encryptedPassword"></param>
        /// <param name="ipfsHash"></param>
        /// <param name="recepient"></param>
        /// <returns></returns>
        public async Task EmitVideoPassword(string encryptedPassword, string ipfsHash, string recepient)
        {
            //var receipt = await contract.
        }
    }
}
