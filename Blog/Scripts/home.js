$.fn.LoadPosts = function () {
	var $this = $(this);
	$.getJSON("/api/blog/posts/", null, function (data) {
		console.log(data);

		$.each(data, function () {
			var post = this;
			var $comments = $("<ul></ul>");
			
			$.each(post.comments, function () {
				$comments.append("<li><p>" + this.body + "</p></li>")
			});
			
			var dateParts = this.datePosted.substring(0, this.datePosted.indexOf("T")).split("-");
			var datePosted = dateParts[2] + "/" + dateParts[1] + "/" + dateParts[0];

			var html = "<li>" +
						"	<article>" +
						"		<span><time>" + datePosted + "</time></span>" +
						"		<h3>" + this.title + "</h3>" +
						"		<section class=\"post-content\"><p>" + this.body + "</p></section>" +
						"	</article>" +
						"</li>";

			$this.append(html + $comments[0].outerHTML + "</li>");
		});
	});
};

$(document).ready(function () {
	$("#postList").LoadPosts();

	$("#btnPublish").click(function () {
		var $formData = $("#newPostForm").serialize();

		$.post("/api/blog/posts/", $formData, function (data, textStatus, xhr) { newPostSuccess(data, textStatus, xhr); }, "json");

		return false;
	});
});

function newPostSuccess(data, textStatus, xhr) {
	debugger;

	if (xhr.status === 201 && xhr.statusText === "Created")
		window.location = "/?s=1";
}