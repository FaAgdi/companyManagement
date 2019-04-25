angular.module('App')
    .controller('LoginController', ['$scope', 'LoginService', '$location', function ($scope, LoginService, $location) {
        $scope.Login = function () {
            var user = { email: $scope.email, password: $scope.password };
            LoginService.Login(user);


        }
        //$scope.Register = function () {
        //    window.location.href = "/Home/Register";
        //}
    }]);