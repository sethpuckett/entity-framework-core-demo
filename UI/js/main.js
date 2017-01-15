$(document).ready(function() {

	// When the #new form is submitted, add the new item
	$('#new').on('submit', addNewItem);

	// When an item gets clicked, mark as complete or incomplete
	$('#todos').on('click', '.item', switchStatus);

	// When a remove link is clicked, remove that item
	$('#todos').on('click', '.remove', removeItem);

	// When an edit link is clicked, go into edit mode
	$('#todos').on('click', '.edit', editItem);

	// When an item editor is submitted, save the changes
	$('#todos').on('submit', '.editor', saveItem);

	// When a user leaves an item editor form, save the changes
	$('#todos').on('blur', '.editor', saveItem);

	// When the Clear List button is clicked, clear out the items 
	$('#clear').on('click', clearList);

	// When the Clear Completed button is clicked, clear out the completed items
	$('#clearCompleted').on('click', clearCompleted);


	// Functions

	function updateCount() {
		// Count the number of items (the number of '#todos li' elements that don't have the .done class)
		var count = $("#todos li").not(".done").length;

		// Update the #count span
		$("#count").text(count);
	}

	function addNewItem(event) {
		// Prevent default behavior
		event.preventDefault();

		// Get the text the user entered
		var text = $("#newItem").val();

		// Append a new li element to #todos. This list item should contain three things:
			// 1. a span with the class 'item'. The text inside the span should be the text the user entered.
			// 2. an anchor tag with class 'edit'. The text should be 'Edit'.
			// 3. an anchor tag with class 'remove'. The text should be 'Remove'.
		var html = "<li>" +
                        "<span class='item'>" +
                            text +
                        "</span>" +
                        "<a href='#' class='edit'>" +
                            "Edit" +
                        "</a>" +
                        "<a href='#' class='remove'>" +
                            "Remove" +
                        "</a>" +
                        "<a href='#' class='tag'>" +
                            "Add Tag" +
                        "</a>" +
                    "</li>";


		$("#todos").append(html);


		// Update the count
		updateCount();
	}

	function switchStatus() {
		// Get the parent list item of the clicked link
		var listItem = $(this).parent();

		// Toggle the '.done' class on the list item
		listItem.toggleClass("done");

		// Update the count
		updateCount();
	}

	function removeItem(event) {
		// Prevent default behavior
		event.preventDefault();

		// The parent of the clicked element is the item. Remove it from the DOM.
		var listItem = $(this).parent();
		listItem.remove();

		// Update the count
		updateCount();
	}

	function clearList() {
		// Remove all list items in the #todos list from the DOM.
		$("#todos li").remove();

		// Update the count
		updateCount();
	}

	function clearCompleted() {
		// Find all the list items in the #todos list with the '.done' class and remove them from the DOM.
		$("#todos li.done").remove();

		// Update the count
		updateCount();
	}

	function editItem(event) {
		// Prevent default behavior
		event.preventDefault();

		// Get the text of the to-do item; it's a sibling of the clicked link and has class .item
		var text = $(this).siblings(".item").text();

		// Get the parent of the clicked link. This is the list item.
		var listItem = $(this).parent();

		// Replace the list item html contents with an edit form. This form should have a class '.editor' and should contain a single text box with a value set to the original item text.
		listItem.html("<form class='editor'><input type='text' value='" + text + "'></form>");

		// Focus the keyboard on the input field that was just added
		listItem.children("input").focus();
	}

	function saveItem(event) {
		// Prevent default behavior
		event.preventDefault();

		// Get the new value from the input field. It is a child of the event element.
		var newValue = $(this).children("input").val();

		// Get the parent of the event element. This is the list item.
		var listItem = $(this).parent();

		// Replace the list item html contents with the updated item and controls. This should be the same content that was in the original html (i.e. 1 span & 2 anchor tags).
		var newHtml = 
							"<span class='item'>" +
								newValue +
							"</span>" +
							"<a href='#' class='edit'>" +
								"Edit" +
							"</a>" +
							"<a href='#' class='remove'>" +
								"Remove" +
							"</a>";

		listItem.html(newHtml);
	}

});