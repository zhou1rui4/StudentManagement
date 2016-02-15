app.factory("httpProxy", ["$http", "$q", "apiTools", "ipCookie", function ($http, $q, apiTools, ipCookie) {
    var baseUrl = apiTools.getApiUrl();
    var getHeaders = function() {
        var offset = new Date().getTimezoneOffset() / 60;
        var language = ipCookie("lang") || "sv";
        return {
            "TimeZoneOffset": -offset,
            "lang": language
        };
    };
    return {
        get: function (action, option) {
            var deferred = $q.defer();
            var defaultOption = {
                method: "Get",
                headers: getHeaders(),
                url: baseUrl + action,
                cache: false
            };
            option = $.extend(defaultOption, option);
            $http(option).success(function (data) {
                deferred.resolve(data);
            }).error(function (data, status) {
                if (navigator.userAgent.indexOf("MSIE 10.0") > 0 && data == null && status == 404) {
                    data = { Code: 401, Errors: ["Unauthorized"] };
                }
                deferred.reject(data);
            });

            return deferred.promise;
        },

        post: function (action, data, option) {
            var deferred = $q.defer();
            var defaultOption = {
                method: "Post",
                headers: getHeaders(),
                crossDomain: true,
                data: data,
                url: baseUrl + action,
                cache: false
            };
            option = $.extend(defaultOption, option);
            $http(option).success(function (successResult) {
                deferred.resolve(successResult);
            }).error(function (errorResult, status) {
                if (navigator.userAgent.indexOf("MSIE 10.0") > 0 && errorResult == null && status == 404) {
                    errorResult = { Code: 401, Errors: ["Unauthorized"] };
                }
                deferred.reject(errorResult);
            });

            return deferred.promise;
        },

        put: function (action, data, option) {
            var deferred = $q.defer();
            var defaultOption = {
                method: "Put",
                headers: getHeaders(),
                data: data,
                url: baseUrl + action,
                cache: false
            };
            option = $.extend(defaultOption, option);
            $http(option).success(function (successResult) {
                deferred.resolve(successResult);
            }).error(function (errorResult) {
                if (navigator.userAgent.indexOf("MSIE 10.0") > 0 && errorResult == null && status == 404) {
                    errorResult = { Code: 401, Errors: ["Unauthorized"] };
                }
                deferred.reject(errorResult);
            });

            return deferred.promise;
        },

        Delete: function (action, option) {
            var deferred = $q.defer();
            var defaultOption = {
                method: "Delete",
                headers: getHeaders(),
                url: baseUrl + action,
                cache: false
            };
            option = $.extend(defaultOption, option);
            $http(option).success(function (successResult) {
                deferred.resolve(successResult);
            }).error(function (errorResult) {
                if (navigator.userAgent.indexOf("MSIE 10.0") > 0 && errorResult == null && status == 404) {
                    errorResult = { Code: 401, Errors: ["Unauthorized"] };
                }
                deferred.reject(errorResult);
            });

            return deferred.promise;
        },

        Download: function (action, data, option, successCallback, errorCallback) {
            var defaultOption = {
                method: "Post",
                url: baseUrl + action,
                headers: getHeaders(),
                cache: false,
                data: data
            };
            option = $.extend(defaultOption, option);
            $http(option).success(successCallback).error(errorCallback);
        }
    };
}]);