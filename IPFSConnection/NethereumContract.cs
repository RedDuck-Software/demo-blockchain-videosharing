using Nethereum.Web3;
using System.Threading.Tasks;
using Contracts.Contracts.HackatonStorage;
using Contracts.Contracts.HackatonStorage.ContractDefinition;
using Nethereum.Contracts;
using System.Linq;
using Nethereum.Hex.HexTypes;
using System.Collections.Generic;

namespace CommonLib
{
    public class NethereumContract
    {
        private readonly Web3 web3;
        private readonly HackatonStorageService contract;
        private readonly HexBigInteger filterNewPaymentEventsForContract;
        private readonly HexBigInteger videoEventsFilter;
        private readonly Event<PaymentEventDTO> paymentEvents;
        private readonly Event<VideoPasswordEventDTO> videoEvents;

        public NethereumContract(Web3 web3, string contractAddress)
        {
            this.web3 = web3;
            this.paymentEvents = web3.Eth.GetEvent<PaymentEventDTO>();
            this.videoEvents = web3.Eth.GetEvent<VideoPasswordEventDTO>();
            this.contract = new HackatonStorageService(web3, contractAddress);
            this.filterNewPaymentEventsForContract = videoEvents.CreateFilterAsync(paymentEvents.CreateFilterInput()).GetAwaiter().GetResult();
            this.videoEventsFilter = videoEvents.CreateFilterAsync(videoEvents.CreateFilterInput()).GetAwaiter().GetResult();
        }

        public async Task<IEnumerable<PaymentEventDTO>> GetPaymentEvents()
        {
            var payments = await paymentEvents.GetFilterChanges(filterNewPaymentEventsForContract);

            var myAddress = web3.TransactionManager.Account.Address;

            var myEvents = payments.Where(i => i.Event.To.Equals(myAddress, System.StringComparison.InvariantCultureIgnoreCase)).Select(i => i.Event);

            return myEvents;
        }

        public async Task<IEnumerable<VideoPasswordEventDTO>> GetVideoPasswordEvents()
        {
            var videos = await videoEvents.GetFilterChanges(videoEventsFilter);

            var myAddress = web3.TransactionManager.Account.Address;

            var myEvents = videos.Where(i => i.Event.BuyerAddress.Equals(myAddress, System.StringComparison.InvariantCultureIgnoreCase)).Select(i => i.Event);

            return myEvents;
        }

        /// <summary>
        /// set at early beginning of the user
        /// </summary>
         /// <param name="publicKey"></param>
        /// <returns></returns>
        public async Task PublishPublicKeyAsync(string publicKey)
        {
            var receipt = await contract.SetPubkeyRequestAndWaitForReceiptAsync(new SetPubkeyFunction()
            {
                PubKey = publicKey
            });
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
        public async Task EmitVideoPassword(string encryptedPassword, string ipfsHash, string recepientAddress)
        {
            var receipt = await contract.EmitVideoPasswordRequestAndWaitForReceiptAsync(new EmitVideoPasswordFunction()
            {
                IpfsHash = ipfsHash, 
                EncryptedPassword = encryptedPassword,
                BuyerAddress = recepientAddress
            });
        }
    }
}
