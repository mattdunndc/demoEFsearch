mod.factory('odataService', function ($resource) {
    var odataUrl = 'http://localhost:65406/odata/';
    return $resource('', {},
        {
            'getAll': { method: 'GET', params: { entity: '@entity' }, url: odataUrl },
            'getTop1000': { method: 'GET',params: { entity: '@entity' }, url: odataUrl + ':entity' + '?$top=1000' },
            'create': { method: 'POST', url: odataUrl },
            'patch': { method: 'PATCH', params: { key: '@key' }, url: odataUrl + '(:key)' },
            'getEntity': { method: 'GET', params: { key: '@key' }, url: odataUrl + '(:key)' },
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