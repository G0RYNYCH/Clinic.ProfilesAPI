FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY . .
WORKDIR "."

RUN dotnet restore "ProfilesAPI.csproj"

RUN dotnet build "ProfilesAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProfilesAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY wait_for_database.sh .
#ENTRYPOINT ["sh", "wait_for_database.sh", "db:1433", "-t", "120", "--", "dotnet", "ProfilesAPI.dll"]
ENTRYPOINT ["dotnet", "ProfilesAPI.dll"]
