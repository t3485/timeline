FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["TimeLine.Web.Host/TimeLine.Web.Host.csproj", "TimeLine.Web.Host/"]
RUN dotnet restore "TimeLine.Web.Host/TimeLine.Web.Host.csproj"
COPY . .
WORKDIR "/src/TimeLine.Web.Host"
RUN dotnet build "TimeLine.Web.Host.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TimeLine.Web.Host.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TimeLine.Web.Host.dll"]
