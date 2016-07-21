    angular.module('timeExampleModule', []).
      // Объявим новый, доступный для инъекций объект
      // и назовем его time
      factory('time', function($timeout) {
        var time = {};
     
        (function tick() {
          time.now = new Date().toString();
          $timeout(tick, 1000);
        })();
        return time;
      });
     
    // Обратите внимание на то, что можно просто запросить time
    // и запрос будет удовлетворен. Не нужно ничего искать.
    function ClockCtrl($scope, time) {
      $scope.time = time;
    }