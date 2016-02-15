'use strict';
var app = angular.module('app', ['ngRoute', 'ui.bootstrap', "ipCookie"]);

app.config(['$routeProvider', '$httpProvider',
 function ($routeProvider) {
     setRoute($routeProvider);
 }]);

app.run(['$rootScope', "ipCookie", "$http", "$location", function ($rootScope, ipCookie, $http, $location) {
    $rootScope.isMini = false;
    $rootScope.pageLoading = true;
    $rootScope.isShowMenu = true;
    $location.path("/student");
}]);

function setRoute($routeProvider) {
    $routeProvider.when("/student", {
        templateUrl: "../views/students.html",
        controller: "studentController"
    }).when("/user", {
        templateUrl: "../views/users.html",
        controller: "userController"
    });
}


