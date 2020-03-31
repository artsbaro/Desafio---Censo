#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["src/Censo.Services.Api/Censo.Services.Api.csproj", "src/Censo.Services.Api/"]
COPY ["src/Censo.Infra.CrossCutting/Censo.Infra.CrossCutting.IoC.csproj", "src/Censo.Infra.CrossCutting/"]
COPY ["src/Censo.Infra.Data/Censo.Infra.Data.csproj", "src/Censo.Infra.Data/"]
COPY ["src/Censo.Domain/Censo.Domain.csproj", "src/Censo.Domain/"]
COPY ["src/Censo.Application/Censo.Application.csproj", "src/Censo.Application/"]
COPY ["src/Censo.Domain.Services/Censo.Domain.Services.csproj", "src/Censo.Domain.Services/"]
RUN dotnet restore "src/Censo.Services.Api/Censo.Services.Api.csproj"
COPY . .
WORKDIR "/src/src/Censo.Services.Api"
RUN dotnet build "Censo.Services.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Censo.Services.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Censo.Services.Api.dll"]