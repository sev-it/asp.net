'use strict';

var phonecatApp = angular.module('phonecatApp',[]);

phonecatApp.controller('PhoneListCtrl', function($scope){
	$scope.phones =[
	{'name':'LG', 'snippet':'loh'},
		{'name':'Samsung', 'snippet':'pidar'},
{'name':'iPhone', 'snippet':'huy'}];
$scope.hello = "Hello, world!";});