using System.Collections.Generic;
using Newtonsoft.Json;
using SPA.Helpers;


namespace SPA.Models.Dtos
{
    /// <summary>
    /// This class holds all quote properties from the JSON response of the Tradier API QUOTE request.
    ///
    /// <see cref="trade_date"/> <see cref="ask_date"/> <see cref="bid_date"/> are all stored
    /// as longs as they are unix timestamps in milliseconds.
    /// </summary>
    public class Quote
    {
        [JsonProperty("symbol")]
        public string Symbol { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("exch")]
        public string ExchangeCode { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("last")]
        public decimal Last { get; set; }

        [JsonProperty("change")]
        public decimal Change { get; set; }

        [JsonProperty("volume")]
        public int Volume { get; set; }

        [JsonProperty("open")]
        public decimal? Open { get; set; }

        [JsonProperty("high")]
        public decimal? High { get; set; }

        [JsonProperty("low")]
        public decimal? Low { get; set; }

        [JsonProperty("close")]
        public decimal? Close { get; set; }

        [JsonProperty("bid")]
        public decimal Bid { get; set; }

        [JsonProperty("ask")]
        public decimal Ask { get; set; }

        [JsonProperty("change_percentage")]
        public decimal ChangePercentage { get; set; }

        [JsonProperty("average_volume")]
        public int AverageVolume { get; set; }

        [JsonProperty("last_volume")]
        public decimal LastVolume { get; set; }

        // TODO convert to DateTime using a jsonConverter.
        [JsonProperty("trade_date")]
        public long TradeDate { get; set; }

        [JsonProperty("prevclose")]
        public decimal PrevClose { get; set; }

        [JsonProperty("week_52_high")]
        public decimal Week52High { get; set; }

        [JsonProperty("week_52_low")]
        public decimal Week52Low { get; set; }

        [JsonProperty("bidsize")]
        public int BidSize { get; set; }

        [JsonProperty("bidexch")]
        public string BidExchangeCode { get; set; }

        [JsonProperty("bid_date")]
        public long BidDate { get; set; }

        [JsonProperty("asksize")]
        public int AskSize { get; set; }

        [JsonProperty("askexch")]
        public string AskExchangeCode { get; set; }

        [JsonProperty("ask_date")]
        public long AskDate { get; set; }

        [JsonProperty("root_symbols")]
        public string RootSymbols { get; set; }
    }

    /// <summary>
    /// Represents the UnmatchedSymbol object from Tradiers API QUOTE request.
    /// Stores the symbols aka ticker of the stocks requested that couldn't be found by Tradier.
    /// </summary>
    public class UnmatchedSymbols
    {
        [JsonProperty("symbol")]
        [JsonConverter(typeof(SingleToListConverter<string>))]
        public List<string> Symbol { get; set; }
    }

    /// <summary>
    /// Represents the Quotes object from Tradiers API QUOTE request.
    /// this object has a List of Quotes and an UnmatchedSymbols object.
    /// </summary>
    public class Quotes
    {
        [JsonProperty("quote")]
        [JsonConverter(typeof(SingleToListConverter<Quote>))]
        public List<Quote> Quote { get; set; }

        [JsonProperty("unmatched_symbols")]
        public UnmatchedSymbols UnmatchedSymbols { get; set; }
    }

    /// <summary>
    /// Root class represents the top object returned by the Tradier API QUOTES request
    /// which just holds the quotes object.
    /// </summary>
    public class Root
    {
        [JsonProperty("quotes")]
        public Quotes Quotes { get; set; }
    }

}