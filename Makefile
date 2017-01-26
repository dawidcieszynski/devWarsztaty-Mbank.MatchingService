all: cleanup restore build test

cleanup:
	rm -r src/Mbank.MatchingService/bin
	rm -r src/Mbank.MatchingService/obj
	rm -r test/Mbank.MatchingService.Tests/bin
	rm -r test/Mbank.MatchingService.Tests/obj
restore:
	dotnet restore src/Mbank.MatchingService
	dotnet restore test/Mbank.MatchingService.Tests
build:
	dotnet build src/Mbank.MatchingService
	dotnet build test/Mbank.MatchingService.Tests
test:
	dotnet test test/Mbank.MatchingService.Tests
