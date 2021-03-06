using System;

namespace Braintree
{
    public class Merchant
    {
        public Merchant(NodeWrapper node)
        {
            if (node == null) return;

            NodeWrapper merchantNode = node.GetNode("merchant");

            Id = merchantNode.GetString("id");
            Email = merchantNode.GetString("email");
            CompanyName = merchantNode.GetString("company-name");
            CountryCodeAlpha3 = merchantNode.GetString("country-code-alpha3");
            CountryCodeAlpha2 = merchantNode.GetString("country-code-alpha2");
            CountryCodeNumeric = merchantNode.GetString("country-code-numeric");
            CountryName = merchantNode.GetString("country-name");

            Credentials = new OAuthCredentials(node.GetNode("credentials"));
        }

        public OAuthCredentials Credentials;

        public string Id
        {
            get; set;
        }

        public string Email
        {
            get; set;
        }

        public string CompanyName
        {
            get; set;
        }

        public string CountryCodeAlpha3
        {
            get; set;
        }

        public string CountryCodeAlpha2
        {
            get; set;
        }

        public string CountryCodeNumeric
        {
            get; set;
        }

        public string CountryName
        {
            get; set;
        }

        [Obsolete("Mock Use Only")]
        protected internal Merchant() { }
    }
}
