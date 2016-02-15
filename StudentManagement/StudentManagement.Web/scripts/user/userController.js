app.controller("userController", [
    "$scope", '$window', "$rootScope", "$modal", "$location", "userService", "ipCookie",
    function ($scope, $window, $rootScope, $modal, $location, userService, ipCookie) {
        $scope.dataLoaded = false;
        $scope.dataUpdating = false;
        $scope.searchUserName = "";
        $scope.users = {};
        $scope.dataListShowLoading = false;
        $rootScope.currentPage = $location.path().replace("/", "");

        function getAllData() {
            $scope.dataListShowLoading = true;
            userService.getUsers().then(function (data) {
                $scope.dataListShowLoading = false;
                $scope.users = data;
            });
        }

        getAllData();

        $scope.searchUser = function () {
            if ($scope.searchUserName === "") {
                return;
            }
            var searchUser = new searchUserModel($scope.searchUserName);
            userService.getUsersByName(searchUser).then(function (data) {
                $scope.dataListShowLoading = false;
                $scope.users = data;
            }
            );
        }

        $scope.addUser = function () {
            $scope.isUpdating = false;
            $scope.user = new createNewUser();
            var addUser = $modal.open({
                templateUrl: 'userModal',
                controller: addUserCtrl,
                backdrop: 'static',
                resolve: { user: function () { return $scope.user; } }
            });

            addUser.result.then(function () {
                getAllData();
            }, function (error) {
            });
        }

        $scope.editUser = function (user) {
            $scope.user = angular.copy(user);
            var userCopy = {};
            angular.copy($scope.user, userCopy);
            var editStudent = $modal.open({
                templateUrl: 'userModal',
                controller: editUserCtrl,
                backdrop: 'static',
                resolve: { user: function () { return userCopy; } }
            });
            editStudent.result.then(function () {
                getAllData();
            }, function (error) {
            });
        };

        $scope.deleteUser = function (user) {

            var deleteStudent = $modal.open({
                templateUrl: 'deleteUserModal',
                controller: deleteUserCtrl,
                backdrop: 'static',
                resolve: { user: function () { return user; } }
            });

            deleteStudent.result.then(function (s) {
                getAllData();
            }, function (error) {

            });
        };
        var addUserCtrl = ["$scope", "$rootScope", "$modalInstance", "userService", "user",
    function ($scope, $rootScope, $modalInstance, visitorLogService, user) {

        $scope.BasicLocations = {};
        $scope.isUpdating = false;

        $scope.user = angular.copy(user);

        $scope.ok = function () {
            var userInfo = angular.copy($scope.user);
            $scope.isUpdating = true;
            visitorLogService.create(userInfo).then(function () {
                $modalInstance.close();
            }, function (error) {
                $scope.isUpdating = false;
            });
        };

        $scope.cancel = function () {
            $modalInstance.dismiss();
        };
    }];

        var editUserCtrl = ["$scope", "$rootScope", "$modalInstance", "userService", "user",
            function ($scope, $rootScope, $modalInstance, userService, user) {

                $scope.BasicLocations = {};

                $scope.isUpdating = false;

                $scope.user = angular.copy(user);

                $scope.ok = function () {
                    $scope.isUpdating = true;
                    var userInfo = angular.copy($scope.user);
                    userService.edit(userInfo).then(function () {
                        $modalInstance.close();
                    }, function (error) {
                        $scope.isUpdating = false;
                    });
                };

                $scope.cancel = function () {
                    $modalInstance.dismiss();
                };
            }];

        var deleteUserCtrl = ["$scope", "$rootScope", "$modalInstance", "userService", "user",
        function ($scope, $rootScope, $modalInstance, userService, user) {
            $scope.deleteUser = user;
            $scope.isUpdating = false;
            $scope.ok = function () {
                $scope.isUpdating = true;
                userService.remove(user.Id).then(function () {
                    $modalInstance.close(user);
                });
            };

            $scope.cancel = function () {
                $modalInstance.dismiss();
            };
        }];

        function createNewUser() {
            return {
                Id: "",
                UserName: "",
                Password: "",
                ConfirmPassword: ""
            };
        }
    }
]);