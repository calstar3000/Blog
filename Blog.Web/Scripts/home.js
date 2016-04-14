var API_BASE_URL = "http://localhost:41824";

$.fn.LoadLatestPost = function ($comments) {
	var $this = $(this);

	$.getJSON(API_BASE_URL + "/api/blog/posts/", null, function (data) {
		var post = data[0];

		if (post == null || post == undefined)
			return;

		$this.append(getPostHTML(post));
		$comments.loadComments(post.id, post.comments);
	});
};

$.fn.LoadPosts = function () {
	var $this = $(this);

	$.getJSON(API_BASE_URL + "/api/blog/posts/?page=1&rows=20", null, function (data) {
		
		$.each(data, function () {
			var post = this;
			var $comments = $("<ul id=\"commentList\" class=\"comment-list\"></ul>");
			var html = getPostHTML(this);

			$comments.loadComments(post.id, post.comments);
			$this.append(html + "<h5>Comments</h5>" + $comments[0].outerHTML);
		});
	});
};

$.fn.loadComments = function (postId, comments) {
	var $this = $(this);
	
	$this.closest(".post-panel").attr("data-post-id", postId);

	if (comments == null || comments == undefined)
		return;

	if (comments.length > 0) {
		$.each(comments, function () {
			$this.append("<li><time>" + formatDate(this.datePosted) + "</time><p>" + this.body + "</p></li>")
		});
	} else {
		$this.append("<li><p>There are no comments</p></li>")
	}
};

$.fn.publishPost = function () {
	var $formData = $(this).serialize();

	$.post(API_BASE_URL + "/api/blog/posts/", $formData, function (data, textStatus, xhr) { newPostSuccess(data, textStatus, xhr); }, "json");
};

$.fn.publishComment = function () {
	var $this = $(this);
	var $formData = $this.serialize();
	var postId = $this.closest(".post-panel").data("post-id");

	$.post(API_BASE_URL + "/api/blog/posts/" + postId + "/comments/", $formData, function (data, textStatus, xhr) { newPostSuccess(data, textStatus, xhr); }, "json");
};

function newPostSuccess(data, textStatus, xhr) {
	if (xhr.status === 201 && xhr.statusText === "Created")
		window.location = "/?s=" + (xhr.responseJSON.url.indexOf("comment") >= 0 ? "2" : "1");
}

function getPostHTML(post) {
	var datePosted = formatDate(post.datePosted);
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

function formatDate(date) {
	var dateParts = date.substring(0, date.indexOf("T")).split("-");
	return (dateParts[2] + "/" + dateParts[1] + "/" + dateParts[0]);
}