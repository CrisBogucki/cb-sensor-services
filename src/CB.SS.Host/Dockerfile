FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CB.SS.Host/CB.SS.Host.csproj", "CB.SS.Host/"]
RUN dotnet restore "src/CB.SS.Host/CB.SS.Host.csproj"
COPY . .
WORKDIR "/src/CB.SS.Host"
RUN dotnet build "CB.SS.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CB.SS.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CB.SS.Host.dll"]
