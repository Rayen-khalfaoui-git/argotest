# stage 1 pour le buid 
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /build

COPY src/*.csproj ./
RUN dotnet restore

COPY src/ ./
RUN dotnet publish -c Release -o /app/publish --no-restore

# stage 2 pour le runtie
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app

# changé le run en root jsp pq les permissions ne laissent pas un user normal faire le run
RUN addgroup --system appgroup && adduser --system --ingroup appgroup appuser
USER appuser

COPY --from=build /app/publish ./

ENV ASPNETCORE_URLS=http://+:8080
ENV ASPNETCORE_ENVIRONMENT=Production

EXPOSE 8080

ENTRYPOINT ["dotnet", "DotnetApp.dll"]