#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
#EXPOSE 80
#EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["corta-e-tchau-backend.csproj", ""]
RUN dotnet restore "./corta-e-tchau-backend.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "corta-e-tchau-backend.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "corta-e-tchau-backend.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "corta-e-tchau-backend.dll"]

CMD ASPNETCORE_URLS=https://*:$PORT dotnet corta-e-tchau-backend.dll