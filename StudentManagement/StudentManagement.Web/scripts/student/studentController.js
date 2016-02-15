app.controller("studentController", ["$scope", '$window', "$rootScope", "$modal", "$location", "studentService", "ipCookie",
function ($scope, $window, $rootScope, $modal, $location, studentService, ipCookie) {

    $scope.dataLoaded = false;
    $scope.dataUpdating = false;
    $scope.searchFirstName = "";
    $scope.searchLastName = "";
    $scope.students = {};
    $scope.dataListShowLoading = false;
    $rootScope.currentPage = $location.path().replace("/", "");

    function getAllData() {
        $scope.dataListShowLoading = true;
        studentService.getStudents().then(function (data) {
            $scope.dataListShowLoading = false;
            $scope.students = data;
        });
    }

    getAllData();

    $scope.searchStudent = function () {
        if ($scope.searchFirstName === "" && $scope.searchLastName === "") {
            return;
        }
        var searchStudent = new searchStudentModel($scope.searchFirstName, $scope.searchLastName);
        studentService.getStudentsByName(searchStudent).then(function (data) {
            $scope.dataListShowLoading = false;
            $scope.students = data;
        });
    }

    $scope.deleteStudent = function (student) {

        var deleteStudent = $modal.open({
            templateUrl: 'deleteStudentModal',
            controller: deleteStudentCtrl,
            backdrop: 'static',
            resolve: { student: function () { return student; } }
        });

        deleteStudent.result.then(function (s) {
            getAllData();
        }, function (error) {

        });
    };

    $scope.editStudent = function (student) {
        $scope.company = angular.copy(student);
        var studentCopy = {};
        angular.copy(student, studentCopy);
        var editStudent = $modal.open({
            templateUrl: 'studentModal',
            controller: editStudentCtrl,
            backdrop: 'static',
            resolve: { student: function () { return studentCopy; } }
        });
        editStudent.result.then(function () {
            getAllData();
        }, function (error) {
        });
    };



    $scope.addStudent = function () {
        $scope.isUpdating = false;
        $scope.student = {};
        var addStudent = $modal.open({
            templateUrl: 'studentModal',
            controller: addStudentCtrl,
            backdrop: 'static',
            resolve: { student: function () { return $scope.student; } }
        });

        addStudent.result.then(function () {
            getAllData();
        }, function (error) {
        });
    };


    var addStudentCtrl = ["$scope", "$rootScope", "$modalInstance", "studentService", "student",
    function ($scope, $rootScope, $modalInstance, visitorLogService, student) {

        $scope.BasicLocations = {};
        $scope.isUpdating = false;

        $scope.student = angular.copy(student);

        $scope.ok = function () {
            var studentInfo = angular.copy($scope.student);
            $scope.isUpdating = true;
            visitorLogService.create(studentInfo).then(function () {
                $modalInstance.close();
            }, function (error) {
                $scope.isUpdating = false;
            });
        };

        $scope.cancel = function () {
            $modalInstance.dismiss();
        };
    }];

    var editStudentCtrl = ["$scope", "$rootScope", "$modalInstance", "studentService", "student",
        function ($scope, $rootScope, $modalInstance, studentService, student) {

            $scope.BasicLocations = {};

            $scope.isUpdating = false;

            $scope.student = angular.copy(student);

            $scope.ok = function () {
                $scope.isUpdating = true;
                var studentInfo = angular.copy($scope.student);
                studentService.edit(studentInfo).then(function () {
                    $modalInstance.close();
                }, function (error) {
                    $scope.isUpdating = false;
                });
            };

            $scope.cancel = function () {
                $modalInstance.dismiss();
            };
        }];

    var deleteStudentCtrl = ["$scope", "$rootScope", "$modalInstance", "studentService", "student",
    function ($scope, $rootScope, $modalInstance, studentService, student) {
        $scope.deleteStudent = student;
        $scope.isUpdating = false;
        $scope.ok = function () {
            $scope.isUpdating = true;
            studentService.remove(student.Id).then(function () {
                student.Deleted = true;
                $modalInstance.close(student);
            });
        };

        $scope.cancel = function () {
            $modalInstance.dismiss();
        };
    }];

    function searchStudentModel(firstName, lastName) {
        return {
            FirstName: firstName,
            LastName: lastName
        };
    }

    $scope.AddStudentScore = function (student) {

        var studentScoreCopy = new CreateStudentScoreModel(student.Id);
        var editStudent = $modal.open({
            templateUrl: 'StudentScoreModal',
            controller: addStudentScoreCtrl,
            backdrop: 'static',
            resolve: { studentScore: function () { return studentScoreCopy; } }
        });
       
    };

    var addStudentScoreCtrl = ["$scope", "$rootScope", "$modalInstance", "studentService", "studentScore",
   function ($scope, $rootScope, $modalInstance, studentService, studentScore) {

       $scope.BasicLocations = {};
       $scope.isUpdating = false;

       $scope.studentScore = angular.copy(studentScore);

       $scope.ok = function () {
           var studentScoreInfo = angular.copy($scope.studentScore);
           $scope.isUpdating = true;
           studentService.AddScore(studentScoreInfo).then(function () {
               $modalInstance.close();
           }, function (error) {
               $scope.isUpdating = false;
           });
       };

       $scope.cancel = function () {
           $modalInstance.dismiss();
       };
   }];
}]);

function CreateStudentScoreModel(studentId) {
    return {
        StudentId: studentId,
        Course: "",
        Score: "",
        ExamTime:""
    };
}
