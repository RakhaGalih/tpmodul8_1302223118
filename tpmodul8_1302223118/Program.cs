using tpmodul8_1302223118;

internal class Program
{
    public static void Main(string[] args)
    {
        ConfigController controller = new ConfigController();

        controller.UbahSatuan();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {controller.config.satuan_suhu} : ");
        double suhuBadan = Convert.ToDouble(Console.ReadLine());

        Console.Write($"Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? : ");
        int hariTerakhirDemam = int.Parse(Console.ReadLine());

        bool BatasDemamTerima = hariTerakhirDemam < controller.config.batas_hari_demam;
        bool suhuCelciusTerima = (controller.config.satuan_suhu == "celcius") &&
                             (suhuBadan >= 36.5 && suhuBadan <= 37.5);
        bool suhuFahrenheitTerima = (controller.config.satuan_suhu == "fahrenheit") &&
                                (suhuBadan >= 97.7 && suhuBadan <= 99.5);
        
        if (
            BatasDemamTerima && (suhuCelciusTerima || suhuFahrenheitTerima)
        )
        {
            Console.WriteLine(controller.config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(controller.config.pesan_ditolak);
        }

    }
}