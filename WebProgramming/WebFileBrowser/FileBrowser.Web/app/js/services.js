'use strict';

/* Services */

var WebService = angular.module('WebService', ['ngResource']);

WebService.factory('Api', ['$resource',
    function ($resource) {
        //$http.defaults.useXDomain = true;
		return {
            /*getCounters: function (ext_path) {
                return $resource('http://localhost:1393/api/counters/:path', {}, {
                    GetFilesSize: {method: 'GET', params: {path:path}, isArray: true}
                });
            },
            getData: function (ext_path) {
                return get($resource('http://localhost:1393/api/directories/:path', {}, {
                    GetData: {method: 'GET', params: {path:ext_path}}}));
            },
			getDrives: function () {
                return $resource('http://localhost:1393/api/directories/', {}, {
                    GetDrives: {method: 'GET'}
                });
            }*/
			Drive: $resource('http://localhost:1393/api/directories/'),
			Folder:  $resource('http://localhost:1393/api/directories/:path', {path: '1'}),
			Counter:  $resource('http://localhost:1393/api/counters/:path', {path: '1'})
        };
    }
]);
