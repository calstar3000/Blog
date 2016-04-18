// Write your Javascript code.

var API_BASE_URL = "http://localhost:41824";

angular.module('blogApp', ['ui.bootstrap'])
	.run(function () {
		console.log('Hello, world, from blogApp!');
	})

	.directive('currentTime', function () {
		return {
			template: '<h2 class="text-center">The time is {{vm.currentTime}}</div>',
			controllerAs: 'vm',
			controller: function () {
				var vm = this;
				vm.currentTime = new Date().toLocaleTimeString();
			}
		}
	})

	.controller('AlertDemoCtrl', function ($scope, $location) {
		$scope.alerts = [
		  { type: 'success', msg: 'Well done! You successfully read this important alert message.' }
		];

		$scope.closeAlert = function (index) {
			$scope.alerts.splice(index, 1);
		};
	});
