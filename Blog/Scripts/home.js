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
			
			$this.append("<li><p>" + this.datePublished + " - " + this.title + "</p><p>" + this.body + "</p>" + $comments[0].outerHTML + "</li>");
		});
	});
};

$(document).ready(function () {
	$("#postList").LoadPosts();
});