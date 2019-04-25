angular.module('App')
    .service('LoginService', ['$http', function ($http) {
        this.Login = function (user) {
            var response = $http({
                method: 'Post',
                url: '/Home/Login',
                datatype: 'Json',
                data: JSON.stringify(user)
            });
            return response;
        }


    }]);