#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Backend/Presentation/Library.WebAPI/Library.WebAPI.csproj", "Backend/Presentation/Library.WebAPI/"]
COPY ["Backend/Core/Library.Application/Library.Application.csproj", "Backend/Core/Library.Application/"]
COPY ["Backend/Infrastructure/Library.DAL/Library.DAL.csproj", "Backend/Infrastructure/Library.DAL/"]
COPY ["Backend/Core/Library.Domain/Library.Domain.csproj", "Backend/Core/Library.Domain/"]
RUN dotnet restore "Backend/Presentation/Library.WebAPI/Library.WebAPI.csproj"
COPY . .
WORKDIR "/src/Backend/Presentation/Library.WebAPI"
RUN dotnet build "Library.WebAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Library.WebAPI.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Library.WebAPI.dll"]