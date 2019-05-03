angular.module('App')
    .controller('EmployeeController', ['$scope', '$filter', 'EmployeeService', '$controller', 'uibDateParser', function ($scope, $filter, EmployeeService, $controller, uibDateParser) {
        $controller('CompanyController', { $scope: $scope })
        $controller('CategoryController', { $scope: $scope })
        $scope.employees = [];
        $scope.employee = {};
        $scope.Text = '';
        $scope.format = 'dd/MM/yyyy';
        $scope.employee.birthday = uibDateParser.parse($scope.employee.birthday, 'dd/MM/yyyy');
        $scope.flag = 'Add';
        $scope.gridOptions = {};
        $scope.gridApi = {};
        $scope.NewErrors = {};

        $scope.Listcompanies = []
        $scope.companies.then(function (response) {
            $scope.Listcompanies = response.data;
        });;
        $scope.Listcategories = []
        $scope.categories.then(function (response) {
            $scope.Listcategories = response.data;
        });



        // Convert Json to date 
        var formatterJsonToDate = function (d) {
            var re = /\/Date\(([0-9]*)\)\//;
            var m = d.match(re);
            if (m) {
                var MyDate = new Date(parseInt(m[1]))
                return $filter('date')(MyDate, 'dd/MM/yyyy');
            }
            else {
                return null;
            }
        };
        getAllEmployees();
        function getAllEmployees() {
            EmployeeService.GetAllEpmloyees().then(function (response) {
                $scope.employees = response.data;
                angular.forEach($scope.employees, function (value, key) {
                    value.birthday = formatterJsonToDate(value.birthday);
                });
            }, function (error) {
                console.log(error);
            });
        }



        //Grid
        $scope.gridOptions = {
            enableSelectAll: true,
            enableGridMenu: true,
            enableFiltering: true,
            useExternalFiltering: true,
            //data
            data: 'employees',
            //columns
            columnDefs: [
                { name: 'codeEmployee', displayName: 'Code', width: 150, enableFiltering: false },
                { name: 'nameEmployee', displayName: 'Full Name', width: 150, enableFiltering: false },
                { name: 'address', displayName: 'Address', width: 200, enableFiltering: false },
                { name: 'tel', displayName: 'Phone', width: 150, enableFiltering: false },
                { name: 'birthday', displayName: 'Birthday', width: 150, enableFiltering: false },
                { name: 'email', displayName: 'E-mail', width: 200, enableFiltering: false },
                { name: 'company.nameCompany', displayName: 'Company', width: 200, enableFiltering: false },
                { name: 'category.nameCategory', displayName: 'Category', width: 200, enableFiltering: false },
                { name: 'salary', displayName: 'Salary', width: 150, enableFiltering: false },
                { name: 'Action', displayName: 'Action', width: 100, enableFiltering: false, cellTemplate: "<div><a ng-click=\"grid.appScope.update(row.entity)\"><span  class=\"glyphicon glyphicon-edit\"></span></a>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<a ng-click=\"grid.appScope.showDelete(row.entity)\" ><span class=\"glyphicon glyphicon-remove\"></span></a></div>" },
            ],
            //pagination
            paginationPageSizes: [10, 20, 30],
            paginationPageSize: 20
        }

        //Filter
        $scope.gridOptions.onRegisterApi = function (gridApi) {
            $scope.gridApi = gridApi;
            $scope.gridApi.grid.registerRowsProcessor($scope.singleFilter, 200);
        }

        $scope.singleFilter = function (renderableRows) {
            var matcher = new RegExp($scope.Text, 'i');
            renderableRows.forEach(function (row) {
                var match = false;
                if (row.entity.nameEmployee.match(matcher)) {
                    match = true;
                }
                if (!match) {
                    row.visible = false;
                }
            });
            return renderableRows;
        };

        $scope.filter = function () {
            $scope.gridApi.grid.refresh();
        };


        // Click Button Add
        $scope.add = function () {
            $scope.employee = {};
            $scope.flag = 'Add';
            clear();
            $('#EmpPopup').modal('show');
        }

        //Click Button Update 

        $scope.update = function (employee) {
            var copyEmployee = angular.copy(employee);
            $scope.flag = 'Edit';
            var s = [];
            s = copyEmployee.birthday.split(/[\/-]/);
            copyEmployee.birthday = new Date(s[2] + '/' + s[1] + '/' + s[0]);
            $scope.employee = angular.copy(copyEmployee);
            clear();
            $('#EmpPopup').modal('show');

        }




        // Save
        $scope.save = function (employee) {
            if ($scope.frm.$valid && $scope.frm.$dirty) {
                if ($scope.flag == 'Add') {
                    //$scope.employee.birthday = $filter('date')($scope.employee.birthday, 'dd/MM/yyyy');
                    $scope.NewErrors = {};
                    EmployeeService.InsertEmployee(employee).then(function (response) {
                        $scope.message = '';
                        $scope.errors = [];
                        if (response.data.success === false) {
                            $scope.errors = response.data.errors;
                            ConvertToNewObject($scope.errors, "key");

                            $(".BackEndError").show();
                        }
                        else {
                            getAllEmployees();
                            $scope.message = 'Saved Successfully';
                            $scope.employee = {};

                            $('#EmpPopup').modal('hide');
                        }
                    }, function (error) {
                        $scope.errors = [];
                        $scope.message = 'Unexpected Error';
                    });
                } else if ($scope.flag == 'Edit') {
                    var u = $filter('filter')($scope.employees, { id: employee.codeEmployee }, true)[0];
                    var index = $scope.employees.indexOf(u);
                    $scope.employees.birthday = $filter('date')($scope.employees.birthday, 'dd/MM/yyyy');
                    if ($scope.employee.birthday) {
                        EmployeeService.UpdateEmployee(employee).then(function (response) {
                            $scope.message = '';
                            $scope.errors = [];
                            if (response.data.success === false) {
                                $scope.errors = response.data.errors;
                                ConvertToNewObject($scope.errors, "key");

                                $(".BackEndError").show();
                            }
                            else {
                                getAllEmployees();
                                $scope.message = 'Saved Successfully';
                                $scope.employee = {};

                                $('#EmpPopup').modal('hide');
                            }
                        }, function (error) {
                            $scope.errors = [];
                            $scope.message = 'Unexpected Error';
                        });
                    }

                }
                else {
                    alert("error");
                }
            }
        }

        // Click Button Delete

        $scope.showDelete = function (employee) {
            $scope.employee = employee;
            $('#RemovePopup').modal('show');
        }

        // Delete Employee
        $scope.delete = function (employee) {
            var index = $scope.employees.findIndex(function (el) {
                return el.id == employee.codeEmployee;
            });
            angular.forEach($scope.employees, function (value, key) {
                if (value.codeEmployee == employee.codeEmployee) {
                    EmployeeService.DeleteEmployee(employee);
                    $scope.employees.splice(index, 1);
                }
            });

            $('#RemovePopup').modal('hide');

        }


        // datepicker
        $scope.popup = {
            opened: false
        };

        $scope.open = function () {
            $scope.popup.opened = true;
        };


        $scope.dateOptions = {
            maxDate: new Date(2003, 12, 31),
            minDate: new Date(1970, 01, 01),
            startingDay: 1,

        };




        // Cancel
        $scope.cancel = function () {
            clear();
            $('#EmpPopup').modal('hide');
        }
        //Clear form 
        var clear = function () {
            $scope.frm.$rollbackViewValue();
            $scope.frm.$setPristine();
            $scope.frm.$setUntouched();
            $(".BackEndError").hide();
        }

        //function 
        function ConvertToNewObject(err, keyField) {
            angular.forEach(err, function (item) {
                $scope.NewErrors[item[keyField]] = item;
            })
        }
    }]);