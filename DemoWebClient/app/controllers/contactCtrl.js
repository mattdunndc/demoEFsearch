'use strict';
app.controller('ContactController', function ($scope, odataService, notificationFactory) {
    // Get Top 10 Employees
    notificationFactory.info('Loading States...');
    $scope.getBanks = function () {
        (new odataService()).$getTop1000({ entity: 't_stcd_state_cd' })
            .then(function (data) {

                $scope.currentPage = 1;
                $scope.pageSize = 10;

                $scope.banks = data.value;

                $scope.pageChangeHandler = function (num) {
                    console.log('page changed to ' + num);
                };
                notificationFactory.success('States loaded.');
                
            });
    };
    $scope.getBanks(); // does initial load replaces ng-init
    

    $scope.sort = function (keyname) {
        $scope.sortKey = keyname; //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    };

        //$scope.message = 'Contact controller loaded';
    }

);
