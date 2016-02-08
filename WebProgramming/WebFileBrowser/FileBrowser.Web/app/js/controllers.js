'use strict';

/* Controllers */

var WebControllers = angular.module('WebControllers', []);

WebControllers.controller('DataController', ['$scope', 'Api',
	function($scope, Api) {
		$scope.currentPath = "/";
		$scope.drives = Api.Drive.get();
		$scope.counters = {"result":{"less_ten":".","ten_to_fifty":".","over_hundred":"."}};
			
		$scope.goTo = function(path) {
			if ($scope.currentPath.lastIndexOf("\\") == $scope.currentPath.indexOf("\\") && $scope.currentPath == "/")
			{
				$scope.currentPath = path
			}
			else
			{
				$scope.currentPath = path+"\\";	
			}
					
			// Добавляем кнопку возврата на одну директорию назад:
			$scope.btnBack = "..";
			$scope.drives = "";
			$scope.subFolders = Api.Folder.get({path:$scope.currentPath});
			$scope.counters = Api.Counter.get({path:$scope.currentPath});
		};
		
		$scope.goBack = function() {
			if($scope.currentPath.lastIndexOf("\\") == $scope.currentPath.indexOf("\\"))
			{
				$scope.currentPath = "/";
				$scope.subFolders = "";
				$scope.drives = Api.Drive.get();
				$scope.btnBack = "";
			}
			else
			{
				$scope.currentPath = $scope.currentPath.slice(0, $scope.currentPath.lastIndexOf("\\"));
				$scope.currentPath = $scope.currentPath.slice(0, $scope.currentPath.lastIndexOf("\\")+1);
				$scope.subFolders = Api.Folder.get({path:$scope.currentPath});
				$scope.counters = Api.Counter.get({path:$scope.currentPath});
			}
		}
		
  }]);
