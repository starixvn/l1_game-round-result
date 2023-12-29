FROM hub.lumigame.com/base/dotnet/core/sdk:5.0.102-ca-patch-buster-slim-2 AS builder

WORKDIR /src

COPY ./GameRoundResult.Core ./GameRoundResult.Core
COPY ./GameRoundResult.Web/GameRoundResult.Web.csproj ./GameRoundResult.Web/GameRoundResult.Web.csproj

WORKDIR /src/GameRoundResult.Web/
RUN dotnet restore -v n

COPY ./GameRoundResult.Web/ .

RUN dotnet publish -r linux-x64 --self-contained false -o /app && echo $CACHEBUST

FROM hub.lumigame.com/base/dotnet/core/aspnet:5.0.15-buster-slim AS base
# RUN apt-get update && apt-get install -y curl tzdata && rm -rf /var/cache/apk/*
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
RUN adduser game_result_user --disabled-password
USER game_result_user 
WORKDIR /app
COPY --from=builder /app .

ENTRYPOINT ["dotnet", "GameRoundResult.Web.dll"]