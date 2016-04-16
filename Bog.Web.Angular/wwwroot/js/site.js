// Write your Javascript code.

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
	});