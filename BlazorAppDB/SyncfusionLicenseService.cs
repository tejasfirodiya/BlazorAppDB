using Syncfusion.Licensing;

namespace BlazorAppDB;

public static class SyncfusionLicenseService
{
    public const string LicenseKeyBlazor = "MzQ0NDg4OUAzMjM2MmUzMDJlMzBtZloveGMwOGxLK042aWJOY0UzZmlQNmZNRFVGcVFtQUxuS2hTalVjVjBZPQ==";
    public static void InitializeBlazor()
    {
        SyncfusionLicenseProvider.RegisterLicense(LicenseKeyBlazor);
    }
}