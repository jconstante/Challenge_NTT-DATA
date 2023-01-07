#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 8081
ENV ASPNETCORE_URLS=http://*:8081

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Solucion.Api/Solucion.Api.csproj", "Solucion.Api/"]
COPY ["Persistencia.Api/Persistencia.Api.csproj", "Persistencia.Api/"]
COPY ["Servicios.Api/Servicios.Api.csproj", "Servicios.Api/"]
RUN dotnet restore "Solucion.Api/Solucion.Api.csproj"
COPY . .
WORKDIR "/src/Solucion.Api"
RUN dotnet build "Solucion.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Solucion.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
RUN ln -fs /usr/share/zoneinfo/America/Ecuador /etc/localtime
RUN dpkg-reconfigure --frontend noninteractive tzdata
ENTRYPOINT ["dotnet", "Solucion.Api.dll"]