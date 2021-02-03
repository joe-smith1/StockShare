using System.Collections.Generic;
using System.Text.Json.Serialization;


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
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("exch")]
        public string ExchangeCode { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("last")]
        public decimal Last { get; set; }

        [JsonPropertyName("change")]
        public decimal Change { get; set; }

        [JsonPropertyName("volume")]
        public int Volume { get; set; }

        [JsonPropertyName("open")]
        public decimal Open { get; set; }

        [JsonPropertyName("high")]
        public decimal High { get; set; }

        [JsonPropertyName("low")]
        public decimal Low { get; set; }

        [JsonPropertyName("close")]
        public decimal Close { get; set; }

        [JsonPropertyName("bid")]
        public decimal Bid { get; set; }

        [JsonPropertyName("ask")]
        public decimal Ask { get; set; }

        [JsonPropertyName("change_percentage")]
        public decimal ChangePercentage { get; set; }

        [JsonPropertyName("average_volume")]
        public int AverageVolume { get; set; }

        [JsonPropertyName("last_volume")]
        public decimal LastVolume { get; set; }

        // TODO convert to DateTime using a jsonConverter.
        [JsonPropertyName("trade_date")]
        public long TradeDate { get; set; }

        [JsonPropertyName("prevclose")]
        public decimal PrevClose { get; set; }

        [JsonPropertyName("week_52_high")]
        public decimal Week52High { get; set; }

        [JsonPropertyName("week_52_low")]
        public decimal Week52Low { get; set; }

        [JsonPropertyName("bidsize")]
        public int BidSize { get; set; }

        [JsonPropertyName("bidexch")]
        public string BidExchangeCode { get; set; }

        [JsonPropertyName("bid_date")]
        public long BidDate { get; set; }

        [JsonPropertyName("asksize")]
        public int AskSize { get; set; }

        [JsonPropertyName("askexch")]
        public string AskExchangeCode { get; set; }

        [JsonPropertyName("ask_date")]
        public long AskDate { get; set; }

        [JsonPropertyName("root_symbols")]
        public string RootSymbols { get; set; }
    }

    /// <summary>
    /// Represents the UnmatchedSymbol object from Tradiers API QUOTE request.
    /// Stores the symbols aka ticker of the stocks requested that couldn't be found by Tradier.
    /// </summary>
    public class UnmatchedSymbols
    {
        [JsonPropertyName("symbol")]
        public List<string> Symbol { get; set; }
    }

    /// <summary>
    /// Represents the Quotes object from Tradiers API QUOTE request.
    /// this object has a List of Quotes and an UnmatchedSymbols object.
    /// </summary>
    public class Quotes
    {
        [JsonPropertyName("quote")]
        public List<Quote> Quote { get; set; }

        [JsonPropertyName("unmatched_symbols")]
        public UnmatchedSymbols UnmatchedSymbols { get; set; }
    }

    /// <summary>
    /// Root class represents the top object returned by the Tradier API QUOTES request
    /// which just holds the quotes object.
    /// </summary>
    public class Root
    {
        [JsonPropertyName("quotes")]
        public Quotes Quotes { get; set; }
    }

}