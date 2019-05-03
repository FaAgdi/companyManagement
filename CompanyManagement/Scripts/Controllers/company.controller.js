angular.module('App')
    .controller('CompanyController', ['$scope', 'CompanyService', function ($scope, CompanyService) {
        $scope.companies = CompanyService.GetAllCompanies();
        
    }]);