(function () {
	'use strict';

	angular
		.module('blogApp')
		.controller('PostsController', PostsController);

	PostsController.$inject = ['$http'];

	function PostsController($http) {
		/*jshint validthis: true */
		var vm = this;

		$http.get(API_BASE_URL + '/api/blog/posts/?page=1&rows=20')
			.success(function (data) {
				vm.posts = getPosts(data);
			})
			.error(function (error) {
				alert("There was an error getting the posts.");
			});
	}

	function getPosts(data) {
		var res = data;

		$.each(res, function () {
			this.datePosted = formatDate(this.datePosted);
			this.paragraphs = this.body.split("\n");
		});

		return res;
	}

	function formatDate(date) {
		var dateParts = date.substring(0, date.indexOf("T")).split("-");
		return (dateParts[2] + "/" + dateParts[1] + "/" + dateParts[0]);
	}
})();
