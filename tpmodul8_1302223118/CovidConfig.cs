using System.Text.Json;

namespace tpmodul8_1302223118

{
    public class CovidConfig
    {
        public string satuan_suhu { get; set; }
        public int batas_hari_demam { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }

        public CovidConfig()
        {
        }
    }

    public class ConfigController
    {

        public CovidConfig config;

        //private const string filePath = "D://JSON/konfigkpl.json";
        private const string filePath = "../../../covid_config.json";

        public ConfigController()
        {
            try
            {
                ReadConfigFile();
            }
            catch
            {
                SetDefault();
                WriteNewConfigFile();
            }
        }

        public void ReadConfigFile()
        {
            string configJsonData = File.ReadAllText(filePath);
            config = JsonSerializer.Deserialize<CovidConfig?>(configJsonData);
        }

        public void WriteNewConfigFile()
        {
            JsonSerializerOptions options = new JsonSerializerOptions()
            {
                WriteIndented = true
            };

            string jsonString = JsonSerializer.Serialize(config, options);
            File.WriteAllText(filePath, jsonString);
        }

        public void SetDefault()
        {
            config = new CovidConfig();

            config.satuan_suhu = "celcius";
            config.batas_hari_demam = 14;
            config.pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            config.pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public void UbahSatuan()
        {
            config.satuan_suhu = (config.satuan_suhu == "celcius") ? "fahrenheit" : "celcius";

            WriteNewConfigFile();
        }
    }
}

