FROM mcr.microsoft.com/dotnet/aspne:8.0 AS base
WORKDIR /app
EXPOSE 8080
ENV ASPNETCORE_URLS=http://+:8080

FROM mcr.microdsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
Run dotnet restore "MontealegreLibraryNowAPI.csproj"
RUN dotnet publish "MontealegreLibraryNowAPI.csproj"-c Release -o /app/out

FROM base AS final
COPY --from=build /app/out .
ENTRYPOINT ["dotnet","MontealegreLibraryNowAPI.dll"]
