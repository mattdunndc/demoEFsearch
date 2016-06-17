'use strict';
app.controller('ProjectController', function ($scope, odataService, notificationFactory, apiService) {
    // Get Top 10 Employees
    notificationFactory.info('Loading Projects...');

    $scope.getProjects = function () {
        (new odataService()).$getTop1000({ entity: 't_proj_project' })
            .then(function (data) {

                $scope.currentPage = 1;
                $scope.pageSize = 10;

                $scope.projects = data.value;

                $scope.pageChangeHandler = function (num) {
                    console.log('page changed to ' + num);
                };
                notificationFactory.success('Projects loaded.');

            });
    };
    $scope.getProjects(); // does initial load replaces ng-init


    //getDepts();
    //function getDepts() {
    //    apiService.getEntity('t_dept_smart')
    //        .then(function (response) {
    //            $scope.depts = response.data;
    //            $scope.currentPage = 1;
    //            $scope.pageSize = 10;

    //            $scope.banks = data.value;

    //            $scope.pageChangeHandler = function (num) {
    //                console.log('page changed to ' + num);
    //            };

    //        }, function (error) {
    //            $scope.message = 'Unable to load data: ' + error.message;
    //        });
    //}
    

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname; //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    };

        //$scope.message = 'Contact controller loaded';
    }

);
