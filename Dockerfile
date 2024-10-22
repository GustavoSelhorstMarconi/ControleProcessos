FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["StageCase.API/StageCase.API.csproj", "StageCase.API/"]
COPY ["StageCase.Application/StageCase.Application.csproj", "StageCase.Application/"]
COPY ["StageCase.Domain/StageCase.Domain.csproj", "StageCase.Domain/"]
COPY ["StageCase.Infra.Data/StageCase.Infra.Data.csproj", "StageCase.Infra.Data/"]
COPY ["StageCase.Infra.IoC/StageCase.Infra.IoC.csproj", "StageCase.Infra.IoC/"]
RUN dotnet restore "StageCase.API/StageCase.API.csproj"
COPY . .
WORKDIR "/src/StageCase.API"
RUN dotnet build "StageCase.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "StageCase.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "StageCase.API.dll" ]

# docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=yourStrong(!)Password" -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest