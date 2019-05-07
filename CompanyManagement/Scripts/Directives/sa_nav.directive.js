angular.module('App')
    .directive('saNav', ['$http', '$compile', function ($http, $compile) {
        return {
            restrict: 'E',
            scope: {
                url : '='
            },
            link: function (scope, element, attrs) {
                
                function getPartialView() {
                    var response = $http({
                        method: 'Get',
                        url: scope.url,
                        datatype: 'Json'
                    });
                    return response;

                }

                element.bind('click', function () {
                    getPartialView().then(function (response) {
                        angular.element(document.getElementById('result')).empty();
                        angular.element(document.getElementById('result')).append($compile(response.data)(scope));

                    })
                });
            },
        }

    }]);