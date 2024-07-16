#FROM mcr.microsoft.com/dotnet/sdk:6.0  AS build
#WORKDIR /app
#
#COPY *.csproj ./
#RUN dotnet restore GrupoGBIControleUsuarios.Domain.csproj
#
#COPY . ./
#RUN dotnet publish GrupoGBIControleUsuarios.Domain.csproj -c Release -o out
#
#FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
#
#WORKDIR /app
#
#COPY --from=build /app/out .
#
#ENTRYPOINT ["dotnet", "GrupoGBIControleUsuarios.Domain.dll"]
#
#

FROM mcr.microsoft.com/dotnet/sdk:6.0  AS build
WORKDIR /app

COPY *.csproj ./
RUN dotnet restore 

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime

WORKDIR /app

COPY --from=build /app/out .
ENTRYPOINT ["dotnet", "GrupoGBIControleUsuarios.Domain.dll"]