FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SealedPerformance.csproj", "./"]
RUN dotnet restore "SealedPerformance.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "SealedPerformance.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SealedPerformance.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SealedPerformance.dll"]
