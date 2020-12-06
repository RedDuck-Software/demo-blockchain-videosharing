using Hackathon_VideoSharing_Platform.Shared;
using System.Collections.Generic;

namespace Hackathon.VideoSharing.Platform.Client
{
    public class SymmetricKeyIPFSDictionary
    {
        private Dictionary<VideoMetaData, string> dictionary = new Dictionary<VideoMetaData, string>(); // metadata <-> symm key

        public void Add(VideoMetaData metadata, string symmKey) => dictionary.Add(metadata, symmKey);

        public string Get(VideoMetaData metadata) => dictionary[metadata];
    }
}
