#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["OEBB_Pruefstand.Web/OEBB_Pruefstand.Web.csproj", "OEBB_Pruefstand.Web/"]
RUN dotnet restore "OEBB_Pruefstand.Web/OEBB_Pruefstand.Web.csproj"
COPY . .
WORKDIR "/src/OEBB_Pruefstand.Web"
RUN dotnet build "OEBB_Pruefstand.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OEBB_Pruefstand.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OEBB_Pruefstand.Web.dll"]