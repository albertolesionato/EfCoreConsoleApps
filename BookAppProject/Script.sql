INSERT INTO public."Books"
("Title", "Description", "PublishedOn", "Publisher", "Price", "ImageUrl")
VALUES('Book of Stuff', 'A stuff book', '01-05-1977', 'Stuffed Man', 56.32, '');

INSERT INTO public."Authors"
("Name")
VALUES('Someone who writes');

INSERT INTO public."BookAuthor"
("BookId", "AuthorId", "Order")
VALUES(1, 1, 1500);

INSERT INTO public."Reviews"
("VoterName", "NumStars", "Comment", "BookId")
VALUES('John', 5, 'I have not read it', 1);

INSERT INTO public."Tags"
("TagId")
VALUES('Useless');


