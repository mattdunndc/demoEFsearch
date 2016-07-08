'use strict';
app.controller('ProjectAddEditController', function (odataService, notifyService, $routeParams, apiService) {
    // Get Top 10 Employees
    ////(new odataService()).$getTop1000({ entity: 't_inst_institutn' })
    /// (new odataService()).$getEntityID({ entity: 't_inst_institutn', id:957})

    var vm = this;
    var projId = ($routeParams.id) ? parseInt($routeParams.id) : 0;
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
                notifyService.success('Project loaded.' + $routeParams.id);
            }, function(error) {
                ///promise rejected
                vm.project.proj_project_nm = "New Project";
                vm.project.pobj_project_type_cd = "DFAST";
                vm.project.proj_start_dt = new Date();
                vm.project.proj_end_dt = new Date(new Date().setDate(new Date().getDate()+30));
                vm.project.proj_active_in = "Y";
                //notifyService.success('reject' + $routeParams.id);
            });
    };
    vm.getProject(); // does initial load replaces ng-init
    
    ///////////
    function getUsers() {
        apiService.getEntity('users')
            .then(function (response) {
                vm.users = response.data;
                notifyService.success('Users loaded.');
            }, function (error) {
                vm.message = 'Unable to load data: ' + error.message;
            });
    }
    getUsers();
    
    //t_rwid_row_id
    //http://localhost:55580/api/vvlu/pobj_project_type_cd
    ///////////
    function getProjectTypes() {
        apiService.getEntity('vvlu/pobj_project_type_cd')
            .then(function (response) {
                vm.projectTypes = response.data;
                notifyService.success('Project Types loaded.');
            }, function (error) {
                vm.message = 'Unable to load data: ' + error.message;
            });
    }
    getProjectTypes();


    vm.saveProject = function () {
        
        if (vm.project && projId > 0) {
            
            return (new odataService({
                    "proj_project_nm": vm.project.proj_project_nm,
                    "proj_project_desc_tx": vm.project.proj_project_desc_tx,
                    "pobj_project_type_cd": vm.project.pobj_project_type_cd,
                    "proj_start_dt": vm.project.proj_start_dt,
                    "proj_end_dt": vm.project.proj_end_dt,
                    "proj_contact_user_id": vm.project.proj_contact_user_id,
                    "proj_active_in": vm.project.proj_active_in,
                    "proj_last_updt_user_id": vm.project.proj_contact_user_id
                })).$patchID({ entity: 't_proj_project', id: $routeParams.id })
                .then(function(data) {
                    notifyService.success('Project with ID ' + vm.project.proj_id + ' updated.')
                    }, function() {
                    notifyService.error('Project with ID ' + vm.project.proj_id + ' not updated.')
                    }
                );
        } else {
            vm.getNextId();
            return (new odataService({
                "proj_id": vm.nextId.value,
                "proj_project_nm": vm.project.proj_project_nm,
                "proj_project_desc_tx": vm.project.proj_project_desc_tx,
                "pobj_project_type_cd": vm.project.pobj_project_type_cd,
                "proj_start_dt": vm.project.proj_start_dt,
                "proj_end_dt": vm.project.proj_end_dt,
                "proj_contact_user_id": vm.project.proj_contact_user_id,
                "proj_active_in": vm.project.proj_active_in,
                "proj_last_updt_user_id": vm.project.proj_contact_user_id,
                "proj_last_updt_ts": new Date()    //vm.project.proj_start_dt
            })).$insert({ entity: 't_proj_project' })
                .then(function (data) {
                    notifyService.success('Project with ID ' + vm.nextId.value + ' inserted.')
                }, function () {
                    notifyService.error('Project with ID ' + vm.nextId.value + ' not inserted.')
                }
                );
        } // if else
    }; //saveBank function



  
    /// (new odataService()).$getEntityID({ entity: 't_inst_institutn', id:957})
    vm.getNextId = function () {
        (new odataService()).$getAll({ entity: 'GetNextId' })
            .then(function (data) {
                // promise fulfilled
                vm.nextId = data;
                notifyService.success('Next ID is ' + vm.nextId.value);
            }, function (error) {
                ///promise rejected
                //notifyService.success('reject' + $routeParams.id);
            });
    };
    vm.getNextId(); // does initial load replaces ng-init
        
});