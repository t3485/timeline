FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY src/TimeLine.Web.Host/TimeLine.Web.Host.csproj src/TimeLine.Web.Host/
COPY src/TimeLine.Web.Core/TimeLine.Web.Core.csproj src/TimeLine.Web.Core/
COPY src/TimeLine.EntityFrameworkCore/TimeLine.EntityFrameworkCore.csproj src/TimeLine.EntityFrameworkCore/
COPY src/TimeLine.Core/TimeLine.Core.csproj src/TimeLine.Core/
COPY src/TimeLine.Application/TimeLine.Application.csproj src/TimeLine.Application/
RUN dotnet restore src/TimeLine.Web.Host/TimeLine.Web.Host.csproj
COPY . .
WORKDIR /src/src/TimeLine.Web.Host
RUN dotnet build TimeLine.Web.Host.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish TimeLine.Web.Host.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TimeLine.Web.Host.dll"]
