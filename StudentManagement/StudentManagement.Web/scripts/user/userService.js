app.service('userService', ["httpProxy", function (httpProxy) {
    var userService = {};

    userService.create = function (createUserModel) {
        return httpProxy.post("api/user/", createUserModel);
    };
    userService.edit = function (user) {
        return httpProxy.put("api/user/", user);
    };
    userService.remove = function (id) {
        return httpProxy.Delete("api/user/" + id);
    };

    userService.getUsers = function () {
        return httpProxy.get("api/user");
    };
    userService.getUsersByName = function (searchUserModel) {
        return httpProxy.post("api/user/search/", searchUserModel);
    };
    userService.getUserById = function (id) {
        return httpProxy.get("api/user/" + id);
    };
    userService.Login = function (loginUserModel) {
        return httpProxy.get("api/user/login", loginUserModel);
    }
    
    return userService;
}]);
