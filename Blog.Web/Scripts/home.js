$.fn.LoadLatestPost = function () {
	var $this = $(this);

	$.getJSON("http://dev.api.blog.co.nz/api/blog/posts/", null, function (data) {
		var $comments = $("<ul></ul>");
		var post = data[0];

		if (post == null || post == undefined)
			return;

		$.each(post.comments, function () {
			$comments.append("<li><p>" + this.body + "</p></li>")
		});

		var html = getPostHTML(post);

		$this.append(html + $comments[0].outerHTML + "</li>");
	});
};

$.fn.LoadPosts = function () {
	var $this = $(this);

	$.getJSON("http://dev.api.blog.co.nz/api/blog/posts/?page=1&rows=20", null, function (data) {
		
		$.each(data, function () {
			var post = this;
			var $comments = $("<ul></ul>");
			
			$.each(post.comments, function () {
				$comments.append("<li><p>" + this.body + "</p></li>")
			});
			
			var html = getPostHTML(this);

			$this.append(html + $comments[0].outerHTML + "</li>");
		});
	});
};

$(document).ready(function () {
	$("#btnPublish").click(function () {
		var $formData = $("#newPostForm").serialize();

		$.post("http://dev.api.blog.co.nz/api/blog/posts/", $formData, function (data, textStatus, xhr) { newPostSuccess(data, textStatus, xhr); }, "json");

		return false;
	});
});

function newPostSuccess(data, textStatus, xhr) {
	if (xhr.status === 201 && xhr.statusText === "Created")
		window.location = "/?s=1";
}

function getPostHTML(post) {
	var dateParts = post.datePosted.substring(0, post.datePosted.indexOf("T")).split("-");
	var datePosted = dateParts[2] + "/" + dateParts[1] + "/" + dateParts[0];

	var paragraphs = post.body.split("\n");
	var bodyText = "";

	$.each(paragraphs, function (k, v) { bodyText += "<p>" + v + "</p>"; });

	var html = "<li>" +
				"	<article>" +
				"		<span><time>" + datePosted + "</time></span>" +
				"		<h3>" + post.title + "</h3>" +
				"		<section class=\"post-content\">" + bodyText + "</section>" +
				"	</article>" +
				"</li>";

	return html;
}