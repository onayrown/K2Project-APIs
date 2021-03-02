#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/K2Project.Juros.Api/K2Project.Juros.Api.csproj", "src/K2Project.Juros.Api/"]
COPY ["src/K2Project.Domain/K2Project.Domain.csproj", "src/K2Project.Domain/"]
COPY ["src/K2Project.Infra/K2Project.Infra.csproj", "src/K2Project.Infra/"]
RUN dotnet restore "src/K2Project.Juros.Api/K2Project.Juros.Api.csproj"
COPY . .
WORKDIR "/src/src/K2Project.Juros.Api"
RUN dotnet build "K2Project.Juros.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "K2Project.Juros.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "K2Project.Juros.Api.dll"]
