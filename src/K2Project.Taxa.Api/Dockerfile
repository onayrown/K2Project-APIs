#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["src/K2Project.Taxa.Api/K2Project.Taxa.Api.csproj", "src/K2Project.Taxa.Api/"]
RUN dotnet restore "src/K2Project.Taxa.Api/K2Project.Taxa.Api.csproj"
COPY . .
WORKDIR "/src/src/K2Project.Taxa.Api"
RUN dotnet build "K2Project.Taxa.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "K2Project.Taxa.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "K2Project.Taxa.Api.dll"]