'use strict';
app.controller('ProjectAddEditController', function (odataService, notificationFactory, $routeParams, apiService) {
    // Get Top 10 Employees
    ////(new odataService()).$getTop1000({ entity: 't_inst_institutn' })
    /// (new odataService()).$getEntityID({ entity: 't_inst_institutn', id:957})

    var vm = this;
    vm.projId = ($routeParams.id) ? parseInt($routeParams.id) : 0;
    vm.project = {};
    vm.users = [];
    
    /// (new odataService()).$getEntityID({ entity: 't_inst_institutn', id:957})
    vm.getProject = function () {
        (new odataService()).$getEntityID({ entity: 't_proj_project', id: $routeParams.id })
            .then(function(data) {
                // promise fulfilled
                vm.project = data;
                vm.project.proj_start_dt = new Date(vm.project.proj_start_dt);
                vm.project.proj_end_dt = new Date(vm.project.proj_end_dt); // for type="date" binding on datepicker
                console.log('userid: ' + vm.project.proj_contact_user_id);
                notificationFactory.success('Project loaded.' + $routeParams.id);
            }, function(error) {
                ///promise rejected
                vm.project.proj_project_nm = "New Project";
                vm.project.pobj_project_type_cd = "DFAST";
                vm.project.proj_start_dt = new Date();
                vm.project.proj_end_dt = new Date(new Date().setDate(new Date().getDate()+30));
                vm.project.proj_active_in = "Y";
                //notificationFactory.success('reject' + $routeParams.id);
            });
    };
    vm.getProject(); // does initial load replaces ng-init
    
    ///////////
    function getUsers() {
        apiService.getEntity('users')
            .then(function (response) {
                vm.users = response.data;
                notificationFactory.success('Users loaded.');
            }, function (error) {
                vm.message = 'Unable to load data: ' + error.message;
            });
    }
    getUsers();

    //t_rwid_row_id



    vm.saveProject = function () {


        if (vm.project) {
            return (new odataService({
                "proj_project_nm": vm.project.proj_project_nm,
                "pobj_project_type_cd": vm.project.pobj_project_type_cd,
                "proj_start_dt": vm.project.proj_start_dt,
                "proj_end_dt": vm.project.proj_end_dt,
                "proj_contact_user_id": vm.project.proj_contact_user_id,
                "proj_active_in": vm.project.proj_active_in,
                "proj_last_updt_user_id": vm.project.proj_contact_user_id
            })).$patchID({ entity: 't_proj_project', id: $routeParams.id })
                .then(function (data) {
                    notificationFactory.success('Project with ID ' + vm.project.proj_id + ' updated.')
                }, function () {
                    notificationFactory.error('Project with ID ' + vm.project.proj_id + ' not updated.')
                }
                );
        }


    }; //saveBank function

        
});