build-images:
	docker-compose build

test: build-images
	docker-compose run unittest dotnet test
 