#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["src/Issue/Issue.API/Issue.API.csproj", "src/Issue/Issue.API/"]
RUN dotnet restore "src/Issue/Issue.API/Issue.API.csproj"
COPY . .
WORKDIR "/src/src/Issue/Issue.API"
RUN dotnet build "Issue.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Issue.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Issue.API.dll"]
