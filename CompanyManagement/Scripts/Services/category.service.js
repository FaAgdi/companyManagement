angular.module('App')
    .service('CategoryService', ['$http', function ($http) {
        this.GetAllCategories = function () {
            var response = $http({
                method: 'Get',
                url: '/Category/GetCategories',
                datatype: 'Json'
            });
            return response;
        }
    }]);