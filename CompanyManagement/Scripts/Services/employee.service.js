angular.module('App')
    .service('EmployeeService', ['$http', function ($http) {
        this.GetAllEpmloyees = function () {
            var response = $http({
                method: 'Get',
                url: '/Employee/GetEmployees',
                datatype: 'Json'
            });
            return response;
        }
    }]);