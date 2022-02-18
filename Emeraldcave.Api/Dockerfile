#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Emeraldcave.Api/Emeraldcave.Api.csproj", "Emeraldcave.Api/"]
RUN dotnet restore "Emeraldcave.Api/Emeraldcave.Api.csproj"
COPY . .
WORKDIR "/src/Emeraldcave.Api"
RUN dotnet build "Emeraldcave.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Emeraldcave.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Emeraldcave.Api.dll"]