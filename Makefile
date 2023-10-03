postgres:
	docker run --name psql -p 5432:5432 -d --rm -e POSTGRES_USER=root -e POSTGRES_PASSWORD=root postgres:15 && \
		ping 127.0.0.1 -n 6 > nul

stopdb:
	docker stop psql

build:
	dotnet build

run-1: build
	cd Expect.Ptmk.Main && \
		dotnet run 1

run-2: build 
	cd Expect.Ptmk.Main && \
		dotnet run 2 "Veselov Roman asdasd" 1999-01-01 Female

run-3: build
	cd Expect.Ptmk.Main && \
		dotnet run 3

run-4: build
	cd Expect.Ptmk.Main && \
		dotnet run 4

run-5: build
	cd Expect.Ptmk.Main && \
		dotnet run 5

tools:
	dotnet tool install --global dotnet-ef

initial-migration:
	dotnet ef migrations add -p ./Expect.Ptmk.Data/Expect.Ptmk.Data.csproj -s ./Expect.Ptmk.Main/Expect.Ptmk.Main.csproj Initial

update-database: 
	dotnet ef database update -p ./Expect.Ptmk.Data/Expect.Ptmk.Data.csproj -s ./Expect.Ptmk.Main/Expect.Ptmk.Main.csproj

.PHONY: postgres stopdb build run-1 tools initial-migration update-database
