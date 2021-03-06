﻿app.factory('odataService', function ($resource) {
    var odataUrl = 'http://hqevdevlweb02:8066/odata/';
    //var odataUrl = 'http://localhost:55580/odata/';
    return $resource('', {},
        {
            'getAll': { method: 'GET', params: { entity: '@entity' }, url: odataUrl + ':entity' },
            'getTop100': { method: 'GET',params: { entity: '@entity' }, url: odataUrl + ':entity' + '?$top=100' },
            'insert': { method: 'POST', params: { entity: '@entity' }, url: odataUrl + ':entity' },
            'patchID': { method: 'PATCH', params: { entity: '@entity', id: '@id' }, url: odataUrl + ':entity' + '(:id)' },
            'getEntityID': { method: 'GET', params: { entity: '@entity', id: '@id' }, url: odataUrl + ':entity' + '(:id)' },
            'getEntity': { method: 'GET', params: { id: '@id' }, url: odataUrl + '(:id)' },
            'getEntityAddress': { method: 'GET', params: { key: '@key' }, url: odataUrl + '(:key)' + '/Address' },
            'getEntityCompany': { method: 'GET', params: { key: '@key' }, url: odataUrl + '(:key)' + '/Company' },
            'deleteEntity': { method: 'DELETE', params: { key: '@key' }, url: odataUrl + '(:key)' },
            'addEntity': { method: 'POST', url: odataUrl }
        });
}).factory('notifyService', function () {
    return {
        success: function (text) {
            toastr.success(text, "Success");
        },
        info: function (text) {
            toastr.info(text, "Info", { "progressBar": true, "newestOnTop": true, "preventDuplicates": true });
        },
        warning: function (text) {
            toastr.warning(text, "Warning");
        },
        error: function (text) {
            toastr.error(text, "Error");
        }
    };
}).factory('apiService', ['$http',function ($http) {

    var urlBase = 'http://hqevdevlweb02:8066/api/';
    //var urlBase = 'http://localhost:55580/api/';
    var apiService = {};

    apiService.getEntity = function (entity) {
        return $http.get(urlBase+entity);
    };

    return apiService;
    
}]);