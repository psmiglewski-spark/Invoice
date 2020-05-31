using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using Newtonsoft.Json;

namespace Invoice
{
    class CurrencyTable
    {
        public string table { get; set; }
        public string no { get; set; }
        public string effectiveDate { get; set; }
        public List<Currency> rates { get; set; }


        static async Task<string> GetURI(Uri u)
        {
            var response = string.Empty;
            using (var client = new HttpClient())
            {
                HttpResponseMessage result = await client.GetAsync(u);
                if (result.IsSuccessStatusCode)
                {
                    response = await result.Content.ReadAsStringAsync();
                }
            }
            return response;
        }

        public List<Currency> Currencies()
        {
            var _currencyTableList = new List<CurrencyTable>();
            var _currencyList = new List<Currency>();
            string jsonString;

            var t = Task.Run(() => GetURI(new Uri("https://api.nbp.pl/api/exchangerates/tables/A/?format=json")));
            t.Wait();
            jsonString = t.Result;
            _currencyTableList = JsonConvert.DeserializeObject<List<CurrencyTable>>(jsonString);
            var db = new DataBase();
            if (!db.SelectCurrencyRates(DateTime.Today.ToString("yyyyMMdd")))
            {
                db.InsertCurrencyRatesTable(DateTime.Today, t.Result);
            }
            
            _currencyList = _currencyTableList[0].rates;

          return _currencyList;
        }

        public float CheckExchangeRate(string currency, DateTime date)
        {
            var _currencyTableList = new List<CurrencyTable>();
            var _currencyList = new List<Currency>();
            string jsonString;
            var db = new DataBase();
            float result = 0f;
            var index = 0;

            jsonString = db.SelectCurrencyRatesTable(date.ToString("yyyyMMdd")).Rows[0]["Currency_Rates_Table_JsonString"].ToString();
            _currencyTableList = JsonConvert.DeserializeObject<List<CurrencyTable>>(jsonString);
            _currencyList = _currencyTableList[0].rates;

            foreach (var _currency in _currencyList)
            {
                if (currency == _currency.code)
                {
                    result = _currency.mid;
                }
            }

            return result;
        }

        


    }

   
}
