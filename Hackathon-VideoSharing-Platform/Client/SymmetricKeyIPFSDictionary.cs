using Hackathon_VideoSharing_Platform.Shared;
using System.Collections.Generic;

namespace Hackathon.VideoSharing.Platform.Client
{
    public class SymmetricKeyIPFSDictionary
    {
        public string UserPublicKey { get; set; }
        public string UserPrivateKey { get; set; }

        private Dictionary<VideoMetaData, string> dictionary = new Dictionary<VideoMetaData, string>(); // metadata <-> symm key

        public void Add(VideoMetaData metadata, string symmKey) => dictionary.Add(metadata, symmKey);

        public string Get(VideoMetaData metadata) => dictionary[metadata];

        public Dictionary<VideoMetaData, string> GetVideos => new Dictionary<VideoMetaData, string>(dictionary);
    }
}
