#!/bin/sh

export ASPNETCORE_ENVIRONMENT="Development"

dotnet ef migrations remove \
  --context "DatabaseContext" \
  --project "./../ODataSample.Library/ODataSample.Library.csproj" \
  --force
