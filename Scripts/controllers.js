	'use strict';
	var gameApp = angular.module('gameApp', ['gameApp.directives']);
	
	// create validation angular controller
	gameApp.controller('validationCtrl', function($scope) {
		//za konfirmacija na lozinka
		$scope.password = 'password';
		// function to submit the form after all validation has occurred			
		$scope.submitForm = function() {

			// check to make sure the form is completely valid
			if ($scope.userForm.$valid) {
				alert('our form is amazing');				
			}
		};
	});
	
	gameApp.controller('gameListCtrl', function($scope) {
		$scope.games = jsonAngular;
	});
	
	//directives
	angular.module('gameApp.directives', [])
    .directive('pwCheck', [function () {
	    return {
	        require: 'ngModel',
	        link: function (scope, elem, attrs, ctrl) {
	            var firstPassword = '#' + attrs.pwCheck;
	            elem.add(firstPassword).on('keyup', function () {
	                scope.$apply(function () {
	                    //console.info(elem.val() === $(firstPassword).val());
	                    ctrl.$setValidity('pwmatch', elem.val() === $(firstPassword).val());	                    
	                });
	            });
	        }
	    }
    }]);
	