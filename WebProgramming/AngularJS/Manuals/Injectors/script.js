    angular.module('timeExampleModule', []).
      // ������� �����, ��������� ��� �������� ������
      // � ������� ��� time
      factory('time', function($timeout) {
        var time = {};
     
        (function tick() {
          time.now = new Date().toString();
          $timeout(tick, 1000);
        })();
        return time;
      });
     
    // �������� �������� �� ��, ��� ����� ������ ��������� time
    // � ������ ����� ������������. �� ����� ������ ������.
    function ClockCtrl($scope, time) {
      $scope.time = time;
    }