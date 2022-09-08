#!/bin/sh

export ASPNETCORE_ENVIRONMENT="Development"

dotnet ef migrations add "$1" \
  --context "DatabaseContext" \
  --project "./../ODataSample.Library/ODataSample.Library.csproj"
