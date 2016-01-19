//Encapsulates data calls to server (AJAX calls)
var dataService = new function () {
    var serviceBase = '/DataService/',
        getAccount = function(callback) {

        },

        getMarketIndexes = function(callback) {
            $.getJSON(serviceBase + 'GetMarketIndexes', function(data) {
                callback(data);
            });
        },

        getQuote = function(sym, callback) {
            $.getJSON(serviceBase + 'GetQuote', { symbol: sym }, function(data) {
                callback(data);
            });
        },

        getTickerQuotes = function(callback) {
            $.getJSON(serviceBase + 'GetTickerQuotes', function(data) {
                callback(data);
            });
        };

    return {
        getAccount: getAccount,
        getMarketIndexes: getMarketIndexes,
        getQuote: getQuote,
        getTickerQuotes: getTickerQuotes
    };

} ();