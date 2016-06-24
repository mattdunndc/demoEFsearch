﻿'use strict';
app.controller('InstitutionAddEditController', function (odataService, notificationFactory, $routeParams) {
    // Get Top 10 Employees
    ////(new odataService()).$getTop1000({ entity: 't_inst_institutn' })
    /// (new odataService()).$getEntityID({ entity: 't_inst_institutn', id:957})

    var vm = this;
    vm.bank = {};
    vm.states = [];
    
    /// (new odataService()).$getEntityID({ entity: 't_inst_institutn', id:957})
    vm.getBank = function () {
        (new odataService()).$getEntityID({ entity: 't_inst_institutn', id: $routeParams.id })
            .then(function (data) {
                
                vm.bank = data;
                //console.log('bank: '+vm.bank.inst_short_name);
                notificationFactory.success('Single Bank loaded.' +$routeParams.id);
            });
    };
    vm.getBank(); // does initial load replaces ng-init
    
    vm.getStates = function () {
        (new odataService()).$getAll({ entity: 't_stcd_state_cd' })
            .then(function (data) {

                vm.states = data.value;
                notificationFactory.success('States loaded.');
            });
    };
    vm.getStates();

    vm.changeState = function() {
        vm.inst_actv_in ? 'Y' : 'N';
        notificationFactory.success('toggled?');
    };

    vm.saveBank = function () {
        
        if (vm.bank) {
                return (new odataService({
                    "inst_short_name": vm.bank.inst_short_name,
                    "inst_loc_city_name": vm.bank.inst_loc_city_name,
                    "inst_loc_st_abbrv": vm.bank.inst_loc_st_abbrv,
                    "inst_loc_zip_code": vm.bank.inst_loc_zip_code,
                    "inst_actv_in": vm.bank.inst_actv_in
                })).$patchID({ entity: 't_inst_institutn', id: $routeParams.id  })
                    .then(function(data) {
                        notificationFactory.success('Bank with ID ' + vm.bank.inst_id + ' updated.')
                    }, function() {
                        notificationFactory.error('Bank with ID ' + vm.bank.inst_id + ' not updated.')
                        }
                    );
        }
    }; //saveBank function

        //// Update Selected Employee
        //    $scope.updateBank = function () {
        //        var currentEmployee = $scope.currentEmployee;
        //        console.log(currentEmployee.Email);
        //        if (currentEmployee) {
        //            return (new odataService({
        //                "ID": currentEmployee.ID,
        //                "FirstName": currentEmployee.FirstName,
        //                "Surname": currentEmployee.Surname,
        //                "Email": currentEmployee.Email
        //            })).$patchID({ entity: 't_inst_institutn', id: currentEmployee.ID })
        //            .then(function (data) {
        //                notificationFactory.success('Employee with ID ' + currentEmployee.ID + ' updated.')
        //            });
        //        }
        //    }

    }

);