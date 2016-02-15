app.service('studentService', ["httpProxy", function (httpProxy) {
    var studentService = {};

    studentService.create = function (student) {
        return httpProxy.post("api/student/", student);
    };
    studentService.AddScore = function (searchStudentScoreNodel) {
        return httpProxy.post("api/studentscore/", searchStudentScoreNodel);
    };
    studentService.edit = function (student) {
        return httpProxy.put("api/student/", student);
    };
    studentService.remove = function (id) {
        return httpProxy.Delete("api/student/" + id);
    };

    studentService.getStudents = function () {
        return httpProxy.get("api/student");
    };
    studentService.getStudentsByName = function (searchStudentModel) {
        return httpProxy.post("api/student/search/", searchStudentModel);
    };
    studentService.getStudentById = function (id) {
        return httpProxy.get("api/student/" + id);
    };
    return studentService;
}]);
