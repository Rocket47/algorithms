namespace SoftwareDesign.sd1_7;

public class Sd174FeaturesPromises
{
    public async Task GetUserBanalce()
    {
        var balance = GetBankAccountInfoAsync();
        await Task.Delay(500);
        var finalBalance = await balance;

        Console.WriteLine($"Request completed. The balance is {finalBalance}.");
    }

    private static async Task<int> GetBankAccountInfoAsync()
    {
        await Task.Delay(2000);
        return 12000; 
    }
}