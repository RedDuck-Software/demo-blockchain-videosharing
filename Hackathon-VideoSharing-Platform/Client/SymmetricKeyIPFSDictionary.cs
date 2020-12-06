using CommonLib;
using Hackathon.VideoSharing.Platform.Shared.DTOs;
using Hackathon_VideoSharing_Platform.Shared;
using Nethereum.JsonRpc.Client;
using Nethereum.Web3;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hackathon.VideoSharing.Platform.Client
{
    public class SymmetricKeyIPFSDictionary
    {
        private PublicPrivateKey ppkey = null;

        private NethereumContract contract;

        private Dictionary<VideoMetaData, string> dictionary = new Dictionary<VideoMetaData, string>(); // metadata <-> symm key

        public void Add(VideoMetaData metadata, string symmKey) => dictionary.Add(metadata, symmKey);

        public string Get(VideoMetaData metadata) => dictionary[metadata];

        public Dictionary<VideoMetaData, string> GetVideos() => new Dictionary<VideoMetaData, string>(dictionary);

        public string GetPublic() => ppkey.PublicKey;
        public string GetPrivate() => ppkey.PrivateKey;


        public void SetPPKey(PublicPrivateKey ppk)
        {
            if (ppkey == null)
            {
                ppkey = ppk;
            }
            else
                throw new System.Exception("Already set");
        }

        public async Task<NethereumContract> GetContract(RequestInterceptor inte)
        {
            if (contract == null)
            {
                var web3 = new Web3();

                web3.Client.OverridingRequestInterceptor = inte;

                contract = new NethereumContract(web3, Constants.ContractAddress);

                await contract.InitializeAsync();
            }

            return contract;
        }
    }
}
