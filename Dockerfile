FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app  
EXPOSE 32034  

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["NurBNB.Reservas.WebAPI/NurBNB.Reservas.WebAPI.csproj", "/NurBNB.Reservas.WebAPI/"]  
COPY . .
RUN dotnet build "NurBNB.Reservas.WebAPI/NurBNB.Reservas.WebAPI.csproj" -c Release -o /app  

FROM build AS publish
RUN dotnet publish "NurBNB.Reservas.WebAPI/NurBNB.Reservas.WebAPI.csproj" -c Release -o /app

#FROM mcr.microsoft.com/dotnet/aspnet:6.0
FROM base AS final
WORKDIR /app
COPY --from=build /app ./
ENTRYPOINT ["dotnet", "NurBNB.Reservas.WebAPI.dll"]