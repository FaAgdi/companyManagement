angular.module('App')
    .service('CompanyService', ['$http', function ($http) {
        this.GetAllCompanies = function () {
            var response = $http({
                method: 'Get',
                url: '/Company/GetCompanies',
                datatype: 'Json'
            });
            return response;
        }
    }]);