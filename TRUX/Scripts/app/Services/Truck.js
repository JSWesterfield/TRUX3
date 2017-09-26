(function () {

    'use strict';

    angular.module('truxApp')
        .factory('truxService', truxServiceFactory);

    function truxServiceFactory() {

        var aTruxServiceObject = trux.services.truck;
        console.log('Trux Service created successfully');
        return aTruxServiceObject;

    };

})();