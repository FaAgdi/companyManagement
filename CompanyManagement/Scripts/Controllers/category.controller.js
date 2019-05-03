angular.module('App')
    .controller('CategoryController', ['$scope', 'CategoryService', function ($scope, CategoryService) {
        $scope.categories =  CategoryService.GetAllCategories();

    }]);