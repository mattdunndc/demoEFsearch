var userCtrl = function ($scope, odataService, notificationFactory) {
    // Get Top 10 Employees
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

    $scope.sort = function(keyname) {
        $scope.sortKey = keyname; //set the sortKey to the param passed
        $scope.reverse = !$scope.reverse; //if true make it false and vice versa
    };
}
mod.controller('userCtrl', userCtrl);