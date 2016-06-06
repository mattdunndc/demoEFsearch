'use strict';
app.controller('InstitutionController', function ($scope, odataService, notificationFactory,$location) {
    // Get Top 10 Employees
    ////(new odataService()).$getTop1000({ entity: 't_inst_institutn' })
    /// (new odataService()).$getEntityID({ entity: 't_inst_institutn', id:957})
    
    notificationFactory.info('Loading Banks...');
    $scope.getBanks = function () {
        (new odataService()).$getTop1000({ entity: 't_inst_institutn' })
            .then(function (data) {

                $scope.currentPage = 1;
                $scope.pageSize = 10;

                $scope.banks = data.value;

                $scope.pageChangeHandler = function (num) {
                    console.log('page changed to ' + num);
                };
                notificationFactory.success('Banks loaded.');
                
            });
    };
    $scope.getBanks(); // does initial load replaces ng-init
    
    $scope.sort = function (keyname) {
        $scope.sortKey = keyname; //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    };


    $scope.goEdit = function (bank) {
        $scope.eBank = bank;
        //notificationFactory.success('go edit location.');
        $location.path('/Home/Institution/edit/'+bank.inst_id);

    };

    $scope.changeView = function (view) {
        notificationFactory.info('change view.');
        $location.path(view);
    };
    
    //$scope.message = 'Institution controller loaded';
    }

);
