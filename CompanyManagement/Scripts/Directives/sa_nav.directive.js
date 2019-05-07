angular.module('App')
    .directive('saNav', ['$http', '$compile', function ($http, $compile) {
        return {
            restrict: 'E',
            scope: {
                url: '=',
                id: '='
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
                        angular.element(document.getElementById(scope.id)).empty();
                        angular.element(document.getElementById(scope.id)).append($compile(response.data)(scope));
                        history.pushState({}, null, scope.url);
                    })
                });

            },
        }

    }]);