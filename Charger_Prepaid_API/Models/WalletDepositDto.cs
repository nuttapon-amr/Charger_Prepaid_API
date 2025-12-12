namespace Charger_prepaid_API.Models;

public class WalletDepositDto
{
    public string external_id { get; set; }
    public double amount { get; set; }
    public string description { get; set; }
    public int invoice_duration { get; set; }
    public Customer customer { get; set; }
    public string success_redirect_url { get; set; }
    public string failure_redirect_url { get; set; }
    public string currency { get; set; }
    public List<object> items { get; set; }
    public Metadata metadata { get; set; }
}
public class Customer
{
    public object reference_id { get; set; }
    public object type { get; set; }
    public string email { get; set; }
    public string mobile_number { get; set; }
    public object individual_detail { get; set; }
}

public class Metadata
{
    public string userId { get; set; }
    public string paymentType { get; set; }
    public string referenceNo { get; set; }
    public string customerName { get; set; }
    public string accountCode { get; set; }
    public int accountId { get; set; }
    public object status { get; set; }
}