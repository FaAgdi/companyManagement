angular.module('App', ['ui.bootstrap', 'ui.grid', 'ui.grid.pagination'])
    .config(['$qProvider', '$httpProvider', function ($qProvider, $httpProvider) {
    $qProvider.errorOnUnhandledRejections(false);
    $httpProvider.defaults.headers.common["X-Requested-With"] = 'XMLHttpRequest';
    
}]);