'use strict';

/* Controllers */

var WebControllers = angular.module('WebControllers', []);

WebControllers.controller('DataController', ['$scope', 'Api',
	function($scope, Api) {
		// Задаём начальные значения для свойств
		$scope.currentPath = "/";
		$scope.drives = Api.Drive.get();
		$scope.counters = {"result":{"less_ten":".","ten_to_fifty":".","over_hundred":"."}};
		
		// Обработчик события перехода в каталог уровня n+1
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
			
			// Отрисовываем дерево каталогов
			$scope.subFolders = Api.Folder.get({path:$scope.currentPath});
			
			// Выводим информацию о количестве файлов
			$scope.counters = Api.Counter.get({path:$scope.currentPath});
		};
		
		// Обработчик события возврата в каталог уровня n-1
		$scope.goBack = function() {
			// Если находимся в корне диска, то запрашиваем список разделов
			if($scope.currentPath.lastIndexOf("\\") == $scope.currentPath.indexOf("\\"))
			{
				$scope.currentPath = "/";
				$scope.subFolders = "";
				$scope.drives = Api.Drive.get();
				$scope.btnBack = "";
			}
			
			// Если находимся не в корне диска, то переходим в родительский каталог
			else
			{
				$scope.currentPath = $scope.currentPath.slice(0, $scope.currentPath.lastIndexOf("\\"));
				$scope.currentPath = $scope.currentPath.slice(0, $scope.currentPath.lastIndexOf("\\")+1);
				$scope.subFolders = Api.Folder.get({path:$scope.currentPath});
				$scope.counters = Api.Counter.get({path:$scope.currentPath});
			}
		}
		
  }]);
