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
	.controller('PostListCtrl', function ($scope, $http) {

		$http.get(API_BASE_URL + '/api/blog/posts/?page=1&rows=20').success(function (data) {
			$scope.posts = getPosts(data);
		});
	});

function getPosts(data) {
	var res = data;

	$.each(res, function () {
		this.datePosted = formatDate(this.datePosted);
		this.paragraphs = getPostParagraphs(this.body);
	});

	return res;
}

function getPostParagraphs(body) {
	return body.split("\n");
}

function formatDate(date) {
	var dateParts = date.substring(0, date.indexOf("T")).split("-");
	return (dateParts[2] + "/" + dateParts[1] + "/" + dateParts[0]);
}