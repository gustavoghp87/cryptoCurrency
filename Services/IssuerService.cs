using cryptoCurrency.Models;

namespace cryptoCurrency.Services
{
    public static class IssuerService
    {
        public static Wallet Get()
        {
            return new Wallet
            {
                PublicKey = "1GPuEJZ6rjh7WfdQwNqUPWgsud95RLBUfK",
                PrivateKey = "L27gRq59TSnXTWanV1SdgHRucFtfqZciec5Grooc6MDPe4o47T5V",
                BitcoinAddress = "12EWT461aNMMfjEGteJ6Bz8BWmDeB1Efkj"
            };
        }
    }
}
