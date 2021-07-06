FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS publish
WORKDIR /app
COPY ./ ./
RUN dotnet publish "PromoCodeFactory.WebHost/PromoCodeFactory.WebHost.csproj" \
  -c Release \
  -o /app/publish

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base

ENV ASPNETCORE_URLS=http://*:5000
EXPOSE 5000
WORKDIR /app

COPY --from=publish /app/publish ./
CMD dotnet PromoCodeFactory.WebHost.dll