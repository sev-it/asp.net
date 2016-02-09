'use strict';

/* Services */
// Сервис для отправки запросов к back-end
var WebService = angular.module('WebService', ['ngResource']);

WebService.factory('Api', ['$resource',
    function ($resource) {
		return {
			Drive: $resource('http://localhost:1393/api/directories/'),
			Folder:  $resource('http://localhost:1393/api/directories/:path', {path: '@path'}),
			Counter:  $resource('http://localhost:1393/api/counters/:path', {path: '@path'})
        };
    }
]);
