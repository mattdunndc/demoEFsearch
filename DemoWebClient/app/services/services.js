app.factory('odataService', function ($resource) {
    var odataUrl = 'http://localhost:65406/odata/';
    var odataUrl2 = 'http://localhost:65406/odata/t_inst_institutn';
    return $resource('', {},
        {
            'getAll': { method: 'GET', params: { entity: '@entity' }, url: odataUrl + ':entity' },
            'getTop1000': { method: 'GET',params: { entity: '@entity' }, url: odataUrl + ':entity' + '?$top=100' },
            'create': { method: 'POST', url: odataUrl },
            'patchID': { method: 'PATCH', params: { entity: '@entity', id: '@id' }, url: odataUrl + ':entity' + '(:id)' },
            'getEntityID': { method: 'GET', params: { entity: '@entity', id: '@id' }, url: odataUrl + ':entity' + '(:id)' },
            'getEntity': { method: 'GET', params: { id: '@id' }, url: odataUrl2 + '(:id)' },
            'getEntityAddress': { method: 'GET', params: { key: '@key' }, url: odataUrl + '(:key)' + '/Address' },
            'getEntityCompany': { method: 'GET', params: { key: '@key' }, url: odataUrl + '(:key)' + '/Company' },
            'deleteEntity': { method: 'DELETE', params: { key: '@key' }, url: odataUrl + '(:key)' },
            'addEntity': { method: 'POST', url: odataUrl }
        });
}).factory('notificationFactory', function () {
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
});