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

        this.InsertEmployee = function (employee) {
            var response = $http({
                method: 'Post',
                url: '/Employee/AddEmployee',
                data: JSON.stringify(employee),
                dataType: "json"
            })
            return response;
        }

        this.UpdateEmployee = function (employee) {
            var response = $http({
                method: "Post",
                url: '/Employee/UpdateEmployee',
                data: JSON.stringify(employee),
                dataType: "json"
            });
            return response;

        }

        this.DeleteEmployee = function (employee) {
            var response = $http({
                method: "Post",
                url: '/Employee/DeleteEmployee',
                data: JSON.stringify(employee),
                dataType: "json"
            });
            return response;

        };
    }]);