#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["TodoItems.Api/TodoItems.Api.csproj", "TodoItems.Api/"]
RUN dotnet restore "TodoItems.Api/TodoItems.Api.csproj"
COPY . .
WORKDIR "/src/TodoItems.Api"
RUN dotnet build "TodoItems.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TodoItems.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TodoItems.Api.dll"]