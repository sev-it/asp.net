'use strict';
var RegisterController = [
    '$scope', '$location', 'RegistrationFactory', function ($scope, $location, RegistrationFactory) {
        $scope.registerForm = {
            emailAddress: '',
            password: '',
            confirmPassword: '',
            registrationFailure: false
        };

        $scope.register = function() {
            var result = RegistrationFactory($scope.registerForm.emailAddress, $scope.registerForm.password, $scope.registerForm.confirmPassword);
            result.then(function (result) {
                if (result.success) {
                    $location.path('/routeOne');
                } else {
                    $scope.registerForm.registrationFailure = true;
                }
            });
        }
    }
];