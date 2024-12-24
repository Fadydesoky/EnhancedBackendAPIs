#!/bin/bash

# Start REST API
cd RestApi && dotnet run --urls="http://localhost:5147" &

# Start SOAP API
cd ../SoapApi && dotnet run --urls="http://localhost:5269" &

# Start gRPC API
cd ../GrpcApi && dotnet run --urls="http://localhost:5115" &

# Wait for all background processes to finish
wait
