angular.module('App')
    .controller('LayoutController', ['$scope', '$http', '$compile', function ($scope, $http, $compile) {
     
        var GetPartialView = function (PartialView) {
            var response = $http({
                method: 'Get',
                url: PartialView,
                datatype: 'Json'
            });
            return response;
        }

        $scope.PartialView = function (PartialView) {
            GetPartialView(PartialView).then(function (response) {
                angular.element(document.getElementById('result')).empty();
                angular.element(document.getElementById('result')).append($compile(response.data)($scope));
            })
        }
    }]);
