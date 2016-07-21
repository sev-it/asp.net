'use strict';
var LoginController = [
    '$scope', '$stateParams', '$location', 'LoginFactory', function ($scope, $stateParams, $location, LoginFactory) {
        $scope.loginForm = {
            emailAddress: '',
            password: '',
            rememberMe: false,
            returnUrl: $stateParams.returnUrl,
            LoginFailure: false
        };

        $scope.login = function() {
            var result = LoginFactory($scope.loginForm.emailAddress, $scope.loginForm.password, $scope.loginForm.rememberMe);
            result.then(function(result) {
                if (result.success) {
                    if (typeof $scope.loginForm.returnUrl !== "undefined") {
                      $location.path($scope.loginForm.returnUrl);
                    } else {
                        $location.path('/stateOne');
                    }
                } else {
                    $scope.loginForm.loginFailure = true;
                }
            });
        }
    }
];