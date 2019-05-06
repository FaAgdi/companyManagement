angular.module('App')
    .controller('LayoutController', ['$scope', '$http', '$compile', function ($scope, $http, $compile) {
     
        var GetPartialView = function (PV) {
            var response = $http({
                method: 'Get',
                url: PV,
                datatype: 'Json'
            });
            return response;
        }

        $scope.PartialView = function (PV) {
            GetPartialView(PV).then(function (response) {
                angular.element(document.getElementById('result')).empty();
                angular.element(document.getElementById('result')).append($compile(response.data)($scope));
            })
        }
    }]);
