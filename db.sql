SELECT b.name_book as "Name", pb.name_publish as "Publish"
	FROM book b
	JOIN publish pb ON pb.id_publish=b.id_publish