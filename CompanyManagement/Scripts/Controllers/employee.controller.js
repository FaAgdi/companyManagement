angular.module('App')
    .controller('EmployeeController', ['$scope', 'EmployeeService', function ($scope, EmployeeService) {
        $scope.employees = [];
        $scope.templateUrl = '/Employee/Index';
        $scope.msg = function () {
            alert('Message d alert')
        }
        var formatterJsonToDate = function (d) {
            var re = /\/Date\(([0-9]*)\)\//;
            var m = d.match(re);
            if (m) {
                var MyDate = new Date(parseInt(m[1]))
                return $filter('date')(MyDate, 'dd/MM/yyyy');
            }
            else {
                return null;
            }
        };
        EmployeeService.GetAllEpmloyees().then(function (response) {
            $scope.employees = response.data;
            angular.forEach($scope.employees, function (value, key) {
                value.birthday = formatterJsonToDate(value.birthday);
            });
        }, function (error) {
            console.log(error);
        });

        

    }]);