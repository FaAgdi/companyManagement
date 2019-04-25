angular.module('App', ['ui.bootstrap', 'ui.grid', 'ui.grid.pagination']).config(['$qProvider', function ($qProvider) {
    $qProvider.errorOnUnhandledRejections(false);

}]);;