using Nethereum.Web3;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CommonLib
{
    public class NethereumContract
    {
        private readonly Web3 web3;

        public NethereumContract(Web3 web3)
        {
            this.web3 = web3;
        }

        public async Task BuyVideoRequestAsync(string sellerAddress, string publicKey, string videoName, decimal etherAmount)
        {

        }
    }
}
