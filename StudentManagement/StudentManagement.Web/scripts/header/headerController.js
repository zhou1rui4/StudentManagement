app.controller('headerController', ['$scope', "$rootScope",
    function ($scope, $rootScope) {
        $scope.switchViewMode = function () {
            $rootScope.isMini = !$rootScope.isMini;
        };
    }]);