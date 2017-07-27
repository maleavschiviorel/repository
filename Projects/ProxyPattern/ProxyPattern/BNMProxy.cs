using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProxyPattern
{
    public class BNMExchange : IExchange
    {
        private string currencyDelimiter;
        private XmlDocument _loadedDocument = new XmlDocument();
        private WebClient _webClientBNM = new WebClient();
        private string _urlPath = "https://www.bnm.md/ro/official_exchange_rates?get_xml=1&date={0}";//20.07.2017

        private DateTime _dateTime = DateTime.Now;
        public DateTime CurrencyDate
        {
            get { return _dateTime; }
            set
            {
                _dateTime = value;
                LoadExchange();
            }
        }
        private void LoadExchange()
        {
            string xmldownloaded = _webClientBNM.DownloadString(string.Format(_urlPath, CurrencyDate.ToString("dd.MM.yyyy")));
            _loadedDocument.RemoveAll();
            _loadedDocument.LoadXml(xmldownloaded);
        }
        public BNMExchange(DateTime date)
        {
            try
            {
                CurrencyDate = date;

                var c = System.Threading.Thread.CurrentThread.CurrentCulture;
                currencyDelimiter = c.NumberFormat.CurrencyDecimalSeparator;
            }
            catch (Exception ex) when (ex.Message.Contains("(404) Not Found"))
            {
                Console.WriteLine("Error:{0}", ex.Message);
            }
        }
        private Valute ReturnAsValuta(XmlNode xmlNodeValuta)
        {
            ValutaWithNumCode valuta = new ValutaWithNumCode();
            if (!string.IsNullOrWhiteSpace(xmlNodeValuta.ChildNodes[0].InnerText))
                valuta.NumCode = Convert.ToInt32(xmlNodeValuta.ChildNodes[0].InnerText);
            if (!string.IsNullOrWhiteSpace(xmlNodeValuta.ChildNodes[1].InnerText))
                valuta.CharCode = Convert.ToString(xmlNodeValuta.ChildNodes[1].InnerText);
            if (!string.IsNullOrWhiteSpace(xmlNodeValuta.ChildNodes[2].InnerText))
                valuta.Nominal = Convert.ToInt32(xmlNodeValuta.ChildNodes[2].InnerText);
            if (!string.IsNullOrWhiteSpace(xmlNodeValuta.ChildNodes[3].InnerText))
                valuta.Name = Convert.ToString(xmlNodeValuta.ChildNodes[3].InnerText);
            if (!string.IsNullOrWhiteSpace(xmlNodeValuta.ChildNodes[4].InnerText))
            {
                valuta.Value = Convert.ToDouble(xmlNodeValuta.ChildNodes[4].InnerText.Replace(".", currencyDelimiter));
            }

            return valuta;
        }
        public Valute GetValutaById(int id)
        {
            XmlNode node = _loadedDocument.SelectSingleNode(string.Format("ValCurs/Valute[@ID='{0}']", id.ToString()));
            if (node != null)
            {
                Valute valuta = ReturnAsValuta(node);
                return valuta;
            }
            return null;
        }
        public Valute GetValutaByCode(string CharCode)
        {

            XmlNode node = _loadedDocument.SelectSingleNode(string.Format("ValCurs/Valute/CharCode[text()='{0}']", CharCode));
            if (node != null)
            {
                node = node.ParentNode;
                Valute valuta = ReturnAsValuta(node);
                return valuta;
            }
            return null;

        }
        public List<string> GetAllCurrenciesCode()
        {
            List<string> currenciesCode = new List<string>();

            XmlNodeList nodes = _loadedDocument.SelectNodes("ValCurs/Valute/CharCode");
            foreach (XmlNode node in nodes)
            {
                currenciesCode.Add(node.InnerText);
            }
            return currenciesCode;
        }
    }
}
