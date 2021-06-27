using System.Collections.Generic;

namespace cryptoCurrency.Models
{
    public class Blockchain
    {
        public List<Block> Blocks { get; set; }
        public Wallet IssuerWallet { get; set; }
        public string LastDifficulty {get;set;}
        public decimal LastReward { get; set; }
        public List<Node> Nodes { get; set; }
    }
}
