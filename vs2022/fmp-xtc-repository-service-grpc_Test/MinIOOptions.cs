
using Microsoft.Extensions.Options;
using XTC.FMP.MOD.Repository.App.Service;

public class MinIOOptions : IOptions<MinIOSettings>
{
    public MinIOSettings Value
    {
        get
        {
            return new MinIOSettings
            {
                Address = "localhost:9000",
                Endpoint = "localhost:9000",
                Bucket = "fmp.repository",
                AccessKey = "3KJLIOSFODNN0EXAMPO0",
                SecretKey = "vJalrXUtnFEMI/I5MDENG/bPxRfmCYEXAMPLEHEY"
            };
        }
    }
}
