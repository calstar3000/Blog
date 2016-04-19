(function () {
	'use strict';

	angular
		.module('blogApp')
		.controller('PublishController', PublishController);

	PublishController.$inject = ['$http'];

	function PublishController($http) {
		/* jshint validthis:true */
		var vm = this;

		vm.publish = function(post) {

			var data = $.param({
				title: post.title,
				body: post.body
			});

			//$http.post(API_BASE_URL + "/api/blog/posts/", data)
			//	.success(function (data, status) {
			//		alert("It worked!");
			//	});

			$.post(API_BASE_URL + "/api/blog/posts/", data, function (data, textStatus, xhr) { newPostSuccess(data, textStatus, xhr); }, "json");

			//var $formData = $(this).serialize();

			//$.post(API_BASE_URL + "/api/blog/posts/", $formData, function (data, textStatus, xhr) { newPostSuccess(data, textStatus, xhr); }, "json");
		}
	}
})();
