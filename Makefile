build-images:
	docker-compose build --progress plain pack
	docker-compose build --progress plain unittest

test: build-images
	docker-compose run --rm pack dotnet pack --configuration Release
	docker-compose run --rm unittest dotnet test
 