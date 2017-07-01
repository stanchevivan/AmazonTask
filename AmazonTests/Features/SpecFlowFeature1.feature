Feature: Amazon book purchase

Scenario: Harry Potter
	When I Open Amazon URL
	Then the browser URL is https://www.amazon.co.uk/
	When I Search for "Harry Potter and the Cursed Child" in section books
	Then The first item has the title: Harry Potter and the Cursed Child - Parts One & Two
	Then It has a badge “Best Seller”
	Then Selected type is Hardcover
	Then The price is "£9.00"
	When I navigate to the book details
	Then The title is "Harry Potter and the Cursed Child - Parts One & Two"
	Then It has the badge “Best Seller”
	Then The price again is "£9.00"
	Then Type is Hardcover
	When I Add the book to the basket
	Then The notification is shown
	Then The title Added to Basket
	Then There is one item in the basket
	When I Click on edit the basket
	Then The book is shown on the list
	Then The type of print is Hardcover
	Then Price is still "£9.00"
	Then Quantity is 1
	Then Total price is "£9.00"


