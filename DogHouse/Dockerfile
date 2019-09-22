FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build-env

WORKDIR /app

COPY /src/DogHouse ./

RUN dotnet build

RUN dotnet publish -c Debug -o out

EXPOSE 5000

ENTRYPOINT [ "dotnet", "/app/out/DogHouse.dll" ]
